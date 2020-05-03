using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWMNU.Net.FlashMessage;
using SWMNU.Net.TestingApp.Models;

namespace SWMNU.Net.TestingApp.Pages.ExampleRazor
{


    public class FormMessageModel : PageModel
    {
        public FormAlert FormAlert { get; set; }

        [BindProperty]
        public FormMessageViewModel FMVM { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(FMVM.FirstName.Length < 2)
            {
                ModelState.AddModelError("", "First Name must be longer than 2 characters.");
            }

            if (FMVM.LastName.Length < 2)
            {
                ModelState.AddModelError("", "Last Name must be longer than 2 characters.");
            }

            if(!ModelState.IsValid)
            {
                var errorsList = ModelState.GetModelStateErrors();

                var errors = MessageHelpers.BuildFormErrorString(errorsList);

                FormAlert = new FormAlert()
                {
                    Title = "Uh oh!",
                    Text = "Houston, we have a problem!",
                    Type = AlertType.Danger,
                    Dismissible = false,
                    Errors = errors
                };                
            }
            else
            {
                FormAlert = new FormAlert()
                {
                    Title = "Hurray!",
                    Text = "Everything is in order!",
                    Type = AlertType.Success,
                    Dismissible = true,
                    Errors = string.Empty
                };
            }

            TempData.SetFormMessage(FormAlert);
            return Page();
        }
    }
}
