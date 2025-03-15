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
    public partial class BrandForm : Form
    {
        public BrandForm()
        {
            InitializeComponent();
        }

        private void BrandForm_Load(object sender, EventArgs e)
        {
            List<Brand> brands = new BrandBUS().GetAll();
            dgvBrand.DataSource = brands;
        }

        private void dgvBrand_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBrand.SelectedRows.Count > 0)
            {
                string Code = dgvBrand.SelectedRows[0].Cells["Code"].Value.ToString();
                Brand brand = new BrandBUS().GetDetails(Code);
                if (brand != null)
                {
                    txtCode.Text = brand.Code;
                    txtName.Text = brand.Name;
                   txtCountry.Text = brand.Country;
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            new SelectForm().Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<Brand> brands = new BrandBUS().Search(keyword);
            dgvBrand.DataSource = brands;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Brand newBrand = new Brand()
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Country = txtCountry.Text.Trim(),
            };
            bool result = new BrandBUS().AddNew(newBrand);
            if (result)
            {
                List<Brand> brands = new BrandBUS().GetAll();
                dgvBrand.DataSource = brands;
            }
            else { MessageBox.Show("SORRY !"); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Brand newBrand = new Brand()
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Country = txtCountry.Text.Trim(),
            };
            bool result = new BrandBUS().Update(newBrand);
            if (result)
            {
                List<Brand> brands = new BrandBUS().GetAll();
                dgvBrand.DataSource = brands;
            }
            else { MessageBox.Show("SORRY !"); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE ?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                string Code = txtCode.Text;
                bool result = new BrandBUS().Delete(Code);
                if (result)
                {
                    List<Brand> brands = new BrandBUS().GetAll();
                    dgvBrand.DataSource = brands;
                }
                else
                {
                    MessageBox.Show("SORRY !");
                }
            }
        }
    }
}
