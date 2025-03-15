using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
     

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'okaiamfai123_DataSet2.CPU' table. You can move, or remove it, as needed.
            this.cPUTableAdapter1.Fill(this.okaiamfai123_DataSet2.CPU);
            //comboBox1.SelectedIndex = 0;
            // TODO: This line of code loads data into the 'okaiamfai123_DataSet1.Account' table. You can move, or remove it, as needed.
            this.accountTableAdapter.Fill(this.okaiamfai123_DataSet1.Account);
            // TODO: This line of code loads data into the 'okaiamfai123_DataSet.CPU' table. You can move, or remove it, as needed.
            //this.cPUTableAdapter.Fill(this.okaiamfai123_DataSet.CPU);
            List<CPU> cpus = new CpuBUS().GetAll();
            dgvCpu.DataSource = cpus;
            dgvCpu.Columns["Img"].Visible = false;
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnOpenFile.Visible = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            CPU newCpu = new CPU()
            {
                ID = int.Parse(textID.Text.Trim()),
                Name = textName.Text.Trim(),
                Series = textSeries.Text.Trim(),
                Generation = textGeneration.Text.Trim(),
                Prices = int.Parse(textPrices.Text.Trim()),
                Img = ConvertImageToBinary(pictureBox1.Image),
            };
       
            bool result = new CpuBUS().Update(newCpu);
            if (result)
            {
                List<CPU> cpus = new CpuBUS().GetAll();
                dgvCpu.DataSource = cpus;
            }
            else
            {
                MessageBox.Show("SORRY BABY!");
            }
            textName.ReadOnly = true;
            textGeneration.ReadOnly = true;
            textSeries.ReadOnly = true;
            textPrices.ReadOnly = true;
            urlImg.ReadOnly = true;

            btnUpdate.Visible = false;
            btnOpenFile.Visible = false;
            btnCancel.Visible = false;
            btnCreate.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CPU newCpu = new CPU()
            {
                ID = 0,
                Name = textName.Text.Trim(),
                Series = textSeries.Text.Trim(),
                Generation = textGeneration.Text.Trim(),
                Prices = int.Parse(textPrices.Text.Trim()),
                Img = ConvertImageToBinary(pictureBox1.Image),
            };
   
            bool result = new CpuBUS().AddNew(newCpu);
            if (result)
            {
                List<CPU> cpus = new CpuBUS().GetAll();
                dgvCpu.DataSource = cpus;
            }
            else { MessageBox.Show("SORRY BABY!");
            }
            textName.ReadOnly = true;
            textGeneration.ReadOnly = true;
            textSeries.ReadOnly = true;
            textPrices.ReadOnly = true;
            urlImg.ReadOnly = true;

            btnAdd.Visible = false;
            btnOpenFile.Visible = false;
            btnCancel.Visible = false;
            btnCreate.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = textKeyword.Text.Trim();
            List<CPU> cpus = new CpuBUS().Search(keyword);
            dgvCpu.DataSource = cpus;
        }



        private void dgvCpu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCpu.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgvCpu.SelectedRows[0].Cells["ID"].Value.ToString());
                CPU cpu = new CpuBUS().GetDetails(id);
                if (cpu != null)
                {
                    textID.Text = cpu.ID.ToString();
                    textName.Text = cpu.Name;
                    textSeries.Text = cpu.Series;
                    textGeneration.Text = cpu.Generation;
                    textPrices.Text = cpu.Prices.ToString();



                    Image img = ConvertBinaryToImage(cpu.Img);
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Refresh();
                    //ConvertImageToBinary(img);


                }
            }
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.accountTableAdapter.Fill(this.okaiamfai123_DataSet1.Account);
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.accountTableAdapter.FillBy(this.okaiamfai123_DataSet1.Account);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        string fileName;

        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnOpenFile_Click_1(object sender, EventArgs e)
        {
            //Read image file
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg|PNG|*.png", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    urlImg.Text = fileName;
                    Image img = Image.FromFile(fileName);
                    pictureBox1.Image = img;
                    //pictureBox1.Height = img.Height;
                    //pictureBox1.Width = img.Width;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Refresh();
                }
            }
        }

        private void dgvCpu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnOpenFile.Visible = true;
            btnCancel.Visible = true;
            btnCreate.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;

            textName.ReadOnly = false;
            textGeneration.ReadOnly = false;
            textSeries.ReadOnly = false;
            textPrices.ReadOnly = false;
            urlImg.ReadOnly = false;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnOpenFile.Visible = true;
            btnCancel.Visible = true;
            btnCreate.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;

            textName.ReadOnly = false;
            textGeneration.ReadOnly = false;
            textSeries.ReadOnly = false;
            textPrices.ReadOnly = false;
            urlImg.ReadOnly = false;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Muon xoa?", "Xoa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int id = int.Parse(textID.Text);
                bool result = new CpuBUS().Delete(id);
                if (result)
                {
                    List<CPU> cpus = new CpuBUS().GetAll();
                    dgvCpu.DataSource = cpus;
                }
                else { MessageBox.Show("Khong the xoa!"); }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textName.ReadOnly = true;
            textGeneration.ReadOnly = true;
            textSeries.ReadOnly = true;
            textPrices.ReadOnly = true;
            urlImg.ReadOnly = true;

            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnOpenFile.Visible = false;
            btnCancel.Visible = false;
            btnCreate.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}