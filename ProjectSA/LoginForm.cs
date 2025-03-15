using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Account account = new Account()
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };
            bool result = new AccountBUS().CheckAccount(account);
            if (result)
            {
                new SelectForm().Show();
                this.Hide();
            }
            else { MessageBox.Show("SORRY BABY!"); }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Account newAccount = new Account()
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };
            bool result = new AccountBUS().AddNew(newAccount);
            if (result) MessageBox.Show("OK !");
            else MessageBox.Show("SORRY !");
        }
    }
}
