using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electronics.DTO.ProductsDTO;
using static System.Net.Mime.MediaTypeNames;

namespace Electronics.DTO
{
    public class ImageConverterDTO
    {
        public string GetImageString(ElectronicDTO electronic)
        {
            string format = "image/png";
            string base64Image = Convert.ToBase64String(electronic.Image);
            return "data:" + format + ";base64," + base64Image;
        }
    }
}
