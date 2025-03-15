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
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            new ProductForm().Show();
            this.Hide();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            new CategoryForm().Show();
            this.Hide();
        }

        private void SelectForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            new BrandForm().Show();
            this.Hide();
        }
    }
}
