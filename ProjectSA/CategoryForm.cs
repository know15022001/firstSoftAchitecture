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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            List<Category> categories = new CategoryBUS().GetAll();
            dgvCategory.DataSource = categories;
        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                string Code = dgvCategory.SelectedRows[0].Cells["Code"].Value.ToString();
                Category category = new CategoryBUS().GetDetails(Code);
                if (category != null)
                {
                    txtCode.Text = category.Code;
                    txtName.Text = category.Name;
                    
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
            List<Category> categories = new CategoryBUS().Search(keyword);
            dgvCategory.DataSource = categories;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category newCategory = new Category()
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
             
            };
            bool result = new CategoryBUS().AddNew(newCategory);
            if (result)
            {
                List<Category> categories = new CategoryBUS().GetAll();
                dgvCategory.DataSource = categories;
            }
            else { MessageBox.Show("SORRY !"); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Category newCategory = new Category()
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
               
            };
            bool result = new CategoryBUS().Update(newCategory);
            if (result)
            {
                List<Category> categories = new CategoryBUS().GetAll();
                dgvCategory.DataSource = categories;
            }
            else { MessageBox.Show("SORRY !"); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE ?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                string Code = txtCode.Text;
                bool result = new CategoryBUS().Delete(Code);
                if (result)
                {
                    List<Category> categories = new CategoryBUS().GetAll();
                    dgvCategory.DataSource = categories;
                }
                else
                {
                    MessageBox.Show("SORRY !");
                }
            }
        }
    }
}
