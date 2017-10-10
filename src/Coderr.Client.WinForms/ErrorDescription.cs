using System.Windows.Forms;

namespace codeRR.Client.WinForms
{
    internal partial class ErrorDescription : UserControl
    {
        public ErrorDescription()
        {
            InitializeComponent();
        }

        public string UserInfo
        {
            get { return feedback2.Text; }
        }
    }
}