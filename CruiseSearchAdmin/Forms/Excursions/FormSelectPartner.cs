using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Excursions
{
    public partial class FormSelectPartner : ProjectForm
    {
        List<Partner> _partners = new List<Partner>();
        private int _prKey;
        private string _prName;
        
        public FormSelectPartner()
        {
            InitializeComponent();
            GetData();
        }
        static public bool SelectPartner(out int prKey,out string prName)
        {
            using(var f = new FormSelectPartner())
            {
                prKey = -1;
                prName = string.Empty;
                if (f.ShowDialog() != DialogResult.OK) return false;
                prKey = f._prKey;
                prName = f._prName;
                return true;
            }
        }
        void GetData()
        {
            foreach (DataRow row in WorkWithData.GetDataTable(@"SELECT PR_KEY,PR_FULLNAME FROM partners where PR_KEY in (select PTP_PRkey from PrtTypesToPartners  where PTP_PTId in (4,5)) ORDER BY PR_FULLNAME",WorkWithData.MasterConnection).Rows)
            {
                _partners.Add(new Partner() {Key = row.Field<int>(0), Value = row[1].ToString()});
            }
            
            dgvPartners.DataSource = _partners;
            SetPartnersGrid();
        }
        void SetPartnersGrid()
        {
            foreach (DataGridViewColumn column in dgvPartners.Columns)
            {
                var n = column.Name.ToLower();
                switch (n)
                {
                    case "value":
                        {
                            column.HeaderText = "Наименование";
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(dgvPartners.SelectedRows.Count<1)
            {
                Messages.Error("Сначала выбирете партнера");
                return;
            }
            var pr = (Partner)dgvPartners.SelectedRows[0].DataBoundItem;
            _prKey = pr.Key;
            _prName = pr.Value;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tbPartnerName_TextChanged(object sender, EventArgs e)
        {
            var tbName = (sender as TextBox);
            dgvPartners.DataSource = tbName.Text.Equals(string.Empty)
                                         ? _partners
                                         : _partners.Where(p => p.Value.ToLower().Contains(tbName.Text.ToLower())).ToList();
            SetPartnersGrid();
        }
    }
    struct Partner
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
