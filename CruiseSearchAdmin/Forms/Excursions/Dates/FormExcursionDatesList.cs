using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Excursions.Dates
{
    public partial class FormExcursionDatesList : ProjectForm
    {
        //private List<DateTime> _dates;
       // List<DateTime> _tmpDates;
        private PartnerExcursion _partnerExcursions;
        public FormExcursionDatesList()
        {
            InitializeComponent();
        }
        public static bool GetDates(PartnerExcursion partnerEcxursion)
        {
            using(var f = new FormExcursionDatesList())
            {
                //f._tmpDates = partnerEcxursion.Dates;
                partnerEcxursion.GetDates(WorkWithData.TsConnection);
                f.dtpExDate.Value = DateTime.Now.Date;
                f.tbPartner.Text = partnerEcxursion.PartnerName;
                f.tbCruiseLine.Text = !partnerEcxursion.ClName.Equals(string.Empty) ? partnerEcxursion.ClName : "Нет";
                f._partnerExcursions = partnerEcxursion;
                if(f.ShowDialog() != DialogResult.OK)return false;
                return true;
            }
        }

        private void FormExcursionDatesList_Load(object sender, EventArgs e)
        {
            _partnerExcursions.Dates.OrderBy(d => d.Date);
            lbDates.Items.AddRange(_partnerExcursions.Dates.Select(d => d.ToString("dd MMMM yyyy HH:mm")).ToArray()); 
        }

        private void btnAddDate_Click(object sender, EventArgs e)
        {
            var addingDate = dtpExDate.Value;//dxdeDate.DateTime.Date; 
            if (_partnerExcursions.Dates.Contains(addingDate)) return;
            addingDate = addingDate.AddSeconds(-addingDate.Second);
            _partnerExcursions.Dates.Add(addingDate);
            lbDates.Items.Clear();
            _partnerExcursions.Dates.OrderBy(d => d.Date);
            lbDates.Items.AddRange(_partnerExcursions.Dates.Select(d => d.ToString("dd MMMM yyyy HH:mm")).ToArray());
        }

        private void btnRemoveDate_Click(object sender, EventArgs e)
        {
            if(lbDates.SelectedIndex<0)
            {
                Messages.Error("Сначала нужно выбрать дату!");
                return;
            }
            var selectedDate = DateTime.Parse(lbDates.SelectedItem.ToString());
            lbDates.Items.Remove(lbDates.SelectedItem);
            _partnerExcursions.Dates.Remove(selectedDate);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            _partnerExcursions.UpdateDates(WorkWithData.TsConnection);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();}

        private void dxdeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Return)
            {
                btnAddDate_Click(btnAddDate,e);
            }
        }

        private void lbDates_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete)
            {
                btnRemoveDate_Click(btnRemoveDate,e);
            }
        }

        

        
       
    }
}
