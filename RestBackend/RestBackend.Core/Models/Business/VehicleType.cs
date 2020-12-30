using System;
using System.Collections.Generic;
using System.Text;

namespace RestBackend.Core.Models.Business
{
    public class VehicleType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
