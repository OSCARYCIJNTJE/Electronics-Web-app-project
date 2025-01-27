using Electronics.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Electronics_project.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }
        public string Title { get; set; }
        public string Message {  get; set; }

        public ContactModel()
        {
            Contact = new Contact();
            Title = "Contact";
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostContact()
        {
            if (ModelState.IsValid)
            {
                Title = "Contact Sent";
                Message = $"Name: {Contact.Name},Email: {Contact.Email},Subject: {Contact.Subject}";
                return RedirectToPage("Index");
            }
            return Page();
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Contact");
        }
    }
}
