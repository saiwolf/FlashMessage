using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWMNU.Net.FlashMessage;

namespace SWMNU.NET.FlashMessage.TestingApp.ExampleRazor.Pages
{
    public class FlashMessageModel : PageModel
    {
        // Bound public property for use in OnPost() method to hold form values.
        [BindProperty]
        public AlertMessage FlashMessage { get; set; }

        /// <summary>
        /// <para>HTTP Method: GET</para>
        /// <para>Stub method to render Razor Page.</para>
        /// </summary>
        public void OnGet()
        {
            // Not explicity needed here, just a CYA.
            FlashMessage = new AlertMessage();
        }

        /// <summary>
        /// <para>HTTP Method: POST</para>
        /// <para>Method that runs on form submission in File: Pages/ExampleRazor/FlashMessage.cshtml</para>
        /// </summary>
        public IActionResult OnPost()
        {
            // Showing a flash message without actual text, even with a title, would just be silly.
            // So we invalidate ModelState by adding a custom error.
            if (string.IsNullOrEmpty(FlashMessage.Text) || string.IsNullOrWhiteSpace(FlashMessage.Text))
            {
                ModelState.AddModelError("", "Flash Message needs some content!");
                // Return View with previous model values, so form stays populated.
                return Page();
            }

            // Set to `false` to use Bootstrap 5.x
            // Not needed as `false` is the default value.
            FlashMessage.UseBootstrap4 = false;
            // If all is well, then set Flash Message params in TempData
            TempData.SetFlashMessage(FlashMessage);
            // Return Page to show set Flash Message.
            return Page();
        }
    }
}
