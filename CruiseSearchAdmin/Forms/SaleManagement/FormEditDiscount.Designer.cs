namespace CruiseSearchAdmin.Forms.SaleManagement
{
    partial class FormEditDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditDiscount));
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.nudValue = new System.Windows.Forms.NumericUpDown();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbActions = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chbSDate = new System.Windows.Forms.CheckBox();
            this.dtpSaleEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpSaleBegin = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chbDate = new System.Windows.Forms.CheckBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbItinerary = new System.Windows.Forms.Label();
            this.cbEnableIti = new System.Windows.Forms.CheckBox();
            this.dgvItinerary = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbCabinClass = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbShip = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCruiseLine = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.nudPriority = new System.Windows.Forms.NumericUpDown();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItinerary)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.nudValue);
            this.groupBox10.Location = new System.Drawing.Point(10, 262);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(62, 59);
            this.groupBox10.TabIndex = 9;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Скидка";
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(5, 20);
            this.nudValue.Name = "nudValue";
            this.nudValue.Size = new System.Drawing.Size(52, 20);
            this.nudValue.TabIndex = 10;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cbRegion);
            this.groupBox9.Location = new System.Drawing.Point(290, 12);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(224, 55);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Регион";
            // 
            // cbRegion
            // 
            this.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Location = new System.Drawing.Point(5, 19);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(214, 21);
            this.cbRegion.TabIndex = 11;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbActions);
            this.groupBox8.Location = new System.Drawing.Point(160, 262);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(353, 55);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Акция";
            // 
            // cbActions
            // 
            this.cbActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActions.FormattingEnabled = true;
            this.cbActions.Location = new System.Drawing.Point(5, 19);
            this.cbActions.Name = "cbActions";
            this.cbActions.Size = new System.Drawing.Size(342, 21);
            this.cbActions.TabIndex = 10;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chbSDate);
            this.groupBox7.Controls.Add(this.dtpSaleEnd);
            this.groupBox7.Controls.Add(this.dtpSaleBegin);
            this.groupBox7.Location = new System.Drawing.Point(285, 168);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(229, 88);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Период продаж";
            // 
            // chbSDate
            // 
            this.chbSDate.AutoSize = true;
            this.chbSDate.Location = new System.Drawing.Point(19, 19);
            this.chbSDate.Name = "chbSDate";
            this.chbSDate.Size = new System.Drawing.Size(81, 17);
            this.chbSDate.TabIndex = 4;
            this.chbSDate.Text = "Отключить";
            this.chbSDate.UseVisualStyleBackColor = true;
            this.chbSDate.CheckedChanged += new System.EventHandler(this.chbSDate_CheckedChanged);
            // 
            // dtpSaleEnd
            // 
            this.dtpSaleEnd.Location = new System.Drawing.Point(19, 62);
            this.dtpSaleEnd.Name = "dtpSaleEnd";
            this.dtpSaleEnd.Size = new System.Drawing.Size(205, 20);
            this.dtpSaleEnd.TabIndex = 3;
            this.dtpSaleEnd.ValueChanged += new System.EventHandler(this.dtpSale_ValueChanged);
            // 
            // dtpSaleBegin
            // 
            this.dtpSaleBegin.Location = new System.Drawing.Point(19, 36);
            this.dtpSaleBegin.Name = "dtpSaleBegin";
            this.dtpSaleBegin.Size = new System.Drawing.Size(205, 20);
            this.dtpSaleBegin.TabIndex = 2;
            this.dtpSaleBegin.ValueChanged += new System.EventHandler(this.dtpSale_ValueChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chbDate);
            this.groupBox6.Controls.Add(this.dtpEnd);
            this.groupBox6.Controls.Add(this.dtpBegin);
            this.groupBox6.Location = new System.Drawing.Point(285, 73);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(229, 89);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Период заезда";
            // 
            // chbDate
            // 
            this.chbDate.AutoSize = true;
            this.chbDate.Location = new System.Drawing.Point(19, 19);
            this.chbDate.Name = "chbDate";
            this.chbDate.Size = new System.Drawing.Size(81, 17);
            this.chbDate.TabIndex = 2;
            this.chbDate.Text = "Отключить";
            this.chbDate.UseVisualStyleBackColor = true;
            this.chbDate.CheckedChanged += new System.EventHandler(this.cbDate_CheckedChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(19, 63);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(205, 20);
            this.dtpEnd.TabIndex = 1;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(19, 37);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(205, 20);
            this.dtpBegin.TabIndex = 0;
            this.dtpBegin.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.lbItinerary);
            this.groupBox5.Controls.Add(this.cbEnableIti);
            this.groupBox5.Controls.Add(this.dgvItinerary);
            this.groupBox5.Location = new System.Drawing.Point(10, 327);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(503, 40);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Маршрут";
            // 
            // lbItinerary
            // 
            this.lbItinerary.AutoSize = true;
            this.lbItinerary.Location = new System.Drawing.Point(5, 19);
            this.lbItinerary.Name = "lbItinerary";
            this.lbItinerary.Size = new System.Drawing.Size(108, 13);
            this.lbItinerary.TabIndex = 2;
            this.lbItinerary.Text = "Маршрут не выбран";
            // 
            // cbEnableIti
            // 
            this.cbEnableIti.AutoSize = true;
            this.cbEnableIti.Location = new System.Drawing.Point(380, 17);
            this.cbEnableIti.Name = "cbEnableIti";
            this.cbEnableIti.Size = new System.Drawing.Size(117, 17);
            this.cbEnableIti.TabIndex = 1;
            this.cbEnableIti.Text = "Выбрать маршрут";
            this.cbEnableIti.UseVisualStyleBackColor = true;
            this.cbEnableIti.CheckedChanged += new System.EventHandler(this.cbEnableIti_CheckedChanged);
            // 
            // dgvItinerary
            // 
            this.dgvItinerary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItinerary.Location = new System.Drawing.Point(5, 42);
            this.dgvItinerary.Name = "dgvItinerary";
            this.dgvItinerary.Size = new System.Drawing.Size(493, 84);
            this.dgvItinerary.TabIndex = 0;
            this.dgvItinerary.Visible = false;
            this.dgvItinerary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItinerary_CellClick);
            this.dgvItinerary.SelectionChanged += new System.EventHandler(this.dgvItinerary_SelectionChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbCabinClass);
            this.groupBox4.Location = new System.Drawing.Point(10, 197);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(269, 59);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Класс каюты";
            // 
            // cbCabinClass
            // 
            this.cbCabinClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCabinClass.FormattingEnabled = true;
            this.cbCabinClass.Location = new System.Drawing.Point(5, 22);
            this.cbCabinClass.Name = "cbCabinClass";
            this.cbCabinClass.Size = new System.Drawing.Size(259, 21);
            this.cbCabinClass.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbShip);
            this.groupBox3.Location = new System.Drawing.Point(10, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Лайнер";
            // 
            // cbShip
            // 
            this.cbShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShip.FormattingEnabled = true;
            this.cbShip.Location = new System.Drawing.Point(5, 19);
            this.cbShip.Name = "cbShip";
            this.cbShip.Size = new System.Drawing.Size(259, 21);
            this.cbShip.TabIndex = 10;
            this.cbShip.SelectedIndexChanged += new System.EventHandler(this.cbShip_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCruiseLine);
            this.groupBox2.Location = new System.Drawing.Point(10, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Круизная компания";
            // 
            // cbCruiseLine
            // 
            this.cbCruiseLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCruiseLine.FormattingEnabled = true;
            this.cbCruiseLine.Location = new System.Drawing.Point(5, 19);
            this.cbCruiseLine.Name = "cbCruiseLine";
            this.cbCruiseLine.Size = new System.Drawing.Size(259, 21);
            this.cbCruiseLine.TabIndex = 9;
            this.cbCruiseLine.SelectedIndexChanged += new System.EventHandler(this.cbCruiseLine_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(5, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(259, 20);
            this.tbName.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(438, 373);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(357, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.nudPriority);
            this.groupBox11.Location = new System.Drawing.Point(77, 262);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(78, 59);
            this.groupBox11.TabIndex = 12;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Приоритет";
            // 
            // nudPriority
            // 
            this.nudPriority.Location = new System.Drawing.Point(5, 20);
            this.nudPriority.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPriority.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.nudPriority.Name = "nudPriority";
            this.nudPriority.Size = new System.Drawing.Size(68, 20);
            this.nudPriority.TabIndex = 10;
            // 
            // FormEditDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 406);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormEditDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование";
            this.Load += new System.EventHandler(this.FormEditDiscount_Load);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItinerary)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbCruiseLine;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbShip;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbCabinClass;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DateTimePicker dtpSaleEnd;
        private System.Windows.Forms.DateTimePicker dtpSaleBegin;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox cbActions;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.NumericUpDown nudValue;
        private System.Windows.Forms.DataGridView dgvItinerary;
        private System.Windows.Forms.CheckBox cbEnableIti;
        private System.Windows.Forms.Label lbItinerary;
        private System.Windows.Forms.CheckBox chbDate;
        private System.Windows.Forms.CheckBox chbSDate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.NumericUpDown nudPriority;
    }
}