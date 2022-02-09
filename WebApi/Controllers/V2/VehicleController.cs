using System.Collections.Generic;
using System.Linq;
using Data.Vehicle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VehicleController : Controller
    {
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(ILogger<VehicleController> logger)
        {
            _logger = logger;
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