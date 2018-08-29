using System;
using System.Threading;
using System.Windows.Forms;
using Coderr.Client;

namespace Coderr.Client.WinForms
{
    /// <summary>
    ///     Class that processes unhandled exceptions that WinForms/WPF applications throw.
    /// </summary>
    public class WinFormsErrorReporter
    {
        private static readonly WinFormsErrorReporter _instance = new WinFormsErrorReporter();

        private static bool _activated;

        static WinFormsErrorReporter()
        {
            FormFactory =
                model =>
                    new ReportDialog(model.Report) {ExceptionMessage = model.Context.Exception.Message};
        }

        internal static Func<FormFactoryContext, Form> FormFactory { get; set; }

        /// <summary>
        ///     Activate this library.
        /// </summary>
        public static void Activate()
        {
            if (_activated)
                return;


            _activated = true;

            Application.ThreadException += OnException;
        }

        private static void OnException(object sender, ThreadExceptionEventArgs e)
        {
            var context = new WinformsErrorReportContext(_instance, e.Exception);

            var dto = Err.GenerateReport(context);
            if (!Err.Configuration.UserInteraction.AskUserForDetails
                && !Err.Configuration.UserInteraction.AskForEmailAddress
                && !Err.Configuration.UserInteraction.AskUserForPermission)
            {
                Err.UploadReport(dto);
                return;
            }

            if (!Err.Configuration.UserInteraction.AskUserForPermission)
                Err.UploadReport(dto);

            var ctx = new FormFactoryContext {Context = context, Report = dto};
            var dialog = FormFactory(ctx);
            dialog.ShowDialog();
        }
    }
}