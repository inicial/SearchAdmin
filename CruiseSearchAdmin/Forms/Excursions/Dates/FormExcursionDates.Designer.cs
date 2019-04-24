namespace CruiseSearchAdmin.Forms.Excursions.Dates
{
    partial class FormExcursionDates
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
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExcursionDates));
            this.dxssExcursions = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbCruiseLine = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPartner = new System.Windows.Forms.TextBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dxscExcursions = new DevExpress.XtraScheduler.SchedulerControl();
            this.btnDatesList = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dxssExcursions)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxscExcursions)).BeginInit();
            this.SuspendLayout();
            // 
            // dxssExcursions
            // 
            this.dxssExcursions.AppointmentInserting += new DevExpress.XtraScheduler.PersistentObjectCancelEventHandler(this.dxssExcursions_AppointmentInserting);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbCruiseLine);
            this.groupBox3.Location = new System.Drawing.Point(508, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(261, 52);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Круизная компания";
            // 
            // tbCruiseLine
            // 
            this.tbCruiseLine.Location = new System.Drawing.Point(6, 19);
            this.tbCruiseLine.Name = "tbCruiseLine";
            this.tbCruiseLine.ReadOnly = true;
            this.tbCruiseLine.Size = new System.Drawing.Size(249, 20);
            this.tbCruiseLine.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbPartner);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 52);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Партнер";
            // 
            // tbPartner
            // 
            this.tbPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPartner.Location = new System.Drawing.Point(6, 19);
            this.tbPartner.Name = "tbPartner";
            this.tbPartner.ReadOnly = true;
            this.tbPartner.Size = new System.Drawing.Size(478, 20);
            this.tbPartner.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(604, 527);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(694, 527);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "ОК";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dxscExcursions);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 451);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Календарь";
            // 
            // dxscExcursions
            // 
            this.dxscExcursions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dxscExcursions.Location = new System.Drawing.Point(3, 16);
            this.dxscExcursions.LookAndFeel.SkinName = "Metropolis";
            this.dxscExcursions.Name = "dxscExcursions";
            this.dxscExcursions.Size = new System.Drawing.Size(754, 432);
            this.dxscExcursions.Start = new System.DateTime(2013, 4, 3, 0, 0, 0, 0);
            this.dxscExcursions.Storage = this.dxssExcursions;
            this.dxscExcursions.TabIndex = 0;
            this.dxscExcursions.Text = "Календарь экскурсий";
            timeRuler1.TimeZone.DaylightBias = System.TimeSpan.Parse("-01:00:00");
            timeRuler1.TimeZone.DaylightZoneName = "Московское время (лето)";
            timeRuler1.TimeZone.DisplayName = "(UTC+04:00) Волгоград, Москва, Санкт-Петербург";
            timeRuler1.TimeZone.StandardZoneName = "Московское время (зима)";
            timeRuler1.TimeZone.UtcOffset = System.TimeSpan.Parse("04:00:00");
            timeRuler1.UseClientTimeZone = false;
            this.dxscExcursions.Views.DayView.TimeRulers.Add(timeRuler1);
            this.dxscExcursions.Views.GanttView.Enabled = false;
            this.dxscExcursions.Views.MonthView.CompressWeekend = false;
            this.dxscExcursions.Views.MonthView.DisplayName = "Календарь";
            this.dxscExcursions.Views.MonthView.NavigationButtonVisibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.dxscExcursions.Views.TimelineView.Enabled = false;
            this.dxscExcursions.Views.WeekView.Enabled = false;
            this.dxscExcursions.Views.WorkWeekView.Enabled = false;
            timeRuler2.TimeZone.DaylightBias = System.TimeSpan.Parse("-01:00:00");
            timeRuler2.TimeZone.DaylightZoneName = "Московское время (лето)";
            timeRuler2.TimeZone.DisplayName = "(UTC+04:00) Волгоград, Москва, Санкт-Петербург";
            timeRuler2.TimeZone.StandardZoneName = "Московское время (зима)";
            timeRuler2.TimeZone.UtcOffset = System.TimeSpan.Parse("04:00:00");
            timeRuler2.UseClientTimeZone = false;
            this.dxscExcursions.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.dxscExcursions.PopupMenuShowing += new DevExpress.XtraScheduler.PopupMenuShowingEventHandler(this.dxscExcursions_PopupMenuShowing);
            this.dxscExcursions.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.dxscExcursions_EditAppointmentFormShowing);
            // 
            // btnDatesList
            // 
            this.btnDatesList.Location = new System.Drawing.Point(12, 527);
            this.btnDatesList.Name = "btnDatesList";
            this.btnDatesList.Size = new System.Drawing.Size(75, 30);
            this.btnDatesList.TabIndex = 6;
            this.btnDatesList.Text = "Списком";
            this.btnDatesList.Click += new System.EventHandler(this.btnDatesList_Click);
            // 
            // FormExcursionDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnDatesList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormExcursionDates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Даты экскурсий";
            this.Load += new System.EventHandler(this.FormExcursionDates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxssExcursions)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxscExcursions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl dxscExcursions;
        private DevExpress.XtraScheduler.SchedulerStorage dxssExcursions;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbPartner;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbCruiseLine;
        private DevExpress.XtraEditors.SimpleButton btnDatesList;

    }
}