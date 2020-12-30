using RestBackend.Core.Models.Business;
using RestBackend.Core.Repositories;

namespace RestBackend.Data.Repositories
{
    public class VehicleBrandRepository : Repository<VehicleBrand>, IVehicleBrandRepository
    {
        public VehicleBrandRepository(RestBackendDbContext context)
            : base(context)
        { }
    }
}
