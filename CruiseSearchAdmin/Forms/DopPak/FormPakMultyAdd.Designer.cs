namespace CruiseSearchAdmin.Forms.DopPak
{
    partial class FormPakMultyAdd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPakMultyAdd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.applyFilter = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.minDur = new System.Windows.Forms.NumericUpDown();
            this.maxDur = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbGroupActions = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbActions = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbShips = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCruiseLines = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRegions = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCruises = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddCruiseAction = new System.Windows.Forms.Button();
            this.btnDeleteCruiseAction = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbDop = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minDur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDur)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCruises)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.applyFilter);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbGroupActions);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbActions);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbShips);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbCruiseLines);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbRegions);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.MinimumSize = new System.Drawing.Size(758, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(1083, 192);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр";
            // 
            // applyFilter
            // 
            this.applyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyFilter.Location = new System.Drawing.Point(846, 149);
            this.applyFilter.Name = "applyFilter";
            this.applyFilter.Size = new System.Drawing.Size(174, 27);
            this.applyFilter.TabIndex = 23;
            this.applyFilter.Text = "OK";
            this.applyFilter.UseVisualStyleBackColor = true;
            this.applyFilter.Click += new System.EventHandler(this.applyFilter_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.minDur);
            this.groupBox2.Controls.Add(this.maxDur);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(809, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 84);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Продолжительность";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(94, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "Ночей";
            // 
            // minDur
            // 
            this.minDur.Location = new System.Drawing.Point(22, 32);
            this.minDur.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minDur.Name = "minDur";
            this.minDur.Size = new System.Drawing.Size(72, 21);
            this.minDur.TabIndex = 3;
            this.minDur.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // maxDur
            // 
            this.maxDur.Location = new System.Drawing.Point(143, 32);
            this.maxDur.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxDur.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxDur.Name = "maxDur";
            this.maxDur.Size = new System.Drawing.Size(68, 21);
            this.maxDur.TabIndex = 2;
            this.maxDur.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(159, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "До";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(45, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "От";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 107);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Группа тематики";
            // 
            // cbGroupActions
            // 
            this.cbGroupActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbGroupActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroupActions.FormattingEnabled = true;
            this.cbGroupActions.Location = new System.Drawing.Point(22, 126);
            this.cbGroupActions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbGroupActions.Name = "cbGroupActions";
            this.cbGroupActions.Size = new System.Drawing.Size(223, 23);
            this.cbGroupActions.TabIndex = 18;
            this.cbGroupActions.SelectedIndexChanged += new System.EventHandler(this.cbGroupActions_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Тематика";
            // 
            // cbActions
            // 
            this.cbActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActions.FormattingEnabled = true;
            this.cbActions.Location = new System.Drawing.Point(22, 167);
            this.cbActions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbActions.Name = "cbActions";
            this.cbActions.Size = new System.Drawing.Size(223, 23);
            this.cbActions.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Дата";
            // 
            // cbShips
            // 
            this.cbShips.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShips.Enabled = false;
            this.cbShips.FormattingEnabled = true;
            this.cbShips.Location = new System.Drawing.Point(22, 80);
            this.cbShips.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbShips.Name = "cbShips";
            this.cbShips.Size = new System.Drawing.Size(223, 23);
            this.cbShips.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Лайнер";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(509, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Регион";
            // 
            // cbCruiseLines
            // 
            this.cbCruiseLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCruiseLines.FormattingEnabled = true;
            this.cbCruiseLines.Location = new System.Drawing.Point(22, 33);
            this.cbCruiseLines.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbCruiseLines.Name = "cbCruiseLines";
            this.cbCruiseLines.Size = new System.Drawing.Size(223, 23);
            this.cbCruiseLines.TabIndex = 7;
            this.cbCruiseLines.SelectedIndexChanged += new System.EventHandler(this.cbCruiseLines_SelectedIndexChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpEnd.Location = new System.Drawing.Point(552, 94);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(192, 20);
            this.dtpEnd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Компания";
            // 
            // cbRegions
            // 
            this.cbRegions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegions.FormattingEnabled = true;
            this.cbRegions.Location = new System.Drawing.Point(283, 33);
            this.cbRegions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbRegions.Name = "cbRegions";
            this.cbRegions.Size = new System.Drawing.Size(495, 23);
            this.cbRegions.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(283, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "С";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(512, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "ПО";
            // 
            // dtpBegin
            // 
            this.dtpBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpBegin.Location = new System.Drawing.Point(305, 96);
            this.dtpBegin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(192, 20);
            this.dtpBegin.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(1, 212);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(1108, 365);
            this.splitContainer1.SplitterDistance = 586;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(586, 365);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Круизы";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgvCruises, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 17);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(582, 345);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // dgvCruises
            // 
            this.dgvCruises.AllowUserToAddRows = false;
            this.dgvCruises.AllowUserToDeleteRows = false;
            this.dgvCruises.AllowUserToResizeRows = false;
            this.dgvCruises.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCruises.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCruises.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCruises.Location = new System.Drawing.Point(2, 99);
            this.dgvCruises.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvCruises.Name = "dgvCruises";
            this.dgvCruises.ReadOnly = true;
            this.dgvCruises.RowHeadersWidth = 45;
            this.dgvCruises.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCruises.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCruises.Size = new System.Drawing.Size(578, 243);
            this.dgvCruises.TabIndex = 0;
            this.dgvCruises.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCruises_CellClick);
            this.dgvCruises.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCruises_CellContentClick);
            this.dgvCruises.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCruises_RowPostPaint);
            this.dgvCruises.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvCruises_RowPrePaint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddCruiseAction, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteCruiseAction, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSelectAll, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDeselectAll, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInvertSelect, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 90);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnAddCruiseAction
            // 
            this.btnAddCruiseAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddCruiseAction.Image = global::CruiseSearchAdmin.Properties.Resources.add1;
            this.btnAddCruiseAction.Location = new System.Drawing.Point(2, 3);
            this.btnAddCruiseAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddCruiseAction.Name = "btnAddCruiseAction";
            this.btnAddCruiseAction.Size = new System.Drawing.Size(73, 84);
            this.btnAddCruiseAction.TabIndex = 4;
            this.btnAddCruiseAction.UseVisualStyleBackColor = true;
            this.btnAddCruiseAction.Click += new System.EventHandler(this.btnAddCruiseAction_Click);
            // 
            // btnDeleteCruiseAction
            // 
            this.btnDeleteCruiseAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteCruiseAction.Image = global::CruiseSearchAdmin.Properties.Resources.delete1;
            this.btnDeleteCruiseAction.Location = new System.Drawing.Point(79, 3);
            this.btnDeleteCruiseAction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeleteCruiseAction.Name = "btnDeleteCruiseAction";
            this.btnDeleteCruiseAction.Size = new System.Drawing.Size(73, 84);
            this.btnDeleteCruiseAction.TabIndex = 5;
            this.btnDeleteCruiseAction.UseVisualStyleBackColor = true;
            this.btnDeleteCruiseAction.Click += new System.EventHandler(this.btnDeleteCruiseAction_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectAll.Image = global::CruiseSearchAdmin.Properties.Resources.check;
            this.btnSelectAll.Location = new System.Drawing.Point(156, 3);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(73, 84);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeselectAll.Image = global::CruiseSearchAdmin.Properties.Resources.checkbox_unchecked;
            this.btnDeselectAll.Location = new System.Drawing.Point(310, 3);
            this.btnDeselectAll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(73, 84);
            this.btnDeselectAll.TabIndex = 3;
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInvertSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnInvertSelect.Image")));
            this.btnInvertSelect.Location = new System.Drawing.Point(233, 3);
            this.btnInvertSelect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(73, 84);
            this.btnInvertSelect.TabIndex = 2;
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbDop);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Size = new System.Drawing.Size(517, 365);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Дополнительные пакеты";
            // 
            // lbDop
            // 
            this.lbDop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDop.FormattingEnabled = true;
            this.lbDop.ItemHeight = 15;
            this.lbDop.Location = new System.Drawing.Point(2, 17);
            this.lbDop.Name = "lbDop";
            this.lbDop.Size = new System.Drawing.Size(513, 345);
            this.lbDop.TabIndex = 0;
            // 
            // FormPakMultyAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 583);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPakMultyAdd";
            this.Text = "Дополнительные пакеты";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minDur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxDur)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCruises)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button applyFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown minDur;
        private System.Windows.Forms.NumericUpDown maxDur;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbGroupActions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbActions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbShips;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCruiseLines;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRegions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvCruises;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddCruiseAction;
        private System.Windows.Forms.Button btnDeleteCruiseAction;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lbDop;
    }
}