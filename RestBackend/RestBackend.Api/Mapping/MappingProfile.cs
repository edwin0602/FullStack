using AutoMapper;
using RestBackend.Api.Resources;
using RestBackend.Core.Models.Business;

namespace RestBackend.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region [ Vehicle ]

            CreateMap<Vehicle, VehicleResource>()
                .ForMember(x => x.VehicleBrand, op => op.MapFrom(src => src.Brand))
                .ForMember(x => x.VehicleType, op => op.MapFrom(src => src.Type));

            CreateMap<VehicleResource, Vehicle>();

            CreateMap<SaveVehicleResource, Vehicle>();

            #endregion

            CreateMap<VehicleBrand, VehicleBrandResource>();
            CreateMap<VehicleBrandResource, VehicleBrand>();

            CreateMap<VehicleType, VehicleTypeResource>();
            CreateMap<VehicleTypeResource, VehicleType>();
        }
    }
}