using CryptoVue.Data.Models;

namespace CryptoVue.Services
{
    public interface IBLPTokenService
    {
        public Task FetchTokenDataAsync();

        public Task<CryptoTokenSnapshot?> GetStoredDataAsync();
    }
}
