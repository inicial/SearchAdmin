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
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Entities.Ships;
using CruiseSearchAdmin.Enums;
using CruiseSearchAdmin.Forms.Actions;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.DopPak
{
    public partial class FormPakMultyAdd : ProjectForm
    {
        private const string SELECT_ACTION_WITH_GROUP = @"select * from
                                                        (select * from
                                                        (select Actions_visible_group.id,Actions_visible_group.Name,SUM(mk_tbVisibleTypes.VT_MASK)as summask from Actions_visible_group inner join dbo.mk_tbVisibleTypes on Actions_visible_group.id =mk_tbVisibleTypes.VT_id_group
                                                        group by Actions_visible_group.id,Actions_visible_group.Name)as grm inner join Actions as a on (a.action_visible_type & summask) >0
                                                        union
                                                        select 0 ,'Без группы',0,Actions.* from Actions where action_visible_type=0 or action_visible_type is null)as t1
                                                        order by t1.id,action_text";
        readonly private CruiseActionsCollection _cruiseActions = new CruiseActionsCollection();
        List<SelectedCruiseView> _cruiseViews = new List<SelectedCruiseView>();
        private readonly DataTable _cruisesTable = new DataTable();
        private int flag;
        List<Ship> _ships = new List<Ship>();
        List<CruiseLine> _cruiseLines = new List<CruiseLine>();
        private DataTable _DopPaket = new DataTable();
        List<ItRegion> _filterRegions = new List<ItRegion>();
        List<SelectedCruiseView> _filteredSource = new List<SelectedCruiseView>();
       
        public FormPakMultyAdd()
        {
            InitializeComponent();
            GettingData();
        }
        void GetDop()
        {
            _DopPaket.Clear();
            SqlCommand com =new SqlCommand(@" select TL_KEY,TL_NAME,TL_NAMEWEB  FROM [dbo].[tbl_TurList] 
            where (TL_TIP = 149 or TL_TIP = 172) and TL_Deleted <>1", WorkWithData.MasterConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(_DopPaket);
            lbDop.DataSource = _DopPaket;
            lbDop.ValueMember = "TL_KEY";
            lbDop.DisplayMember = "TL_NAME";

        }
        void GettingData()
        {

            WaitForm.WaitInBackground("Загрузка данных", false, () =>
            {
                RefreshData();
                GetDop();
            });
            dgvCruises.DataSource = _cruisesTable;
            UpdateDataGrid();
            CruiseFilterHelper.GetFilterData(cbShips, ref _ships, cbCruiseLines, ref _cruiseLines, cbRegions, ref _filterRegions, cbGroupActions);

        }
       
        void RefreshData()
        {
            DataTable dt = WorkWithData.GetDataTable("select max(saildate) as dateend,max(duration) as dur from cruises", WorkWithData.TsConnection);
            dtpEnd.Value = dt.Rows[0].Field<DateTime>("dateend");
            dtpBegin.Value = DateTime.Now;
            flag = 1;
            
            minDur.Text = "1";
            maxDur.Text = dt.Rows[0].Field<int>("dur").ToString();
            SqlCommand cruiseSqlCommand = new SqlCommand(@"[dbo].[search_cruises_admin]", WorkWithData.TsConnection);

            cruiseSqlCommand.CommandType = CommandType.StoredProcedure;


            cruiseSqlCommand.Parameters.AddWithValue("@datebegin", dtpBegin.Value);
            cruiseSqlCommand.Parameters.AddWithValue("@mindur", Convert.ToInt32(minDur.Text));
            cruiseSqlCommand.Parameters.AddWithValue("@maxdur", Convert.ToInt32(maxDur.Text));
            cruiseSqlCommand.Parameters.AddWithValue("@dateend", dtpEnd.Value);
            SqlDataAdapter cruiseAdapter = new SqlDataAdapter(cruiseSqlCommand);


            cruiseAdapter.Fill(_cruisesTable);
            DataColumn col = _cruisesTable.Columns.Add("selected", typeof(Boolean));
            _cruisesTable.Clear();
            col.DefaultValue = false;
            cruiseAdapter.Fill(_cruisesTable);flag = 0;

        }
        void UpdateDataGrid()
        {
            foreach (DataGridViewColumn column in dgvCruises.Columns)
            {
                switch (column.Name.ToLower())
                {
                    case "pacadge":
                        {
                            column.HeaderText = "Код круиза";
                            column.MinimumWidth = dgvCruises.Width / 3 + 30;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DisplayIndex = 6;
                        }
                        break;
                    case "saildate":
                        {
                            column.HeaderText = "Дата";
                            column.MinimumWidth = dgvCruises.Width / 9 + 30;
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
                            column.DisplayIndex = 7;
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
        void SetFilter()
        {
            if (flag == 1) return;
            _cruisesTable.Clear();
            int? reg, act, ship, gact, durmin, durmax;
            string crline;
            SqlCommand cruiseSqlCommand = new SqlCommand(@"[dbo].[search_cruises_admin]", WorkWithData.TsConnection);
            cruiseSqlCommand.CommandType = CommandType.StoredProcedure;
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
            {durmin = null;
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
            if (Convert.ToInt32(cbGroupActions.SelectedValue) == 0)
            {
                gact = null;
            }
            else
            {
                gact = Convert.ToInt32(cbGroupActions.SelectedValue);
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
            SqlDataAdapter cruisesAdapter = new SqlDataAdapter(cruiseSqlCommand);
            cruisesAdapter.Fill(_cruisesTable);
            dgvCruises.DataSource = _cruisesTable;

            
        }
        private void applyFilter_Click(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void btnAddCruiseAction_Click(object sender, EventArgs e)
        {
            int? id;
            if (lbDop.SelectedValue != null)
            {
                id = Convert.ToInt32(lbDop.SelectedValue);
            }
            else
            {
                id = null;
            }
            if ((id == 0) || (id == null))
            {
                Messages.Error("Не выбрана Акция/Бонус");
                return;
            }

            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(string.Format(@"select * from Cruise_dop_paket where Tur_master_Id= {0}", id), WorkWithData.TsConnection));
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            var inserted = new List<string>();
            DataRow[] selcruses = _cruisesTable.Select("selected=true");
            foreach (DataRow row in selcruses)
            {
                if (dt.Select(string.Format("package='{0}' and sailDate='{1}'", row.Field<string>("Pacadge"), row.Field<DateTime>("saildate").ToString("yyyy-MM-dd"))).Length != 0) continue;
                var insertingStr = string.Format("{0}{1}{2}", id, row.Field<string>("Pacadge"),
                                                    row.Field<DateTime>("saildate").ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                if (inserted.Contains(insertingStr)) continue;
                inserted.Add(insertingStr);

                using (
                    SqlCommand command = new SqlCommand(
                            string.Format(
                                @"insert into Cruise_dop_paket (Tur_master_Id,package,sailDate) values ({0},'{1}','{2}')",
                                id, row.Field<string>("Pacadge"), row.Field<DateTime>("saildate").ToString("yyyy-MM-ddTHH:mm:ss.fff")),
                            WorkWithData.TsConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            SetFilter();
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            SetCruiseSelection(SelectItemSetter.UNSELECT_ALL);
        }

        private void cbGroupActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView grup = cbGroupActions.SelectedItem as DataRowView;
            if ((Convert.ToInt32(grup["id"]) != 0) && (Convert.ToInt32(grup["id"]) != -1))
            {
                cbActions.Enabled = true;
                CruiseFilterHelper.GetActionFilter(cbActions, Convert.ToInt32(grup["id"]));
            }
            else
            {

                cbActions.Enabled = false;
            }
        }

        private void cbCruiseLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((CruiseLine)cbCruiseLines.SelectedItem).ID != 0)
            {
                cbShips.Enabled = true;
                List<Ship> dataSource = new List<Ship> { new Ship(0, "All", 0, string.Empty, null) };
                dataSource.AddRange(_ships.Where(s => s.CruiseLineID == ((CruiseLine)cbCruiseLines.SelectedItem).ID).ToList());
                cbShips.DataSource = dataSource;
            }
            else
            {
                cbShips.Enabled = false;
                cbShips.DataSource = _ships;
            }
        }
        void SetCruiseSelection(SelectItemSetter sis)
        {
            foreach (DataGridViewRow view in dgvCruises.Rows)
            {
                if (sis == SelectItemSetter.UNSELECT_ALL)
                    view.Cells["selected"].Value = false;
                else if (sis == SelectItemSetter.INVERT)
                    view.Cells["selected"].Value = !Convert.ToBoolean(view.Cells["selected"].Value);
                else view.Cells["selected"].Value = true;
            }
            dgvCruises.Invalidate();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetCruiseSelection(SelectItemSetter.ALL);
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            SetCruiseSelection(SelectItemSetter.INVERT);
        }

        private void btnDeleteCruiseAction_Click(object sender, EventArgs e)
        {
            DataRow[] selcruses = _cruisesTable.Select("selected=true");

            if (selcruses.Length < 1)
            {Messages.Error(@"Не выбрано ни одного круиза");
                return;
            }
            int? id;
            if (lbDop.SelectedValue != null)
            {
                id = Convert.ToInt32(lbDop.SelectedValue);
            }
            else
            {
                id = null;
            }
            if ((id == 0) || (id == null))
            {
                Messages.Error("Не выбрана Акция/Бонус");
                return;
            }
            StringBuilder sb = new StringBuilder(string.Format("select Tur_master_Id from Cruise_dop_paket where Tur_master_Id={0} and (", id));

            foreach (var row in selcruses)
            {
                sb.Append(string.Format("(package='{0}' and sailDate='{1}')", row.Field<string>("Pacadge"),
                                                    row.Field<DateTime>("saildate").ToString("yyyy-MM-ddTHH:mm:ss.fff")));
                sb.Append(row != selcruses.Last() ? " or " : ")");
            }
            if (WorkWithData.TsConnection.State == ConnectionState.Closed) WorkWithData.TsConnection.Open();
            var dt = WorkWithData.GetDataTable(sb.ToString());
            foreach (var row in selcruses)
            {
                using (SqlCommand com = new SqlCommand("delete from Cruise_dop_paket where Tur_master_Id=@actid and package=@pack and sailDate=@date", WorkWithData.TsConnection))
                {
                    com.Parameters.AddWithValue("@actid", id);
                    com.Parameters.AddWithValue("@pack", row.Field<string>("Pacadge"));
                    com.Parameters.AddWithValue("@date", row.Field<DateTime>("saildate"));
                    com.ExecuteNonQuery();
                }

            }
            SetFilter();
        }

        private void dgvCruises_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow selCruise = ((DataGridView)sender).Rows[e.RowIndex];
            if (selCruise == null) return;
            selCruise.Cells["selected"].Value
                = !(Convert.ToBoolean(selCruise.Cells["selected"].Value));
            dgvCruises.InvalidateRow(e.RowIndex);
        }

        private void dgvCruises_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCruises_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Point p = new Point(e.RowBounds.Location.X + 10,e.RowBounds.Location.Y + 5);
            e.Graphics.DrawString(e.RowIndex.ToString(), dgvCruises.Font,
                                  Brushes.Black, p);
            
            
        }

        private void dgvCruises_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow selCruise = ((DataGridView)sender).Rows[e.RowIndex];
            if (selCruise == null) return;
            if (Convert.ToBoolean(selCruise.Cells["selected"].Value))
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            }
            else
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Silver;
            }}
    }
}
