using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers.V1
{
    //Use MapToVersion for some examples of having an endpoint versioned
    //TODO How do we version a method vs the entire controller
    //if v1 has method a and v2 is missing method a will calling v2->a default to v1->a?
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]// Now used for backwards compatability
    public class VehicleController : Controller
    {
        private static IEnumerable<Vehicle> Vehicles = new List<Vehicle> {
            new Vehicle(id: 1, bodyType: BodyType.Truck, modelName: "Silverado"),
            new Vehicle(id: 2, bodyType: BodyType.Suv, modelName: "Suburban")
        };

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
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return Vehicles;
        }

        [HttpGet("{id}")]
        public Vehicle Get([FromQuery] int id)
        {
            return Vehicles.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public Vehicle CreateNewVehicle([FromBody] Vehicle vehicle)
        {
            Vehicles = Vehicles.Append(vehicle);

            return vehicle;
        }
    }
}