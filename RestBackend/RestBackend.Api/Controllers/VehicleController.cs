using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestBackend.Api.Resources;
using RestBackend.Api.Validators;
using RestBackend.Core.Models.Business;
using RestBackend.Core.Services;

namespace RestBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleController(
            IMapper mapper,
            IVehicleService vehicleService)
        {
            _mapper = mapper;
            _vehicleService = vehicleService;
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<VehicleTypeResource>>> GetAllTypes()
        {
            var models = await _vehicleService.GetTypes();
            var modelsResources = _mapper.Map<IEnumerable<VehicleType>, IEnumerable<VehicleTypeResource>>(models);

            return Ok(modelsResources);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<VehicleBrandResource>>> GetAllBrands()
        {
            var models = await _vehicleService.GetBrands();
            var modelsResources = _mapper.Map<IEnumerable<VehicleBrand>, IEnumerable<VehicleBrandResource>>(models);

            return Ok(modelsResources);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<VehicleResource>>> GetAll()
        {
            var models = await _vehicleService.GetAll();
            var modelsResources = _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(models);

            return Ok(modelsResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleResource>> GetById(int id)
        {
            var model = await _vehicleService.GetById(id);
            var modelResource = _mapper.Map<Vehicle, VehicleResource>(model);

            return Ok(modelResource);
        }

        [HttpPost()]
        public async Task<ActionResult<VehicleResource>> Create([FromBody] SaveVehicleResource saveResource)
        {
            #region [ Model Validations ]

            var validator = new SaveVehicleResourceValidator();
            var validationResult = await validator.ValidateAsync(saveResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            #endregion

            var modelToCreate = _mapper.Map<SaveVehicleResource, Vehicle>(saveResource);
            var newModel = await _vehicleService.Create(modelToCreate);

            var model = await _vehicleService
                .GetById(newModel.Id);

            return Created(nameof(GetById), _mapper.Map<Vehicle, VehicleResource>(model));
        }
    }
}
