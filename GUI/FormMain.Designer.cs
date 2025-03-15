namespace WindowsFormsApp1.GUI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCpu = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.btnCus = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCus);
            this.panel1.Controls.Add(this.btnBill);
            this.panel1.Controls.Add(this.btnCpu);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 85);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Location = new System.Drawing.Point(1, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 419);
            this.panel2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Ravie", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(24, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 70);
            this.label7.TabIndex = 22;
            this.label7.Text = "HELLO\r\n CPU\r\n";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnCpu
            // 
            this.btnCpu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCpu.BackgroundImage")));
            this.btnCpu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCpu.Location = new System.Drawing.Point(187, 12);
            this.btnCpu.Name = "btnCpu";
            this.btnCpu.Size = new System.Drawing.Size(85, 60);
            this.btnCpu.TabIndex = 23;
            this.btnCpu.UseVisualStyleBackColor = true;
            this.btnCpu.Click += new System.EventHandler(this.btnCpu_Click);
            // 
            // btnBill
            // 
            this.btnBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBill.BackgroundImage")));
            this.btnBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBill.Location = new System.Drawing.Point(332, 13);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(79, 60);
            this.btnBill.TabIndex = 24;
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // btnCus
            // 
            this.btnCus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCus.BackgroundImage")));
            this.btnCus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCus.Location = new System.Drawing.Point(466, 12);
            this.btnCus.Name = "btnCus";
            this.btnCus.Size = new System.Drawing.Size(74, 60);
            this.btnCus.TabIndex = 25;
            this.btnCus.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(849, 509);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCus;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button btnCpu;
    }
}