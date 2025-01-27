using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electronics.DTO.ProductsDTO;

namespace Electronics.DTO
{
    public class CartDTO
    {
        [Required]
        public int SerialNumber { get; set; }
        public ElectronicDTO Electronic { get; set; } = new ElectronicDTO();
        [Required]
        public int Quantity { get; set; } = 1;
        public int TotalPrice { get; set; }

        public void CalculateTotalPrice()
        {
            TotalPrice = Convert.ToInt32(Electronic.Price) * Quantity;
        }

    }
}
