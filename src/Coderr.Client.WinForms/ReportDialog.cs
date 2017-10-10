using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using codeRR.Client.ContextCollections;
using codeRR.Client.Contracts;

namespace codeRR.Client.WinForms
{
    /// <summary>
    ///     Default dialog which is shown when an error has been caught
    /// </summary>
    public partial class ReportDialog : Form
    {
        private readonly ErrorReportDTO _dto;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReportDialog" /> class.
        /// </summary>
        public ReportDialog(ErrorReportDTO dto)
        {
            _dto = dto ?? throw new ArgumentNullException(nameof(dto));

            InitializeComponent();

            var img = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(GetType().Namespace + ".Resources.nomorelogs.jpg");
            pictureBox1.Image = Image.FromStream(img);

            if (!Err.Configuration.UserInteraction.AskUserForDetails)
            {
                controlsPanel.Controls.Remove(errorDescription1);
            }
            if (!Err.Configuration.UserInteraction.AskForEmailAddress)
            {
                controlsPanel.Controls.Remove(notificationControl1);
            }
            if (!Err.Configuration.UserInteraction.AskUserForPermission)
            {
                btnCancel.Hide();
            }

            var height = CalculateFormHeight();
            Height = height;
            if (controlsPanel.Controls.Count == 2)
                Width = 550;
        }

        /// <summary>
        ///     Exception message
        /// </summary>
        public string ExceptionMessage
        {
            set { lblErrorMessage.Text = value; }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            var info = errorDescription1.UserInfo;
            var email = notificationControl1.Email;

            // only upload it if the flag is set, it have already been uploaded otherwise.
            if (Err.Configuration.UserInteraction.AskUserForPermission)
                Err.UploadReport(_dto);

            if (!string.IsNullOrEmpty(info) || !string.IsNullOrEmpty(email))
            {
                Err.LeaveFeedback(_dto.ReportId, new UserSuppliedInformation(info, email));
            }

            Close();
        }

        private int CalculateFormHeight()
        {
            var height = 0;
            foreach (Control control in controlsPanel.Controls)
            {
                height += control.Height;
            }
            height += panel1.Height;
            height += 100;
            return height;
        }

        private void ErrorDescription1_Load(object sender, EventArgs e)
        {
        }
        

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }


        private void ReportDialog_Load(object sender, EventArgs e)
        {
        }
    }
}