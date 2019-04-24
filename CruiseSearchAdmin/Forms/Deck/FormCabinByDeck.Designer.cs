using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.Deck
{
    partial class FormCabinByDeck : ProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCabinByDeck));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemoveCabin = new System.Windows.Forms.Button();
            this.btnAddCabin = new System.Windows.Forms.Button();
            this.lbCabins = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbCabins, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(796, 419);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.3617F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.6383F));
            this.tableLayoutPanel2.Controls.Add(this.btnRemoveCabin, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAddCabin, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(91, 43);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnRemoveCabin
            // 
            this.btnRemoveCabin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveCabin.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnRemoveCabin.Location = new System.Drawing.Point(3, 3);
            this.btnRemoveCabin.Name = "btnRemoveCabin";
            this.btnRemoveCabin.Size = new System.Drawing.Size(38, 37);
            this.btnRemoveCabin.TabIndex = 0;
            this.btnRemoveCabin.UseVisualStyleBackColor = true;
            this.btnRemoveCabin.Click += new System.EventHandler(this.btnRemoveCabin_Click);
            // 
            // btnAddCabin
            // 
            this.btnAddCabin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddCabin.Image = global::CruiseSearchAdmin.Properties.Resources.add;
            this.btnAddCabin.Location = new System.Drawing.Point(47, 3);
            this.btnAddCabin.Name = "btnAddCabin";
            this.btnAddCabin.Size = new System.Drawing.Size(41, 37);
            this.btnAddCabin.TabIndex = 1;
            this.btnAddCabin.UseVisualStyleBackColor = true;
            this.btnAddCabin.Click += new System.EventHandler(this.btnAddCabin_Click);
            // 
            // lbCabins
            // 
            this.lbCabins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCabins.FormattingEnabled = true;
            this.lbCabins.ItemHeight = 15;
            this.lbCabins.Location = new System.Drawing.Point(3, 52);
            this.lbCabins.Name = "lbCabins";
            this.lbCabins.Size = new System.Drawing.Size(790, 337);
            this.lbCabins.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormCabinByDeck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 419);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCabinByDeck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Каюты на палубе ";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnRemoveCabin;
        private System.Windows.Forms.Button btnAddCabin;
        private System.Windows.Forms.ListBox lbCabins;
        private System.Windows.Forms.Button btnCancel;


    }
}