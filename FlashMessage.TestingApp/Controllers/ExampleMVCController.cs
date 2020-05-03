using Microsoft.AspNetCore.Mvc;
using SWMNU.Net.FlashMessage;
using SWMNU.Net.TestingApp.Models;

namespace SWMNU.Net.TestingApp.Controllers
{
    [Route("ExampleMVC")]
    public class ExampleMVCController : Controller
    {
        /// <summary>
        /// Index Method for ExampleMVC Controller.
        /// </summary>
        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// <para>HTTP Method: GET</para>
        /// <para>View method for Flash Message example.</para>
        /// </summary>
        [HttpGet("FlashMessage")]
        public IActionResult FlashMessage()
        {
            // This is called by @model in Views/ExampleMVC/FlashMessage.cshtml
            // So we need to initialize it.
            var flashMessage = new AlertMessage();
            // Return View with initialized `flashMessage` model.
            return View(flashMessage);
        }

        /// <summary>
        /// <para>HTTP Method: POST</para>
        /// <para>Form submission method for Flash Message example</para>
        /// </summary>
        /// <param name="flashMessage"><see cref="AlertMessage"/> containing parameters from submitted form.</param>        
        [HttpPost("FlashMessage")]
        [ValidateAntiForgeryToken]
        public IActionResult FlashMessage([FromForm] AlertMessage flashMessage)
        {
            // Showing a flash message without actual text, even with a title, would just be silly.
            // So we invalidate ModelState by adding a custom error.
            if(string.IsNullOrEmpty(flashMessage.Text) || string.IsNullOrWhiteSpace(flashMessage.Text))
            {
                ModelState.AddModelError("", "Flash Message needs some content!");
                // Return View with previous model values, so form stays populated.
                return View(flashMessage);
            }

            // If all is well, then set Flash Message params in TempData
            TempData.SetFlashMessage(flashMessage);
            // Return View to show set Flash Message.
            return View();
        }

        /// <summary>
        /// <para>HTTP Method: GET</para>
        /// <para>View method for Form Message example</para>
        /// </summary>
        [HttpGet("FormMessage")]
        public IActionResult FormMessage()        
        {
            // This is called by @model in Views/ExampleMVC/FormMessage.cshtml,
            // so we initialize it here.
            var FMVM = new FormMessageViewModel();
            // Return View with initialized model.
            return View(FMVM);
        }

        // Public Property FormAlert for upcoming POST method.
        public FormAlert FormAlert { get; set; }

        /// <summary>
        /// <para>HTTP Method: POST</para>
        /// <para>Form submission method for Form Message example</para>
        /// </summary>
        /// <param name="FMVM"><see cref="FormMessageViewModel"/> populated from submitted form.</param>
        /// <returns></returns>
        [HttpPost("FormMessage")]
        [ValidateAntiForgeryToken]
        public IActionResult FormMessage([FromForm]FormMessageViewModel FMVM)
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
                    Errors = string.Empty
                };
            }

            // Set Form Message params to show on form submission.
            TempData.SetFormMessage(FormAlert);
            // Return View with populated Model so form keeps its contents.
            return View(FMVM);
        }
    }
}