using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Forms.CountryForSeaports;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms
{
    public partial class FormSeaPorts : ProjectForm
    {
        
        private List<Seaport> _seaPorts = new List<Seaport>();
        private List<Seaport> _display;
        private DataTable _tbcrLines, _tbRegion;
        private FormSeaPorts()
        {
            InitializeComponent();
            Init();
        }
        public static void EditSeaPorts()
        {
            using (var f = new FormSeaPorts())
            {
                f.ShowDialog();
            }
        }
        void Init()
        {

            var _seaPortsTable = WorkWithData.GetSeaPortsTable(WorkWithData.TsConnection);
            foreach (DataRow dataRow in _seaPortsTable.Rows)
            {
                _seaPorts.Add(new Seaport(dataRow));
            }

            cbRegions.DisplayMember = "name";
            cbRegions.ValueMember = "id";
            _tbRegion = WorkWithData.GetSeaportRegionsTable();
            var row = _tbRegion.NewRow();
            row["name"] = "All";
            row["id"] = 0;
            _tbRegion.Rows.InsertAt(row, 0);
            row = _tbRegion.NewRow();
            row["name"] = "Без региона";
            row["id"] = DBNull.Value;
            _tbRegion.Rows.InsertAt(row, 1);
            cbRegions.DataSource = _tbRegion;
            

            cbCruiseLine.DisplayMember = "name_en";
            cbCruiseLine.ValueMember = "id";
            _tbcrLines = WorkWithData.GetDataTable(@"select * from CruiseLines order by name_en",WorkWithData.TsConnection);//GetCruiseLinesTable();
            row = _tbcrLines.NewRow();
            row["name_en"] = "All";
            row["id"] = 0;
            _tbcrLines.Rows.InsertAt(row, 0);
            row = _tbcrLines.NewRow();
            row["name_en"] = "Без компании";
            row["id"] = DBNull.Value;
            _tbcrLines.Rows.InsertAt(row, 1);
            cbCruiseLine.DataSource = _tbcrLines;

            cbItemCrLine.DisplayMember = "name_en";
            cbItemCrLine.ValueMember = "id";
            var dt = _tbcrLines.Copy();
            dt.Rows.RemoveAt(0);
            cbItemCrLine.DataSource = dt;

            cbItemRegion.DisplayMember = "name";
            cbItemRegion.ValueMember = "id";
            var regDT = _tbRegion.Copy();
            regDT.Rows.RemoveAt(0);
            cbItemRegion.DataSource = regDT;
        }
        void RefreshDataGrid()
        {
            if (_display == null)
            {
                _display = _seaPorts;}
            dgvSeaPorts.DataSource = _display;
            foreach (DataGridViewColumn column in dgvSeaPorts.Columns)
            {
                var c = column.Name.ToLower();
                switch (c)
                {
                    case "name_ru":
                        {
                            column.HeaderText = "Русское название";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.MinimumWidth = 150;
                        } break;
                    
                    case "name":
                        {
                            column.HeaderText = "Английское название";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.MinimumWidth = 150;
                        }break;
                    case "cruiselinename":
                        {
                            column.HeaderText = "Компания";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.MinimumWidth = 150;
                        }
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }
            dgvSeaPorts.Invalidate();
        }

        private void cbCruiseLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        void ApplyFilter()
        {
            
            List<Seaport> filtredSource = _seaPorts.ToList();
            if (chbUnLinked.Checked) filtredSource = filtredSource.Where(sp => sp.ParentID == null && sp.CruiseLineID != null).ToList();
            if (cbRegions.SelectedValue != DBNull.Value)
            {
                if (Convert.ToInt32(cbRegions.SelectedValue) != 0)
                {
                    filtredSource =
                        filtredSource.Where(sp => sp.RegionID == Convert.ToInt32(cbRegions.SelectedValue)).ToList();
                }
            }
            else
            {
                filtredSource = filtredSource.Where(sp => sp.RegionID == null).ToList();
            }
            if(cbCruiseLine.SelectedValue != DBNull.Value)
            {
                if (Convert.ToInt32(cbCruiseLine.SelectedValue) != 0)
                {
                    filtredSource =
                        filtredSource.Where(sp => sp.CruiseLineID == Convert.ToInt32(cbCruiseLine.SelectedValue)).ToList
                            ();

                }
            }
            else
            {
                 filtredSource = filtredSource.Where(sp => sp.CruiseLineID == null).ToList();
            }
            if (tbNameFilter.Text != string.Empty)
            {
                filtredSource = filtredSource.Where(sp => sp.Name.ToLower().Contains(tbNameFilter.Text.ToLower())).ToList();
            }
            _display = filtredSource;
            RefreshDataGrid();
            if (dgvSeaPorts.RowCount < 1)
            {
                _selectedPort = null;
                tbParent.Text = string.Empty;
                tbName_en.Text = string.Empty;
                tbName_ru.Text = string.Empty;
                tbCode.Text = string.Empty;
                groupBox3.Enabled = false;

            }
            else
            {
                groupBox3.Enabled = true;
            }

        }

        private void cbRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        

        private void dgvSeaPorts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Point p = new Point(e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 5);
            e.Graphics.DrawString(e.RowIndex.ToString(), dgvSeaPorts.Font, Brushes.Black, p);
          
        }

        private void chbUnLinked_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private Seaport _selectedPort;
        private void dgvSeaPorts_SelectionChanged(object sender, EventArgs e)
        {
            CheckChanges();
                
            try
            {
                _selectedPort = dgvSeaPorts.SelectedRows[0].DataBoundItem as Seaport;
                if (_selectedPort == null) return;
               
                tbName_en.Text = _selectedPort.Name;
                tbName_ru.Text = _selectedPort.Name_ru;
                tbCode.Text = _selectedPort.Code;
                int idx = 0;
                if(_selectedPort.CruiseLineID!=null)
                foreach (DataRowView dataRow in cbItemCrLine.Items)
                {
                    if (dataRow["id"]==DBNull.Value)continue;
                    if (Convert.ToInt32(dataRow["id"]) == _selectedPort.CruiseLineID)
                        idx = cbItemCrLine.Items.IndexOf(dataRow);
                }
                cbItemCrLine.SelectedIndex = idx;
                idx = 0;
                if (_selectedPort.RegionID != null)
                    foreach (DataRowView dataRow in cbItemRegion.Items)
                    {
                        if (dataRow["id"] == DBNull.Value) continue;
                        if (Convert.ToInt32(dataRow["id"]) == _selectedPort.RegionID)
                            idx = cbItemRegion.Items.IndexOf(dataRow);
                    }
                cbItemRegion.SelectedIndex = idx;
                tbParent.Text = _selectedPort.ParentID == null ? string.Empty : _seaPorts.Find(sp => sp.ID == _selectedPort.ParentID).Name;
            }
            catch (Exception)
            {
                try
                {
                    tbName_en.Text = string.Empty;
                    tbCode.Text = string.Empty;
                    cbItemRegion.SelectedIndex = 0;
                    cbItemCrLine.SelectedIndex = 0;
                }
                catch 
                {
                }
                
                return;
            }
            
            
        }

        private void cbItemCrLine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbItemCrLine.SelectedValue==DBNull.Value)
            {   _selectedPort.CruiseLineID = null;
                _selectedPort.CruiseLineName = null;
            }else
            {
                _selectedPort.CruiseLineID = Convert.ToInt32(cbItemCrLine.SelectedValue);
                _selectedPort.CruiseLineName = cbItemCrLine.Text;
            }
            RefreshDataGrid();
        }

        private void tbPortName_Leave(object sender, EventArgs e)
        {
            _selectedPort.Name = tbName_en.Text;
            RefreshDataGrid();
        }

        private void tbCode_Leave(object sender, EventArgs e)
        {
            _selectedPort.Code = tbCode.Text;
        }

        private void cbItemRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbItemRegion.SelectedValue == DBNull.Value)
            {
                _selectedPort.RegionID = null;
            }
            else
            {
                _selectedPort.RegionID = Convert.ToInt32(cbItemRegion.SelectedValue);
            }
            RefreshDataGrid();
        }

        private void FormSeaPorts_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckChanges();
        }
        void CheckChanges()
        {
            if (dgvSeaPorts.RowCount < 1) { _selectedPort=null;  return; }
            if (_selectedPort != null)
            {
                if (_selectedPort.ItemState != EditState.None)
                {
                    {
                        if(_selectedPort.Name==string.Empty ||_selectedPort.Code==string.Empty)
                        {
                            _selectedPort.ResetChanges();
                            RefreshDataGrid();
                            return;
                        }
                    }

                    if (Messages.Question("Были внесены изменения, сохранить?"))
                    {
                        _selectedPort.Update(WorkWithData.TsConnection);
                        
                    }
                    else
                    {
                        _selectedPort.ResetChanges();
                        RefreshDataGrid();
                        
                    }
                }
            }
           
        }

        private void btnAddParent_Click(object sender, EventArgs e)
        {
            if (_selectedPort == null) return;
            int? id;
            string name;
            if(!FormSeaPortsParent.GetParentPortID(out id,out name, _seaPorts.Where(sp=>sp.CruiseLineID==null&&sp.ParentID==null).ToList(), _tbRegion))return;
            _selectedPort.ParentID = id;
            tbParent.Text = name;
            RefreshDataGrid();
        }

        private void btnDeleteParent_Click(object sender, EventArgs e)
        {
            if (_selectedPort == null) return;
            if (_selectedPort.ParentID == null) return;
            _selectedPort.ParentID = null;
            tbParent.Text = string.Empty; 
            RefreshDataGrid();
        }

        private void btnRemPort_Click(object sender, EventArgs e)
        {
            if(_selectedPort==null)return;
            if(_selectedPort.CruiseLineID==null&&_selectedPort.ParentID==null)
            {
                if (
                    !Messages.Question(string.Format(
                        "Этот порт может являться родительским, удаление затронет все порты которые к нему привязаны, продолжить удаление {0}?", _selectedPort.Name)))
                return;
            }
            if(Messages.Question(string.Format("Удалить порт {0}?",_selectedPort.Name)))
                if (_selectedPort.Delete(WorkWithData.TsConnection))
                {
                    _seaPorts.Remove(_seaPorts.Find(sp=>sp.ID==_selectedPort.ID));
                    Messages.Information("Удаление прошло успешно!");
                }
            _selectedPort = null;
            ApplyFilter();
        }

        private void btnAddPort_Click(object sender, EventArgs e)
        {
            FormSeaPortAdd.AddSeaport(_seaPorts.Where(sp => sp.CruiseLineID == null && sp.ParentID == null).ToList(), _tbRegion,_tbcrLines);
            var _seaPortsTable = WorkWithData.GetSeaPortsTable(WorkWithData.TsConnection);
            _seaPorts.Clear();
            foreach (DataRow dataRow in _seaPortsTable.Rows)
            {
                _seaPorts.Add(new Seaport(dataRow));
            }
            ApplyFilter();
        }

        private void tbNameFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbName_ru_Leave(object sender, EventArgs e)
        {
            _selectedPort.Name_ru = tbName_ru.Text;
            RefreshDataGrid();
        }

        

        }
}
