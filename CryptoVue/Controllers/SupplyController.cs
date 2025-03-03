using CryptoVue.Data.Models;
using CryptoVue.Dtos;
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

        //[Authorize]
        //[HttpPost("updatesupply")]
        //public async Task<IActionResult> UpdateSupply()
        //{
        //    await tokenService.FetchTokenDataAsync();
        //    return Ok();
        //}

        [HttpGet("getsupply")]
        public async Task<ActionResult<TokenDataRecord?>> GetSuppy()
        {
            return await tokenService.GetStoredDataAsync();
        }

        //[Authorize]
        [HttpGet("dasboard")]
        public async Task<DashboardDTO> GetDashboardData()
        {
            return await tokenService.FetchDashboardDataAsync();
        }

        [HttpGet("vestingschedule")]
        public IEnumerable<VestingScheduleDTO> GetVestingSchedule()
        {
            return VestingSchedules;
        }

        [HttpGet("unlockschedule")]
        public IEnumerable<UnlockScheduleDTO> GetUnlockSchedule()
        {
            return UnlockSchedles;
        }

        private IEnumerable<VestingScheduleDTO> VestingSchedules =
        [
            new VestingScheduleDTO
            {
                Round = "Private",
                Tokens = 30000000,
                Percentage = 10.00,
                TGEUnlock = 11,
                Cliff = 0,
                UnlockStart = new DateTime(2021, 6, 16),
                UnlockEnd = new DateTime(2022, 4, 16),
                Summary = "11% at TGE, then 8.9% monthly for 10 months"
            },
            new VestingScheduleDTO
            {
                Round = "Seed",
                Tokens = 6000000,
                Percentage = 2.00,
                TGEUnlock = 5,
                Cliff = 0,
                UnlockStart = new DateTime(2021, 6, 16),
                UnlockEnd = new DateTime(2022, 5, 16),
                Summary = "5% at TGE and month 2, then 9% monthly for 10 months"
            },
            new VestingScheduleDTO
            {
                Round = "Strategic",
                Tokens = 16500000,
                Percentage = 5.50,
                TGEUnlock = 8,
                Cliff = 0,
                UnlockStart = new DateTime(2021, 6, 16),
                UnlockEnd = new DateTime(2022, 4, 16),
                Summary = "8% at TGE, then 9.2% monthly for 10 months"
            },
            new VestingScheduleDTO
            {
                Round = "Public",
                Tokens = 6000000,
                Percentage = 2.00,
                TGEUnlock = 50,
                Cliff = 0,
                UnlockStart = new DateTime(2021, 6, 16),
                UnlockEnd = new DateTime(2021, 8, 16),
                Summary = "50% at TGE, then 25% monthly for 2 months"
            },
            new VestingScheduleDTO
            {
                Round = "Team",
                Tokens = 39000000,
                Percentage = 13.00,
                TGEUnlock = 0,
                Cliff = 12,
                UnlockStart = new DateTime(2022, 6, 16),
                UnlockEnd = new DateTime(2023, 5, 16),
                Summary = "1 year cliff, then 8.33% monthly for 12 months"
            },
            new VestingScheduleDTO
            {
                Round = "Advisors",
                Tokens = 15000000,
                Percentage = 5.00,
                TGEUnlock = 0,
                Cliff = 8,
                UnlockStart = new DateTime(2022, 1, 16),
                UnlockEnd = new DateTime(2023, 1, 16),
                Summary = "8 months cliff, then 8.33% monthly for 12 months"
            },
            new VestingScheduleDTO
            {
                Round = "Treasury",
                Tokens = 82500000,
                Percentage = 27.50,
                TGEUnlock = 6,
                Cliff = 0,
                UnlockStart = new DateTime(2021, 6, 16),
                UnlockEnd = new DateTime(2022, 8, 16),
                Summary = "6.66% monthly for 15 months"
            },
            new VestingScheduleDTO
            {
                Round = "Liquidity & Staking Rewards",
                Tokens = 60000000,
                Percentage = 20.00,
                TGEUnlock = 50,
                Cliff = 0,
                UnlockStart = new DateTime(2021, 6, 16),
                UnlockEnd = new DateTime(2021, 9, 16),
                Summary = "50% at TGE, then 16.66% monthly for 3 months"
            },
            new VestingScheduleDTO
            {
                Round = "Operations",
                Tokens = 15000000,
                Percentage = 5.00,
                TGEUnlock = 10,
                Cliff = 0,
                UnlockStart = new DateTime(2021, 6, 16),
                UnlockEnd = new DateTime(2023, 3, 16),
                Summary = "10% monthly for 10 months"
            },
            new VestingScheduleDTO
            {
                Round = "Foundation",
                Tokens = 30000000,
                Percentage = 10.00,
                TGEUnlock = 5,
                Cliff = 0,
                UnlockStart = new DateTime(2021, 6, 16),
                UnlockEnd = new DateTime(2023, 1, 16),
                Summary = "5% monthly for 20 months"
            }
        ];

        private IEnumerable<UnlockScheduleDTO> UnlockSchedles =
        [
            new UnlockScheduleDTO { Date = new DateTime(2021, 6, 16), Name = "Private Sale", Amount = 3300000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 6, 16), Name = "Seed", Amount = 300000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 6, 16), Name = "Strategic", Amount = 1320000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 6, 16), Name = "Public Sale", Amount = 3000000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 6, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 6, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 6, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 6, 16), Name = "Liquidity & Staking Rewards", Amount = 30000000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 6, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 6, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2021, 7, 16), Name = "Private Sale", Amount = 2670000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 7, 16), Name = "Seed", Amount = 300000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 7, 16), Name = "Strategic", Amount = 1518000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 7, 16), Name = "Public Sale", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 7, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 7, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 7, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 7, 16), Name = "Liquidity & Staking Rewards", Amount = 10000000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 7, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 7, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2021, 8, 16), Name = "Private Sale", Amount = 2670000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 8, 16), Name = "Seed", Amount = 540000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 8, 16), Name = "Strategic", Amount = 1518000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 8, 16), Name = "Public Sale", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 8, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 8, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 8, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 8, 16), Name = "Liquidity & Staking Rewards", Amount = 10000000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 8, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 8, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2021, 9, 16), Name = "Private Sale", Amount = 2670000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 9, 16), Name = "Seed", Amount = 540000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 9, 16), Name = "Strategic", Amount = 1518000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 9, 16), Name = "Public Sale", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 9, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 9, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 9, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 9, 16), Name = "Liquidity & Staking Rewards", Amount = 10000000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 9, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 9, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2021, 10, 16), Name = "Private Sale", Amount = 2670000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 10, 16), Name = "Seed", Amount = 540000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 10, 16), Name = "Strategic", Amount = 1518000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 10, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 10, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 10, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 10, 16), Name = "Liquidity & Staking Rewards", Amount = 10000000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 10, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 10, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2021, 11, 16), Name = "Private Sale", Amount = 2670000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 11, 16), Name = "Seed", Amount = 540000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 11, 16), Name = "Strategic", Amount = 1518000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 11, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 11, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 11, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 11, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 11, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 11, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 11, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2021, 12, 16), Name = "Private Sale", Amount = 2670000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 12, 16), Name = "Seed", Amount = 540000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 12, 16), Name = "Strategic", Amount = 1518000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 12, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 12, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 12, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 12, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 12, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 12, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2021, 12, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2022, 1, 16), Name = "Private Sale", Amount = 2670000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 1, 16), Name = "Seed", Amount = 540000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 1, 16), Name = "Strategic", Amount = 1518000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 1, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 1, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 1, 16), Name = "Advisors", Amount = 1250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 1, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 1, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 1, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 1, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2022, 2, 16), Name = "Private Sale", Amount = 2670000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 2, 16), Name = "Seed", Amount = 540000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 2, 16), Name = "Strategic", Amount = 1518000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 2, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 2, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 2, 16), Name = "Advisors", Amount = 1250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 2, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 2, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 2, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 2, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2022, 3, 16), Name = "Private Sale", Amount = 2670000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 3, 16), Name = "Seed", Amount = 540000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 3, 16), Name = "Strategic", Amount = 1518000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 3, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 3, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 3, 16), Name = "Advisors", Amount = 1250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 3, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 3, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 3, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 3, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2022, 4, 16), Name = "Private Sale", Amount = 2670000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 4, 16), Name = "Seed", Amount = 540000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 4, 16), Name = "Strategic", Amount = 1518000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 4, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 4, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 4, 16), Name = "Advisors", Amount = 1250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 4, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 4, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 4, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 4, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2022, 5, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 5, 16), Name = "Seed", Amount = 540000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 5, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 5, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 5, 16), Name = "Team", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 5, 16), Name = "Advisors", Amount = 1250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 5, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 5, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 5, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 5, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2022, 6, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 6, 16), Name = "Seed", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 6, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 6, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 6, 16), Name = "Team", Amount = 3250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 6, 16), Name = "Advisors", Amount = 1250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 6, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 6, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 6, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 6, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2022, 7, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 7, 16), Name = "Seed", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 7, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 7, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 7, 16), Name = "Team", Amount = 3250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 7, 16), Name = "Advisors", Amount = 1250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 7, 16), Name = "Treasury", Amount = 5500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 7, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 7, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 7, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2022, 10, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 10, 16), Name = "Seed", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 10, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 10, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 10, 16), Name = "Team", Amount = 3250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 10, 16), Name = "Advisors", Amount = 1250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 10, 16), Name = "Treasury", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 10, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 10, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 10, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2022, 11, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 11, 16), Name = "Seed", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 11, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 11, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 11, 16), Name = "Team", Amount = 3250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 11, 16), Name = "Advisors", Amount = 1250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 11, 16), Name = "Treasury", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 11, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 11, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 11, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2022, 12, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 12, 16), Name = "Seed", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 12, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 12, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 12, 16), Name = "Team", Amount = 3250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 12, 16), Name = "Advisors", Amount = 1250000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 12, 16), Name = "Treasury", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 12, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 12, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2022, 12, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2023, 1, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 1, 16), Name = "Seed", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 1, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 1, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 1, 16), Name = "Team", Amount = 3250000 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 1, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 1, 16), Name = "Treasury", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 1, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 1, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 1, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2023, 2, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 2, 16), Name = "Seed", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 2, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 2, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 2, 16), Name = "Team", Amount = 3250000 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 2, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 2, 16), Name = "Treasury", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 2, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 2, 16), Name = "Operations", Amount = 1500000 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 2, 16), Name = "Foundation", Amount = 1500000 },

            new UnlockScheduleDTO { Date = new DateTime(2023, 3, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 3, 16), Name = "Seed", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 3, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 3, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 3, 16), Name = "Team", Amount = 3250000 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 3, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 3, 16), Name = "Treasury", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 3, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 3, 16), Name = "Operations", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 3, 16), Name = "Foundation", Amount = 0 },

            new UnlockScheduleDTO { Date = new DateTime(2023, 4, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 4, 16), Name = "Seed", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 4, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 4, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 4, 16), Name = "Team", Amount = 3250000 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 4, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 4, 16), Name = "Treasury", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 4, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 4, 16), Name = "Operations", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 4, 16), Name = "Foundation", Amount = 0 },

            new UnlockScheduleDTO { Date = new DateTime(2023, 5, 16), Name = "Private Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 5, 16), Name = "Seed", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 5, 16), Name = "Strategic", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 5, 16), Name = "Public Sale", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 5, 16), Name = "Team", Amount = 3250000 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 5, 16), Name = "Advisors", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 5, 16), Name = "Treasury", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 5, 16), Name = "Liquidity & Staking Rewards", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 5, 16), Name = "Operations", Amount = 0 },
            new UnlockScheduleDTO { Date = new DateTime(2023, 5, 16), Name = "Foundation", Amount = 0 },
        ];

    }
}
