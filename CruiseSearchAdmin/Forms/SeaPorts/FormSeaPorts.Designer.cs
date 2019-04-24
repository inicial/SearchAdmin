namespace CruiseSearchAdmin.Forms
{
    partial class FormSeaPorts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeaPorts));
            this.cbCruiseLine = new System.Windows.Forms.ComboBox();
            this.cbRegions = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNameFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chbUnLinked = new System.Windows.Forms.CheckBox();
            this.dgvSeaPorts = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddPort = new System.Windows.Forms.Button();
            this.btnRemPort = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbName_ru = new System.Windows.Forms.TextBox();
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
            this.tbName_en = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeaPorts)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCruiseLine
            // 
            this.cbCruiseLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCruiseLine.FormattingEnabled = true;
            this.cbCruiseLine.Location = new System.Drawing.Point(27, 36);
            this.cbCruiseLine.Name = "cbCruiseLine";
            this.cbCruiseLine.Size = new System.Drawing.Size(199, 21);
            this.cbCruiseLine.TabIndex = 0;
            this.cbCruiseLine.SelectedIndexChanged += new System.EventHandler(this.cbCruiseLine_SelectedIndexChanged);
            // 
            // cbRegions
            // 
            this.cbRegions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegions.FormattingEnabled = true;
            this.cbRegions.Location = new System.Drawing.Point(291, 36);
            this.cbRegions.Name = "cbRegions";
            this.cbRegions.Size = new System.Drawing.Size(187, 21);
            this.cbRegions.TabIndex = 1;
            this.cbRegions.SelectedIndexChanged += new System.EventHandler(this.cbRegions_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbNameFilter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbCruiseLine);
            this.groupBox1.Controls.Add(this.cbRegions);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(79, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "По названию";
            // 
            // tbNameFilter
            // 
            this.tbNameFilter.Location = new System.Drawing.Point(27, 73);
            this.tbNameFilter.Name = "tbNameFilter";
            this.tbNameFilter.Size = new System.Drawing.Size(199, 20);
            this.tbNameFilter.TabIndex = 6;
            this.tbNameFilter.TextChanged += new System.EventHandler(this.tbNameFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(363, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Регион";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(79, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Компания";
            // 
            // chbUnLinked
            // 
            this.chbUnLinked.AutoSize = true;
            this.chbUnLinked.BackColor = System.Drawing.Color.Transparent;
            this.chbUnLinked.Location = new System.Drawing.Point(4, 23);
            this.chbUnLinked.Name = "chbUnLinked";
            this.chbUnLinked.Size = new System.Drawing.Size(149, 17);
            this.chbUnLinked.TabIndex = 6;
            this.chbUnLinked.Text = "Только не привязанные";
            this.chbUnLinked.UseVisualStyleBackColor = false;
            this.chbUnLinked.CheckedChanged += new System.EventHandler(this.chbUnLinked_CheckedChanged);
            // 
            // dgvSeaPorts
            // 
            this.dgvSeaPorts.AllowUserToAddRows = false;
            this.dgvSeaPorts.AllowUserToDeleteRows = false;
            this.dgvSeaPorts.AllowUserToResizeColumns = false;
            this.dgvSeaPorts.AllowUserToResizeRows = false;
            this.dgvSeaPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSeaPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeaPorts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSeaPorts.Location = new System.Drawing.Point(3, 46);
            this.dgvSeaPorts.MultiSelect = false;
            this.dgvSeaPorts.Name = "dgvSeaPorts";
            this.dgvSeaPorts.RowHeadersWidth = 50;
            this.dgvSeaPorts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeaPorts.Size = new System.Drawing.Size(292, 232);
            this.dgvSeaPorts.TabIndex = 3;
            this.dgvSeaPorts.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSeaPorts_RowPostPaint);
            this.dgvSeaPorts.SelectionChanged += new System.EventHandler(this.dgvSeaPorts_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnAddPort);
            this.groupBox2.Controls.Add(this.btnRemPort);
            this.groupBox2.Controls.Add(this.chbUnLinked);
            this.groupBox2.Controls.Add(this.dgvSeaPorts);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 294);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Порты";
            // 
            // btnAddPort
            // 
            this.btnAddPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPort.Image = global::CruiseSearchAdmin.Properties.Resources.add;
            this.btnAddPort.Location = new System.Drawing.Point(237, 13);
            this.btnAddPort.Name = "btnAddPort";
            this.btnAddPort.Size = new System.Drawing.Size(25, 27);
            this.btnAddPort.TabIndex = 8;
            this.btnAddPort.UseVisualStyleBackColor = true;
            this.btnAddPort.Click += new System.EventHandler(this.btnAddPort_Click);
            // 
            // btnRemPort
            // 
            this.btnRemPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemPort.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnRemPort.Location = new System.Drawing.Point(268, 13);
            this.btnRemPort.Name = "btnRemPort";
            this.btnRemPort.Size = new System.Drawing.Size(26, 27);
            this.btnRemPort.TabIndex = 7;
            this.btnRemPort.UseVisualStyleBackColor = true;
            this.btnRemPort.Click += new System.EventHandler(this.btnRemPort_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbName_ru);
            this.groupBox3.Controls.Add(this.cbItemRegion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbItemCrLine);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbCode);
            this.groupBox3.Controls.Add(this.tbName_en);
            this.groupBox3.Location = new System.Drawing.Point(311, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 293);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информация о порте";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Название русское";
            // 
            // tbName_ru
            // 
            this.tbName_ru.Location = new System.Drawing.Point(12, 71);
            this.tbName_ru.Name = "tbName_ru";
            this.tbName_ru.Size = new System.Drawing.Size(175, 20);
            this.tbName_ru.TabIndex = 14;
            this.tbName_ru.Leave += new System.EventHandler(this.tbName_ru_Leave);
            // 
            // cbItemRegion
            // 
            this.cbItemRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemRegion.FormattingEnabled = true;
            this.cbItemRegion.Location = new System.Drawing.Point(14, 183);
            this.cbItemRegion.Name = "cbItemRegion";
            this.cbItemRegion.Size = new System.Drawing.Size(175, 21);
            this.cbItemRegion.TabIndex = 13;
            this.cbItemRegion.SelectionChangeCommitted += new System.EventHandler(this.cbItemRegion_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Регион";
            // 
            // cbItemCrLine
            // 
            this.cbItemCrLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemCrLine.FormattingEnabled = true;
            this.cbItemCrLine.Location = new System.Drawing.Point(14, 110);
            this.cbItemCrLine.Name = "cbItemCrLine";
            this.cbItemCrLine.Size = new System.Drawing.Size(175, 21);
            this.cbItemCrLine.TabIndex = 10;
            this.cbItemCrLine.SelectionChangeCommitted += new System.EventHandler(this.cbItemCrLine_SelectionChangeCommitted);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeleteParent);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.tbParent);
            this.groupBox4.Location = new System.Drawing.Point(6, 210);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(212, 73);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Главный порт";
            // 
            // btnDeleteParent
            // 
            this.btnDeleteParent.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnDeleteParent.Location = new System.Drawing.Point(146, 42);
            this.btnDeleteParent.Name = "btnDeleteParent";
            this.btnDeleteParent.Size = new System.Drawing.Size(27, 25);
            this.btnDeleteParent.TabIndex = 9;
            this.btnDeleteParent.UseVisualStyleBackColor = true;
            this.btnDeleteParent.Click += new System.EventHandler(this.btnDeleteParent_Click);
            // 
            // button1
            // 
            this.button1.Image = global::CruiseSearchAdmin.Properties.Resources.tag_blue_edit;
            this.button1.Location = new System.Drawing.Point(179, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 25);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAddParent_Click);
            // 
            // tbParent
            // 
            this.tbParent.Location = new System.Drawing.Point(4, 16);
            this.tbParent.Name = "tbParent";
            this.tbParent.ReadOnly = true;
            this.tbParent.Size = new System.Drawing.Size(202, 20);
            this.tbParent.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Код";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Компания";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Название";
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(14, 146);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(85, 20);
            this.tbCode.TabIndex = 2;
            this.tbCode.Leave += new System.EventHandler(this.tbCode_Leave);
            // 
            // tbName_en
            // 
            this.tbName_en.Location = new System.Drawing.Point(15, 32);
            this.tbName_en.Name = "tbName_en";
            this.tbName_en.Size = new System.Drawing.Size(175, 20);
            this.tbName_en.TabIndex = 0;
            this.tbName_en.Leave += new System.EventHandler(this.tbPortName_Leave);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Location = new System.Drawing.Point(456, 413);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 30);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "Назад";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // FormSeaPorts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 442);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSeaPorts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Порты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSeaPorts_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeaPorts)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCruiseLine;
        private System.Windows.Forms.ComboBox cbRegions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSeaPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TextBox tbName_en;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbParent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbUnLinked;
        private System.Windows.Forms.ComboBox cbItemCrLine;
        private System.Windows.Forms.ComboBox cbItemRegion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeleteParent;
        private System.Windows.Forms.Button btnAddPort;
        private System.Windows.Forms.Button btnRemPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNameFilter;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbName_ru;
    }
}