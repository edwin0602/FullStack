using RestBackend.Core;
using RestBackend.Core.Models.Business;
using RestBackend.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBackend.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Vehicle> Create(Vehicle newItem)
        {
            await _unitOfWork.Vehicles.AddAsync(newItem);
            await _unitOfWork.CommitAsync();

            return newItem;
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
            => await _unitOfWork.Vehicles
                .GetAllAsync(q => q.OrderBy(s => s.Model), x => x.Brand, x => x.Type);

        public async Task<Vehicle> GetById(int Id)
            => await _unitOfWork.Vehicles
                .FirstOrDefaultAsync(w => w.Id == Id, x => x.Brand, x => x.Type);

        public async Task<IEnumerable<VehicleBrand>> GetBrands()
            => await _unitOfWork.VehicleBrands
                .GetAllAsync(q => q.OrderBy(s => s.Name));

        public async Task<IEnumerable<VehicleType>> GetTypes()
            => await _unitOfWork.VehicleTypes
                .GetAllAsync(q => q.OrderBy(s => s.Name));
    }
}
