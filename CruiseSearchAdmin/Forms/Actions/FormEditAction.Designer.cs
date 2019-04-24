namespace CruiseSearchAdmin
{
    partial class FormEditAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditAction));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tbText = new System.Windows.Forms.TextBox();
            this.gbVisible = new System.Windows.Forms.GroupBox();
            this.btnSetVisMask = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpActEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpActBeg = new System.Windows.Forms.DateTimePicker();
            this.chbIsUnlim = new System.Windows.Forms.CheckBox();
            this.gbVisible.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Location = new System.Drawing.Point(128, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOK.Location = new System.Drawing.Point(209, 365);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(107, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ссылка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(105, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название";
            // 
            // tbUrl
            // 
            this.tbUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbUrl.Location = new System.Drawing.Point(7, 84);
            this.tbUrl.Multiline = true;
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(260, 84);
            this.tbUrl.TabIndex = 1;
            // 
            // tbText
            // 
            this.tbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbText.Location = new System.Drawing.Point(7, 41);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(260, 20);
            this.tbText.TabIndex = 0;
            // 
            // gbVisible
            // 
            this.gbVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVisible.Controls.Add(this.btnSetVisMask);
            this.gbVisible.Location = new System.Drawing.Point(10, 295);
            this.gbVisible.Name = "gbVisible";
            this.gbVisible.Size = new System.Drawing.Size(274, 64);
            this.gbVisible.TabIndex = 7;
            this.gbVisible.TabStop = false;
            this.gbVisible.Text = "Видимость";
            // 
            // btnSetVisMask
            // 
            this.btnSetVisMask.Location = new System.Drawing.Point(5, 19);
            this.btnSetVisMask.Name = "btnSetVisMask";
            this.btnSetVisMask.Size = new System.Drawing.Size(258, 33);
            this.btnSetVisMask.TabIndex = 11;
            this.btnSetVisMask.Text = "Область видимости";
            this.btnSetVisMask.UseVisualStyleBackColor = true;
            this.btnSetVisMask.Click += new System.EventHandler(this.btnSetVisMask_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbText);
            this.groupBox1.Controls.Add(this.tbUrl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 185);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тематика";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpActEnd);
            this.groupBox2.Controls.Add(this.dtpActBeg);
            this.groupBox2.Controls.Add(this.chbIsUnlim);
            this.groupBox2.Location = new System.Drawing.Point(10, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 86);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Период действия";
            // 
            // dtpActEnd
            // 
            this.dtpActEnd.Location = new System.Drawing.Point(142, 51);
            this.dtpActEnd.Name = "dtpActEnd";
            this.dtpActEnd.Size = new System.Drawing.Size(128, 20);
            this.dtpActEnd.TabIndex = 2;
            this.dtpActEnd.ValueChanged += new System.EventHandler(this.dtpValueChanged);
            // 
            // dtpActBeg
            // 
            this.dtpActBeg.Location = new System.Drawing.Point(9, 51);
            this.dtpActBeg.Name = "dtpActBeg";
            this.dtpActBeg.Size = new System.Drawing.Size(128, 20);
            this.dtpActBeg.TabIndex = 1;
            this.dtpActBeg.ValueChanged += new System.EventHandler(this.dtpValueChanged);
            // 
            // chbIsUnlim
            // 
            this.chbIsUnlim.AutoSize = true;
            this.chbIsUnlim.Location = new System.Drawing.Point(7, 19);
            this.chbIsUnlim.Name = "chbIsUnlim";
            this.chbIsUnlim.Size = new System.Drawing.Size(86, 17);
            this.chbIsUnlim.TabIndex = 0;
            this.chbIsUnlim.Text = "Бессрочная";
            this.chbIsUnlim.UseVisualStyleBackColor = true;
            this.chbIsUnlim.CheckedChanged += new System.EventHandler(this.chbIsUnlim_CheckedChanged);
            // 
            // FormEditAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbVisible);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditAction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Круизная тематика";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEditAction_KeyDown);
            this.gbVisible.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbVisible;
        private System.Windows.Forms.Button btnSetVisMask;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpActEnd;
        private System.Windows.Forms.DateTimePicker dtpActBeg;
        private System.Windows.Forms.CheckBox chbIsUnlim;
    }
}