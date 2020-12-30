using RestBackend.Core.Models.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBackend.Core.Services
{
    public interface IVehicleService
    {
        Task<Vehicle> GetById(int Id);

        Task<IEnumerable<Vehicle>> GetAll();

        Task<Vehicle> Create(Vehicle newItem);

        Task<IEnumerable<VehicleType>> GetTypes();

        Task<IEnumerable<VehicleBrand>> GetBrands();
    }
}
