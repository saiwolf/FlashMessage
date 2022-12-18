# Flash Messages for ASP.NET Core

## Description
This is a Razor Class Library that provides a means to display Flash Messages in an ASP.NET web application. (Razor Pages and MVC are supported.)

It depends on and utilizes Twitter Bootstrap for the alert CSS and HTML.

Currently, [Bootstrap 5](https://getbootstrap.com/docs/5.1/getting-started/introduction/) is supported.

Check out the [Wiki](https://github.com/saiwolf/FlashMessage/wiki/Getting-Started) to get started!

## Download

You can grab this package from [NuGet](https://www.nuget.org/packages/SWMNU.Net.FlashMessage/)
or by going to the [Releases](https://github.com/saiwolf/FlashMessage/releases) of this repo.

## What's a Flash Message?
A Flash Message can be thought of as a one time notification.

Perhaps a Welcome message after you sign up for a web site. Or an error notification indicating
that an action has failed. They're meant to be seen once and never again.

## How it works

In a nutshell, this library exports functions and a few Razor View Partials that work in tandem
to display a Flash Message or a Form Alert using [`TempData`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-3.1#tempdata) and 
Bootstrap for the Alert styling.

By using `TempData`, the flash message is only shown
once. A refresh or reload will cause the message to disappear.

## Requirements

1. An ASP.NET Web App. Razor Pages and/or MVC supported.
2. Bootstrap 5.x.

## Example Apps

The `FlashMessage.TestingApp` folder contains an ASP.NET Web App that show 
off the Flash Message and Form Alert features. It contains both Razor Pages and MVC Examples.

The example app utilizes [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) (located at [https://localhost:5001/swagger/](https://localhost:5001/swagger/))
to show the MVC endpoints currently mapped.

It also utilizes [Serilog.AspNetCore](https://github.com/serilog/serilog-aspnetcore) for better logging all around.

### Running the Example App

1. Change directory to the example app.
2. Execute `dotnet run`

## LICENSE

This project is licensed under the [MIT License](LICENSE).

## Contact
You can contact me at robertcato015 at gmail dot com, if you have any questions!

Or feel free to open up an issue or pull request!
