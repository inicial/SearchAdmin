namespace CruiseSearchAdmin.Forms.CruiseSearchSettings
{
    partial class FormCruiseSearchSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCruiseSearchSettings));
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.lbSettings = new System.Windows.Forms.ListBox();
            this.gbEdit = new System.Windows.Forms.GroupBox();
            this.btnSqlQueryEdit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbValues = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbParamName = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbSettings.SuspendLayout();
            this.gbEdit.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.lbSettings);
            this.gbSettings.Location = new System.Drawing.Point(12, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(251, 242);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Список настроек";
            // 
            // lbSettings
            // 
            this.lbSettings.FormattingEnabled = true;
            this.lbSettings.ItemHeight = 15;
            this.lbSettings.Location = new System.Drawing.Point(6, 20);
            this.lbSettings.Name = "lbSettings";
            this.lbSettings.Size = new System.Drawing.Size(239, 214);
            this.lbSettings.TabIndex = 0;
            this.lbSettings.SelectedIndexChanged += new System.EventHandler(this.lbSettings_SelectedIndexChanged);
            // 
            // gbEdit
            // 
            this.gbEdit.Controls.Add(this.btnSqlQueryEdit);
            this.gbEdit.Controls.Add(this.groupBox2);
            this.gbEdit.Controls.Add(this.groupBox1);
            this.gbEdit.Controls.Add(this.btnApply);
            this.gbEdit.Location = new System.Drawing.Point(269, 12);
            this.gbEdit.Name = "gbEdit";
            this.gbEdit.Size = new System.Drawing.Size(291, 242);
            this.gbEdit.TabIndex = 1;
            this.gbEdit.TabStop = false;
            this.gbEdit.Text = "Редактирование";
            // 
            // btnSqlQueryEdit
            // 
            this.btnSqlQueryEdit.Location = new System.Drawing.Point(6, 208);
            this.btnSqlQueryEdit.Name = "btnSqlQueryEdit";
            this.btnSqlQueryEdit.Size = new System.Drawing.Size(85, 30);
            this.btnSqlQueryEdit.TabIndex = 3;
            this.btnSqlQueryEdit.Text = "SQL Запрос";
            this.btnSqlQueryEdit.UseVisualStyleBackColor = true;
            this.btnSqlQueryEdit.Click += new System.EventHandler(this.btnSqlQueryEdit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbValues);
            this.groupBox2.Location = new System.Drawing.Point(6, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 61);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Значение";
            // 
            // cbValues
            // 
            this.cbValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValues.FormattingEnabled = true;
            this.cbValues.Location = new System.Drawing.Point(6, 20);
            this.cbValues.Name = "cbValues";
            this.cbValues.Size = new System.Drawing.Size(267, 23);
            this.cbValues.TabIndex = 0;
            this.cbValues.SelectedIndexChanged += new System.EventHandler(this.cbValues_SelectedIndexChanged);
            this.cbValues.SelectionChangeCommitted += new System.EventHandler(this.cbValues_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbParamName);
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название";
            // 
            // tbParamName
            // 
            this.tbParamName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbParamName.Location = new System.Drawing.Point(6, 20);
            this.tbParamName.Name = "tbParamName";
            this.tbParamName.Size = new System.Drawing.Size(267, 21);
            this.tbParamName.TabIndex = 0;
            this.tbParamName.TextChanged += new System.EventHandler(this.tbParamName_TextChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(200, 208);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(85, 30);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(469, 260);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Назад";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormCruiseSearchSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 298);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbEdit);
            this.Controls.Add(this.gbSettings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCruiseSearchSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки круизного поиска";
            this.gbSettings.ResumeLayout(false);
            this.gbEdit.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.GroupBox gbEdit;
        private System.Windows.Forms.ListBox lbSettings;
        private System.Windows.Forms.Button btnSqlQueryEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbValues;
        private System.Windows.Forms.TextBox tbParamName;
    }
}