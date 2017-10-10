using System;
using System.Windows.Forms;

namespace codeRR.Client.WinForms.Demo
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
                "5f219f356daa40b3b31dfc67514df6d6",
                "22612e4444f347d1bb3d841d64c9750a");

            // to catch unhandled exceptions
            Err.Configuration.CatchWinFormsExceptions();

            // different types of available options.
            Err.Configuration.TakeScreenshotOfActiveFormOnly();
            //Err.Configuration.TakeScreenshots();
            Err.Configuration.UserInteraction.AskUserForDetails = true;
            Err.Configuration.UserInteraction.AskUserForPermission = true;
            Err.Configuration.UserInteraction.AskForEmailAddress = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreateUserForm());
        }
    }
}