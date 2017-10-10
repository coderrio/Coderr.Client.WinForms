Integration library for WinForms applications
=============================================

[![VSTS](https://1tcompany.visualstudio.com/_apis/public/build/definitions/75570083-b1ef-4e78-88e2-5db4982f756c/16/badge)]() [![NuGet](https://img.shields.io/nuget/dt/codeRR.Client.WinForms.svg?style=flat-square)]()

This library will detect all unhandled exceptions in WinForms based applications and report them to your codeRR server.

## Built in error page
![The built in error page](docs/screenshot.png)

## Example of captured screenshot when an exception was detected
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
* One property collection for each open form.
* Screenshot of the active form (the one that threw an exception)

# Requirements

You need to either install [codeRR Community Server](https://github.com/coderrapp/coderr.server) or use [codeRR Live](https://coderrapp.com/live).

# Help?

* [Documentation](https://coderrapp.com/documentation/client/libraries/winforms/)
* [Forum](http://discuss.coderrapp.com)
