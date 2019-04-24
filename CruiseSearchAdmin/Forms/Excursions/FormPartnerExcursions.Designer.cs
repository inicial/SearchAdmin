namespace CruiseSearchAdmin.Forms.Excursions
{
    partial class FormPartnerExcursions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPartnerExcursions));
            this.dgvPartnerExcursions = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddPartnerExcursion = new System.Windows.Forms.Button();
            this.btnEditPartnerExcursion = new System.Windows.Forms.Button();
            this.btnRemovePartnerExcursion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbExcursion = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartnerExcursions)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPartnerExcursions
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartnerExcursions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPartnerExcursions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartnerExcursions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPartnerExcursions.Location = new System.Drawing.Point(3, 50);
            this.dgvPartnerExcursions.MultiSelect = false;
            this.dgvPartnerExcursions.Name = "dgvPartnerExcursions";
            this.dgvPartnerExcursions.RowHeadersVisible = false;
            this.dgvPartnerExcursions.Size = new System.Drawing.Size(491, 215);
            this.dgvPartnerExcursions.TabIndex = 0;
            this.dgvPartnerExcursions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartnerExcursions_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 287);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Партнеры";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPartnerExcursions, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(497, 268);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.Controls.Add(this.btnAddPartnerExcursion, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEditPartnerExcursion, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRemovePartnerExcursion, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(491, 41);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnAddPartnerExcursion
            // 
            this.btnAddPartnerExcursion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddPartnerExcursion.Image = global::CruiseSearchAdmin.Properties.Resources.add1;
            this.btnAddPartnerExcursion.Location = new System.Drawing.Point(451, 3);
            this.btnAddPartnerExcursion.Name = "btnAddPartnerExcursion";
            this.btnAddPartnerExcursion.Size = new System.Drawing.Size(37, 35);
            this.btnAddPartnerExcursion.TabIndex = 0;
            this.btnAddPartnerExcursion.UseVisualStyleBackColor = true;
            this.btnAddPartnerExcursion.Click += new System.EventHandler(this.btnAddPartnerExcursion_Click);
            // 
            // btnEditPartnerExcursion
            // 
            this.btnEditPartnerExcursion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditPartnerExcursion.Image = global::CruiseSearchAdmin.Properties.Resources.tag_blue_edit1;
            this.btnEditPartnerExcursion.Location = new System.Drawing.Point(408, 3);
            this.btnEditPartnerExcursion.Name = "btnEditPartnerExcursion";
            this.btnEditPartnerExcursion.Size = new System.Drawing.Size(37, 35);
            this.btnEditPartnerExcursion.TabIndex = 1;
            this.btnEditPartnerExcursion.UseVisualStyleBackColor = true;
            this.btnEditPartnerExcursion.Click += new System.EventHandler(this.btnEditPartnerExcursion_Click);
            // 
            // btnRemovePartnerExcursion
            // 
            this.btnRemovePartnerExcursion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemovePartnerExcursion.Image = global::CruiseSearchAdmin.Properties.Resources.delete1;
            this.btnRemovePartnerExcursion.Location = new System.Drawing.Point(3, 3);
            this.btnRemovePartnerExcursion.Name = "btnRemovePartnerExcursion";
            this.btnRemovePartnerExcursion.Size = new System.Drawing.Size(37, 35);
            this.btnRemovePartnerExcursion.TabIndex = 2;
            this.btnRemovePartnerExcursion.UseVisualStyleBackColor = true;
            this.btnRemovePartnerExcursion.Click += new System.EventHandler(this.btnRemovePartnerExcursion_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbExcursion);
            this.groupBox2.Location = new System.Drawing.Point(10, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 65);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Экскурсия";
            // 
            // tbExcursion
            // 
            this.tbExcursion.Location = new System.Drawing.Point(5, 28);
            this.tbExcursion.Name = "tbExcursion";
            this.tbExcursion.ReadOnly = true;
            this.tbExcursion.Size = new System.Drawing.Size(193, 20);
            this.tbExcursion.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(437, 376);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormPartnerExcursions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 413);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(534, 420);
            this.Name = "FormPartnerExcursions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Экскурсии от партнеров";
            this.Load += new System.EventHandler(this.FormPartnerExcursions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartnerExcursions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPartnerExcursions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbExcursion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAddPartnerExcursion;
        private System.Windows.Forms.Button btnEditPartnerExcursion;
        private System.Windows.Forms.Button btnRemovePartnerExcursion;
        private System.Windows.Forms.Button btnBack;
    }
}