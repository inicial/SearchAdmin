namespace CruiseSearchAdmin.Forms.CabineCatigories
{
    partial class FormCabineCatigories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCabineCatigories));
            this.gbCabines = new System.Windows.Forms.GroupBox();
            this.dgvCabines = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddCabine = new System.Windows.Forms.Button();
            this.btnRemoveCabine = new System.Windows.Forms.Button();
            this.btnEditCabine = new System.Windows.Forms.Button();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.ECodCabine = new DevExpress.XtraEditors.TextEdit();
            this.ERu_Name = new DevExpress.XtraEditors.TextEdit();
            this.EEn_Name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.EDescriptor = new DevExpress.XtraEditors.MemoEdit();
            this.EVisable = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.CBCabinClass = new System.Windows.Forms.ComboBox();
            this.EMaxPax = new System.Windows.Forms.NumericUpDown();
            this.CBIn_Out = new System.Windows.Forms.ComboBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gbCabines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabines)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ECodCabine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ERu_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EEn_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDescriptor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EVisable.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EMaxPax)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCabines
            // 
            this.gbCabines.Controls.Add(this.dgvCabines);
            this.gbCabines.Controls.Add(this.groupBox2);
            this.gbCabines.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbCabines.Location = new System.Drawing.Point(0, 0);
            this.gbCabines.Name = "gbCabines";
            this.gbCabines.Size = new System.Drawing.Size(478, 458);
            this.gbCabines.TabIndex = 0;
            this.gbCabines.TabStop = false;
            this.gbCabines.Text = "Каюты";
            // 
            // dgvCabines
            // 
            this.dgvCabines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCabines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCabines.Location = new System.Drawing.Point(3, 65);
            this.dgvCabines.MultiSelect = false;
            this.dgvCabines.Name = "dgvCabines";
            this.dgvCabines.ReadOnly = true;
            this.dgvCabines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCabines.Size = new System.Drawing.Size(472, 390);
            this.dgvCabines.TabIndex = 1;
            this.dgvCabines.SelectionChanged += new System.EventHandler(this.dvgCabines_SelectionChanged_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddCabine);
            this.groupBox2.Controls.Add(this.btnRemoveCabine);
            this.groupBox2.Controls.Add(this.btnEditCabine);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 48);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnAddCabine
            // 
            this.btnAddCabine.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddCabine.Image = global::CruiseSearchAdmin.Properties.Resources.add;
            this.btnAddCabine.Location = new System.Drawing.Point(404, 17);
            this.btnAddCabine.Name = "btnAddCabine";
            this.btnAddCabine.Size = new System.Drawing.Size(34, 28);
            this.btnAddCabine.TabIndex = 4;
            this.btnAddCabine.UseVisualStyleBackColor = true;
            this.btnAddCabine.Click += new System.EventHandler(this.btnAddCabine_Click);
            // 
            // btnRemoveCabine
            // 
            this.btnRemoveCabine.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRemoveCabine.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnRemoveCabine.Location = new System.Drawing.Point(3, 17);
            this.btnRemoveCabine.Name = "btnRemoveCabine";
            this.btnRemoveCabine.Size = new System.Drawing.Size(32, 28);
            this.btnRemoveCabine.TabIndex = 3;
            this.btnRemoveCabine.UseVisualStyleBackColor = true;
            this.btnRemoveCabine.Click += new System.EventHandler(this.btnRemoveCabine_Click);
            // 
            // btnEditCabine
            // 
            this.btnEditCabine.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditCabine.Image = global::CruiseSearchAdmin.Properties.Resources.tag_blue_edit;
            this.btnEditCabine.Location = new System.Drawing.Point(438, 17);
            this.btnEditCabine.Name = "btnEditCabine";
            this.btnEditCabine.Size = new System.Drawing.Size(31, 28);
            this.btnEditCabine.TabIndex = 5;
            this.btnEditCabine.UseVisualStyleBackColor = true;
            this.btnEditCabine.Click += new System.EventHandler(this.btnEditCabine_Click);
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.tableLayoutPanel1);
            this.gbInfo.Enabled = false;
            this.gbInfo.Location = new System.Drawing.Point(478, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(444, 423);
            this.gbInfo.TabIndex = 1;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ECodCabine, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ERu_Name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.EEn_Name, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.EDescriptor, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.EVisable, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelControl9, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.CBCabinClass, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.EMaxPax, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.CBIn_Out, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.34783F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.65217F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(438, 403);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Код каюты";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Русское название";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(3, 72);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(109, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Английское название";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 104);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Описание";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(3, 161);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(128, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Внутренняя или внешняя";
            // 
            // ECodCabine
            // 
            this.ECodCabine.Location = new System.Drawing.Point(222, 3);
            this.ECodCabine.Name = "ECodCabine";
            this.ECodCabine.Size = new System.Drawing.Size(188, 20);
            this.ECodCabine.TabIndex = 6;
            this.ECodCabine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit1_KeyPress);
            // 
            // ERu_Name
            // 
            this.ERu_Name.Location = new System.Drawing.Point(222, 41);
            this.ERu_Name.Name = "ERu_Name";
            this.ERu_Name.Size = new System.Drawing.Size(188, 20);
            this.ERu_Name.TabIndex = 8;
            // 
            // EEn_Name
            // 
            this.EEn_Name.Location = new System.Drawing.Point(222, 72);
            this.EEn_Name.Name = "EEn_Name";
            this.EEn_Name.Size = new System.Drawing.Size(188, 20);
            this.EEn_Name.TabIndex = 7;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(3, 237);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(67, 13);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Класс каюты";
            // 
            // EDescriptor
            // 
            this.EDescriptor.Location = new System.Drawing.Point(222, 104);
            this.EDescriptor.Name = "EDescriptor";
            this.EDescriptor.Size = new System.Drawing.Size(188, 50);
            this.EDescriptor.TabIndex = 14;
            // 
            // EVisable
            // 
            this.EVisable.Location = new System.Drawing.Point(3, 197);
            this.EVisable.Name = "EVisable";
            this.EVisable.Properties.Caption = "Видимость";
            this.EVisable.Size = new System.Drawing.Size(105, 19);
            this.EVisable.TabIndex = 17;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(3, 276);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(155, 13);
            this.labelControl9.TabIndex = 19;
            this.labelControl9.Text = "Максимальное кол-во человек";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.86855F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.13145F));
            this.tableLayoutPanel2.Controls.Add(this.btnOk, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(222, 318);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(213, 82);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(29, 52);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 27);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ок";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(123, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CBCabinClass
            // 
            this.CBCabinClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CBCabinClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCabinClass.FormattingEnabled = true;
            this.CBCabinClass.Location = new System.Drawing.Point(222, 243);
            this.CBCabinClass.Name = "CBCabinClass";
            this.CBCabinClass.Size = new System.Drawing.Size(213, 23);
            this.CBCabinClass.TabIndex = 22;
            // 
            // EMaxPax
            // 
            this.EMaxPax.Location = new System.Drawing.Point(222, 276);
            this.EMaxPax.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.EMaxPax.Name = "EMaxPax";
            this.EMaxPax.Size = new System.Drawing.Size(42, 21);
            this.EMaxPax.TabIndex = 24;
            // 
            // CBIn_Out
            // 
            this.CBIn_Out.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBIn_Out.FormattingEnabled = true;
            this.CBIn_Out.Location = new System.Drawing.Point(222, 161);
            this.CBIn_Out.Name = "CBIn_Out";
            this.CBIn_Out.Size = new System.Drawing.Size(41, 23);
            this.CBIn_Out.TabIndex = 25;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(829, 429);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(87, 27);
            this.simpleButton1.TabIndex = 26;
            this.simpleButton1.Text = "Назад";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FormCabineCatigories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 458);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gbCabines);
            this.Controls.Add(this.simpleButton1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCabineCatigories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbCabines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCabines)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ECodCabine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ERu_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EEn_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDescriptor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EVisable.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EMaxPax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCabines;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddCabine;
        private System.Windows.Forms.Button btnRemoveCabine;
        private System.Windows.Forms.Button btnEditCabine;
        private System.Windows.Forms.DataGridView dgvCabines;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit ECodCabine;
        private DevExpress.XtraEditors.TextEdit EEn_Name;
        private DevExpress.XtraEditors.TextEdit ERu_Name;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.MemoEdit EDescriptor;
        private DevExpress.XtraEditors.CheckEdit EVisable;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.ComboBox CBCabinClass;
        private System.Windows.Forms.NumericUpDown EMaxPax;
        private System.Windows.Forms.ComboBox CBIn_Out;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;


    }
}