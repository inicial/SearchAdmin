using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.HandCruises
{
    partial class FormHandCruises : ProjectForm
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHandCruises));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCruises = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnEditPrice = new System.Windows.Forms.Button();
            this.btnCopyCruiseFromAuto = new System.Windows.Forms.Button();
            this.btnAddCruise = new System.Windows.Forms.Button();
            this.btnEditItenerary = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.cbCrLine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbShips = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEditCruise = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCruises)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvCruises, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(847, 405);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvCruises
            // 
            this.dgvCruises.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCruises.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCruises.Location = new System.Drawing.Point(3, 37);
            this.dgvCruises.MultiSelect = false;
            this.dgvCruises.Name = "dgvCruises";
            this.dgvCruises.Size = new System.Drawing.Size(841, 297);
            this.dgvCruises.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel2.Controls.Add(this.btnCopy, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEditPrice, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCopyCruiseFromAuto, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAddCruise, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEditItenerary, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 340);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(841, 28);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnCopy
            // 
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopy.Location = new System.Drawing.Point(3, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(154, 22);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "Скопировать круиз";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnEditPrice
            // 
            this.btnEditPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditPrice.Location = new System.Drawing.Point(329, 3);
            this.btnEditPrice.Name = "btnEditPrice";
            this.btnEditPrice.Size = new System.Drawing.Size(148, 22);
            this.btnEditPrice.TabIndex = 2;
            this.btnEditPrice.Text = "Редактировать цены";
            this.btnEditPrice.UseVisualStyleBackColor = true;
            this.btnEditPrice.Click += new System.EventHandler(this.btnEditPrice_Click);
            // 
            // btnCopyCruiseFromAuto
            // 
            this.btnCopyCruiseFromAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopyCruiseFromAuto.Location = new System.Drawing.Point(483, 3);
            this.btnCopyCruiseFromAuto.Name = "btnCopyCruiseFromAuto";
            this.btnCopyCruiseFromAuto.Size = new System.Drawing.Size(168, 22);
            this.btnCopyCruiseFromAuto.TabIndex = 3;
            this.btnCopyCruiseFromAuto.Text = "Скопировать из основных";
            this.btnCopyCruiseFromAuto.UseVisualStyleBackColor = true;
            this.btnCopyCruiseFromAuto.Click += new System.EventHandler(this.btnEditCruise_Click);
            // 
            // btnAddCruise
            // 
            this.btnAddCruise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddCruise.Location = new System.Drawing.Point(657, 3);
            this.btnAddCruise.Name = "btnAddCruise";
            this.btnAddCruise.Size = new System.Drawing.Size(181, 22);
            this.btnAddCruise.TabIndex = 4;
            this.btnAddCruise.Text = "Добавить круиз";
            this.btnAddCruise.UseVisualStyleBackColor = true;
            this.btnAddCruise.Click += new System.EventHandler(this.btnAddCruise_Click);
            // 
            // btnEditItenerary
            // 
            this.btnEditItenerary.Location = new System.Drawing.Point(163, 3);
            this.btnEditItenerary.Name = "btnEditItenerary";
            this.btnEditItenerary.Size = new System.Drawing.Size(160, 22);
            this.btnEditItenerary.TabIndex = 1;
            this.btnEditItenerary.Text = "Редактировать маршрут";
            this.btnEditItenerary.UseVisualStyleBackColor = true;
            this.btnEditItenerary.Click += new System.EventHandler(this.btnEditItenerary_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 244F));
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbCrLine, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbShips, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(841, 28);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 22);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btn
            // 
            this.btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn.Location = new System.Drawing.Point(74, 3);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(120, 22);
            this.btn.TabIndex = 1;
            this.btn.Text = "Удалить круиз";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // cbCrLine
            // 
            this.cbCrLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCrLine.FormattingEnabled = true;
            this.cbCrLine.Location = new System.Drawing.Point(600, 3);
            this.cbCrLine.Name = "cbCrLine";
            this.cbCrLine.Size = new System.Drawing.Size(238, 23);
            this.cbCrLine.TabIndex = 2;
            this.cbCrLine.SelectedIndexChanged += new System.EventHandler(this.cbCrLine_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(465, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Круизная компания :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(200, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Лайнер :";
            // 
            // cbShips
            // 
            this.cbShips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShips.Enabled = false;
            this.cbShips.FormattingEnabled = true;
            this.cbShips.Location = new System.Drawing.Point(281, 3);
            this.cbShips.Name = "cbShips";
            this.cbShips.Size = new System.Drawing.Size(178, 23);
            this.cbShips.TabIndex = 5;
            this.cbShips.SelectedIndexChanged += new System.EventHandler(this.cbShips_SelectedIndexChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.39715F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.60285F));
            this.tableLayoutPanel4.Controls.Add(this.btnEditCruise, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 374);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(841, 28);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // btnEditCruise
            // 
            this.btnEditCruise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditCruise.Location = new System.Drawing.Point(3, 3);
            this.btnEditCruise.Name = "btnEditCruise";
            this.btnEditCruise.Size = new System.Drawing.Size(216, 22);
            this.btnEditCruise.TabIndex = 0;
            this.btnEditCruise.Text = "Редактировать даты действия";
            this.btnEditCruise.UseVisualStyleBackColor = true;
            this.btnEditCruise.Click += new System.EventHandler(this.btnEditCruise_Click_1);
            // 
            // FormHandCruises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 405);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHandCruises";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCruises)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvCruises;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnEditItenerary;
        private System.Windows.Forms.Button btnEditPrice;
        private System.Windows.Forms.Button btnCopyCruiseFromAuto;
        private System.Windows.Forms.Button btnAddCruise;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ComboBox cbCrLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbShips;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnEditCruise;
    }
}