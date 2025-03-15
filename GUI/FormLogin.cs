using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.BUS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace WindowsFormsApp1.GUI
{
    public partial class FormLogin : Form
    {
        public static string userame = "";
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            Application.Exit();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_AuthoLogin";
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Connection = con;
                userame = txtUsername.Text;
                object kq = cmd.ExecuteScalar();
                int code = Convert.ToInt32(kq);
                 if (code == 1)
                {
                    MessageBox.Show("Chào mừng Admin đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormMain main = new FormMain();
                    this.Hide();
                    main.ShowDialog();
                }
                 else if (code == 2)
                {
                    MessageBox.Show("Chào mừng User đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormMain main = new FormMain();
                    this.Hide();
                    main.ShowDialog();
                }
                else if (code == 3)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    txtUsername.Focus();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    txtUsername.Focus();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cb_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_pass.Checked)
            {
                txtPassword.PasswordChar = (char)0;
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
    
}
