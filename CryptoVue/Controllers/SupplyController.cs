using CryptoVue.Data.Models;
using CryptoVue.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost("calculatesupply")]
        public async Task<IActionResult> CalculateSupply()
        {
            await tokenService.FetchTokenDataAsync();
            return Created();
        }

        [HttpGet("getsupply")]
        public async Task<ActionResult<CryptoTokenSnapshot?>> GetSuppy()
        {
            return await tokenService.GetStoredDataAsync();
        }
    }
}
