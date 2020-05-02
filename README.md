# Flash Messages for ASP.NET Core 3.1

## Description
This is a Razor Class Library I wrote that provides a means to display Flash Messages in an ASP.NET Core 3.1 web application. (Razor Pages and MVC are supported.)

## Getting Started

Install the NuGet Package

Reference the Flash Message partial somewhere in your app. A good location is in the `_Layout` partial.

```c#
<div class="container">
    <partial name="_FlashMessage" />
    <main role="main" class="pb-3">
        @RenderBody()
    </main>
</div>
```

In your code, define a new instance of the `AlertMessage` class, then call `TempData.SetFlashMessage` when you're ready to set the Flash:

(Razor Example)

```c#
using SWMNU.Net.FlashMessage;

namespace Example.App.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {            
        }

        public IActionResult OnPost()
        {
            var alertMessage = new AlertMessage()
            {
                Text = "The Meat of the message.",
                Title = "Optional. Not Required.",
                Type = AlertType.Danger // You can specify any of the Bootstrap 4 theme colors here.
                Dismissible = true // Defaults to `false`.
            }

            // Call `TempData.SetFlashMessage(alertMessage) to set the Flash
            TempData.SetFlashMessage(alertMessage);

            return Page();
        }
    }
}
```

(MVC Example)
```c#
using SWMNU.Net.FlashMessage;

namespace Example.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public void Index()
        {            
        }

        [HttpPost]
        public IActionResult Index()
        {
            var alertMessage = new AlertMessage()
            {
                Text = "The Meat of the message.",
                Title = "Optional. Not Required.",
                Type = AlertType.Danger // You can specify any of the Bootstrap 4 theme colors here.
                Dismissible = true // Defaults to `false`.
            }

            // Call `TempData.SetFlashMessage(alertMessage) to set the Flash
            TempData.SetFlashMessage(alertMessage);

            return View();
        }
    }
}
```


## Alert Types

These are the current types selectable for Flash Message colors.
They follow the Bootstrap 4 Theme.

```c#
// File: FlashMessage.Src/Models/FlashMessage.cs
public enum AlertType
{
    Primary,
    Secondary,
    Success,
    Danger,
    Warning,
    Info,
    Light,
    Dark
}
```

## How it works

In a nutshell, this library exports functions and a Razor View Partial that work in tandem
to display a Flash Message using [`TempData`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-3.1#tempdata).

By using `TempData`, the flash message is only shown
once. A refresh or reload will cause the message to disappear.

## LICENSE

This project is licensed under the [MIT License](LICENSE).

## Contact
You can contact me at robertcato015 at gmail dot com, if you have any questions!

Or feel free to open up an issue or pull request!