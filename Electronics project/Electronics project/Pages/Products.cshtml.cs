using Electronics.DTO;
using Electronics.Logic.Converters;
using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.CustomExceptions;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.ProductsServicesFolder;
using Electronics.Logic.UserServicesFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Electronics_project.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ComputerServices _ComputerServices;
        private readonly PhoneServices _PhoneServices;
        private readonly CustomerServices _CustomerServices;
        private readonly ElectronicServices _ElectronicServices;
        public readonly List<Computer> Computers = new List<Computer>();
        public readonly List<Phone> Phones = new List<Phone>();
        private readonly ElectronicConverter _ElectronicConverter;
        public List<Electronic> Favorites;
        public int Favorite;
        [BindProperty]
        public Cart NewCart { get; set; }
        public string Message { get; private set; }
        public ProductsModel(ComputerServices computerServices, PhoneServices phoneServices, CustomerServices customerServices, ElectronicServices eServices)
        {
            _ComputerServices = computerServices;
            _PhoneServices = phoneServices;
            _CustomerServices = customerServices;
            _ElectronicServices = eServices;
            try
            {
                Computers = new List<Computer>(_ComputerServices.GetComputers());
                Phones = new List<Phone>(_PhoneServices.GetPhones());
            }
            catch (DatabaseConnectionException ex)
            {
                Message = ex.Message;
            }
            _ElectronicConverter = new ElectronicConverter();
            Favorites = new List<Electronic>();
        }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(CheckLoggedInUser()))
            {
                Customer customer = _CustomerServices.GetCustomerById(Convert.ToInt32(CheckLoggedInUser()));
                customer.LoadFavorites(new List<Electronic>(_CustomerServices.GetFavorites(customer)));

                if (customer.Favorites.Count == 0)
                {
                    Favorites = new List<Electronic>();
                }
                else
                {
                    Favorites = customer.Favorites;
                }
            }
        }

        private string CheckLoggedInUser()
        {
            var userIdClaim = User.FindFirst("Id");

            if (userIdClaim == null)
            {
                return string.Empty;
            }

            return userIdClaim.Value;
        }

        public IActionResult OnPost()
        {

            Electronic electronic = _ElectronicServices.GetElectronicById(NewCart.SerialNumber);

            if (NewCart.Quantity > electronic.Stock)
            {
                ViewData["AlertMessage"] = "The quantity exceeds the stock";
                return Page();
            }
            NewCart.Electronic = electronic;
            NewCart.TotalPrice = NewCart.Electronic.Price * NewCart.Quantity;

            if (ModelState.IsValid)
            {
                var serializedElectronicCart = System.Text.Json.JsonSerializer.Serialize<Cart>(NewCart);
                HttpContext.Session.SetString("Electronic", serializedElectronicCart);
                Message = "Product added to cart";
            }

            return Page();
        }

/*        private Electronic SetElectronic(int serialNumber)
        {
            Electronic electronic = _ComputerServices.GetComputerBySerialNumber(Convert.ToInt32(serialNumber));
        }*/

        public IActionResult OnPostFavorite()
        {
            Electronic electronic = _ElectronicServices.GetElectronicById(Favorite);

            Customer customer = _CustomerServices.GetCustomerById(Convert.ToInt32(CheckLoggedInUser()));
            if (customer == null)
            {
                return Page();
            }
            else if (customer.Favorites.Contains(electronic))
            {
                customer.RemoveFromFavorites(electronic);
            }
            else
            {
                customer.AddToFavorite(electronic);
            }

            return RedirectToPage("Products");
        }
    }
}
