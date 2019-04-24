using System;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Forms.Excursions.Dates;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Excursions
{
    public partial class FormPartnerExcursions : ProjectForm
    {
        
        private ExcursionsCollection _excursions;
        private Excursion _excursion;
        public FormPartnerExcursions()
        {
            InitializeComponent();
        }
        static public void GetPartnerExcursions(Excursion excursion,ExcursionsCollection excursions)
        {
            using(var f= new FormPartnerExcursions())
            {
                f._excursion = excursion;
                f._excursions = excursions;
                f.ShowDialog();
            }
        }
        private void GetData()
        {
            _excursion.PartnerExcursions.GetPartnerExcursions(WorkWithData.TsConnection);
            //_partnerExcursions.AddRange(from DataRow row in WorkWithData.GetPartnerExcursions().Rows where row.Field<int?>("EX_UID")==_exId select new PartnerExcursion(row));
        }

        private void FormPartnerExcursions_Load(object sender, EventArgs e)
        {
            GetData();
            UpdateDgv();
        }
        void UpdateDgv()
        {
            dgvPartnerExcursions.DataSource = new BindingSource(_excursion.PartnerExcursions, null);
            tbExcursion.Text = _excursion.Text;
            SetPartnerExcursionsGrid();
        }
        void SetPartnerExcursionsGrid()
        {
            foreach (DataGridViewColumn column in dgvPartnerExcursions.Columns)
            {
                var n = column.Name.ToLower();
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                switch(n)
                {
                    case "partnername":
                        {
                            column.HeaderText = "Партнер";
                            column.MinimumWidth = 180;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        break;
                    case "clname":
                        {
                            column.HeaderText = "Круизная компания";
                            column.MinimumWidth = 180;
                        }
                        break;
                    default:
                        {
                            column.Visible = false;
                        }
                        break;
                }
            }
        }

        private void btnEditPartnerExcursion_Click(object sender, EventArgs e)
        {
            if(dgvPartnerExcursions.SelectedRows.Count<1)
            {
                Messages.Error("Сначала следует выбрать пратнера");
                return;
            }
            var pExcursion = dgvPartnerExcursions.SelectedRows[0].DataBoundItem as PartnerExcursion;
            if (pExcursion == null)
            {
                Messages.Error("Не удалось выбрать партнера");
                return;
            }
            if (!FormEditPartnerExcursion.EditPartnerExcursion(pExcursion, _excursions, _excursion.PartnerExcursions)) return;
            pExcursion.UpdatePartnerExcursion(WorkWithData.TsConnection);
            GetData();
            UpdateDgv();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemovePartnerExcursion_Click(object sender, EventArgs e)
        {
            
            if (dgvPartnerExcursions.SelectedRows.Count < 1)
            {
                Messages.Error("Сначала следует выбрать пратнера");
                return;
            }
            var pExcursion = dgvPartnerExcursions.SelectedRows[0].DataBoundItem as PartnerExcursion;
             if (pExcursion == null)
            {
                Messages.Error("Не удалось выбрать партнера");
                return;
            }
             if (!Messages.Question("Вы действительно хотите удалить " + pExcursion.PartnerName + "?")) return;
             pExcursion.DeletePartnerExcursion(WorkWithData.TsConnection);
             GetData();
             UpdateDgv();
        }

        private void btnAddPartnerExcursion_Click(object sender, EventArgs e)
        {
            var pExcursion = new PartnerExcursion {ExUid = _excursion.ID, ExName = _excursion.Text};
            pExcursion.InsertPartnerExcursion(WorkWithData.TsConnection);
            GetData();
            UpdateDgv();
            pExcursion = dgvPartnerExcursions.Rows[dgvPartnerExcursions.Rows.Count - 1].DataBoundItem as PartnerExcursion;
            if (!FormEditPartnerExcursion.EditPartnerExcursion(pExcursion, _excursions, _excursion.PartnerExcursions)) pExcursion.DeletePartnerExcursion(WorkWithData.TsConnection);
            if (pExcursion == null) return;
            pExcursion.UpdatePartnerExcursion(WorkWithData.TsConnection);
            GetData();
            UpdateDgv();
        }

        private void dgvPartnerExcursions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Hide();
            FormExcursionDatesList.GetDates((((DataGridView) sender).Rows[e.RowIndex].DataBoundItem as PartnerExcursion));
            //FormExcursionDates.SetExcursionDates(((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as PartnerExcursion); 
            Show();
        }
    }
}
