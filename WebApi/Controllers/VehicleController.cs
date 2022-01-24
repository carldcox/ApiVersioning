﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private static IEnumerable<Vehicle> Vehicles = new List<Vehicle> {
            new Vehicle(id: 1, bodyType: BodyType.Truck, modelName: "Silverado"),
            new Vehicle(id: 2, bodyType: BodyType.Suv, modelName: "Suburban")
        };

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