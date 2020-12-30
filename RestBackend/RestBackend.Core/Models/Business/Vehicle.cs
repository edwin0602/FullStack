namespace RestBackend.Core.Models.Business
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string CylinderCap { get; set; }

        public int BrandId { get; set; }
        public VehicleBrand Brand { get; set; }

        public int TypeId { get; set; }
        public VehicleType Type { get; set; }
    }
}
