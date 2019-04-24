using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.Spec
{
    partial class FormHandCruisesCashe: Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHandCruisesCashe));
            this.dgvCruises = new System.Windows.Forms.DataGridView();
            this.gbCruise = new System.Windows.Forms.GroupBox();
            this.pnCon = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRollback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCruises)).BeginInit();
            this.gbCruise.SuspendLayout();
            this.pnCon.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCruises
            // 
            this.dgvCruises.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCruises.Location = new System.Drawing.Point(3, 17);
            this.dgvCruises.MultiSelect = false;
            this.dgvCruises.Name = "dgvCruises";
            this.dgvCruises.ReadOnly = true;
            this.dgvCruises.Size = new System.Drawing.Size(844, 328);
            this.dgvCruises.TabIndex = 0;
            this.dgvCruises.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCruises_RowLeave);
            this.dgvCruises.SelectionChanged += new System.EventHandler(this.dgvCruises_SelectionChanged);
            // 
            // gbCruise
            // 
            this.gbCruise.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCruise.Controls.Add(this.dgvCruises);
            this.gbCruise.Location = new System.Drawing.Point(12, 77);
            this.gbCruise.Name = "gbCruise";
            this.gbCruise.Size = new System.Drawing.Size(850, 348);
            this.gbCruise.TabIndex = 1;
            this.gbCruise.TabStop = false;
            this.gbCruise.Text = "СпецПредложения";
            // 
            // pnCon
            // 
            this.pnCon.Controls.Add(this.tableLayoutPanel1);
            this.pnCon.Location = new System.Drawing.Point(15, 3);
            this.pnCon.Name = "pnCon";
            this.pnCon.Size = new System.Drawing.Size(480, 68);
            this.pnCon.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRollback, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(480, 68);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Image = global::CruiseSearchAdmin.Properties.Resources.add1;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 62);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseMnemonic = false;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Image = global::CruiseSearchAdmin.Properties.Resources.tag_blue_edit1;
            this.btnEdit.Location = new System.Drawing.Point(91, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(82, 62);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Image = global::CruiseSearchAdmin.Properties.Resources.delete1;
            this.btnDelete.Location = new System.Drawing.Point(179, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 62);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Image = global::CruiseSearchAdmin.Properties.Resources.exit;
            this.btnClose.Location = new System.Drawing.Point(391, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 62);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRollback.Location = new System.Drawing.Point(267, 3);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(82, 62);
            this.btnRollback.TabIndex = 4;
            this.btnRollback.Text = "Откатить изменения";
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Visible = false;
            this.btnRollback.Click += new System.EventHandler(this.btnRollba_Click);
            // 
            // FormHandCruisesCashe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 437);
            this.Controls.Add(this.pnCon);
            this.Controls.Add(this.gbCruise);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHandCruisesCashe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormHandCruisesCashe_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCruises)).EndInit();
            this.gbCruise.ResumeLayout(false);
            this.pnCon.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCruises;
        private System.Windows.Forms.GroupBox gbCruise;
        private System.Windows.Forms.Panel pnCon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private Button btnRollback;

    }
}