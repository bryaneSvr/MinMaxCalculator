using Microsoft.AspNetCore.Mvc;
using MinMaxCalculator.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinMaxCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        ICalculationService _calcService;

        public CalculateController(ICalculationService calcService)
        {
            _calcService= calcService;
        }

        // POST api/Calculate
        [HttpPost]
        public int Post([FromBody] string value)
        {
            return _calcService.Calculate(value);
        }
    }
}
