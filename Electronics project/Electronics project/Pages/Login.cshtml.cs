using Electronics.Logic.DomainClasses.Security;
using Electronics.Logic.DomainClasses.Users;
using Electronics.Logic.UserServicesFolder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Electronics.DTO;

namespace Electronics_project.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginCredentialsDTO CustomerCredentials { get; set; }
        private Customer? Customer { get; set; }
        public string Message { get; private set; }
        private readonly CustomerServices _CustomerServices;
        public LoginModel(CustomerServices customerServices)
        {
            _CustomerServices = customerServices;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost(string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                Customer = _CustomerServices.CheckUsernameAndPassword(CustomerCredentials.UserName, CustomerCredentials.Password);
                if (Customer == null)
                {
                    Message = "Invalid username/password";
                    return Page();
                }

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, Customer.UserName));
                claims.Add(new Claim("Id", Customer.Id.ToString()));

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimIdentity))
                    .GetAwaiter()
                    .GetResult();

                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                if (HttpContext.Session.GetString("SavedList") != null)
                {
                    return RedirectToPage("Cart");
                }
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
