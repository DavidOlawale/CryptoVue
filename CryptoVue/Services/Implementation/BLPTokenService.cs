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
            double CirculatingSupplyFigure = 0;
            double nonCirculatingSupplyFigure = 0;

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
                CirculatingSupplyFigure += ConvertApiBalanceToDecimalFigure(account.Balance);
            }

            var totalSupplyFigure = ConvertApiBalanceToDecimalFigure(totalSupply.Result);
            nonCirculatingSupplyFigure = totalSupplyFigure - CirculatingSupplyFigure;

            var circulatingSupplyFigure = totalSupplyFigure - nonCirculatingSupplyFigure;

            var tokenData = await dbContext.TokenDataRecords.FirstOrDefaultAsync();
            if (tokenData != null)
            {
                tokenData.TotalSupply = totalSupplyFigure;
                tokenData.CirculatingSupply = nonCirculatingSupplyFigure;
                tokenData.CaptureDate = DateTime.Now;

                dbContext.TokenDataRecords.Update(tokenData);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                tokenData = new TokenDataRecord
                {
                    Name = "BLP token",
                    TotalSupply = totalSupplyFigure,
                    CirculatingSupply = circulatingSupplyFigure,
                    CaptureDate = DateTime.Now,
                };

                await dbContext.TokenDataRecords.AddAsync(tokenData);
                await dbContext.SaveChangesAsync();
            }

        }


        public async Task<TokenDataRecord?> GetStoredDataAsync()
        {
            return await dbContext.TokenDataRecords.OrderByDescending(c => c.CaptureDate).FirstOrDefaultAsync();
        }

        public double ConvertApiBalanceToDecimalFigure(string balance)
        {
            if (balance == "0")
            { 
                return 0;
            }
            // Extract the integer part (since api returns figures with 18 decimal places without a dot)
            string integerPart = balance.Length <= 18 ? "0" : balance.Substring(0, balance.Length - 18);

            // Extract only 2 decimal points
            string fractionalPart = balance.Substring(balance.Length - 18);

            // Combine the integer part with the decimal part
            string decimalStr = $"{integerPart}.{fractionalPart.Substring(0, 2)}";

            // Parse the decimal string to a double
            return double.Parse(decimalStr);
        }
    }
}
