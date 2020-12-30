using System.Collections.Generic;

namespace RestBackend.Core.Models.Business
{
    public class VehicleBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
