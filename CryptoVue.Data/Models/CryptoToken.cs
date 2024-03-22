using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoVue.Data.Models
{
    public class CryptoToken: Base.BaseEntity
    {
        [Required]
        public int Name { get; set; }

        [Required]
        public long TotalSupply { get; set; }

        [Required]
        public long CirculatingSupply { get; set; }
    }
}
