using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms
{
    public partial class FormSeaPortsParent : ProjectForm
    {
        internal int? parentID = null;
        internal string parentName;
        private List<Seaport> _seaPorts;
        private DataTable _tbSource;
        public FormSeaPortsParent(List<Seaport> _sPorts, DataTable dt)
        {
            InitializeComponent();
            _seaPorts = _sPorts;
            _tbSource = dt;

            cbRegions.DisplayMember = "name";
            cbRegions.ValueMember = "id";
            cbRegions.DataSource = _tbSource;

            dgvSeaPorts.DataSource = _seaPorts;
           
        }

        static public bool GetParentPortID(out int? id,out string parentName,List<Seaport> _seaPorts,DataTable dt)
        {
            using (var f = new FormSeaPortsParent(_seaPorts,dt))
            {
                id = null;
                parentName = null;
                if(f.ShowDialog()==DialogResult.OK)
                {
                    if (f.parentID == 0) return false;
                    id = f.parentID;
                    parentName = f.parentName;
                    return true;
                }
                return false;
            }
        }
        void RefreshDataGrid()
        {
            //dgvSeaPorts.DataSource = _seaPorts;
            foreach (DataGridViewColumn column in dgvSeaPorts.Columns)
            {
                var c = column.Name.ToLower();
                switch (c)
                {
                    case "name":
                        {
                            column.HeaderText = "Порт";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }break;
                   
                    default:
                        column.Visible = false;
                        break;
                }
                 
            }
            dgvSeaPorts.Invalidate();
        }

        private void dgvSeaPorts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Point p = new Point(e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 5);
            e.Graphics.DrawString(e.RowIndex.ToString(), dgvSeaPorts.Font, Brushes.Black, p);
        }

        private void cbRegions_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            ApplyFilter();
        }
        void ApplyFilter()
        {
            var filteredList = _seaPorts.ToList();
            if(cbRegions.SelectedValue!=DBNull.Value)
            {
                if(Convert.ToInt32(cbRegions.SelectedValue) != 0)
                {
                    filteredList =
                        filteredList.Where(sp => sp.RegionID == Convert.ToInt32(cbRegions.SelectedValue)).ToList();
                }
            }
            else
            {
                filteredList = filteredList.Where(sp => sp.RegionID == null).ToList();
            }
            if(tbNameFilter.Text!=string.Empty)
            {
                filteredList = filteredList.Where(sp => sp.Name.ToLower().Contains(tbNameFilter.Text.ToLower())).ToList();
            }
            dgvSeaPorts.DataSource = filteredList;
            RefreshDataGrid();
        }

        private void tbNameFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void dgvSeaPorts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSeaPorts.SelectedRows.Count < 1) return;
            Seaport port = dgvSeaPorts.SelectedRows[0].DataBoundItem as Seaport;
            parentID = port.ID;
            parentName = port.Name;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormSeaPortsParent_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
    }
}
