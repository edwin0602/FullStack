namespace RestBackend.Api.Resources
{
    public class VehicleResource
    {
        public string Model { get; set; }

        public string Year { get; set; }

        public string CylinderCap { get; set; }

        public VehicleBrandResource VehicleBrand { get; set; }

        public VehicleTypeResource VehicleType { get; set; }
    }

    public class VehicleTypeResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class VehicleBrandResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SaveVehicleResource
    {

        public string Model { get; set; }

        public string Year { get; set; }

        public string CylinderCap { get; set; }

        public int TypeId { get; set; }

        public int BrandId { get; set; }
    }
}
