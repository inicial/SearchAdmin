namespace CruiseSearchAdmin.Forms
{
    partial class FormSeaPortAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeaPortAdd));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbItemRegion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbItemCrLine = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteParent = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbParent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tbName_ru = new System.Windows.Forms.TextBox();
            this.tbOK = new System.Windows.Forms.Button();
            this.tbCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbname_en = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tbname_en);
            this.groupBox3.Controls.Add(this.cbItemRegion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbItemCrLine);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbCode);
            this.groupBox3.Controls.Add(this.tbName_ru);
            this.groupBox3.Location = new System.Drawing.Point(3, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 375);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информация о порте";
            // 
            // cbItemRegion
            // 
            this.cbItemRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemRegion.FormattingEnabled = true;
            this.cbItemRegion.Location = new System.Drawing.Point(17, 213);
            this.cbItemRegion.Name = "cbItemRegion";
            this.cbItemRegion.Size = new System.Drawing.Size(233, 21);
            this.cbItemRegion.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Регион";
            // 
            // cbItemCrLine
            // 
            this.cbItemCrLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemCrLine.FormattingEnabled = true;
            this.cbItemCrLine.Location = new System.Drawing.Point(20, 129);
            this.cbItemCrLine.Name = "cbItemCrLine";
            this.cbItemCrLine.Size = new System.Drawing.Size(233, 21);
            this.cbItemCrLine.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeleteParent);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.tbParent);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, 291);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(252, 81);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Главный порт";
            // 
            // btnDeleteParent
            // 
            this.btnDeleteParent.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnDeleteParent.Location = new System.Drawing.Point(193, 46);
            this.btnDeleteParent.Name = "btnDeleteParent";
            this.btnDeleteParent.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteParent.TabIndex = 9;
            this.btnDeleteParent.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::CruiseSearchAdmin.Properties.Resources.tag_blue_edit;
            this.button1.Location = new System.Drawing.Point(223, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 22);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbParent
            // 
            this.tbParent.Location = new System.Drawing.Point(6, 20);
            this.tbParent.Name = "tbParent";
            this.tbParent.ReadOnly = true;
            this.tbParent.Size = new System.Drawing.Size(246, 20);
            this.tbParent.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Код";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Компания";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Название русское";
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(20, 171);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(111, 20);
            this.tbCode.TabIndex = 2;
            // 
            // tbName_ru
            // 
            this.tbName_ru.Location = new System.Drawing.Point(21, 47);
            this.tbName_ru.Name = "tbName_ru";
            this.tbName_ru.Size = new System.Drawing.Size(233, 20);
            this.tbName_ru.TabIndex = 0;
            // 
            // tbOK
            // 
            this.tbOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOK.Location = new System.Drawing.Point(186, 391);
            this.tbOK.Name = "tbOK";
            this.tbOK.Size = new System.Drawing.Size(75, 30);
            this.tbOK.TabIndex = 7;
            this.tbOK.Text = "OK";
            this.tbOK.UseVisualStyleBackColor = true;
            this.tbOK.Click += new System.EventHandler(this.tbOK_Click);
            // 
            // tbCancel
            // 
            this.tbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCancel.Location = new System.Drawing.Point(102, 391);
            this.tbCancel.Name = "tbCancel";
            this.tbCancel.Size = new System.Drawing.Size(75, 30);
            this.tbCancel.TabIndex = 8;
            this.tbCancel.Text = "Отмена";
            this.tbCancel.UseVisualStyleBackColor = true;
            this.tbCancel.Click += new System.EventHandler(this.tbCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Название английское";
            // 
            // tbname_en
            // 
            this.tbname_en.Location = new System.Drawing.Point(18, 88);
            this.tbname_en.Name = "tbname_en";
            this.tbname_en.Size = new System.Drawing.Size(233, 20);
            this.tbname_en.TabIndex = 14;
            // 
            // FormSeaPortAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 433);
            this.Controls.Add(this.tbCancel);
            this.Controls.Add(this.tbOK);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSeaPortAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить порт";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbItemRegion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbItemCrLine;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDeleteParent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbParent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TextBox tbName_ru;
        private System.Windows.Forms.Button tbOK;
        private System.Windows.Forms.Button tbCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbname_en;
    }
}