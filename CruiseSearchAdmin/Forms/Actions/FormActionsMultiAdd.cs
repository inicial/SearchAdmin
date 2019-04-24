using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Entities.Ships;
using CruiseSearchAdmin.Entities.SyncModel;
using CruiseSearchAdmin.Enums;
using CruiseSearchAdmin.Forms.Actions;
using CruiseSearchAdmin.Forms.SynchronizationForms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Actions

{
    public partial class FormActionsMultiAdd : ProjectForm
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
        List<ItRegion> _filterRegions = new List<ItRegion>();
        List<SelectedCruiseView> _filteredSource = new List<SelectedCruiseView>();
        private Synchronizer _synchronizer = new Synchronizer(null, WorkWithData.TsConnection);
        private FormActionsMultiAdd()
        {
            InitializeComponent();
            GettingData();
            btnBack.Click += (s, e) => Close();
            btnSyncCruiseActions.Enabled = Program.AccessController.IsAccess(AccessRigt.SyncAccess);
            SetFilter();
        }
        void GettingData()
        {
           
            
            WaitForm.WaitInBackground("Загрузка данных", false, () =>
                {
                    
                    RefreshData();
                    GetActions();
                });
            RefreshActionsControls();
            dgvCruises.DataSource = _cruisesTable;
            UpdateDataGrid();
            //UpdateCruiseViews(cruises);
            
            CruiseFilterHelper.GetFilterData(cbShips, ref _ships, cbCruiseLines, ref _cruiseLines, cbRegions, ref _filterRegions, cbGroupActions);
            
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
                            column.MinimumWidth = dgvCruises.Width/3 + 30;
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
        void RefreshActionsControls()
        {
            lbActions.DataSource = null;
            lbActions.DataSource = _cruiseActions;
            lbActions.DisplayMember = "Text";
            lbActions.ValueMember = "ID";
            lbActions.Invalidate();

            int idx = cbActions.SelectedIndex;idx = idx == -1 ? 0 : idx;
            if ((cbGroupActions.SelectedValue != null) && (Convert.ToInt32(cbGroupActions.SelectedValue) != 0) &&
                (Convert.ToInt32(cbGroupActions.SelectedValue) != -1))
            {
                cbActions.Enabled = true;
                CruiseFilterHelper.GetActionFilter(cbActions, Convert.ToInt32(cbGroupActions.SelectedValue));
                
            }
            else
            {
                cbActions.Enabled = false;
            }
           // if (cbActions.Items.Count > idx) cbActions.SelectedIndex = idx;

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
        void DateTimePickerMonitor(DateTimePicker dtp1, DateTimePicker dtp2)
        {
            if (dtp1.Value > dtp2.Value)
                dtp2.Value = dtp1.Value;
        }
        static public bool SetActionsSettings()
        {
            using (var f = new FormActionsMultiAdd())
            {
                return f.ShowDialog() == DialogResult.OK;
            }
        }

        private void GetActions()
        {
            var dt = WorkWithData.GetDataTable(SELECT_ACTION_WITH_GROUP);
            string selGroup = string.Empty;
            TreeNode selRoot = new TreeNode();
            tvActions.Nodes.Clear();
           
            foreach (DataRow dataRow in dt.Rows)
            {
                if (selGroup.Equals(string.Empty))
                {
                    selGroup = dataRow["Name"].ToString();
                    selRoot = tvActions.Nodes.Add(dataRow["Id"].ToString(), selGroup);
                    TreeNode newNode = selRoot.Nodes.Add(dataRow["action_id"].ToString(),
                        dataRow["action_text"].ToString() + " id=" + dataRow["action_id"].ToString());
                    newNode.Tag = dataRow.Field<int>("action_id");
                }
                else
                {

                    if (selGroup != dataRow["Name"].ToString())
                    {
                        selGroup = dataRow["Name"].ToString();
                        selRoot = tvActions.Nodes.Add(dataRow["Id"].ToString(), selGroup);
                        TreeNode newNode = selRoot.Nodes.Add(dataRow["action_id"].ToString(),
                            dataRow["action_text"].ToString() + " id=" + dataRow["action_id"].ToString());
                        newNode.Tag = dataRow.Field<int>("action_id");
                    }
                    else
                    {
                        TreeNode newNode = selRoot.Nodes.Add(dataRow["action_id"].ToString(),
                            dataRow["action_text"].ToString() + " id=" + dataRow["action_id"].ToString());
                        newNode.Tag = dataRow.Field<int>("action_id");
                    }
                }
            }
        }

        /// <summary>
        /// Заполнение представлений круизов
        /// </summary>
        /// <param name="cruises">Коллекция круизов</param>
        //void UpdateCruiseViews(List<Cruise> cruises)
        //{
        //    _cruiseViews.Clear();
        //    _cruiseViews.AddRange(from cruise in cruises select new SelectedCruiseView(cruise));
        //    dgvCruises.DataSource = _cruiseViews;
        //    if (_cruiseViews.Count <= 0) return;
        //    dtpBegin.Value = DateTime.Now;
        //    dtpEnd.Value = _cruiseViews.Last().SailDate;
        //    CruiseFilterHelper.SetCruiseGrid(dgvCruises);
        //}
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

            //_cruiseViews.ForEach(cv => cv.Selected = false);
            //ItRegion reg = cbRegions.SelectedItem as ItRegion;
            //CruiseLine crLine = cbCruiseLines.SelectedItem as CruiseLine;
            //Ship s = cbShips.SelectedItem as Ship;
            //DataRowView action = cbActions.SelectedItem as DataRowView;
            //if (reg == null || crLine == null || s == null) return;

            //_filteredSource = crLine.ID != 0 ? _cruiseViews.Where(c => c.CruiseLink.CruiseLn.ID == crLine.ID).ToList() : _cruiseViews;//Фильтр по компаниям
            //if (s.ID != 0)
            //    _filteredSource = _filteredSource.Where(c => c.ShipEN == s.Name || c.Selected).ToList();//Фильтр по лайнерам
            //_filteredSource = _filteredSource.Where(c => c.SailDate.Date >= dtpBegin.Value.Date && c.SailDate.Date <= dtpEnd.Value.Date).ToList();//фильтер по дате
            //var fs = new List<SelectedCruiseView>();
            //if (action != null)//Фильтр по Тематикам
            //    if (Convert.ToInt32(action["action_Id"]) != 0)
            //    {
            //        if (Convert.ToInt32(action["action_Id"]) == -1)
            //            _filteredSource = _filteredSource.Where(c => c.Actions == null || c.Actions.Count == 0).ToList();
            //        else
            //        {
            //            fs.AddRange(_filteredSource.Where(cruiseView => cruiseView.Actions != null && cruiseView.Actions.Count != 0).Where(cruiseView => cruiseView.Actions.Count<CruiseAction>(act => act.ID == Convert.ToInt32(action["action_Id"])) != 0));
            //            _filteredSource = fs;
            //        }
            //    }
            //try
            //{
            //    //OrderFilterBySelect(_filteredSource);
            //    switch (reg.ID)//Фильтр по регионам
            //    {
            //        case -1:
            //            dgvCruises.DataSource =
            //                _filteredSource.Where(c => !c.Regions.Any()).ToList();
            //            break;
            //        case 0:
            //            dgvCruises.DataSource = _filteredSource;
            //            break;
            //        default:
            //            {
            //                List<SelectedCruiseView> addViews = new List<SelectedCruiseView>();
            //                foreach (var cruiseView in from cruiseView in _filteredSource
            //                                           from itRegion in cruiseView.Regions
            //                                           where reg.ID == itRegion.ID
            //                                           where !addViews.Contains(cruiseView)
            //                                           select cruiseView)
            //                {
            //                    addViews.Add(cruiseView);
            //                }
            //                dgvCruises.DataSource = _filteredSource = addViews;
            //            }
            //            break;
            //    }
            //    CruiseFilterHelper.SetCruiseGrid(dgvCruises);
            //}
            //catch (Exception)
            //{
            //    return;
            //}
        }

        void OrderFilterBySelect(List<SelectedCruiseView> fs)
        {
            List<SelectedCruiseView> tmpfs = new List<SelectedCruiseView>();
            for (int i = 0; i < fs.Count; i++)
            {
                if (!fs[i].Selected) continue;
                tmpfs.Add(fs[i]);
                fs.RemoveAt(i);
            }
            tmpfs.OrderBy(c => c.SailDate);
            fs.InsertRange(0, tmpfs);
        }

        //void GetCruiseBonuses(List<Cruise> cruises)
        //{
        //    var dt = WorkWithData.GetDataTable("select * from mk_tbCruiseBonuses");
        //    var dtDescs = WorkWithData.GetDataTable("select * from mk_tbCruiseBonusDescriptions");
        //    foreach (var cruise in cruises)
        //    {
        //        var rows = dt.Select(string.Format("C_PACKAGE='{0}' and C_SAILDATE='{1}'", cruise.Package,
        //                                cruise.SailDate.ToString("dd.MM.yyyy")));
        //        cruise.Bonuses.AddRange(from r in rows select new CruiseBonus((int)r["CB_ID"], (int)r["B_ID"], Convert.ToDateTime(r["CB_DATEBEG"]), Convert.ToDateTime(r["CB_DATEEND"])));
        //        foreach (var bonus in cruise.Bonuses)
        //        {
        //            var descRows = dtDescs.Select(string.Format("CB_ID={0}", bonus.CB_ID));
        //            bonus.Descriptions.AddRange(from r in descRows select r["CBD_DESCRIPTION"].ToString());
        //        }

        //    }
        //}
        private void cbCruiseLines_SelectionChangeCommitted(object sender, EventArgs e)
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
            //SetFilter();
        }
        private void dgvCruises_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;
            DataGridViewRow selCruise = ((DataGridView) sender).Rows[e.RowIndex];
            if (selCruise == null) return;
            selCruise.Cells["selected"].Value
                = !(Convert.ToBoolean(selCruise.Cells["selected"].Value));
            dgvCruises.InvalidateRow(e.RowIndex);
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
            }
        }

        private void btnAddCruiseAction_Click(object sender, EventArgs e)
        {
            int? action;
            if (tvActions.SelectedNode!=null){
             action =  Convert.ToInt32(tvActions.SelectedNode.Tag);
            }
            else
            {
                 action = null;
            }
            if ((action == 0) || (action==null))
            {
                Messages.Error("Не выбрана Акция/Бонус");
                return;
            }
            
            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(string.Format(@"select * from CruiseActions where actionId = {0}", action), WorkWithData.TsConnection));
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            var inserted = new List<string>();
            DataRow[] selcruses = _cruisesTable.Select("selected=true");
            foreach (DataRow row  in selcruses)
            {
                if (dt.Select(string.Format("package='{0}' and sailDate='{1}'", row.Field<string>("Pacadge"), row.Field<DateTime>("saildate").ToString("yyyy-MM-dd"))).Length != 0) continue;
                var insertingStr = string.Format("{0}{1}{2}", action, row.Field<string>("Pacadge"),
                                                    row.Field<DateTime>("saildate").ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                if (inserted.Contains(insertingStr)) continue;
                inserted.Add(insertingStr);
                
                using (
                    SqlCommand command =new SqlCommand(
                            string.Format(
                                @"insert into CruiseActions(actionId,package,sailDate) values ({0},'{1}','{2}')",
                                action, row.Field<string>("Pacadge"), row.Field<DateTime>("saildate").ToString("yyyy-MM-ddTHH:mm:ss.fff")),
                            WorkWithData.TsConnection))
                {
                    command.ExecuteNonQuery();
                }}
            SetFilter();
        }
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            
            SetCruiseSelection(SelectItemSetter.ALL);
        }
        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            SetCruiseSelection(SelectItemSetter.INVERT);
        }
        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            SetCruiseSelection(SelectItemSetter.UNSELECT_ALL);
        }
        private void cbShips_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SetFilter();
        }
        private void SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SetFilter();
        }
        private void dtpValueChanged(object sender, EventArgs e)
        {
            //SetFilter(); 
            DateTimePickerMonitor(dtpBegin, dtpEnd);
        }
        private void dgvCruises_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Point p = new Point(e.RowBounds.Location.X + 10,
                                    e.RowBounds.Location.Y + 5);
            e.Graphics.DrawString(e.RowIndex.ToString(), dgvCruises.Font,
                                  Brushes.Black, p);
        }
        private void btnAddAction_Click(object sender, EventArgs e)
        {
            string t, url;
            t = url = string.Empty;
            int v = int.MinValue;
            DateTime? dBeg = null, dEnd = null;
            if (!FormEditAction.EditAction(ref t, ref url, ref v, ref dBeg, ref dEnd)) return;
            if (v == int.MinValue) v = FormVisibleType.GetVisibleMask(v);
            var action = new CruiseAction(0, t, url, v, dBeg, dEnd, null, _synchronizer);
            action.InsertActionToBase(WorkWithData.TsConnection);
            //WorkWithData.InsertActionToBase(action.Text, action.Url, v, dBeg, dEnd);
            GetActions();
            RefreshActionsControls();
        }
        private void btnRemoveAction_Click(object sender, EventArgs e)
        {

            TreeNode item = tvActions.SelectedNode;
            if ((item == null) || (item.Tag == null))
            {
                MessageBox.Show("Акция не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
            if (!Messages.Question(@"Произвести удаление " + item.Text + "?"))
                return;
            var dt = WorkWithData.GetDataTable(@"select distinct actionId,package from CruiseActions where actionId = " + Convert.ToInt32(item.Tag));
            if (dt.Rows.Count > 1)
                if (MessageBox.Show(@"Эта акция используется в других круизах, продолжить удаление?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            using (SqlCommand com = new SqlCommand(@"delete from CruiseActions where actionId=@id", WorkWithData.TsConnection))
            {
                com.Parameters.AddWithValue("@id", Convert.ToInt32(item.Tag));
                com.ExecuteNonQuery();
            }
            using (SqlCommand com = new SqlCommand(@"delete from Actions where action_id=@id", WorkWithData.TsConnection))
            {
                com.Parameters.AddWithValue("@id", Convert.ToInt32(item.Tag));
                com.ExecuteNonQuery();
            }
            //item.DeleteActionFromBase(WorkWithData.TsConnection);
            //WorkWithData.DeleteActionFromBase(item.ID);
            //cruiseActions.First(a => a.ID == item.ID).ChekState=ChekState.Delete;
            GetActions();//UpdateCLBActionsCheck();
        }
        private void btnEditAction_Click(object sender, EventArgs e)
        {
            var node = tvActions.SelectedNode;
            if ((node == null)||(node.Tag==null))
            {
                MessageBox.Show(@"Акция не выбрана", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            DataRow actinRow =
                WorkWithData.GetDataTable(@"select * from Actions where action_id=" + Convert.ToInt32(node.Tag)).Rows[0];
            CruiseAction item = new CruiseAction(actinRow.Field<int>("action_id"), actinRow.Field<string>("action_text"), actinRow.Field<string>("action_URL"), actinRow.Field<int>("action_visible_type"), actinRow.Field<DateTime?>("action_date_beg"), actinRow.Field<DateTime?>("action_date_end"), actinRow.Field<int?>("sort_order"), null);
            var t = item.Text;
            var url = item.Url;
            int v = item.Visiblity;
            DateTime? dBeg = item.DateBegin;
            DateTime? dEnd = item.DateEnd;
            if (!FormEditAction.EditAction(ref t, ref url, ref v, ref dBeg, ref dEnd)) return;
            item.Text = t;
            item.Url = url;
            item.Text = t;
            item.Url = url;
            item.Visiblity = v;
            item.DateBegin = dBeg;
            item.DateEnd = dEnd;
            item.UpdateAction(WorkWithData.TsConnection);
            //WorkWithData.UpdateActions(item.ID, t, url,v,dBeg,dEnd);
            //UpdateCLBActionsCheck();
            GetActions();
        }
        private void btnDeleteCruiseActions_Click(object sender, EventArgs e)
        {
            DataRow[] selcruses = _cruisesTable.Select("selected=true");

            if (selcruses.Length < 1)
            {
                Messages.Error(@"Не выбрано ни одного круиза");
                return;
            }
            int? id;
            if (tvActions.SelectedNode != null)
            {
                id = Convert.ToInt32(tvActions.SelectedNode.Tag);
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
            StringBuilder sb = new StringBuilder(string.Format("select actionId from CruiseActions where actionId={0} and (", id));

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
                using (SqlCommand com = new SqlCommand("delete from CruiseActions where actionId=@actid and package=@pack and sailDate=@date", WorkWithData.TsConnection))
                {
                    com.Parameters.AddWithValue("@actid", id);
                    com.Parameters.AddWithValue("@pack", row.Field<string>("Pacadge"));
                    com.Parameters.AddWithValue("@date", row.Field<DateTime>("saildate"));
                    com.ExecuteNonQuery();
                }
               
            }
            SetFilter();
        }

        private void dgvCruises_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                StringBuilder sb = new StringBuilder();
                //  var selectedCruiseView = ((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as SelectedCruiseView;
                CruiseView cruise = new CruiseView(WorkWithData.GetCruise(((DataGridView)sender).Rows[e.RowIndex].Cells["pacadge"].Value.ToString(), Convert.ToDateTime(((DataGridView)sender).Rows[e.RowIndex].Cells["saildate"].Value)));
                if (cruise.Actions.Count < 1)
                {
                    sb.AppendLine("На данный круиз не назначено тематик");
                }
                else
                {
                    sb.AppendLine("Тематики круиза:");
                    foreach (CruiseAction cruiseAction in cruise.Actions)
                    {
                        sb.AppendLine(string.Format("\t\u2022 {0}", cruiseAction.Text));
                    }
                }
                ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = sb.ToString();
            }
            catch (Exception)
            {

            }
            
            
        }

        private void btnSyncCruiseActions_Click(object sender, EventArgs e)
        {
           
            var crActsForSync = new CruiseActionsCollection();
            DataRow[] selcruses = _cruisesTable.Select("selected=true");
            foreach (var row in selcruses)
            {
                _cruiseViews.Clear();
                _cruiseViews.Add(new SelectedCruiseView(WorkWithData.GetCruise(row.Field<string>("Pacadge"), row.Field<DateTime>("saildate"))));
                _cruiseViews.Last().Selected = true;
            }
            foreach (CruiseAction action in from selectedCruiseView in _cruiseViews.Where(cw => cw.Selected) from CruiseAction action in selectedCruiseView.Actions where !crActsForSync.Any<CruiseAction>(ca => ca.ID == action.ID) select action)
            {
                crActsForSync.Add(action);
            }
            //if (!FormSelectSyncItems.SelectsyncItems(crActsForSync)) return;
            if (!FormSelectSyncBases.SelectSyncBases(_synchronizer.SyncProccessors)) return;
            WaitForm.WaitInBackground("Идет синхронизация", false, () =>
            {
                foreach (var syncProcessor in _synchronizer.SyncProccessors.Where(sp => sp.IsEnable))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(string.Format("select * from CruiseActions"), syncProcessor.ToConnection));
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                        var inserted = new List<string>();
                        foreach (SelectedCruiseView selectedCruiseView in _cruiseViews.Where(cw => cw.Selected))
                        {
                            const string deleteQuery = "delete from CruiseActions where package = @p0 and sailDate = @p1";
                            deleteQuery.ExecuteNonQuery(syncProcessor.ToConnection,selectedCruiseView.Package,selectedCruiseView.SailDate);
                            foreach (CruiseAction action in selectedCruiseView.Actions)
                            {
                                int newActid;
                                try
                                {
                                    newActid = syncProcessor.GetUpdatingItemId(action.ID.Value, action.SyncItemType);
                                }
                                catch (ArgumentException)
                                {
                                    var si = action.Synchronize(syncProcessor, SynchronyzeMethod.Insert);
                                    if (si == null) continue;
                                    si.InsertSyncRecord(WorkWithData.TsConnection);
                                    newActid = si.DestinationId;
                                }
                                var insertingStr = string.Format("{0}{1}{2}", action.ID, selectedCruiseView.Package,
                                                       selectedCruiseView.SailDate.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
                                if (inserted.Contains(insertingStr)) continue;
                                inserted.Add(insertingStr);
                                using (SqlCommand command = new SqlCommand(string.Format(@"insert into CruiseActions(actionId,package,sailDate) values ({0},'{1}','{2}')",
                                        newActid, selectedCruiseView.Package, selectedCruiseView.SailDate.ToString("yyyy-MM-ddTHH:mm:ss.fff")), syncProcessor.ToConnection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    syncProcessor.ResetSyncData();
                }
                Messages.Information("Синхронизация прошла успешно");
            });
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

            cruiseSqlCommand.CommandType = CommandType.StoredProcedure;


            cruiseSqlCommand.Parameters.AddWithValue("@datebegin", dtpBegin.Value);
            cruiseSqlCommand.Parameters.AddWithValue("@mindur", Convert.ToInt32(minDur.Text));
            cruiseSqlCommand.Parameters.AddWithValue("@maxdur", Convert.ToInt32(maxDur.Text));
            cruiseSqlCommand.Parameters.AddWithValue("@dateend", dtpEnd.Value);
            SqlDataAdapter cruiseAdapter = new SqlDataAdapter(cruiseSqlCommand);


            cruiseAdapter.Fill(_cruisesTable);
            DataColumn col=_cruisesTable.Columns.Add("selected",typeof(Boolean));
            col.DefaultValue = false;

            flag = 0;

        }

        private void applyFilter_Click(object sender, EventArgs e)
        {
            SetFilter();
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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
    public class SelectedCruiseView : CruiseView
    {
        public bool Selected { get; set; }
        public SelectedCruiseView(Cruise cruise)
            : base(cruise)
        {
        }

    }
   
}
