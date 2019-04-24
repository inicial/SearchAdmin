using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.HelperClasses;
using DevExpress.XtraScheduler;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Excursions.Dates
{
    public partial class FormExcursionDates : ProjectForm
    {
        private PartnerExcursion _partnerExcursion;
        private bool isLoad = true;
        public FormExcursionDates()
        {
            InitializeComponent();
        }

        void GetPartnerExcursionDates()
        {
            _partnerExcursion.GetDates(WorkWithData.TsConnection);
          
            foreach (DateTime date in _partnerExcursion.Dates)
            {
                dxscExcursions.ShowEditAppointmentForm(new Appointment(date, date.AddDays(1).AddHours(-date.Hour)));
            }
            isLoad = false;
        }

        public static void SetExcursionDates(PartnerExcursion partnerExcursion)
        {
            using (var f = new FormExcursionDates())
            {
                f._partnerExcursion = partnerExcursion;
                f.dxscExcursions.ActiveViewType = SchedulerViewType.Month;
                f.dxscExcursions.Views.DayView.Enabled = false;
                f.tbPartner.Text = partnerExcursion.PartnerName;
                f.tbCruiseLine.Text = !partnerExcursion.ClName.Equals(string.Empty) ? partnerExcursion.ClName : "Нет";
                f.ShowDialog();
            }
        }

        private void dxscExcursions_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.OpenAppointment);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.EditSeries);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.RestoreOccurrence);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
            }
            if (e.Menu.Id != SchedulerMenuItemId.DefaultMenu) return;
            SchedulerPopupMenu itemChangeViewTo = e.Menu.GetPopupMenuById(SchedulerMenuItemId.SwitchViewMenu);
            itemChangeViewTo.Visible = false;
            //Add new menuitem
            SchedulerMenuItem setDate = new SchedulerMenuItem("Назначить/отменить экскурсию", SetDateHandler);
            e.Menu.Items.Insert(0, setDate);
            //Remove unnecessary items.
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAppointment);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringAppointment);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent);
            e.Menu.RemoveMenuItem(SchedulerMenuItemId.SwitchToGroupByResource);
        }
        public void SetDateHandler(object sender, EventArgs e)
        {
            TimeInterval SelectedTimeIntervals = dxscExcursions.ActiveView.SelectedInterval;

            for (int i = 0; i < SelectedTimeIntervals.Duration.Days; i++)
            {
                DateTime excDate = SelectedTimeIntervals.Start.AddDays(i);
                var excur = new Appointment(excDate, excDate.AddDays(1));
                dxscExcursions.ShowEditAppointmentForm(excur);
            }

        }

        private void dxscExcursions_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            Appointment excursionDate = e.Appointment;
            excursionDate.Subject = "Экскурсия";
            var isExcurExist = false;
            for (int i = 0; i < dxssExcursions.Appointments.Count; i++)
            {
                var apt = dxssExcursions.Appointments[i];
                if (apt.Start == excursionDate.Start)
                {
                    isExcurExist = true;
                    dxssExcursions.Appointments.Remove(dxssExcursions.Appointments[i]);
                    break;
                }
            }
            if (!isExcurExist)
            {
                if (!isLoad)
                {
                    //FormSetTime.GetTime(ref excursionDate.Start);
                }
                dxssExcursions.Appointments.Add(excursionDate);
            }

            dxscExcursions.Refresh();
            e.Handled = true;
            
        }

        private void FormExcursionDates_Load(object sender, EventArgs e)
        {
            GetPartnerExcursionDates();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _partnerExcursion.Dates.Clear();
            _partnerExcursion.Dates.AddRange((from apt in dxssExcursions.Appointments.Items select apt.Start.Date).ToList());
            if(_partnerExcursion.Uid==null||_partnerExcursion.Uid==-1) return;
            if (!_partnerExcursion.UpdateDates(WorkWithData.TsConnection))
            {
                Messages.Error("Обновление дат не удалось");
                return;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dxssExcursions_AppointmentInserting(object sender, PersistentObjectCancelEventArgs e)
        {
            var a = e.Object as Appointment;
            a.Subject = "Экскурсия";
        }

        private void btnDatesList_Click(object sender, EventArgs e)
        {
            var dates = dxssExcursions.Appointments.Items.Select(i => i.Start).ToList();
            //if(!FormExcursionDatesList.GetDates(_partnerExcursion.PartnerName, _partnerExcursion.ClName,ref dates))return;
            dxssExcursions.Appointments.Clear();
            foreach (var date in dates)
            {
                dxscExcursions.ShowEditAppointmentForm(new Appointment(date.Date, date.AddDays(1)));
            }
        }

        
    }
}
