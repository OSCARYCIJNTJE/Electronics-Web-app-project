using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.DTO.ProductsDTO
{
    public class ComputerDTO : ElectronicDTO
    {
        [Required, MinLength(10)]
        public string Processor { get; set; } = string.Empty;
        [Required, MaxLength(2)]
        public string RAM { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string KeyboardType { get; set; } = string.Empty;
        [Required, MaxLength(6)]
        public string MouseType { get; set; } = String.Empty;
        [Required]
        public List<string> Ports { get; set; } = new List<string>();
        [Required, MinLength(6)]
        public string PowerSource { get; set; } = string.Empty;
    }
}
