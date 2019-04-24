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

namespace CruiseSearchAdmin.Forms.Excursions
{
    public partial class FormSelectPort : ProjectForm
    {
        private List<Seaport> _seaPorts = new List<Seaport>();
        private Seaport _port = null;
        public FormSelectPort()
        {
            InitializeComponent();
            GetData();
        }
        void GetData()
        {
            var portsTable = WorkWithData.GetSeaPortsTable(WorkWithData.TsConnection);
            _seaPorts.AddRange(from DataRow row in portsTable.Rows select new Seaport(row));
            _seaPorts.RemoveAll(sp => sp.CruiseLineID != null || sp.ParentID != null);
            dgvPorts.DataSource = _seaPorts;
            SetSeaPortsGrid();
        }
        public static Seaport SelectSeaPort()
        {
            using(var f = new FormSelectPort())
            {
                
                if (f.ShowDialog() != System.Windows.Forms.DialogResult.OK) return null;
                return f._port;
            }
        }
        void SetSeaPortsGrid()
        {
            foreach (DataGridViewColumn column in dgvPorts.Columns)
            {
                var n = column.Name.ToLower();
                switch (n)
                {
                    case "name":
                        {
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.HeaderText = "Порт";
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

        private void tbPortNameFilter_TextChanged(object sender, EventArgs e)
        {
            var tbName = (sender as TextBox);
            dgvPorts.DataSource = tbName.Text.Equals(string.Empty) ? _seaPorts : _seaPorts.Where(sp => sp.Name.ToLower().Contains(tbName.Text.ToLower())).ToList();
            SetSeaPortsGrid();
        }

       

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_port == null) 
                { 
                Messages.Error("Сначала вы должны выбрать порт");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvPorts_SelectionChanged(object sender, EventArgs e)
        {
            var rows = (sender as DataGridView).SelectedRows;
            if(rows.Count<1) return;
            var sp = rows[0].DataBoundItem as Seaport;
            _port = sp;
        }

        private void dgvPorts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dgv = sender as DataGridView;
            if (dgv == null) return;
            var sp = dgv.Rows[e.RowIndex].DataBoundItem as Seaport;
            _port = sp;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
