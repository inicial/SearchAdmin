using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Entities.Ships;
using CruiseSearchAdmin.Forms.Actions;
using CruiseSearchAdmin.Forms.Itinerary;
using CruiseSearchAdmin.HelperClasses;
using DevExpress.XtraEditors.Controls;
using DxHelpersLib;

namespace CruiseSearchAdmin
{
  
     public partial  class FormCruises : ProjectForm
     {
         private static string pake;
         private static DateTime saildate;
        DataTable _cruisesTable=new DataTable();
        readonly List<Ship> _ships = new List<Ship>();
        readonly List<CruiseLine> _cruiseLines = new List<CruiseLine>();
        readonly List<ItRegion> _filterRegions = new List<ItRegion>();
        List<CruiseView> _filteredSource = new List<CruiseView>();
        private int flag;
        
        private FormCruises()
        {
            InitializeComponent();
            CruiseFilterHelper.GetFilterData(cbShips,ref _ships,cbCruiseLines,ref _cruiseLines,null,ref _filterRegions,null);
            DxHelpersLib.WaitForm.WaitInBackground("Получение данных", false, () =>RefreshData());
            dgvCruises.DataSource = _cruisesTable;
            UpdateDataGrid();
            btnReturn.Click += (s, e) => Close();
           
        }


