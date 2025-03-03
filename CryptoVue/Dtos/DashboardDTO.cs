using System.ComponentModel.DataAnnotations;

namespace CryptoVue.Dtos
{
    public class DashboardDTO
    {
        public string? Name { get; set; }

        public double TotalSupply { get; set; }

        public double CirculatingSupply { get; set; }
        public double NonCirculatingSupply { get; set; }
        public List<Wallet> NonCirculatingWallets { get; set; } = [];
    }

    public class Wallet
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double Balance { get; set; }

    }
}
