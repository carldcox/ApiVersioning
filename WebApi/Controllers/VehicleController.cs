using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.CQRS.Vehicle.Commands;
using Services.CQRS.Vehicle.Queries;

namespace WebApi.Controllers
{
    //Use MapToVersion for some examples of having an endpoint versioned
    //TODO How do we version a method vs the entire controller
    //if v1 has method a and v2 is missing method a will calling v2->a default to v1->a?
    [ApiController]
    // [ApiVersion("1.0")]
    // [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]// Now used for backwards compatability
    public class VehicleController : Controller
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IMediator _mediator;

        public VehicleController(
            ILogger<VehicleController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            var result = await _mediator.Send(new GetAllVehiclesQuery());
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Vehicle> Get([FromQuery] int id)
        {
            var result = await _mediator.Send(new GetVehicleByIdQuery(id));
            return result;
        }

        [HttpPost]
        public async Task<Vehicle> CreateNewVehicle(AddVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}