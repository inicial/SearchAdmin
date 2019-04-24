namespace CruiseSearchAdmin.Forms.Ships
{
    partial class FormShips
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShips));
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbShipCruiseLine = new System.Windows.Forms.ComboBox();
            this.tbShipName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbShipCode = new System.Windows.Forms.TextBox();
            this.chbShipVisible = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCommitEdit = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.gbShips = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvShips = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddShip = new System.Windows.Forms.Button();
            this.btnRemoveShip = new System.Windows.Forms.Button();
            this.btnEditShip = new System.Windows.Forms.Button();
            this.btnCabineCatigories = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeck = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbInfo.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.gbShips.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShips)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.tableLayoutPanel5);
            this.gbInfo.Enabled = false;
            this.gbInfo.Location = new System.Drawing.Point(358, 12);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(285, 348);
            this.gbInfo.TabIndex = 2;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.86021F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.13979F));
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.cbShipCruiseLine, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.tbShipName, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.tbShipCode, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.chbShipVisible, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 5);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(279, 329);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название лайнера";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Круизная компания";
            // 
            // cbShipCruiseLine
            // 
            this.cbShipCruiseLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShipCruiseLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShipCruiseLine.FormattingEnabled = true;
            this.cbShipCruiseLine.Location = new System.Drawing.Point(116, 40);
            this.cbShipCruiseLine.Name = "cbShipCruiseLine";
            this.cbShipCruiseLine.Size = new System.Drawing.Size(160, 21);
            this.cbShipCruiseLine.TabIndex = 3;
            // 
            // tbShipName
            // 
            this.tbShipName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbShipName.Location = new System.Drawing.Point(116, 8);
            this.tbShipName.Name = "tbShipName";
            this.tbShipName.Size = new System.Drawing.Size(148, 20);
            this.tbShipName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Код лайнера";
            // 
            // tbShipCode
            // 
            this.tbShipCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbShipCode.Location = new System.Drawing.Point(116, 77);
            this.tbShipCode.Name = "tbShipCode";
            this.tbShipCode.Size = new System.Drawing.Size(78, 20);
            this.tbShipCode.TabIndex = 5;
            // 
            // chbShipVisible
            // 
            this.chbShipVisible.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbShipVisible.AutoSize = true;
            this.chbShipVisible.Location = new System.Drawing.Point(3, 111);
            this.chbShipVisible.Name = "chbShipVisible";
            this.chbShipVisible.Size = new System.Drawing.Size(86, 17);
            this.chbShipVisible.TabIndex = 6;
            this.chbShipVisible.Text = "Невидимый";
            this.chbShipVisible.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.75F));
            this.tableLayoutPanel6.Controls.Add(this.btnCommitEdit, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnCancelEdit, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(116, 293);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(160, 33);
            this.tableLayoutPanel6.TabIndex = 7;
            // 
            // btnCommitEdit
            // 
            this.btnCommitEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommitEdit.Location = new System.Drawing.Point(88, 3);
            this.btnCommitEdit.Name = "btnCommitEdit";
            this.btnCommitEdit.Size = new System.Drawing.Size(69, 27);
            this.btnCommitEdit.TabIndex = 0;
            this.btnCommitEdit.Text = "Сохранить";
            this.btnCommitEdit.UseVisualStyleBackColor = true;
            this.btnCommitEdit.Click += new System.EventHandler(this.btnCommitEdit_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelEdit.Location = new System.Drawing.Point(7, 3);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(72, 27);
            this.btnCancelEdit.TabIndex = 1;
            this.btnCancelEdit.Text = "Отмена";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // gbShips
            // 
            this.gbShips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbShips.Controls.Add(this.tableLayoutPanel3);
            this.gbShips.Location = new System.Drawing.Point(10, 12);
            this.gbShips.Name = "gbShips";
            this.gbShips.Size = new System.Drawing.Size(347, 357);
            this.gbShips.TabIndex = 1;
            this.gbShips.TabStop = false;
            this.gbShips.Text = "Лайнеры";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(341, 338);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvShips, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 332);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvShips
            // 
            this.dgvShips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShips.Location = new System.Drawing.Point(3, 38);
            this.dgvShips.MultiSelect = false;
            this.dgvShips.Name = "dgvShips";
            this.dgvShips.RowHeadersWidth = 40;
            this.dgvShips.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvShips.Size = new System.Drawing.Size(329, 291);
            this.dgvShips.TabIndex = 0;
            this.dgvShips.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShips_CellDoubleClick);
            this.dgvShips.SelectionChanged += new System.EventHandler(this.dgvShips_SelectionChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Controls.Add(this.btnAddShip, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnRemoveShip, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEditShip, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCabineCatigories, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDeck, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(329, 29);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnAddShip
            // 
            this.btnAddShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddShip.Image = global::CruiseSearchAdmin.Properties.Resources.add;
            this.btnAddShip.Location = new System.Drawing.Point(297, 3);
            this.btnAddShip.Name = "btnAddShip";
            this.btnAddShip.Size = new System.Drawing.Size(29, 23);
            this.btnAddShip.TabIndex = 1;
            this.btnAddShip.UseVisualStyleBackColor = true;
            this.btnAddShip.Click += new System.EventHandler(this.btnAddShip_Click);
            // 
            // btnRemoveShip
            // 
            this.btnRemoveShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveShip.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnRemoveShip.Location = new System.Drawing.Point(3, 3);
            this.btnRemoveShip.Name = "btnRemoveShip";
            this.btnRemoveShip.Size = new System.Drawing.Size(26, 23);
            this.btnRemoveShip.TabIndex = 0;
            this.btnRemoveShip.UseVisualStyleBackColor = true;
            this.btnRemoveShip.Click += new System.EventHandler(this.btnRemoveShip_Click);
            // 
            // btnEditShip
            // 
            this.btnEditShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditShip.Image = global::CruiseSearchAdmin.Properties.Resources.tag_blue_edit;
            this.btnEditShip.Location = new System.Drawing.Point(264, 3);
            this.btnEditShip.Name = "btnEditShip";
            this.btnEditShip.Size = new System.Drawing.Size(27, 23);
            this.btnEditShip.TabIndex = 2;
            this.btnEditShip.UseVisualStyleBackColor = true;
            this.btnEditShip.Click += new System.EventHandler(this.btnEditShip_Click);
            // 
            // btnCabineCatigories
            // 
            this.btnCabineCatigories.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCabineCatigories.Location = new System.Drawing.Point(183, 3);
            this.btnCabineCatigories.Name = "btnCabineCatigories";
            this.btnCabineCatigories.Size = new System.Drawing.Size(75, 23);
            this.btnCabineCatigories.TabIndex = 3;
            this.btnCabineCatigories.Text = "Каюты";
            this.btnCabineCatigories.Click += new System.EventHandler(this.btnCabineCatigories_Click);
            // 
            // btnDeck
            // 
            this.btnDeck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeck.Location = new System.Drawing.Point(92, 3);
            this.btnDeck.Name = "btnDeck";
            this.btnDeck.Size = new System.Drawing.Size(75, 23);
            this.btnDeck.TabIndex = 4;
            this.btnDeck.Text = "Палубы";
            this.btnDeck.UseVisualStyleBackColor = true;
            this.btnDeck.Click += new System.EventHandler(this.btnDeck_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(565, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Назад";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormShips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 393);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gbShips);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(654, 400);
            this.Name = "FormShips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Лайнеры";
            this.gbInfo.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.gbShips.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShips)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbShips;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvShips;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbShipCruiseLine;
        private System.Windows.Forms.TextBox tbShipName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbShipCode;
        private System.Windows.Forms.CheckBox chbShipVisible;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnCommitEdit;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnAddShip;
        private System.Windows.Forms.Button btnRemoveShip;
        private System.Windows.Forms.Button btnEditShip;
        private System.Windows.Forms.Button btnClose;
        private DevExpress.XtraEditors.SimpleButton btnCabineCatigories;
        private System.Windows.Forms.Button btnDeck;
    }
}