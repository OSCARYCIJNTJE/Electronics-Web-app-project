using Electronics.DTO;
using Electronics.Logic.Converters;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.UserServicesFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace Electronics_project.Pages
{
    public class RegisterModel : PageModel
    {
        public Customer Customer { get; set; }
        public string Message { get; set; }
        private readonly CustomerServices _CustomerServices;
        [BindProperty]
        public CustomerRegistrationDTO RegisterCredentials { get; set; }
        public RegisterModel(CustomerServices customerServices)
        {
            Customer = null;
            _CustomerServices = customerServices;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Customer customer = CustomerConverter.ConvertToCustomer(RegisterCredentials);
                _CustomerServices.RegisterNewCustomer(customer);
                return RedirectToPage("Login");
            }
            return Page();
        }
    }
}
