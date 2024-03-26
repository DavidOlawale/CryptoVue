using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoVue.Data.Models
{
    public class TokenDataRecord: Base.BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double TotalSupply { get; set; }

        [Required]
        public double CirculatingSupply { get; set; }

        [Required]
        public DateTime CaptureDate { get; set; }
    }
}
