using System;
using System.Windows.Forms;
using Coderr.Client;

namespace Coderr.Client.WinForms.Demo
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // replace with your own settings
            var uri = new Uri("http://localhost:50473/");
            Err.Configuration.Credentials(uri,
                "9aaf662e-caf7-49bb-8741-1997cea362ff",
                "aa866c0b-235c-4190-9581-9e8b59db8db5");

            // to catch unhandled exceptions
            Err.Configuration.CatchWinFormsExceptions();

            // different types of available options.
            Err.Configuration.TakeScreenshotOfActiveFormOnly();
            //Err.Configuration.TakeScreenshots();

            // Once of these must be active to show the error form
            //=============
            Err.Configuration.UserInteraction.AskUserForDetails = true;
            //Err.Configuration.UserInteraction.AskUserForPermission = true;
            //Err.Configuration.UserInteraction.AskForEmailAddress = true;

            Err.Configuration.SetErrorForm(context => new CustomErrorDialog(context));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreateUserForm());
        }
    }
}