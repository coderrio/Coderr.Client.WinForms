using System;
using System.Windows.Forms;
using Coderr.Client;
using Coderr.Client.Config;
using Coderr.Client.WinForms.ContextProviders;

// Keeps in the root namespace to get IntelliSense

// ReSharper disable once CheckNamespace

namespace Coderr.Client.WinForms
{
    /// <summary>
    ///     Use <c>Err.Configuration.CatchWinFormsExceptions()</c> to get started.
    /// </summary>
    public static class ConfigExtensions
    {
        /// <summary>
        ///     Catch all uncaught windows form exceptions.
        /// </summary>
        /// <param name="configurator">OneTrueError configurator (accessed through <see cref="Err.Configuration" />).</param>
        public static void CatchWinFormsExceptions(this CoderrConfiguration configurator)
        {
            if (configurator == null) throw new ArgumentNullException(nameof(configurator));
            WinFormsErrorReporter.Activate();
            Err.Configuration.ContextProviders.Add(new OpenFormsCollector());
        }

        /// <summary>
        ///     Catch all uncaught windows form exceptions.
        /// </summary>
        /// <param name="configurator">OneTrueError configurator (accessed through <see cref="Err.Configuration" />).</param>
        [Obsolete("Spelling error. Will be removed. Use OneTrue.Configuration.CatchWinFormsExceptions()")]
        public static void CatchWinFormsExeptions(this CoderrConfiguration configurator)
        {
            if (configurator == null) throw new ArgumentNullException(nameof(configurator));
            WinFormsErrorReporter.Activate();
            Err.Configuration.ContextProviders.Add(new OpenFormsCollector());
        }

        /// <summary>
        ///     Set a customized form which will be shown when OneTrueError detects an uncaught exception.
        /// </summary>
        /// <param name="configurator">OneTrueError configurator (accessed through <see cref="Err.Configuration" />)</param>
        /// <param name="formFactory">Factory used to create the form.</param>
        /// <example>
        ///     <para>Start by creating your custom form. It should contain something like this:</para>
        ///     <code>
        /// public partial class CustomReportDialog : Form
        /// {
        /// 	public CustomReportDialog()
        /// 	{
        /// 		InitializeComponent();
        /// 	}
        /// 
        /// 	// It's important that you store it
        /// 	public string reportId { get; set; }
        /// 
        /// 	// And do something like this when the user clicks on the
        /// 	// send report button
        /// 	private void btnSubmit(object sender, EventArgs e)
        /// 	{
        /// 		var info = tbErrorDetails.Text;
        /// 		var email = tbEmail.Text;
        /// 
        /// 		// supplied info, attach it.
        /// 		if (!string.IsNullOrEmpty(info) || !string.IsNullOrEmpty(email))
        /// 		{
        /// 			OneTrue.SendReport(reportId, new UserSuppliedInformation(info, email));
        /// 		}
        /// 		else
        /// 		{
        /// 			// otherwise just send error and all contexts.
        /// 			OneTrue.SendReport(reportId);
        /// 		}
        /// 	}
        /// 
        /// 	private void btnCancel_Click(object sender, EventArgs e)
        /// 	{
        /// 		Close();
        /// 	}
        /// }
        /// </code>
        ///     <para>
        ///         Then configure OTE to use it:
        ///     </para>
        ///     <code>
        /// // don't forget to set the error reporter first.
        /// 
        /// Err.Configuration.CatchWinFormsExceptions();
        /// Err.Configuration.SetErrorForm(context => new CustomReportDialog() { reportId = context.reportId });
        /// </code>
        /// </example>
        public static void SetErrorForm(this CoderrConfiguration configurator,
            Func<FormFactoryContext, Form> formFactory)
        {
            if (configurator == null) throw new ArgumentNullException(nameof(configurator));
            WinFormsErrorReporter.FormFactory = formFactory ?? throw new ArgumentNullException(nameof(formFactory));
        }


        /// <summary>
        ///     Take a screen shot of every form that is opened when an error happen.
        /// </summary>
        /// <param name="configurator">OneTrueError configurator (accessed through <see cref="Err.Configuration" />).</param>
        public static void TakeScreenshotOfActiveFormOnly(this CoderrConfiguration configurator)
        {
            if (configurator == null) throw new ArgumentNullException(nameof(configurator));
            WinFormsErrorReporter.Activate();
            Err.Configuration.ContextProviders.Add(new ScreenshotProvider());
        }

        /// <summary>
        ///     Take a screen shot of every form that is opened when an error happen.
        /// </summary>
        /// <param name="configurator">OneTrueError configurator (accessed through <see cref="Err.Configuration" />).</param>
        public static void TakeScreenshots(this CoderrConfiguration configurator)
        {
            if (configurator == null) throw new ArgumentNullException(nameof(configurator));
            WinFormsErrorReporter.Activate();
            Err.Configuration.ContextProviders.Add(new ScreenshotProvider(true));
        }
    }
}