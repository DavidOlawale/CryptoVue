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
        [HttpPost("updatesupply")]
        public async Task<IActionResult> UpdateSupply()
        {
            await tokenService.FetchTokenDataAsync();
            return Ok();
        }

        [HttpGet("getsupply")]
        public async Task<ActionResult<TokenDataRecord?>> GetSuppy()
        {
            return await tokenService.GetStoredDataAsync();
        }
    }
}
