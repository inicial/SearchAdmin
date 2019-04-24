namespace CruiseSearchAdmin.Forms.HandCruises
{
    partial class FormAddHandSteps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddHandSteps));
            this.dtActivity = new System.Windows.Forms.DateTimePicker();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.tbTimeArrival = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTimeDepature = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.clbDayType = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // dtActivity
            // 
            this.dtActivity.Location = new System.Drawing.Point(12, 33);
            this.dtActivity.Name = "dtActivity";
            this.dtActivity.Size = new System.Drawing.Size(199, 20);
            this.dtActivity.TabIndex = 0;
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(11, 72);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(200, 21);
            this.cbPort.TabIndex = 1;
            // 
            // tbTimeArrival
            // 
            this.tbTimeArrival.Location = new System.Drawing.Point(224, 33);
            this.tbTimeArrival.Mask = "90:00";
            this.tbTimeArrival.Name = "tbTimeArrival";
            this.tbTimeArrival.Size = new System.Drawing.Size(44, 20);
            this.tbTimeArrival.TabIndex = 2;
            this.tbTimeArrival.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Дата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Порт";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Время захода";
            // 
            // tbTimeDepature
            // 
            this.tbTimeDepature.Location = new System.Drawing.Point(224, 73);
            this.tbTimeDepature.Mask = "90:00";
            this.tbTimeDepature.Name = "tbTimeDepature";
            this.tbTimeDepature.Size = new System.Drawing.Size(44, 20);
            this.tbTimeDepature.TabIndex = 6;
            this.tbTimeDepature.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Время выхода\r\n";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 429);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(458, 429);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Тип дня:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Описание";
            // 
            // rtbDescription
            // 
            this.rtbDescription.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbDescription.Location = new System.Drawing.Point(11, 185);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(521, 238);
            this.rtbDescription.TabIndex = 13;
            this.rtbDescription.Text = "";
            // 
            // clbDayType
            // 
            this.clbDayType.FormattingEnabled = true;
            this.clbDayType.Location = new System.Drawing.Point(324, 33);
            this.clbDayType.Name = "clbDayType";
            this.clbDayType.Size = new System.Drawing.Size(202, 139);
            this.clbDayType.TabIndex = 14;
            // 
            // FormAddHandSteps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 464);
            this.Controls.Add(this.clbDayType);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTimeDepature);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTimeArrival);
            this.Controls.Add(this.cbPort);
            this.Controls.Add(this.dtActivity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddHandSteps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtActivity;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.MaskedTextBox tbTimeArrival;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbTimeDepature;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.CheckedListBox clbDayType;
    }
}