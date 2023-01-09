using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {

        private readonly IDatabaseService _dbService;

        public WarehousesController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }


        [HttpPost("CreateProductWarehouse")]
        public IActionResult CreateProductWarehouse(ProductWarehouse pw) {

            string dbMessage = _dbService.CreateProductWarehouse(pw);

            if (!dbMessage.StartsWith("Success.")) {

                return NotFound(dbMessage);
            }

            return Ok(dbMessage);
        
        }
    }
}
