using Electronics.DTO;
using Electronics.Logic.Converters;
using Electronics.Logic.DomainClasses;
using Electronics.Logic.DomainClasses.CustomExceptions;
using Electronics.Logic.DomainClasses.Products;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.UserServicesFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace Electronics_project.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public CustomerRegistrationDTO RegisterCredentialsDTO { get; set; }
        protected Customer Customer;
        private readonly CustomerServices _CustomerServices;
        public List<Electronic> Favorites { get; set; }
        public string Message {  get; private set; }
        public ProfileModel(CustomerServices customerServices)
        {
            _CustomerServices = customerServices;
            RegisterCredentialsDTO = new CustomerRegistrationDTO();
            Favorites = new List<Electronic>();
        }
        public IActionResult OnGet()
        {
            Customer = _CustomerServices.GetCustomerById(Convert.ToInt32(CheckLoggedInUser()));
            _CustomerServices.SetRegisterDTOFiller(Customer, RegisterCredentialsDTO);
            Customer.LoadFavorites( new List<Electronic>(_CustomerServices.GetFavorites(Customer)));

            if (Customer.Favorites.Count() == 0)
            {
                Message = "You do not have a product added here, try adding one";
            }
            else
            {
                Favorites = Customer.Favorites;
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

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Customer customer = CustomerConverter.ConvertToCustomer(RegisterCredentialsDTO);
                try
                {
                    _CustomerServices.EditCustomer(customer);
                }
                catch (DatabaseConnectionException ex)
                {
                    Message += ex.Message;
                }
                return RedirectToPage("Profile");
            }
            Message = "Please try again";
            return Page();
        }
    }
}
