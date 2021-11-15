using CreditApp.Models;
using CreditApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CreditApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditAppController : ControllerBase
    {
        private readonly ICreditService creditService;

        public CreditAppController(ICreditService creditService)
        {
            this.creditService = creditService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CreditResponse))]
        public ActionResult<CreditResponse> Credit([FromBody] CreditRequest creditRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(creditService.GetInterestWithDecision(creditRequest));
        }
    }
}