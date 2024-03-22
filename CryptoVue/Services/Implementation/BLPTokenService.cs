using CryptoVue.Common.BscScan;
using CryptoVue.Data;
using CryptoVue.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.Json;

namespace CryptoVue.Services.Implementation
{
    public class BLPTokenService : IBLPTokenService
    {
        private readonly string bscscanApiUrl;
        private readonly string bscscanApiKey;
        private readonly string BLPTokenContractAddress = "0xfE1d7f7a8f0bdA6E415593a2e4F82c64b446d404";
        private readonly CryptoVueDbContext dbContext;
        private string monitoredAddressed = 
            "0x000000000000000000000000000000000000dEaD,"
            + "0xe9e7CEA3DedcA5984780Bafc599bD69ADd087D56,"
            + "0xfE1d7f7a8f0bdA6E415593a2e4F82c64b446d404,"
            + "0x71F36803139caC2796Db65F373Fb7f3ee0bf3bF9,"
            + "0x62D6d26F86F2C1fBb65c0566Dd6545ae3F9A63F1,"
            + "0x83a7152317DCfd08Be0F673Ab614261b4D1e1622,"
            + "0x5A749B82a55f7d2aCEc1d71011442E221f55A537,"
            + "0x9eBbBE47def2F776D6d2244AcB093AB2fD1B2C2A,"
            + "0xcdD80c6F317898a8aAf0ec7A664655E25E4833a2,"
            + "0x456F20bb4d89d10A924CE81b7f0C89D5711CE05B";

        public BLPTokenService(IConfiguration configuration, CryptoVueDbContext dbContext)
        {
            bscscanApiUrl = configuration["bscscanApi:apiUrl"]!;
            bscscanApiKey = configuration["bscscanApi:apiKey"]!;
            this.dbContext = dbContext;
        }

        public async Task FetchTokenDataAsync()
        {
            TokenSupplyResponse? totalSupply = null;
            MultiAccountTokenBalanceResponse? nonCirculatingSupply = null;
            BigInteger CirculatingSupplyFigure = BigInteger.Zero;
            BigInteger nonCirculatingSupplyFigure = BigInteger.Zero;

            using (var httpClient = new HttpClient())
            {
                // Fetch total supply
                var totalSupplyUrl = $"{bscscanApiUrl}?module=stats&action=tokenCsupply&contractaddress={BLPTokenContractAddress}&apikey={bscscanApiKey}";

                var totalSupplyResponse = await httpClient.GetAsync(totalSupplyUrl);
                var totalSupplyjsonResponse = await totalSupplyResponse.Content.ReadAsStringAsync();
                totalSupply = JsonSerializer.Deserialize<TokenSupplyResponse>(totalSupplyjsonResponse)!;

                // Then fetch account balance of monitored addresses
                var noncirculatingSupplyUrl = $"https://api.bscscan.com/api?module=account&action=balancemulti&address={monitoredAddressed}&apikey={bscscanApiKey}";
                var nonCirculatingSupplyResponse = await httpClient.GetAsync(noncirculatingSupplyUrl);
                var nonCirculatingjsonResponse = await nonCirculatingSupplyResponse.Content.ReadAsStringAsync();
                nonCirculatingSupply = JsonSerializer.Deserialize<MultiAccountTokenBalanceResponse>(nonCirculatingjsonResponse)!;
            }

            foreach (var account in nonCirculatingSupply.Result)
            {
                CirculatingSupplyFigure += BigInteger.Parse(account.Balance);
            }

            var totalSupplyFigure = BigInteger.Parse(totalSupply.Result);
            nonCirculatingSupplyFigure = totalSupplyFigure - CirculatingSupplyFigure;

            var circulatingSupplyFigure = totalSupplyFigure - nonCirculatingSupplyFigure;

            var snapshot = new CryptoTokenSnapshot
            {
                Name = "BLP token",
                TotalSupply = totalSupply.Result,
                CirculatingSupply = circulatingSupplyFigure.ToString(),
                CaptureDate = DateTime.Now,
            };

            await dbContext.CryptoTokenSnapshots.AddAsync(snapshot);
            await dbContext.SaveChangesAsync();
        }


        public IEnumerable<CryptoTokenSnapshot> GetStoredDataAsync()
        {
            return dbContext.CryptoTokenSnapshots.ToList();
        }
    }
}
