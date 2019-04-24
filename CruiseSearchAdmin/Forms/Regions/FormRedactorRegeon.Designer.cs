namespace CruiseSearchAdmin.Forms.Regions
{
    partial class FormRedactorRegeon
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRedactorRegeon));
            this.lbRegion = new System.Windows.Forms.ListBox();
            this.cmsRegion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddPodRegeon = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDoun = new System.Windows.Forms.Button();
            this.btnRegionEdit = new System.Windows.Forms.Button();
            this.btnRegionRemove = new System.Windows.Forms.Button();
            this.btnRegionAdd = new System.Windows.Forms.Button();
            this.cmsRegion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRegion
            // 
            this.lbRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRegion.ContextMenuStrip = this.cmsRegion;
            this.lbRegion.FormattingEnabled = true;
            this.lbRegion.ItemHeight = 15;
            this.lbRegion.Location = new System.Drawing.Point(14, 46);
            this.lbRegion.Name = "lbRegion";
            this.lbRegion.Size = new System.Drawing.Size(592, 424);
            this.lbRegion.TabIndex = 0;
            // 
            // cmsRegion
            // 
            this.cmsRegion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddRegion,
            this.ToolStripMenuItemAddPodRegeon});
            this.cmsRegion.Name = "contextMenuStrip1";
            this.cmsRegion.Size = new System.Drawing.Size(189, 48);
            // 
            // toolStripMenuItemAddRegion
            // 
            this.toolStripMenuItemAddRegion.Name = "toolStripMenuItemAddRegion";
            this.toolStripMenuItemAddRegion.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItemAddRegion.Text = "Добавить ";
            this.toolStripMenuItemAddRegion.Click += new System.EventHandler(this.toolStripMenuItemAddRegion_Click);
            // 
            // ToolStripMenuItemAddPodRegeon
            // 
            this.ToolStripMenuItemAddPodRegeon.Name = "ToolStripMenuItemAddPodRegeon";
            this.ToolStripMenuItemAddPodRegeon.Size = new System.Drawing.Size(188, 22);
            this.ToolStripMenuItemAddPodRegeon.Text = "Добавить подрегион";
            this.ToolStripMenuItemAddPodRegeon.Click += new System.EventHandler(this.ToolStripMenuItemAddPodRegeon_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(517, 479);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(371, 10);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 28);
            this.btnUp.TabIndex = 19;
            this.btnUp.Text = "Вверх";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDoun
            // 
            this.btnDoun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoun.Location = new System.Drawing.Point(452, 10);
            this.btnDoun.Name = "btnDoun";
            this.btnDoun.Size = new System.Drawing.Size(75, 28);
            this.btnDoun.TabIndex = 18;
            this.btnDoun.Text = "Вниз";
            this.btnDoun.UseVisualStyleBackColor = true;
            this.btnDoun.Click += new System.EventHandler(this.btnDoun_Click);
            // 
            // btnRegionEdit
            // 
            this.btnRegionEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegionEdit.Image = global::CruiseSearchAdmin.Properties.Resources.tag_blue_edit;
            this.btnRegionEdit.Location = new System.Drawing.Point(533, 13);
            this.btnRegionEdit.Name = "btnRegionEdit";
            this.btnRegionEdit.Size = new System.Drawing.Size(31, 25);
            this.btnRegionEdit.TabIndex = 17;
            this.btnRegionEdit.UseVisualStyleBackColor = true;
            this.btnRegionEdit.Click += new System.EventHandler(this.btnRegionEdit_Click);
            // 
            // btnRegionRemove
            // 
            this.btnRegionRemove.Image = global::CruiseSearchAdmin.Properties.Resources.delete;
            this.btnRegionRemove.Location = new System.Drawing.Point(7, 13);
            this.btnRegionRemove.Name = "btnRegionRemove";
            this.btnRegionRemove.Size = new System.Drawing.Size(34, 27);
            this.btnRegionRemove.TabIndex = 16;
            this.btnRegionRemove.UseVisualStyleBackColor = true;
            this.btnRegionRemove.Click += new System.EventHandler(this.btnRegionRemove_Click);
            // 
            // btnRegionAdd
            // 
            this.btnRegionAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegionAdd.Image = global::CruiseSearchAdmin.Properties.Resources.add;
            this.btnRegionAdd.Location = new System.Drawing.Point(572, 13);
            this.btnRegionAdd.Name = "btnRegionAdd";
            this.btnRegionAdd.Size = new System.Drawing.Size(33, 25);
            this.btnRegionAdd.TabIndex = 15;
            this.btnRegionAdd.UseVisualStyleBackColor = true;
            this.btnRegionAdd.Click += new System.EventHandler(this.btnRegionAdd_Click);
            // 
            // FormRedactorRegeon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 519);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDoun);
            this.Controls.Add(this.btnRegionEdit);
            this.Controls.Add(this.btnRegionRemove);
            this.Controls.Add(this.btnRegionAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbRegion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRedactorRegeon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регионы плавания";
            this.cmsRegion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbRegion;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRegionEdit;
        private System.Windows.Forms.Button btnRegionRemove;
        private System.Windows.Forms.Button btnRegionAdd;
        private System.Windows.Forms.ContextMenuStrip cmsRegion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddRegion;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddPodRegeon;
        private System.Windows.Forms.Button btnDoun;
        private System.Windows.Forms.Button btnUp;

    }
}