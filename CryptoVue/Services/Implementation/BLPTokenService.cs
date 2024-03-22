using CryptoVue.Common.BscScan;
using CryptoVue.Data.Models;
using System.Text.Json;

namespace CryptoVue.Services.Implementation
{
    public class BLPTokenService : IBLPTokenService
    {
        private readonly string bscscanApiUrl;
        private readonly string bscscanApiKey;
        private readonly string BLPTokenContractAddress = "0xfE1d7f7a8f0bdA6E415593a2e4F82c64b446d404";
        public BLPTokenService(IConfiguration configuration)
        {
            bscscanApiUrl = configuration["bscscanApi:apiUrl"]!;
            bscscanApiKey = configuration["bscscanApi:apiKey"]!;
            var a = 2;
        }

        public async Task FetchTokenDataAsync()
        {
            TokenSupplyResponse? tokenSupply = null;

            using (var httpClient = new HttpClient())
            {
                var url = $"{bscscanApiUrl}?module=stats&action=tokenCsupply&contractaddress={BLPTokenContractAddress}&apikey={bscscanApiKey}";

                var response = await httpClient.GetAsync(url);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                tokenSupply = JsonSerializer.Deserialize<TokenSupplyResponse>(jsonResponse);
            }

            //save to db
            

        }
    }
}
