using System.Windows.Forms;
using Coderr.Client.ContextCollections;

namespace Coderr.Client.WinForms.Demo
{
    public partial class CustomErrorDialog : Form
    {
        private readonly FormFactoryContext _context;

        public CustomErrorDialog(FormFactoryContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void CustomErrorDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Err.LeaveFeedback(_context.Report.ReportId, textBox1.Text, null);
        }
    }
}