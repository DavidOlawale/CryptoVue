using CryptoVue.Data.Models;
using CryptoVue.Dtos;

namespace CryptoVue.Services
{
    public interface IBLPTokenService
    {
        public Task<TokenDataRecord?> GetStoredDataAsync();

        public Task<DashboardDTO> FetchDashboardDataAsync();
    }
}
