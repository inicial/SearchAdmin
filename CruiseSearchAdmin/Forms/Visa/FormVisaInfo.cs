using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.DataBaseEntities;
using CruiseSearchAdmin.Forms.CountryForSeaports;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Visa
{
    public partial class FormVisaInfo : ProjectForm
    {
        private VisaDataContext _visaDataContext;
        public FormVisaInfo()
        {
            InitializeComponent();
            dgvVisas.ReadOnly = true;
        }
        public static void ShowVisasInfo()
        {
            using (var f = new FormVisaInfo())
            {
                f.FillDataGrid();
                f.ShowDialog();
            }
        }

        private void FillDataGrid()
        {
            _visaDataContext = new VisaDataContext(WorkWithData.MasterConnection);
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            var source = _visaDataContext.GetVisasFullInfo();

            dgvVisas.DataSource = source;
// ReSharper disable PossibleNullReferenceException
            dgvVisas.Columns["Visa"].Visible = false;
            dgvVisas.Columns["ServiceName"].MinimumWidth = 120;
            dgvVisas.Columns["ServiceName"].HeaderText = @"Услуга";
            dgvVisas.Columns["Country"].HeaderText = @"Страна";
            dgvVisas.Columns["IsShengen"].HeaderText = @"Шенген";
            dgvVisas.Columns["Disabled"].HeaderText = @"Отключена";
            dgvVisas.Columns["Partner"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvVisas.Columns["Partner"].HeaderText = @"Партнер";
            dgvVisas.Columns["crline"].HeaderText = @"Круизная компания";
            dgvVisas.Columns["user"].HeaderText = @"Менеджер";
            dgvVisas.Columns["Date"].HeaderText = @"Дата до";
            dgvVisas.Columns["Date"].DefaultCellStyle.Format = "dd.MM.yy";
// ReSharper restore PossibleNullReferenceException
        }

        private void dgvVisas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // ReSharper disable PossibleNullReferenceException
            DataBaseEntities.lanta_visa_dna visa = (sender as DataGridView)["Visa", e.RowIndex].Value as DataBaseEntities.lanta_visa_dna;
            // ReSharper restore PossibleNullReferenceException
            if(!FormVisaEdit.EditVisa(_visaDataContext,visa))return;
            _visaDataContext.SubmitChanges();
            FillDataGrid();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVisas.SelectedRows.Count<1) return;
            DataBaseEntities.lanta_visa_dna visa = dgvVisas.SelectedRows[0].Cells["Visa"].Value as DataBaseEntities.lanta_visa_dna;
            if(!Messages.Question(string.Format("Удалить выбранный элемент?")))return;
            _visaDataContext.lanta_visa_dnas.DeleteOnSubmit(visa);
            _visaDataContext.SubmitChanges();
            FillDataGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataBaseEntities.lanta_visa_dna visa = new  DataBaseEntities.lanta_visa_dna();
            if (!FormVisaEdit.EditVisa(_visaDataContext, visa)) return;
            _visaDataContext.SubmitChanges();
            FillDataGrid();
        }

        private void btnSeaPorts_Click(object sender, EventArgs e)
        {
            SeaportsVisa frm = new SeaportsVisa();
            frm.ShowDialog();
        }

    }
}
