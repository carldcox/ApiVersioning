﻿using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InactiveUsersController : Controller
    {
        
    }
}