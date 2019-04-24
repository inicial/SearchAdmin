namespace CruiseSearchAdmin.Forms.CountryForSeaports
{
    partial class SeaportsVisa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param DislayMember="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeaportsVisa));
            this.dgvSeaports = new System.Windows.Forms.DataGridView();
            this.lbCountry = new System.Windows.Forms.ListBox();
            this.cbCounry = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeaports)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSeaports
            // 
            this.dgvSeaports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSeaports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeaports.Location = new System.Drawing.Point(12, 63);
            this.dgvSeaports.MultiSelect = false;
            this.dgvSeaports.Name = "dgvSeaports";
            this.dgvSeaports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeaports.Size = new System.Drawing.Size(493, 348);
            this.dgvSeaports.TabIndex = 0;
            this.dgvSeaports.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeaports_CellDoubleClick);
            this.dgvSeaports.SelectionChanged += new System.EventHandler(this.dgvSeaports_SelectionChanged);
            // 
            // lbCountry
            // 
            this.lbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCountry.FormattingEnabled = true;
            this.lbCountry.ItemHeight = 15;
            this.lbCountry.Location = new System.Drawing.Point(511, 63);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(371, 349);
            this.lbCountry.TabIndex = 1;
            // 
            // cbCounry
            // 
            this.cbCounry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCounry.FormattingEnabled = true;
            this.cbCounry.Location = new System.Drawing.Point(183, 34);
            this.cbCounry.Name = "cbCounry";
            this.cbCounry.Size = new System.Drawing.Size(322, 23);
            this.cbCounry.TabIndex = 2;
            this.cbCounry.SelectedIndexChanged += new System.EventHandler(this.cbCounry_SelectedIndexChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 36);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(165, 21);
            this.tbName.TabIndex = 3;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(511, 35);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(592, 36);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SeaportsVisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 423);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.cbCounry);
            this.Controls.Add(this.lbCountry);
            this.Controls.Add(this.dgvSeaports);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SeaportsVisa";
            this.Load += new System.EventHandler(this.SeaportsVisa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeaports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSeaports;
        private System.Windows.Forms.ListBox lbCountry;
        private System.Windows.Forms.ComboBox cbCounry;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}