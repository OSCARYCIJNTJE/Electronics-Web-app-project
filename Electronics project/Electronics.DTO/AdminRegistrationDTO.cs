using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.DTO
{
    public class AdminRegistrationDTO : RegisterCredentialsDTO
    {
        [Required]
        public Department Department { get; set; }
        [Required(ErrorMessage = "BSN must have atleast 7 characters"), MinLength(7)]
        public string BSN { get; set; } = string.Empty;
        [Required (ErrorMessage = "Phone number max character length is 11"), MaxLength(11)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
