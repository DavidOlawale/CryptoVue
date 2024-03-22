using CryptoVue.Data.Models;

namespace CryptoVue.Services
{
    public interface IBLPTokenService
    {
        public Task FetchTokenDataAsync();

        public IEnumerable<CryptoTokenSnapshot> GetStoredDataAsync();
    }
}
