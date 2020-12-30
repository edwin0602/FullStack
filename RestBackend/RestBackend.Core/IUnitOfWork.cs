using System;
using System.Threading.Tasks;
using RestBackend.Core.Repositories;

namespace RestBackend.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleRepository Vehicles { get; }

        IVehicleTypeRepository VehicleTypes { get; }

        IVehicleBrandRepository VehicleBrands { get; }

        Task<int> CommitAsync();
    }
}