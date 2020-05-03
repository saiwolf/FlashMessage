# Flash Messages for ASP.NET Core 3.1

## Description
This is a Razor Class Library I wrote that provides a means to display Flash Messages in an ASP.NET Core 3.1 web application. (Razor Pages and MVC are supported.)

It depends on and utilizes [Twitter Bootstrap 4](https://getbootstrap.com/docs/4.4/getting-started/introduction/) for the alert CSS and HTML.

Check out the [Wiki](https://github.com/saiwolf/FlashMessage/wiki/Getting-Started) to get started!

## What's a Flash Message?
A Flash Message can be thought of as a one time notification.

Perhaps a Welcome message after you sign up for a web site. Or an error notification indicating
that an action has failed. They're meant to be seen once and never again.

## How it works

In a nutshell, this library exports functions and a few Razor View Partials that work in tandem
to display a Flash Message or a Form Alert using [`TempData`](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-3.1#tempdata) and 
Bootstrap 4 for the Alert styling.

By using `TempData`, the flash message is only shown
once. A refresh or reload will cause the message to disappear.

## Requirements

1. An ASP.NET Core 3.1 Web App. Razor Pages and/or MVC supported.
2. Bootstrap 4.

## Example App

The `FlashMessage.TestingApp` folder contains an ASP.NET Core 3.1 Web App that shows 
off the Flash Message and Form Alert features. It contains both Razor Pages and MVC Examples.

It utilizes [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) (located at [https://localhost:5001/swagger/](https://localhost:5001/swagger/))
to show the MVC endpoints currently mapped.

It also utilizes [Serilog.AspNetCore](https://github.com/serilog/serilog-aspnetcore) for better logging all around.

### Running the Example App

1. Change directory to `FlashMessage.TestingApp`.
2. Execute `dotnet run`

## LICENSE

This project is licensed under the [MIT License](LICENSE).

## Contact
You can contact me at robertcato015 at gmail dot com, if you have any questions!

Or feel free to open up an issue or pull request!