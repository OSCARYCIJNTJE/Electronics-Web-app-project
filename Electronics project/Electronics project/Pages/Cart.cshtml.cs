using Electronics.Logic.ProductsServicesFolder;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.UserServicesFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Electronics.DTO;
using Electronics.Logic.Converters;
using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.Users;
using System.Text.Json;
using Electronics.Logic.DomainClasses.CustomExceptions;

namespace Electronics_project.Pages
{
    public class CartModel : PageModel
    {
        private readonly CustomerServices _CustomerServices;
        private readonly ComputerServices _ComputerServices;
        private readonly PhoneServices _PhoneServices;
        public readonly OrderServices _OrderServices;
        public List<Cart> CartList { get; private set; }
        [BindProperty]
        public CustomerRegistrationDTO RegisterCredentialsDTO { get; set; }
        public Customer customer { get; private set; }
        public string Message { get; private set; }
        public CartModel(CustomerServices customerServices, ComputerServices computerServices, PhoneServices phoneServices, OrderServices orderServices)
        {
            _ComputerServices = computerServices;
            _CustomerServices = customerServices;
            _PhoneServices = phoneServices;
            _OrderServices = orderServices;
        }
        public void OnGet()
        {
            CartList = LoadList();
            GetElectronicAndAddToList();
        }

        public void GetElectronicAndAddToList()
        {
            var getSession = HttpContext.Session.GetString("Electronic");
            if (!string.IsNullOrEmpty(getSession))
            {
                var deserializeSession = System.Text.Json.JsonSerializer.Deserialize<Cart>(getSession);
                if (deserializeSession is Cart cart)
                {
                    foreach (Cart item in CartList)
                    {
                        if (cart.SerialNumber == item.SerialNumber)
                        {
                            cart.Quantity += item.Quantity;
                            CartList.Add(cart);
                            CartList.Remove(item);
                            break;
                        }
                    }
                    if (!CartList.Contains(cart))
                    {
                        CartList.Add(cart);
                    }

                    HttpContext.Session.Remove("Electronic");
                    SaveListInSession(CartList);
                }
            }
        }

        public void SaveListInSession(List<Cart> carts)
        {
            if (carts.Count > 0)
            {
                var serializeList = System.Text.Json.JsonSerializer.Serialize<List<Cart>>(carts);
                HttpContext.Session.SetString("SavedList", serializeList);
            }
        }

        public List<Cart> LoadList()
        {
            var getSession = HttpContext.Session.GetString("SavedList");
            if (!string.IsNullOrEmpty(getSession))
            {
                var deserializeList = System.Text.Json.JsonSerializer.Deserialize<List<Cart>>(getSession);
                if (deserializeList is List<Cart> carts)
                {
                    return carts;
                }
            }
            return new List<Cart>();
        }

        public IActionResult OnPost()
        {
            CartList = LoadList();
            var userId = User.FindFirst("Id");
            if (userId == null)
            {
                Message = "You are not logged in";
                return Page();
            }
            customer = _CustomerServices.GetCustomerById(Convert.ToInt32(userId.Value));
            if (CartList.Count == 0)
            {
                Message = "You need to add a product in the cart";
                return Page();
            }
            try
            {
                _OrderServices.Purchase(customer, CartList);
            }
            catch (DatabaseConnectionException ex)
            {
                Message = ex.Message;
            }
            return RedirectToPage("PurchaseSuccess");
        }

        public IActionResult OnPostRegister()
        {
            if (ModelState.IsValid)
            {
                Customer customer = CustomerConverter.ConvertToCustomer(RegisterCredentialsDTO);
                _CustomerServices.RegisterNewCustomer(customer);
                return RedirectToPage("Login");
            }
            return Page();
        }
    }
}
