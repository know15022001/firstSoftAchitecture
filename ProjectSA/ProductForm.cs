using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSA
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            List<Product> products = new ProductBUS().GetAll();
            dgvProduct.DataSource = products;

        }

        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0)
            {
                int Code = int.Parse(dgvProduct.SelectedRows[0].Cells["Code"].Value.ToString());
                Product product = new ProductBUS().GetDetails(Code);
                if (product != null)
                {
                    txtCode.Text = product.Code.ToString();
                    txtName.Text = product.Name;
                    txtBrand.Text = product.Brand;
                    txtBrandCode.Text = product.BrandCode;
                    txtCategory.Text = product.Category;
                    txtCategoryCode.Text = product.CategoryCode;
                    txtPrice.Text = product.Price.ToString();
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
            List<Product> products = new ProductBUS().Search(keyword);
            dgvProduct.DataSource = products;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product()
            {
                Code = 0,
                Name = txtName.Text.Trim(),
                Brand = txtBrand.Text.Trim(),
                BrandCode = txtBrandCode.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                CategoryCode = txtCategoryCode.Text.Trim(),
                Price = int.Parse(txtPrice.Text.Trim())

            };
            bool result = new ProductBUS().AddNew(newProduct);
            if (result)
            {
                List<Product> products = new ProductBUS().GetAll();
                dgvProduct.DataSource = products;
            }
            else { MessageBox.Show("SORRY !"); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product()
            {
                Code = int.Parse(txtCode.Text.Trim()),
                Name = txtName.Text.Trim(),
                Brand = txtBrand.Text.Trim(),
                BrandCode = txtBrandCode.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                CategoryCode = txtCategoryCode.Text.Trim(),
                Price = int.Parse(txtPrice.Text.Trim())
            };
            bool result = new ProductBUS().Update(newProduct);
            if (result)
            {
                List<Product> products = new ProductBUS().GetAll();
                dgvProduct.DataSource = products;
            }
            else { MessageBox.Show("SORRY !"); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE ?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                int Code = int.Parse(txtCode.Text);
                bool result = new ProductBUS().Delete(Code);
                if (result)
                {
                    List<Product> products = new ProductBUS().GetAll();
                    dgvProduct.DataSource = products;
                }
                else
                {
                    MessageBox.Show("SORRY !");
                }
            }
        }
    }
}
        

