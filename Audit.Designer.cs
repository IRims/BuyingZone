
namespace TheBuyingZone
{
    partial class Audit
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
            this.DgshipperAudit = new System.Windows.Forms.DataGridView();
            this.PnlshipperLog = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HeaderLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnShiping = new System.Windows.Forms.Button();
            this.STIDLBL = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Stlbl = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BillingBtn = new System.Windows.Forms.Button();
            this.custCb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgshipperAudit)).BeginInit();
            this.PnlshipperLog.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // DgshipperAudit
            // 
            this.DgshipperAudit.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DgshipperAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgshipperAudit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgshipperAudit.Location = new System.Drawing.Point(34, 144);
            this.DgshipperAudit.Name = "DgshipperAudit";
            this.DgshipperAudit.Size = new System.Drawing.Size(680, 360);
            this.DgshipperAudit.TabIndex = 25;
            // 
            // PnlshipperLog
            // 
            this.PnlshipperLog.BackColor = System.Drawing.Color.LightGray;
            this.PnlshipperLog.Controls.Add(this.custCb);
            this.PnlshipperLog.Controls.Add(this.panel5);
            this.PnlshipperLog.Controls.Add(this.DgshipperAudit);
            this.PnlshipperLog.Location = new System.Drawing.Point(151, -2);
            this.PnlshipperLog.Name = "PnlshipperLog";
            this.PnlshipperLog.Size = new System.Drawing.Size(763, 543);
            this.PnlshipperLog.TabIndex = 42;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.HeaderLbl);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(763, 55);
            this.panel5.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::TheBuyingZone.Properties.Resources.close_W_;
            this.pictureBox1.Location = new System.Drawing.Point(727, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // HeaderLbl
            // 
            this.HeaderLbl.AutoSize = true;
            this.HeaderLbl.BackColor = System.Drawing.Color.Black;
            this.HeaderLbl.Font = new System.Drawing.Font("Vivaldi", 29F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.HeaderLbl.ForeColor = System.Drawing.Color.Snow;
            this.HeaderLbl.Location = new System.Drawing.Point(268, 9);
            this.HeaderLbl.Name = "HeaderLbl";
            this.HeaderLbl.Size = new System.Drawing.Size(233, 46);
            this.HeaderLbl.TabIndex = 14;
            this.HeaderLbl.Text = "Billing_Audit";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.BtnShiping);
            this.panel2.Controls.Add(this.STIDLBL);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.Stlbl);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.BillingBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 540);
            this.panel2.TabIndex = 43;
            // 
            // BtnShiping
            // 
            this.BtnShiping.BackColor = System.Drawing.Color.Gray;
            this.BtnShiping.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShiping.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShiping.ForeColor = System.Drawing.Color.Black;
            this.BtnShiping.Location = new System.Drawing.Point(0, 284);
            this.BtnShiping.Name = "BtnShiping";
            this.BtnShiping.Size = new System.Drawing.Size(153, 52);
            this.BtnShiping.TabIndex = 23;
            this.BtnShiping.Text = "Shipping Info";
            this.BtnShiping.UseVisualStyleBackColor = false;
            this.BtnShiping.Click += new System.EventHandler(this.BtnShiping_Click);
            // 
            // STIDLBL
            // 
            this.STIDLBL.AutoSize = true;
            this.STIDLBL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.STIDLBL.Location = new System.Drawing.Point(3, 104);
            this.STIDLBL.Name = "STIDLBL";
            this.STIDLBL.Size = new System.Drawing.Size(91, 22);
            this.STIDLBL.TabIndex = 21;
            this.STIDLBL.Text = "Staff Id  : ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TheBuyingZone.Properties.Resources.person_icon_1694;
            this.pictureBox3.Location = new System.Drawing.Point(12, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(120, 93);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // Stlbl
            // 
            this.Stlbl.AutoSize = true;
            this.Stlbl.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.Stlbl.Location = new System.Drawing.Point(100, 104);
            this.Stlbl.Name = "Stlbl";
            this.Stlbl.Size = new System.Drawing.Size(20, 22);
            this.Stlbl.TabIndex = 19;
            this.Stlbl.Text = "0";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Gray;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(0, 234);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(153, 54);
            this.button5.TabIndex = 18;
            this.button5.Text = "Shippers logs";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gray;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(0, 179);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(153, 54);
            this.button4.TabIndex = 17;
            this.button4.Text = "Manage Shippers";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(0, 500);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 40);
            this.button2.TabIndex = 16;
            this.button2.Text = "Log Out";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BillingBtn
            // 
            this.BillingBtn.BackColor = System.Drawing.Color.Gray;
            this.BillingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BillingBtn.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillingBtn.ForeColor = System.Drawing.Color.Black;
            this.BillingBtn.Location = new System.Drawing.Point(0, 127);
            this.BillingBtn.Name = "BillingBtn";
            this.BillingBtn.Size = new System.Drawing.Size(153, 53);
            this.BillingBtn.TabIndex = 6;
            this.BillingBtn.Text = "Billing";
            this.BillingBtn.UseVisualStyleBackColor = false;
            this.BillingBtn.Click += new System.EventHandler(this.BillingBtn_Click);
            // 
            // custCb
            // 
            this.custCb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custCb.ForeColor = System.Drawing.Color.Black;
            this.custCb.FormattingEnabled = true;
            this.custCb.Items.AddRange(new object[] {
            "View Orders",
            "View Shippers logs"});
            this.custCb.Location = new System.Drawing.Point(249, 77);
            this.custCb.Name = "custCb";
            this.custCb.Size = new System.Drawing.Size(252, 27);
            this.custCb.TabIndex = 43;
            this.custCb.SelectedValueChanged += new System.EventHandler(this.custCb_SelectedValueChanged);
            // 
            // Audit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 540);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PnlshipperLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Audit";
            this.Text = "Audit";
            ((System.ComponentModel.ISupportInitialize)(this.DgshipperAudit)).EndInit();
            this.PnlshipperLog.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgshipperAudit;
        private System.Windows.Forms.Panel PnlshipperLog;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label HeaderLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label STIDLBL;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label Stlbl;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BillingBtn;
        private System.Windows.Forms.Button BtnShiping;
        private System.Windows.Forms.ComboBox custCb;
    }
}