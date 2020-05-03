using Microsoft.AspNetCore.Mvc;
using SWMNU.Net.FlashMessage;
using SWMNU.Net.TestingApp.Models;

namespace SWMNU.Net.TestingApp.Controllers
{
    [Route("ExampleMVC")]
    public class ExampleMVCController : Controller
    {
        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("FlashMessage")]
        public IActionResult FlashMessage()
        {
            var flashMessage = new AlertMessage();
            return View(flashMessage);
        }

        [HttpPost("FlashMessage")]
        [ValidateAntiForgeryToken]
        public IActionResult FlashMessage([FromForm] AlertMessage flashMessage)
        {
            if(string.IsNullOrEmpty(flashMessage.Text) || string.IsNullOrWhiteSpace(flashMessage.Text))
            {
                ModelState.AddModelError("", "Flash Message needs some content!");
                return View(flashMessage);
            }

            TempData.SetFlashMessage(flashMessage);
            return View();
        }

        [HttpGet("FormMessage")]
        public IActionResult FormMessage()        
        {
            var FMVM = new FormMessageViewModel();
            return View(FMVM);
        }

        public FormAlert FormAlert { get; set; }

        [HttpPost("FormMessage")]
        [ValidateAntiForgeryToken]
        public IActionResult FormMessage([FromForm]FormMessageViewModel FMVM)
        {
            if (FMVM.FirstName.Length < 2)
            {
                ModelState.AddModelError("", "First Name must be longer than 2 characters.");
            }

            if (FMVM.LastName.Length < 2)
            {
                ModelState.AddModelError("", "Last Name must be longer than 2 characters.");
            }

            if (!ModelState.IsValid)
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
            return View(FMVM);
        }
    }
}