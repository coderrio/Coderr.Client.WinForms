Integration library for WinForms applications
=============================================

[![VSTS](https://1tcompany.visualstudio.com/_apis/public/build/definitions/75570083-b1ef-4e78-88e2-5db4982f756c/16/badge)]() [![NuGet](https://img.shields.io/nuget/dt/codeRR.Client.WinForms.svg?style=flat-square)]()

This library will detect all unhandled exceptions in ASP.NET MVC v5 based applications and report them to your codeRR server (or your account at https://coderrapp.com).

![The built in error page](docs/screenshot.png)
![Captured screenshot when an exception was thrown](docs/context-data.png)

# Installation

1. Download and install the [codeRR server](https://github.com/coderrapp/coderr.server) or create an account at [coderrapp.com](https://coderrapp.com)
2. Install this client library (using nuget `coderr.client.netstd`)
3. Configure the credentials from your codeRR account in your `Program.cs`.

# Getting started

All unhandled exceptions are reported manually. 
But sometimes you need to deal with exceptions yourself. 

To report exceptions manually in your controller, use `this.ReportError(exception)` to allow codeRR to include RouteData, ViewBag, TempData etc when your exception is reported.
If you do not have access to the controller, you can use the `httpContext` (`httpContext.ReportException()`) or just `Err.Report()`. 

```csharp
public ActionResult UpdatePost(int uid, ForumPost post)
{
	try
	{
		_service.Update(uid, post);
	}
	catch (Exception ex)
	{
		this.ReportException(ex, new{ UserId = uid, ForumPost = post });
	}
}
```

# Context collections

This library includes the following context collections for every reported exceptions:

* All in the [core library](https://github.com/coderrapp/coderr.client)
* All in the [asp.net library](https://github.com/coderrapp/coderr.client.aspnet)
* Action parameters
* Controller information
* ModelState
* Query string
* RouteData
* Session data
* TempData
* Uploaded files
* ViewBag

# Requirements

You need to either install [codeRR Community Server](https://github.com/coderrapp/coderr.server) or use [codeRR Live](https://coderrapp.com/live).

# Help?

* [Documentation](https://coderrapp.com/documentation/client/libraries/aspnet/mvc5/)
* [Forum](http://discuss.coderrapp.com)



Integration library for WinForms applications
==========================

This library will detect all unhandled exceptions in WinForms-based applications and report them to your OneTrueError server (or your account at https://onetrueerror.com).

# Context collections

This library includes the following context collections for every reported exceptions:

* All in the [core library](https://github.com/onetrueerror/onetrueerror.client)
* One property collection for each open form.
* Screenshot of the active form (the one that threw an exception)

# Getting started

1. Download and install the [OneTrueError server](https://github.com/onetrueerror/onetrueerror.server) or create an account at [OneTrueError.com](https://onetrueerror.com)
2. Install this client library (using nuget `onetrueerror.client.winforms`)
3. Configure the credentials from your OneTrueError account in your `Program.cs`.
4. Add `OneTrue.Configuration.CatchWinFormsExceptions()` in your `Program.cs`.

Done.
