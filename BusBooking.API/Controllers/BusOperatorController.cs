using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBooking.Application.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusOperatorController : ControllerBase
    {
        private readonly IBusOperator _busOperatorRepository;
        public BusOperatorController(IBusOperator busOperatorRepository)
        {
            _busOperatorRepository = busOperatorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var busOperators = await _busOperatorRepository.GetAllAsync();
            return Ok(busOperators);
        }
    }
}