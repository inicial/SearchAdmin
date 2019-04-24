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
    public partial class FormEditCruises : ProjectForm
    {
        DataTable _cruisesTable=new DataTable();
        //readonly List<Cruise> _cruises = new List<Cruise>();
        //readonly List<CruiseView> _cruiseViews = new List<CruiseView>();
        readonly List<Ship> _ships = new List<Ship>();
        readonly List<CruiseLine> _cruiseLines = new List<CruiseLine>();
        readonly List<ItRegion> _filterRegions = new List<ItRegion>();
        List<CruiseView> _filteredSource = new List<CruiseView>();
        private int flag;
        
        private FormEditCruises()
        {
            InitializeComponent();
            CruiseFilterHelper.GetFilterData(cbShips,ref _ships,cbCruiseLines,ref _cruiseLines,cbRegions,ref _filterRegions,cbGroupVisible);
            WaitForm.WaitInBackground("Получение данных", false, () =>RefreshData());
            dgvCruises.DataSource = _cruisesTable;
            UpdateDataGrid();
            //cbGroupVisible.SelectionChangeCommitted += (s, e) => SetFilter();
           // cbActions.SelectionChangeCommitted += (s,e)=>SetFilter();
           // minDur.TextChanged += (s, e) => SetFilter();
           // maxDur.TextChanged += (s, e) => SetFilter();
            //cbRegions.SelectionChangeCommitted += (s, e) => SetFilter();
           // cbShips.SelectionChangeCommitted += (s, e) => SetFilter();
            btnReturn.Click += (s, e) => Close();
         
            dgvCruises.CellDoubleClick += (s, e) => SetRegionsToCruise();
        }

        public static void EditCruises()
        {
            using (var f = new FormEditCruises())
            {
                f.ShowDialog();
            }
        }

    
        //void UpdateCruiseView()
        //{
        //   _cruiseViews.Clear();
        //   _cruiseViews.AddRange(from cruise in _cruises select new CruiseView(cruise));
        //    dgvCruises.DataSource = _cruiseViews;
        //    CruiseFilterHelper.SetCruiseGrid(dgvCruises);
        //}
        
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
        void SetRegionsToCruise()
        {
            try
            {
                DataGridViewRow row = dgvCruises.SelectedRows[0];
                Cruise cruise = WorkWithData.GetCruise(row.Cells["pacadge"].Value.ToString(),
                    Convert.ToDateTime(row.Cells["sailDate"].Value));
                List<CruiseView> cruises = WorkWithData.GetListCruiseView(cruise.Ship.Code, cruise.CruiseItinerery.ID,
                    cruise.CruiseLn.Mnemo);
                FormRegionsByItinerary.GetSettings(cruise,cruises);
                

            }
            catch (Exception)
            {
                throw;
            }
        }
        void RefreshData()
        {
            DataTable dt = WorkWithData.GetDataTable("select max(saildate) as dateend,max(duration) as dur from cruises", WorkWithData.TsConnection);
            dtpEnd.Value = dt.Rows[0].Field<DateTime>("dateend");
            dtpBegin.Value = DateTime.Now;
            flag = 1;
            _cruisesTable.Clear();
            minDur.Text = "1";
            maxDur.Text = dt.Rows[0].Field<int>("dur").ToString();
            SqlCommand cruiseSqlCommand = new SqlCommand(@"[dbo].[search_cruises_admin]", WorkWithData.TsConnection);                                              
                                                         
            cruiseSqlCommand.CommandType=CommandType.StoredProcedure;
           

            cruiseSqlCommand.Parameters.AddWithValue("@datebegin",dtpBegin.Value);
            cruiseSqlCommand.Parameters.AddWithValue("@mindur", Convert.ToInt32(minDur.Text));
            cruiseSqlCommand.Parameters.AddWithValue("@maxdur", Convert.ToInt32(maxDur.Text));
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
            if ((maxDur.Text != null) && (maxDur.Text != string.Empty))
            {
                durmax = Convert.ToInt32(maxDur.Text);
            }
            else
            {
                durmax = null;
            }
            if ((minDur.Text != null) && (minDur.Text != string.Empty))
            {
                durmin = Convert.ToInt32(minDur.Text);
            }
            else
            {
                durmin = null;
            }
            if (Convert.ToInt32(cbRegions.SelectedValue) == 0)
            {
                reg = null;
            }
            else
            {
                reg = Convert.ToInt32(cbRegions.SelectedValue);
            }
            if ((Convert.ToInt32(cbActions.SelectedValue) == 0) || (!cbActions.Enabled))
            {
                act = null;

            }
            else
            {
                act = Convert.ToInt32(cbActions.SelectedValue);
            }
            if (Convert.ToInt32(cbGroupVisible.SelectedValue) == 0)
            {
                gact = null;
            }
            else
            {
                gact = Convert.ToInt32(cbGroupVisible.SelectedValue);
            }
            if (Convert.ToString(cbCruiseLines.SelectedValue) == "all")
            {
                crline = null;
            }
            else
            {
                crline = Convert.ToString(cbCruiseLines.SelectedValue);
            }
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
            cruiseSqlCommand.Parameters.AddWithValue("@region", reg);
            cruiseSqlCommand.Parameters.AddWithValue("@actions", act);
            cruiseSqlCommand.Parameters.AddWithValue("@crlinekey", crline);
            cruiseSqlCommand.Parameters.AddWithValue("@groupaction", gact);
            cruiseSqlCommand.Parameters.AddWithValue("@shipid", ship);
            cruiseSqlCommand.Parameters.AddWithValue("@mindur", durmin);
            cruiseSqlCommand.Parameters.AddWithValue("@maxdur", durmax);
            if (cbIsSpec.Checked)
            {
                cruiseSqlCommand.Parameters.AddWithValue("@isspec",1 );   
            }
            else
            {
                cruiseSqlCommand.Parameters.AddWithValue("@isspec",0 );
            }SqlDataAdapter cruisesAdapter =new SqlDataAdapter(cruiseSqlCommand);
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
        
        private void cbGroupVisible_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView grup = cbGroupVisible.SelectedItem as DataRowView;
            if ((Convert.ToInt32(grup["id"]) != 0) && (Convert.ToInt32(grup["id"]) != -1))
                                                       
            {
                cbActions.Enabled = true;
                CruiseFilterHelper.GetActionFilter(cbActions,Convert.ToInt32(grup["id"]));
                          
            }
            else
            {
                
                cbActions.Enabled = false;
            }
        }
        private void dgvCruises_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.ColumnIndex != 5) return;
                StringBuilder sb = new StringBuilder();

                CruiseView cruise = new CruiseView(WorkWithData.GetCruise(((DataGridView)sender).Rows[e.RowIndex].Cells["pacadge"].Value.ToString(), Convert.ToDateTime(((DataGridView)sender).Rows[e.RowIndex].Cells["saildate"].Value)));
                string[] ports = cruise.Itinerary.Split('-');
                int i = 0;
                string str = string.Empty;
                foreach (string port in ports)
                {
                    str = str + port + "-";
                    i++;


                    if (i == 6)
                    {
                        sb.AppendLine(str);
                        i = 0;
                        str = string.Empty;
                    }

                }
                sb.AppendLine(str);
                ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = sb.ToString();
            }
            catch (Exception)
            {
                
               }
            
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

       
    }
}
