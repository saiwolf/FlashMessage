using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWMNU.Net.FlashMessage;

namespace SWMNU.Net.FlashMessage.TestingApp.Pages.ExampleRazor
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public AlertMessage FlashMessage { get; set; }

        public void OnGet()
        {
            FlashMessage = new AlertMessage();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(FlashMessage.Text) || string.IsNullOrWhiteSpace(FlashMessage.Text))
            {
                ModelState.AddModelError("", "Flash Message needs some content!");
                return Page();
            }

            TempData.SetFlashMessage(FlashMessage);
            return RedirectToPage("/Index");
        }
    }
}
