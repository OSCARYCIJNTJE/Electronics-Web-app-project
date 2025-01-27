using Electronics.Logic.DomainClasses.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Electronics.Logic.DomainClasses
{
    public class Cart
    {
        [Required]
        public int SerialNumber { get; set; }
        public Electronic? Electronic { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
