using CryptoVue.Data.Models;
using CryptoVue.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVue.Controllers
{

    [Authorize]
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

        [HttpGet("getsupply")]
        public IEnumerable<CryptoTokenSnapshot> GetSuppy()
        {
            return tokenService.GetStoredDataAsync();
        }
    }
}
