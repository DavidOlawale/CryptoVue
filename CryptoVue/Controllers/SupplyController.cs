using CryptoVue.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVue.Controllers
{

    [Route("api/supply")]
    public class SupplyController : BaseController
    {
        private readonly IBLPTokenService tokenService;

        public SupplyController(IBLPTokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost("calculatesupply")]
        public async Task<IActionResult> CalculateSupply()
        {
            await tokenService.FetchTokenDataAsync();
            return Created();
        }
    }
}
