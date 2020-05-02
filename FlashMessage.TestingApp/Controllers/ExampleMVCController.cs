using Microsoft.AspNetCore.Mvc;
using SWMNU.Net.FlashMessage;

namespace SWMNU.Net.FlashMessage.TestingApp.Controllers
{
    [Route("examplemvc")]
    public class ExampleMVCController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var flashMessage = new AlertMessage();
            return View(flashMessage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] AlertMessage flashMessage)
        {
            if(string.IsNullOrEmpty(flashMessage.Text) || string.IsNullOrWhiteSpace(flashMessage.Text))
            {
                ModelState.AddModelError("", "Flash Message needs some content!");
                return View(flashMessage);
            }

            TempData.SetFlashMessage(flashMessage);
            return RedirectToPage("/Index");
        }
    }
}