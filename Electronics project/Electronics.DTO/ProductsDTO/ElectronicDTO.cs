using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.DTO
{
    public class ElectronicDTO
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        [Required, MinLength(5)] /*Add some soort of vulgar checks*/
        public string Name { get; set; } = string.Empty;
        [Required, MinLength(5)]
        public string Model { get; set; } = string.Empty;
        [Required, MaxLength(7)]
        public string OperatingSystem { get; set; } = string.Empty;
        [Required, MaxLength(3)]
        public string ScreenSizeInInches { get; set; } = string.Empty;
        [Required, MaxLength(4)]
        public string StorageCapacity { get; set; } = string.Empty;
        [Required, MaxLength(3)]
        public string Stock { get; set; } = string.Empty;
        [Required, MaxLength(5)]
        public string Price { get; set; } = string.Empty;
        [Required]
        public byte[]? Image { get; set; }
    }
}
