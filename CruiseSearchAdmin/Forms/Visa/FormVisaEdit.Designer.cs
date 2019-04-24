namespace CruiseSearchAdmin.Forms.Visa
{
    partial class FormVisaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVisaEdit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCountryFiltr = new System.Windows.Forms.TextBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.chbShengen = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPartnerFiltr = new System.Windows.Forms.TextBox();
            this.cbPartner = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbServiceFiltr = new System.Windows.Forms.TextBox();
            this.cbService = new System.Windows.Forms.ComboBox();
            this.chbUnuse = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbCruiseLines = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCountryFiltr);
            this.groupBox1.Controls.Add(this.cbCountry);
            this.groupBox1.Controls.Add(this.chbShengen);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Страна";
            // 
            // tbCountryFiltr
            // 
            this.tbCountryFiltr.Location = new System.Drawing.Point(77, 11);
            this.tbCountryFiltr.Name = "tbCountryFiltr";
            this.tbCountryFiltr.Size = new System.Drawing.Size(196, 20);
            this.tbCountryFiltr.TabIndex = 7;
            this.tbCountryFiltr.TextChanged += new System.EventHandler(this.tbCountryFiltr_TextChanged);
            // 
            // cbCountry
            // 
            this.cbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(5, 37);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(268, 21);
            this.cbCountry.TabIndex = 4;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // chbShengen
            // 
            this.chbShengen.AutoSize = true;
            this.chbShengen.Location = new System.Drawing.Point(5, 64);
            this.chbShengen.Name = "chbShengen";
            this.chbShengen.Size = new System.Drawing.Size(64, 17);
            this.chbShengen.TabIndex = 3;
            this.chbShengen.Text = "Шенген";
            this.chbShengen.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPartnerFiltr);
            this.groupBox2.Controls.Add(this.cbPartner);
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 77);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Партнер";
            // 
            // tbPartnerFiltr
            // 
            this.tbPartnerFiltr.Location = new System.Drawing.Point(77, 19);
            this.tbPartnerFiltr.Name = "tbPartnerFiltr";
            this.tbPartnerFiltr.Size = new System.Drawing.Size(196, 20);
            this.tbPartnerFiltr.TabIndex = 6;
            this.tbPartnerFiltr.TextChanged += new System.EventHandler(this.tbPartnerFiltr_TextChanged);
            // 
            // cbPartner
            // 
            this.cbPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPartner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartner.FormattingEnabled = true;
            this.cbPartner.Location = new System.Drawing.Point(5, 45);
            this.cbPartner.Name = "cbPartner";
            this.cbPartner.Size = new System.Drawing.Size(268, 21);
            this.cbPartner.TabIndex = 5;
            this.cbPartner.SelectedIndexChanged += new System.EventHandler(this.cbPartner_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbServiceFiltr);
            this.groupBox3.Controls.Add(this.cbService);
            this.groupBox3.Location = new System.Drawing.Point(12, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 77);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Услуга";
            // 
            // tbServiceFiltr
            // 
            this.tbServiceFiltr.Location = new System.Drawing.Point(77, 19);
            this.tbServiceFiltr.Name = "tbServiceFiltr";
            this.tbServiceFiltr.Size = new System.Drawing.Size(196, 20);
            this.tbServiceFiltr.TabIndex = 7;
            this.tbServiceFiltr.TextChanged += new System.EventHandler(this.tbServiceFiltr_TextChanged);
            // 
            // cbService
            // 
            this.cbService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbService.FormattingEnabled = true;
            this.cbService.Location = new System.Drawing.Point(5, 45);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(268, 21);
            this.cbService.TabIndex = 5;
            this.cbService.SelectedIndexChanged += new System.EventHandler(this.cbService_SelectedIndexChanged);
            // 
            // chbUnuse
            // 
            this.chbUnuse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbUnuse.AutoSize = true;
            this.chbUnuse.Location = new System.Drawing.Point(209, 337);
            this.chbUnuse.Name = "chbUnuse";
            this.chbUnuse.Size = new System.Drawing.Size(81, 17);
            this.chbUnuse.TabIndex = 4;
            this.chbUnuse.Text = "Отключить";
            this.chbUnuse.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(215, 360);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(132, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbCruiseLines);
            this.groupBox4.Location = new System.Drawing.Point(12, 275);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 54);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Круизная компания";
            // 
            // cbCruiseLines
            // 
            this.cbCruiseLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCruiseLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCruiseLines.FormattingEnabled = true;
            this.cbCruiseLines.Location = new System.Drawing.Point(6, 19);
            this.cbCruiseLines.Name = "cbCruiseLines";
            this.cbCruiseLines.Size = new System.Drawing.Size(268, 21);
            this.cbCruiseLines.TabIndex = 5;
            // 
            // FormVisaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 395);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chbUnuse);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVisaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование визы";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.CheckBox chbShengen;
        private System.Windows.Forms.ComboBox cbPartner;
        private System.Windows.Forms.ComboBox cbService;
        private System.Windows.Forms.CheckBox chbUnuse;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbCountryFiltr;
        private System.Windows.Forms.TextBox tbPartnerFiltr;
        private System.Windows.Forms.TextBox tbServiceFiltr;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbCruiseLines;
    }
}