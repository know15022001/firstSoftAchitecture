using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;

namespace WindowsFormsApp1.GUI
{
    public partial class FormBill : Form
    {
        public FormBill()
        {
            InitializeComponent();
            LoadCategory();
            //LoadCbbTable(cbbCBan);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormBill_Load(object sender, EventArgs e)
        {

        }

        private void lvBill_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        
        #region LoadCategory_Product
        void LoadCategory()
        {
            List<CPU> cpus = new CpuBUS().GetAll();
            cbbProduct.DataSource = cpus;
            cbbProduct.DisplayMember = "Name";
        }

        void ProductListCategoryID(int id)
        {
            
        }
        #endregion

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
         
                

            
        }

        private void btThemMon_Click(object sender, EventArgs e)
        {
            object b = cbbProduct.SelectedItem;
            string be = Convert.ToString(b);
            ListViewItem item = new ListViewItem();
            String name = be;
            String num = nmCount.ToString();
            //String price = ;
            string allprice = cbbProduct.Name;
            lvBill.Items.Add(item);

       
            ListViewItem.ListViewSubItem numitem = new ListViewItem.ListViewSubItem(item, (nmCount.Text));
            item.SubItems.Add(numitem);
            ListViewItem.ListViewSubItem priceitem = new ListViewItem.ListViewSubItem(item, (name.ToString()));
            item.SubItems.Add(priceitem);

            
        }

        private void cbbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
