using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Calculators;
using Electronics.Logic.DomainClasses.CustomExceptions;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.ProductsServicesFolder;
using Electronics.Logic.UserServicesFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Electronics_project.Pages
{
    public class ProductsDetailsModel : PageModel
    {
        private readonly ComputerServices _ComputerServices;
        private readonly PhoneServices _PhoneServices;
        private readonly OrderServices _OrderServices;
        private readonly CustomerServices _CustomerServices;
        private readonly ElectronicServices _ElectronicServices;
        protected Customer Customer { get; private set; }
        public Computer Computer { get; private set; }
        public Phone Phone { get; private set; }
        public List<MyPropertyInfo> ComputerProperties { get; private set; }
        public List<MyPropertyInfo> PhoneProperties { get; private set; }
        public List<Electronic> Relateds { get; private set; }
        [BindProperty]
        public Cart NewCart { get; set; }
        public string Message {  get; private set; }

        public ProductsDetailsModel(ComputerServices computerServices, PhoneServices phoneServices, OrderServices orderServices, CustomerServices customerServices, ElectronicServices electronicServices)
        {
            _ComputerServices = computerServices;
            _PhoneServices = phoneServices;
            _OrderServices = orderServices;
            _CustomerServices = customerServices;
            _ElectronicServices = electronicServices;
            Relateds = new List<Electronic>();
        }

        public IActionResult OnGet(int serialNumber)
        {
            if (serialNumber == 0)
            {
                return RedirectToPage("Products");
            }
            try
            {
                Computer = _ComputerServices.GetComputerBySerialNumber(serialNumber);
                if (Computer == null)
                {
                    Phone = _PhoneServices.GetPhoneBySerialNumber(serialNumber);
                    PhoneProperties = _PhoneServices.GetProperties(Phone);
                    GetRelateds(Phone);
                }
                else
                {
                    ComputerProperties = _ComputerServices.GetProperties(Computer);
                    GetRelateds(Computer);
                }
            }
            catch (DatabaseConnectionException ex)
            {
                Message = ex.Message;
            }

            return Page();
        }

        public string CheckLoggedInUser()
        {
            var userIdClaim = User.FindFirst("Id");

            if (userIdClaim == null)
            {
                return string.Empty;
            }

            return userIdClaim.Value;
        }

        private void GetRelateds(Electronic electronic)
        {
            string checkUser = CheckLoggedInUser();
            List<Electronic> pastOrders = new List<Electronic>();
            if (!string.IsNullOrEmpty(checkUser))
            {
                Customer = _CustomerServices.GetCustomerById(Convert.ToInt32(checkUser));
                pastOrders = new List<Electronic>(_OrderServices.GetPastOrder(Customer));
            }
            try
            {
                if (Customer == null || pastOrders == null || pastOrders.Count == 0)
                {
                    Relateds = new List<Electronic>(_ElectronicServices.GetRelatedElectronics(electronic, pastOrders));
                }
                Relateds = new List<Electronic> (_ElectronicServices.GetRelatedElectronics(electronic, pastOrders));
            }
            catch (DatabaseConnectionException ex)
            {
                Message += ex.Message;
            }
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
            NewCart.TotalPrice = electronic.Price * NewCart.Quantity;

            if (ModelState.IsValid)
            {
                var serializedElectronicCart = System.Text.Json.JsonSerializer.Serialize<Cart>(NewCart);
                HttpContext.Session.SetString("Electronic", serializedElectronicCart);
                Message = "Product added to cart";
                return Page();
            }

            return Page();
        }
    }
}
