using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace CancellationTknDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenDemoController(ITknService tknService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(bool includeCancellation, CancellationToken tkn = default)
        {
            if (!includeCancellation)
            {
                tkn = CancellationToken.None;
            }

            return Ok(await tknService.GetDataFromExpensiveOperation(tkn));
        }

        [HttpGet("codefirst")]
        public async Task<IActionResult> GetDataFromDB()
        {
            return Ok(await tknService.GetDatFromDB());
        }
    }
}
