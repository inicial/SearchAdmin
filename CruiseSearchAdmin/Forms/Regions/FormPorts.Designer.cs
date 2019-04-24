namespace CruiseSearchAdmin.Forms.Regions
{
    partial class FormPorts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPorts));
            this.btbCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.LbPort = new System.Windows.Forms.ListBox();
            this.tbFilterPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btbCancel
            // 
            this.btbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btbCancel.Location = new System.Drawing.Point(514, 382);
            this.btbCancel.Name = "btbCancel";
            this.btbCancel.Size = new System.Drawing.Size(87, 32);
            this.btbCancel.TabIndex = 0;
            this.btbCancel.Text = "Назад";
            this.btbCancel.UseVisualStyleBackColor = true;
            this.btbCancel.Click += new System.EventHandler(this.btbCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(14, 382);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 32);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // LbPort
            // 
            this.LbPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbPort.FormattingEnabled = true;
            this.LbPort.ItemHeight = 15;
            this.LbPort.Location = new System.Drawing.Point(14, 44);
            this.LbPort.Name = "LbPort";
            this.LbPort.Size = new System.Drawing.Size(587, 319);
            this.LbPort.TabIndex = 2;
            // 
            // tbFilterPort
            // 
            this.tbFilterPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilterPort.Location = new System.Drawing.Point(14, 13);
            this.tbFilterPort.Name = "tbFilterPort";
            this.tbFilterPort.Size = new System.Drawing.Size(587, 21);
            this.tbFilterPort.TabIndex = 3;
            this.tbFilterPort.TextChanged += new System.EventHandler(this.tbFilterPort_TextChanged);
            // 
            // FormPorts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 426);
            this.Controls.Add(this.tbFilterPort);
            this.Controls.Add(this.LbPort);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btbCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPorts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Порты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btbCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox LbPort;
        private System.Windows.Forms.TextBox tbFilterPort;
    }
}