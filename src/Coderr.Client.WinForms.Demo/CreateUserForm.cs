using System;
using System.Data;
using System.Windows.Forms;

namespace Coderr.Client.WinForms.Demo
{
    public partial class CreateUserForm : Form
    {
        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void OnSaveButton(object sender, EventArgs e)
        {
            SomeOperation();
        }

        private void SomeOperation()
        {
            //Press F5 if Visual Studio breaks here ("First chance exceptions")
            throw new DataException("Failed to save user");
        }
    }
}