        public static void EditCruises(out string pak,out DateTime sail)
        {
            using (var f = new FormCruises())
            {
                f.ShowDialog();
            }
            pak = pake;
            sail = saildate;
        }

    
    
        
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CheckDTPValue();
              
            }
            catch (Exception)
            {
                return;
            }
        }
        
        void CheckDTPValue()
        {
            if (dtpEnd.Value < dtpBegin.Value)
                dtpEnd.Value = dtpBegin.Value;
        }
       
        void RefreshData()
        {
            DataTable dt = WorkWithData.GetDataTable("select max(saildate) as dateend,max(duration) as dur from cruises", WorkWithData.TsConnection);
            dtpEnd.Value = dt.Rows[0].Field<DateTime>("dateend");
            dtpBegin.Value = DateTime.Now;
            flag = 1;
            _cruisesTable.Clear();
            
            SqlCommand cruiseSqlCommand = new SqlCommand(@"[dbo].[search_cruises_admin]", WorkWithData.TsConnection);                                              
                                                         
            cruiseSqlCommand.CommandType=CommandType.StoredProcedure;
           

            cruiseSqlCommand.Parameters.AddWithValue("@datebegin",dtpBegin.Value);
            
            cruiseSqlCommand.Parameters.AddWithValue("@dateend", dtpEnd.Value);
            SqlDataAdapter cruiseAdapter =new SqlDataAdapter(cruiseSqlCommand);
            
            
            cruiseAdapter.Fill(_cruisesTable);
            flag = 0;

        }
        private void cbCruiseLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((CruiseLine)cbCruiseLines.SelectedItem).ID != 0)
            {
                cbShips.Enabled = true; 
                List<Ship> dataSource = new List<Ship> { new Ship(0, "All", 0, string.Empty,null) };
                dataSource.AddRange(_ships.Where(s => s.CruiseLineID == ((CruiseLine)cbCruiseLines.SelectedItem).ID).ToList());
                cbShips.DataSource = dataSource;
            }
            else
            {
                cbShips.Enabled = false;
                cbShips.DataSource = _ships;
            }
           
        }

        private void SetFilter()
        {
            if (flag == 1) return;
            _cruisesTable.Clear();
            int? reg, act,ship, gact,durmin,durmax;
            string crline;
            SqlCommand cruiseSqlCommand = new SqlCommand(@"[dbo].[search_cruises_admin]",WorkWithData.TsConnection);
            cruiseSqlCommand.CommandType=CommandType.StoredProcedure;
            
            if ((Convert.ToInt32(cbShips.SelectedValue) == 0) || (!cbShips.Enabled))
            {
                ship = null;

            }
            else
            {
                ship = Convert.ToInt32(cbShips.SelectedValue);
            }
            cruiseSqlCommand.Parameters.AddWithValue("@datebegin", dtpBegin.Value);
            cruiseSqlCommand.Parameters.AddWithValue("@dateend", dtpEnd.Value);
            cruiseSqlCommand.Parameters.AddWithValue("@region", null);
            cruiseSqlCommand.Parameters.AddWithValue("@actions", null);
            cruiseSqlCommand.Parameters.AddWithValue("@crlinekey", cbCruiseLines.SelectedValue);
            cruiseSqlCommand.Parameters.AddWithValue("@groupaction", null);
            cruiseSqlCommand.Parameters.AddWithValue("@shipid", ship);
            cruiseSqlCommand.Parameters.AddWithValue("@mindur", null);
            cruiseSqlCommand.Parameters.AddWithValue("@maxdur", null);
            SqlDataAdapter cruisesAdapter =new SqlDataAdapter(cruiseSqlCommand);
            cruisesAdapter.Fill(_cruisesTable);
            dgvCruises.DataSource = _cruisesTable;

        }

        void UpdateDataGrid()
        {
            foreach (DataGridViewColumn column in dgvCruises.Columns)
            {
                switch (column.Name.ToLower())
                { case "saildate":
                    {
                        column.HeaderText = "Дата";
                        column.MinimumWidth = dgvCruises.Width/9 + 30;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        column.DisplayIndex = 0; 

                    }
                    break;
                case "departureport":
                    {
                        column.HeaderText = "Порт отправления";
                        column.MinimumWidth = dgvCruises.Width / 8 + 50;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        column.DisplayIndex = 1;
                    }
                    break;
                case "crlinename":
                    {
                        column.HeaderText = "Круизная компания";
                        column.MinimumWidth = dgvCruises.Width / 8 + 50;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        column.DisplayIndex = 2;
                    }
                    break;
                case "shipname":
                    {
                        column.HeaderText = "Лайнер";
                        column.MinimumWidth = dgvCruises.Width / 8 + 50;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        column.DisplayIndex = 3;
                    }
                    break;
                case "duration":
                    {
                        column.HeaderText = "Ночей";
                        column.MinimumWidth = dgvCruises.Width / 20 + 30;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        column.DisplayIndex = 4;
                    }
                    break;
                case "itenary":
                    {
                        column.HeaderText = "Маршрут";
                        column.MinimumWidth = dgvCruises.Width / 5 + 30;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        column.DisplayIndex = 6;
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
        
        private void dgvCruises_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Point p = new Point(e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 5);
            e.Graphics.DrawString(e.RowIndex.ToString(), dgvCruises.Font, Brushes.Black, p);
        }
        
       
        private void dgvCruises_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0||e.ColumnIndex!=5) return;
            StringBuilder sb = new StringBuilder();
           
            CruiseView cruise = new CruiseView(WorkWithData.GetCruise(((DataGridView)sender).Rows[e.RowIndex].Cells["pacadge"].Value.ToString(), Convert.ToDateTime(((DataGridView)sender).Rows[e.RowIndex].Cells["saildate"].Value)));
            string[] ports = cruise.Itinerary.Split('-');
            int i = 0;
            string str=string.Empty;
            foreach (string port in ports )
            {
                str = str + ports + "-";
                i++;
                
           
            if (i ==6)
            {
                sb.AppendLine(str);
                i = 0;
                str = string.Empty;
            } 

            }
            sb.AppendLine(str);
            ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = sb.ToString();
        }
    
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void applyFilter_Click(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void dgvCruises_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCruises.SelectedRows.Count < 1) return;
            DataGridViewRow row = dgvCruises.SelectedRows[0];
            pake = row.Cells["pacadge"].Value.ToString();
            saildate = Convert.ToDateTime(row.Cells["sailDate"].Value);
        }

       
    }
}
