using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoVue.Common.BscScan
{
    public class MultiAccountTokenBalanceResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("result")]
        public IEnumerable<AccountBalance> Result { get; set; }
    }

    public class AccountBalance
    {
        [JsonPropertyName("balance")]
        public string Balance { get; set; }
    }
}
