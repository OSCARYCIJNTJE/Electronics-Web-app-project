using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.DTO
{
    public class CustomerRegistrationDTO : RegisterCredentialsDTO
    {
        [Required]
        public string Country { get; set; } = string.Empty;
        [Required, MaxLength(6)]
        public string PostalCode { get; set; } = string.Empty;
        public string CardInfo { get; set; } = string.Empty;
    }
}
