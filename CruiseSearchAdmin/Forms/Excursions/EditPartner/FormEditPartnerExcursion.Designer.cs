namespace CruiseSearchAdmin.Forms.Excursions
{
    partial class FormEditPartnerExcursion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditPartnerExcursion));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnChangePartner = new System.Windows.Forms.Button();
            this.tbPartner = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCruiseLine = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbExcursions = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChangePort = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnServices = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(137, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(218, 319);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnChangePartner);
            this.groupBox5.Controls.Add(this.tbPartner);
            this.groupBox5.Location = new System.Drawing.Point(10, 189);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(283, 79);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Партнер";
            // 
            // btnChangePartner
            // 
            this.btnChangePartner.Location = new System.Drawing.Point(194, 45);
            this.btnChangePartner.Name = "btnChangePartner";
            this.btnChangePartner.Size = new System.Drawing.Size(78, 23);
            this.btnChangePartner.TabIndex = 1;
            this.btnChangePartner.Text = "Изменить";
            this.btnChangePartner.UseVisualStyleBackColor = true;
            this.btnChangePartner.Click += new System.EventHandler(this.btnChangePartner_Click);
            // 
            // tbPartner
            // 
            this.tbPartner.Location = new System.Drawing.Point(5, 19);
            this.tbPartner.Name = "tbPartner";
            this.tbPartner.ReadOnly = true;
            this.tbPartner.Size = new System.Drawing.Size(273, 20);
            this.tbPartner.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbCruiseLine);
            this.groupBox3.Location = new System.Drawing.Point(10, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 61);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Круизная компания";
            // 
            // cbCruiseLine
            // 
            this.cbCruiseLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCruiseLine.FormattingEnabled = true;
            this.cbCruiseLine.Location = new System.Drawing.Point(5, 23);
            this.cbCruiseLine.Name = "cbCruiseLine";
            this.cbCruiseLine.Size = new System.Drawing.Size(273, 21);
            this.cbCruiseLine.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbExcursions);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Экскурсия";
            // 
            // cbExcursions
            // 
            this.cbExcursions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExcursions.FormattingEnabled = true;
            this.cbExcursions.Location = new System.Drawing.Point(5, 73);
            this.cbExcursions.Name = "cbExcursions";
            this.cbExcursions.Size = new System.Drawing.Size(273, 21);
            this.cbExcursions.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChangePort);
            this.groupBox2.Controls.Add(this.tbPort);
            this.groupBox2.Location = new System.Drawing.Point(5, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 48);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Порт";
            // 
            // btnChangePort
            // 
            this.btnChangePort.Location = new System.Drawing.Point(189, 16);
            this.btnChangePort.Name = "btnChangePort";
            this.btnChangePort.Size = new System.Drawing.Size(78, 23);
            this.btnChangePort.TabIndex = 1;
            this.btnChangePort.Text = "Изменить";
            this.btnChangePort.UseVisualStyleBackColor = true;
            this.btnChangePort.Click += new System.EventHandler(this.btnChangePort_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(5, 19);
            this.tbPort.Name = "tbPort";
            this.tbPort.ReadOnly = true;
            this.tbPort.Size = new System.Drawing.Size(178, 20);
            this.tbPort.TabIndex = 0;
            // 
            // btnServices
            // 
            this.btnServices.Location = new System.Drawing.Point(10, 274);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(283, 30);
            this.btnServices.TabIndex = 6;
            this.btnServices.Text = "Задать услуги";
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // FormEditPartnerExcursion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 358);
            this.Controls.Add(this.btnServices);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditPartnerExcursion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование экскурсии от партнера";
            this.Load += new System.EventHandler(this.FormEditPartnerExcursion_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbExcursions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChangePort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbCruiseLine;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChangePartner;
        private System.Windows.Forms.TextBox tbPartner;
        private System.Windows.Forms.Button btnServices;
    }
}