using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWMNU.Net.FlashMessage;
using SWMNU.NET.BS5.FlashMessage.TestingApp.Models;

namespace SWMNU.NET.BS5.FlashMessage.TestingApp.ExampleRazor.Pages
{
    public class FormMessageModel : PageModel
    {
        // Public Property FormAlert for use in OnPost() method.
        public FormAlert FormAlert { get; set; }

        // Bound Public Property used to hold Form values on form submission.
        [BindProperty]
        public FormMessageViewModel FMVM { get; set; }

        /// <summary>
        /// <para>HTTP Method: GET</para>
        /// <para>Stub method to return Razor Page.</para>
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// <para>HTTP Method: POST</para>
        /// <para>Method that runs on form submission in file: Pages/ExampleRazor/FormMessage.chstml</para>
        /// </summary>
        public IActionResult OnPost()
        {
            //
            // A Note:
            //
            // If you take a peek in Models/FormMessageViewModel.cs, you'll notice that Data
            // Attributes are put on `FirstName` and `LastName`. This is for when you submit
            // the form without any values whatsoever; which shows off ASP.NET Core's Form 
            // Validation, which ties in with jQuery Validate and jQuery Validation Unobtrusive.
            //
            // We could have used Data Attribute Validation in Models/FormMessageViewModel.cs
            // to check for string length on our form properties; but that would invalidate ModelState
            // without actually calling this method.
            //
            // So we check our form values here, so we can explicity invalidate ModelState should
            // the values not conform to our rules.
            //
            if (FMVM.FirstName.Length < 2)
            {
                ModelState.AddModelError("", "First Name must be longer than 2 characters.");
            }

            if (FMVM.LastName.Length < 2)
            {
                ModelState.AddModelError("", "Last Name must be longer than 2 characters.");
            }

            // If the submitted values didn't pass our rules above,
            // then we build our error alert.
            if (!ModelState.IsValid)
            {
                // This calls a custom extension method, which extends `ModelStateDictionary`.
                // It gathers all validation errors and returns them in an `List<string>`.
                var errorsList = ModelState.GetModelStateErrors();

                // This calls a custom helper method which takes a List<string> and returns
                // a string containing an HTML <ul></ul> element with child <li></li> elements
                // containing Validation Errors.
                var errors = MessageHelpers.BuildFormErrorString(errorsList);

                // Build our Error Alert
                FormAlert = new FormAlert()
                {
                    Title = "Uh oh!",
                    Text = "Houston, we have a problem!",
                    Type = AlertType.Danger,
                    Dismissible = false,
                    UseBootstrap4 = false , // Use Bootstrap 5.x, not required as this is the default.
                    Errors = errors
                };                
            }
            // Nothing went wrong, so we make a success alert.
            else
            {
                FormAlert = new FormAlert()
                {
                    Title = "Hurray!",
                    Text = "Everything is in order!",
                    Type = AlertType.Success,
                    Dismissible = true,
                    UseBootstrap4 = false, // Use Bootstrap 5.x, not required as this is the default.
                    Errors = string.Empty
                };
            }

            // Set Form Message params to show on form submission.
            TempData.SetFormMessage(FormAlert);
            // Return Page.
            return Page();
        }
    }
}
