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
