using Microsoft.AspNetCore.Mvc;

namespace ApiB.Controllers
{
    [ApiController]
    [Route("currency")]
    public class CurrencyController : ControllerBase
    {
        [HttpGet("convert")]
        public IActionResult Convert(decimal amount = 1)
        {
            decimal usdToInr = 82.5m;
            return Ok(new
            {
                amount,
                converted = amount * usdToInr,
                rate = usdToInr
            });
        }
    }
}
