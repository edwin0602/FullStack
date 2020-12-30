using System.Threading.Tasks;
using RestBackend.Core;
using RestBackend.Core.Repositories;
using RestBackend.Data.Repositories;

namespace RestBackend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestBackendDbContext _context;

        private VehicleRepository _vehicleRepository;
        private VehicleBrandRepository _vehicleBrandRepository;
        private VehicleTypeRepository _vehicleTypeRepository;

        public UnitOfWork(RestBackendDbContext context)
        {
            this._context = context;
        }

        public IVehicleRepository Vehicles => _vehicleRepository ??= new VehicleRepository(_context);

        public IVehicleTypeRepository VehicleTypes => _vehicleTypeRepository ??= new VehicleTypeRepository(_context);

        public IVehicleBrandRepository VehicleBrands => _vehicleBrandRepository ??= new VehicleBrandRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}