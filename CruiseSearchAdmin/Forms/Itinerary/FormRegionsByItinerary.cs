using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CruiseSearchAdmin;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.SyncModel;
using CruiseSearchAdmin.Forms.Regions;
using CruiseSearchAdmin.HelperClasses;
using DevExpress.Data.Selection;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Itinerary
{
    public partial class FormRegionsByItinerary : ProjectForm
    {
        private const string SELECT_ACTION_WITH_GROUP = @"select * from
                                                        (select * from
                                                        (select Actions_visible_group.id,Actions_visible_group.Name,SUM(mk_tbVisibleTypes.VT_MASK)as summask from Actions_visible_group inner join dbo.mk_tbVisibleTypes on Actions_visible_group.id =mk_tbVisibleTypes.VT_id_group
                                                        group by Actions_visible_group.id,Actions_visible_group.Name)as grm inner join Actions as a on (a.action_visible_type & summask) >0
                                                        union
                                                        select 0 ,'Без группы',0,Actions.* from Actions where action_visible_type=0 or action_visible_type is null)as t1
                                                        order by t1.id,action_text";
        readonly List<ItRegion> _regions = new List<ItRegion>();
        readonly List<long> _regIds = new List<long>();
        readonly List<int> _actIds = new List<int>();
        readonly List<long> _deletedRegionsIDs = new List<long>();
        readonly List<long> _insertedRegionsIDs = new List<long>();
        readonly List<long> _deletedActionsIDs = new List<long>();
        readonly List<long> _insertedActionsIDs = new List<long>();
        readonly CruiseActionsCollection _cruiseActions = new CruiseActionsCollection();
        private Synchronizer _synchronizer;
        private AccessRigts _access = AccessRigts.All;
        private int _itenareryId;
        private string _pack;
        private Cruise _selectedCruise;
        private string _mapImagePath;
        public FormRegionsByItinerary(Cruise cruise, List<CruiseView> cruises)
        {
            InitializeComponent();
            InitializeSpecialOffersPageEvents();

            _selectedCruise = cruise;
            GetData();

            cbPeresadka.Items.Add(0);
            cbPeresadka.Items.Add(1);
            
            InitializeMapEvents();
            InitializeTabPagesWithRigts();
            cbCruiseDate.DataSource = cruises;
            cbCruiseDate.DisplayMember = "sailDate";
            cbCruiseDate.SelectedIndex =cbCruiseDate.Items.IndexOf((cbCruiseDate.DataSource as List<CruiseView>).First(c => c.SailDate == cruise.SailDate));
            groupBox3.Enabled = chbHasSO.Checked;
            RefreshMap();
            
        }void InitializeSpecialOffersPageEvents()
        {
            
            chbHasSO.CheckedChanged += (s, o) => { tbCost.Enabled = cbSpecialOffers.Enabled=groupBox3.Enabled = chbHasSO.Checked; formErorrProvider.Clear(); GetDopPaket(); };
            btnRemSpecOffer.Click += (s, e) => RemoveSpecialOffer();
            btnAddSpecOffer.Click += (s, e) => AddSpecialOffer();
            btnRenameSpecOffer.Click += (s, e) => EditSpecialOffer();
            tbCost.KeyPress += (s, e) =>
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+") && e.KeyChar != '\b')
                    e.Handled = true;
                formErorrProvider.Clear();
            };
        }
        void InitializeTabPagesWithRigts()
        {
            if (_access == AccessRigts.Actions || _access == AccessRigts.None)
            {
                tabControl.TabPages.Remove(tabControl.TabPages[0]); // Enabled = false;
            }
            if (_access == AccessRigts.Regions || _access == AccessRigts.None)
            {
                var i = 1;
                if (_access == AccessRigts.None) i = 0;
                tabControl.TabPages.Remove(tabControl.TabPages[i]);
            }
        }
        void InitializeMapEvents()
        {
            btnRefreshMap.Click += (s, e) => RefreshMap();
            btnSaveMap.Click += (s, e) => SaveImage();
            btnLoad.Click += (s, e) => pbMap.Image = LoadMap(pbMap.Image);
        }

        void GetData()
        {
            GetRegions();
            GetActions();
            GetSpecialOffers();
            _synchronizer = new Synchronizer(_cruiseActions,WorkWithData.TsConnection);
        }

        void RefreshMap()
        {
            string fPath = WorkWithData.GetCruiseMapPath(_selectedCruise.CruiseItinerery.ID.ToString());
            pbMap.LoadAsync(fPath);
        }
        void GetSelectedCruise()
        {
            tbItinerary.Text = _selectedCruise.CruiseItinerery.Text;
            _itenareryId = _selectedCruise.CruiseItinerery.ID;
            _insertedRegionsIDs.Clear();
            tbCrLine.Text = _selectedCruise.CruiseLn.EnName;
            tbPort.Text = _selectedCruise.DepPort.Name.EN;
            tbShip.Text = _selectedCruise.Ship.Name;
            _pack = _selectedCruise.Package;
            tbDuration.Text = _selectedCruise.Duration;

            if (_access == AccessRigts.All || _access == AccessRigts.Regions)
                GetRegionsByItinary(_itenareryId);
            if (_access == AccessRigts.All || _access == AccessRigts.Actions)
                ChekActionUpdate();
                // GetActionsByCruise(_selectedCruise.Package, _selectedCruise.SailDate);
            GetSpecialOffers();
            cbCruiseDate.SelectedIndex =
                cbCruiseDate.Items.IndexOf(
                    (cbCruiseDate.DataSource as List<CruiseView>).First(c => c.SailDate == _selectedCruise.SailDate));
           
            
        }
        void GetDopPaket()
        {
            DataTable dopPak = new DataTable();
            SqlCommand dop = new SqlCommand(@"select TL_KEY,TL_NAME  FROM [dbo].[tbl_TurList] 
            where TL_TIP = 149 and TL_Deleted <>1",WorkWithData.MasterConnection);
            SqlDataAdapter dopad = new SqlDataAdapter(dop);
            dopad.Fill(dopPak);
            DataTable cruisPak = new DataTable();
            SqlCommand crPak = new SqlCommand(@"select Tur_master_Id from Cruise_dop_paket where (package=@p1 and sailDate=@p2)",WorkWithData.TsConnection);
            crPak.Parameters.AddWithValue("@p1", _selectedCruise.Package);
            crPak.Parameters.AddWithValue("@p2", _selectedCruise.SailDate);
            SqlDataAdapter crPakad = new SqlDataAdapter(crPak);
            crPakad.Fill(cruisPak);
            List <DopPaket> paks= new List<DopPaket>();
            foreach (DataRow row in cruisPak.Rows)
            {

                DopPaket pak = new DopPaket();
                pak.id = row.Field<int>("Tur_master_Id");
                foreach (DataRow rowi in dopPak.Rows)
                {
                    if (rowi.Field<int>("TL_KEY") == pak.id)
                    {
                        pak.name = rowi.Field<string>("TL_NAME");
                        break;
                    }
                }
                paks.Add(pak);

            }
            DopPaket par = new DopPaket();
            par.id = -1;par.name = "Без пакета";paks.Insert(0,par);
            cbPaket.DataSource = paks;

        }

        void GetSpecialOffers()
        {
            var specialOffer = new List<SpecialOffer>();
            var dt = WorkWithData.GetDataTable("select  * from mk_tbSpecialOffers");
            specialOffer.Add(new SpecialOffer() { Id = -1, Text = "Без названия" });
            specialOffer.AddRange(from DataRow row in dt.Rows
                                  let SoID = Convert.ToInt32(row["SO_ID"])
                                  let txt = row["SO_TEXT"].ToString()
                                  let vis = row.Field<int>("SO_VISIBLE")
                                  select new SpecialOffer() {Id =SoID, Text = txt,Visible = vis});
            cbSpecialOffers.DataSource = specialOffer;
            cbSpecialOffers.ValueMember = "Id";
            cbSpecialOffers.DisplayMember = "Text";

            var cdt = WorkWithData.GetDataTable(string.Format(@"select * from mk_tbCruiseSpecialOffers where C_PACKAGE = '{0}' and C_SAILDATE = '{1}'", _selectedCruise.Package, _selectedCruise.SailDate.ToString("yyyy-MM-dd")));
            if (cdt.Rows.Count < 1) return;
            int cSoID = -1;
            int cCBC = (int) cdt.Rows[0][2];
            int csoID = (int) cdt.Rows[0][0];
            int paket = -1;
            if (cdt.Rows[0].Field<int?>("Dop_paket") != null)
            {
                paket = Convert.ToInt32(cdt.Rows[0].Field<int?>("Dop_paket"));
            }
            tbCitys.Text = cdt.Rows[0].Field<int?>("N_city").ToString();
            tbCountrys.Text = cdt.Rows[0].Field<int?>("N_country").ToString();
            tbTemp.Text = cdt.Rows[0].Field<int?>("Temperature").ToString();
            tbFrom.Text = cdt.Rows[0].Field<string>("aero_From");
            tbTo.Text = cdt.Rows[0].Field<string>("aero_to");
            cbPeresadka.SelectedItem= cdt.Rows[0].Field<int>("Is_peresfdka"); 
            tbTimeFly.Text = cdt.Rows[0].Field<string>("time_of_fly");tbCostFly.Text = cdt.Rows[0].Field<int?>("Cost_of_fly").ToString();
            if (cdt.Rows[0][1] != DBNull.Value) cSoID = (int)cdt.Rows[0][1];
            _selectedCruise.SpecialOffer = new CruisSpecialOffer() { CsoId = csoID, CsoBaseCost = cCBC, SoId = cSoID };
            tbCost.Text = cdt.Rows[0][2].ToString();
            cbSpecialOffers.SelectedValue = cSoID;
            for (int i = 0; i < cbPaket.Items.Count;i++ )
            {
                DopPaket pak = cbPaket.Items[i] as DopPaket;
                if (pak.id == paket)
                {
                    cbPaket.SelectedIndex = i;break;
                }
            }
            chbHasSO.Checked =true;
        }
        
        void RemoveSpecialOffer()
        {
            formErorrProvider.Clear();
            if(cbSpecialOffers.Items.Count==1){Messages.Information("Не существует ни одного спецпредложения");
                return;
            }
            int ID =FormSelectSpecialOffers.GetSpecialOffer(
                    (cbSpecialOffers.DataSource as List<SpecialOffer>).Where(so => so.Id >= 0).ToList());
            if(ID==-1) return;
            if (!Messages.Question("Вы действительно хотите удалить " + (cbSpecialOffers.DataSource as List<SpecialOffer>).Find(so => so.Id >= 0).Text)) return;
                string deleteSOQuery = @"delete from mk_tbSpecialOffers where SO_ID=@p0";
                deleteSOQuery.ExecuteNonQuery(ID);
            GetSpecialOffers();
        }
        void EditSpecialOffer()
        {
            if (cbSpecialOffers.Items.Count == 1)
            {
                Messages.Information("Не существует ни одного спецпредложения");
                return;
            }
            int ID =
                FormSelectSpecialOffers.GetSpecialOffer(
                    (cbSpecialOffers.DataSource as List<SpecialOffer>).Where(so => so.Id >= 0).ToList());
            if (ID == -1) return;
            var specOf = (cbSpecialOffers.DataSource as List<SpecialOffer>).Find(so => so.Id == ID);
            var SO_TEXT = specOf.Text;
            if (!FormSetName.GetName(ref SO_TEXT)) return;
            var SO_Visible = specOf.Visible;
            SO_Visible = FormVisibleType.GetVisibleMask(SO_Visible);
            string updateSOQuery = @"update mk_tbSpecialOffers set SO_TEXT=@p1,SO_VISIBLE=@p2 where SO_ID=@p0";
            updateSOQuery.ExecuteNonQuery(ID,SO_TEXT,SO_Visible);
            GetSpecialOffers();
        }
        void AddSpecialOffer()
        {
            var SO_TEXT = string.Empty;
            if (!FormSetName.GetName(ref SO_TEXT)) return;
            var visible = int.MaxValue;
            visible = FormVisibleType.GetVisibleMask(visible);
            string insertSOQuery = @"insert into mk_tbSpecialOffers values(@p0,@p1)";
            insertSOQuery.ExecuteNonQuery(SO_TEXT,visible);
            GetSpecialOffers();
        }

        void GetActions()
        {
            var dt = WorkWithData.GetDataTable(SELECT_ACTION_WITH_GROUP); 
            if (dt == null)
            
            {
               _access = AccessRigts.Regions;
               return;
            }
            string selGroup = string.Empty;
            TreeNode selRoot = new TreeNode();
            tvAction.Nodes.Clear();
            //_cruiseActions.Clear();
            foreach (DataRow dataRow in dt.Rows)
            {
                if (selGroup.Equals(string.Empty))
                {
                    selGroup = dataRow["Name"].ToString();
                    selRoot = tvAction.Nodes.Add(dataRow["Id"].ToString(), selGroup);
                    TreeNode newNode = selRoot.Nodes.Add(dataRow["action_id"].ToString(),dataRow["action_text"].ToString());
                    newNode.Tag = dataRow.Field<int>("action_id");
                }
                else
                {
                   
                    if (selGroup != dataRow["Name"].ToString())
                    {
                        selGroup = dataRow["Name"].ToString();
                        selRoot = tvAction.Nodes.Add(dataRow["Id"].ToString(), selGroup);
                        TreeNode newNode = selRoot.Nodes.Add(dataRow["action_id"].ToString(), dataRow["action_text"].ToString());
                        newNode.Tag = dataRow.Field<int>("action_id"); 
                    }
                    else
                    {
                        TreeNode newNode = selRoot.Nodes.Add(dataRow["action_id"].ToString(), dataRow["action_text"].ToString());
                        newNode.Tag = dataRow.Field<int>("action_id");
                    }
                }

                /*int id = Convert.ToInt32(dataRow["action_id"]);
                string text = dataRow["action_text"].ToString();
                string url = dataRow["action_URL"] != DBNull.Value ? dataRow["action_URL"].ToString() : string.Empty;
                int v = Convert.ToInt32(dataRow["action_visible_type"]);
                var dbeg = dataRow.Field<DateTime?>("action_date_beg");
                var dend = dataRow.Field<DateTime?>("action_date_end"); 
                var sortOrder = dataRow.Field<int?>("sort_order");
                _cruiseActions.Add(new CruiseAction(id, text, url,v,dbeg,dend,sortOrder,_synchronizer));*/
            }
            ChekActionUpdate();
            /*clbActions.DataSource = null;
            clbActions.DataSource = _cruiseActions.ToList<CruiseAction>();
            clbActions.DisplayMember = "Text";*/
        }
        void ChekActionUpdate()
        {
            DataTable dt;
            tvAction.CheckBoxes = true;
            dt = WorkWithData.GetDataTable(@"select * from CruiseActions where package='" + _selectedCruise.Package + "'" + "and saildate='" + _selectedCruise.SailDate.ToString("yyyy-MM-dd")+"'");
            foreach (DataRow dataRow in dt.Rows)
            {
                foreach (var node in tvAction.Nodes.Find(dataRow.Field<int>("actionID").ToString(), true))
                {
                    node.Checked = true;
                }
            }
            _insertedActionsIDs.Clear();}

        public static void GetSettings(Cruise cruise, List<CruiseView> cruises)
        {
            using (var f = new FormRegionsByItinerary(cruise, cruises))
            {
                f.ShowDialog();
            }}
      public  void GetRegions()
        {
            DataTable dt = WorkWithData.GetRegionsTable();
            if (dt == null || !WorkWithData.GetPermissions())
            {
                _access = AccessRigts.Actions;
                return;
            }
            _regions.Clear();
            foreach (DataRow row in dt.Rows)
            {
                long id = row.Field<long>("id");
                int? id_parent=0;
                string name_ru = row["name_ru"].ToString();
                int? order=0;
                try
                {
                     id_parent = row.Field<int?>("parent");
                }
                catch
                {
                    Debug.WriteLine("perent "+row.Field<long?>("parent").ToString());
                  }
                try
                { 
                    order = row.Field<int?>("ordrer");
                }
                catch 
                {
                    Debug.WriteLine("Order "+row.Field<int?>("ordrer").ToString());
                    
                    
                }
                
                _regions.Add(new ItRegion(id, name_ru,id_parent,order));
                tvRegions.CheckBoxes = true;
                if (id_parent == null){
                    TreeNode newNode=tvRegions.Nodes.Add(id.ToString(),name_ru);
                     newNode.Tag = id;

                }
                else
                {
                    if (tvRegions.Nodes.Find(id_parent.ToString(), false).Count()>0)
                    {
                       TreeNode parentNode = tvRegions.Nodes.Find(id_parent.ToString(), false)[0];
                       TreeNode newNode=parentNode.Nodes.Add(id.ToString(),name_ru);
                       newNode.Tag = id;
                        


                    }
                    
                }
            }
          ChekUpdate();
             /* 
            clbRegions.DataSource = null;
            clbRegions.DataSource = _regions;
            clbRegions.DisplayMember = "Name";
             */
        }
        void GetRegionsByItinary(int itineraryId)
        {
            var dt = WorkWithData.GetRegionsByItineraryTable(itineraryId);
            ClearCheckedListBoxCheck(clbRegions);
            _regIds.Clear();
            foreach (int id in
                from DataRow row in dt.Rows
                select Convert.ToInt32(row["key_if_region"])
                into id where !_regIds.Contains(id) select id)
            {
                _regIds.Add(id);
            }
            try
            {
                for (int index = 0; index < clbRegions.Items.Count; index++)
                {
                    ItRegion item = clbRegions.Items[index] as ItRegion;
                    if(item==null)continue;
                    if (_regIds.Contains(item.ID))
                        clbRegions.SetItemChecked(clbRegions.Items.IndexOf(item), true);
                }
                _insertedRegionsIDs.Clear();
            }
            catch(Exception)
            {
            
                throw;
            }
        }
        void ClearCheckedListBoxCheck (CheckedListBox clb)
        {
            foreach (int i in clb.CheckedIndices)
            {
                clb.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        bool GetChanges()
        {
            if ((_deletedActionsIDs.Count>0)||(_insertedActionsIDs.Count>0))
            {
                return true;
            }
        else
            {
              return false;   
            }
            //var cAct = (from CruiseAction ca in _cruiseActions where ca.Text[ca.Text.Length - 1] == '*' select ca).Count() ;
            //return _cruiseActions.Count<CruiseAction>(ca => ca.Text[ca.Text.Length - 1] == '*') != 0;
        }
        //void GetActionsByCruise(string pack, DateTime datetime)
        //{
        //    var dt = WorkWithData.GetActionsByCruiseTable(pack, datetime);
        //    ClearCheckedListBoxCheck(clbActions);
        //    _actIds.Clear();
        //    try
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            int id = Convert.ToInt32(row["actionId"]);
        //            _cruiseActions.First<CruiseAction>(c => c.ID == id).Checked = true;
        //        }
        //        for (int index = 0; index < clbActions.Items.Count; index++)
        //        {
        //            CruiseAction item = clbActions.Items[index] as CruiseAction;
        //            if (item.Checked)
        //            {
        //                item.ChekState = CheckActionState.Lock;
        //                clbActions.SetItemChecked(clbActions.Items.IndexOf(item), true);
        //                item.ChekState = CheckActionState.None;
        //                if (item.Text[item.Text.Length - 1] == '*')
        //                    item.Text = item.Text.Remove(item.Text.Length - 1);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        #region 'Применение изменений'
        void ApplyChangesToDB(string query, SqlTransaction transaction)
        {
            using (SqlCommand command = new SqlCommand(query, WorkWithData.TsConnection))
            {
                command.Transaction = transaction;
                command.ExecuteNonQuery();
             
            }
        }
        void DeleteDeselectedRegions(SqlTransaction sqlTransaction)
        {
            foreach (var iD in _deletedRegionsIDs)
            {
                ApplyChangesToDB(
                    string.Format(@"delete from regionsbyitenary where key_if_region = {0} and itenary = {1}", iD,
                                  _itenareryId), sqlTransaction);
               // (_selectedCruise.Regions).Remove(_selectedCruise.Regions.First(r => r.ID == iD));

            }
            _deletedRegionsIDs.Clear();
        }
        void DeleteDeselectedActions(SqlTransaction sqlTransaction)
        {
            foreach (long actionsID in _deletedActionsIDs)
            {
                ApplyChangesToDB(string.Format(@"delete from CruiseActions   where (actionId={0}) and (package='{1}') and (sailDate ='{2}') ", actionsID, _selectedCruise.Package, _selectedCruise.SailDate.ToString("yyyy-MM-ddTHH:mm:ss.fff")), sqlTransaction);
               
            }
            _deletedActionsIDs.Clear();
            /* foreach (var ca in _cruiseActions.Where<CruiseAction>(c => c.ChekState == CheckActionState.Delete).ToList())
            {
                ca.ChekState = CheckActionState.None;
                var iD = ca.ID;
                ApplyChangesToDB(string.Format(@"delete from CruiseActions where actionId={0} and package='{1}' and sailDate='{2}'", iD, _pack, _selectedCruise.SailDate.ToString("yyyy-MM-ddTHH:mm:ss.fff")), sqlTransaction);
            }*/

        }
        void InsertAddedActions(SqlTransaction sqlTransaction)
        {
            foreach (long actionsID in _insertedActionsIDs)
            {
                ApplyChangesToDB(string.Format(@"insert into CruiseActions(actionId,package,sailDate) values({0},'{1}','{2}')", actionsID, _selectedCruise.Package, _selectedCruise.SailDate.ToString("yyyy-MM-ddTHH:mm:ss.fff")), sqlTransaction);
                
            }
            _insertedActionsIDs.Clear();
            /* foreach (var ca in _cruiseActions.Where<CruiseAction>(c => c.ChekState == CheckActionState.Insert).ToList())
            {
                ca.ChekState = CheckActionState.None;
                var iD = ca.ID;
                ApplyChangesToDB(string.Format(@"insert into CruiseActions(actionId,package,sailDate) values ({0},'{1}','{2}')", iD, _pack, _selectedCruise.SailDate.ToString("yyyy-MM-ddTHH:mm:ss.fff")), sqlTransaction);
            }*/
        }
        void InsertAddedRegions(SqlTransaction sqlTransaction)
        {
            foreach (var iD in _insertedRegionsIDs)
            {
                ApplyChangesToDB(string.Format(@"insert  into regionsbyitenary (key_if_region,itenary) values({0},{1})", iD, _itenareryId), sqlTransaction);
                var res = _selectedCruise.Regions.Where(r => r.ID == iD);
                if (res.Count() == 0)
                    ((List<ItRegion>)_selectedCruise.Regions).Add(new ItRegion(iD, ""));
            }
            _insertedRegionsIDs.Clear();
        }
       
        void UpdateCruiseSpecOffer()
        {
            int? SoBaseCost=null,cytis=null,coutrys=null,tempirature=null,costsfly=null,doppaket=null;
            string  timefly=null;
           
            if (chbHasSO.Checked)
            {
                if (tbCost.Text == String.Empty)
                {
                    //formErorrProvider.SetError(tbCost,"Поле не может быть пустым");
                   //throw new DataException("Базовая цена спец предложения должна быть заполнена!");
                    SoBaseCost = 1;
                }
                else
                {
                    SoBaseCost = Convert.ToInt32(tbCost.Text);
                }
                
                DopPaket pak = cbPaket.SelectedValue as DopPaket;
                if (pak.id == -1)
                {
                    doppaket = null;

                }
                else
                {
                    doppaket = Convert.ToInt32(pak.id);
                }
                
                if (tbTimeFly.Text == string.Empty)
                {
                    timefly = null;
                }
                else
                {
                    timefly = tbTimeFly.Text;
                }

                if (tbCostFly.Text == string.Empty)
                {
                    costsfly = null;
                }
                else
                {
                    costsfly = Convert.ToInt32(tbCostFly.Text);
                }

                if (tbTemp.Text == string.Empty)
                {
                    tempirature = null;
                }
                else
                {
                    tempirature = Convert.ToInt32(tbTemp.Text);
                }
                
                if (tbCountrys.Text == string.Empty)
                {
                    coutrys = null;
                }
                else
                {
                    coutrys= Convert.ToInt32(tbCountrys.Text);
                }

                if (tbCitys.Text == string.Empty)
                {
                    cytis = null;
                }
                else
                {
                    cytis = Convert.ToInt32(tbCitys.Text);
                }
                object SoId = null;
                if (cbSpecialOffers.Items.Count > 0 && (int)cbSpecialOffers.SelectedValue!=-1)
                    SoId = (int) cbSpecialOffers.SelectedValue;
                
                //if (cbCruiseDate.)
                if (_selectedCruise.SpecialOffer == null)
                {
                    string insertCOQuery =
                        @"insert into mk_tbCruiseSpecialOffers(SO_ID,CSO_BASE_COST,C_PACKAGE,C_SAILDATE,N_city,N_country,Temperature,time_of_fly,Cost_of_fly,Dop_paket,aero_From,aero_to,Is_peresfdka) values(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)";
                    insertCOQuery.ExecuteNonQuery(SoId, SoBaseCost, _selectedCruise.Package, _selectedCruise.SailDate.ToString("yyyy-MM-dd"), cytis, coutrys, tempirature, timefly, costsfly, doppaket, tbFrom.Text, tbTo.Text, cbPeresadka.SelectedItem == null ? 0 : cbPeresadka.SelectedItem);
                }
                else
                {
                    string updateCOQuery =
                        @"update mk_tbCruiseSpecialOffers set SO_ID=@p0,CSO_BASE_COST=@p1,N_city=@p2,N_country=@p3,Temperature=@p4,time_of_fly=@p5,Cost_of_fly=@p6,Dop_paket=@p7,aero_From=@p8,aero_to=@p9,Is_peresfdka=@p10 where CSO_ID=@p11";
                    updateCOQuery.ExecuteNonQuery(SoId, SoBaseCost, cytis, coutrys, tempirature, timefly, costsfly, doppaket, tbFrom.Text, tbTo.Text, cbPeresadka.SelectedItem, _selectedCruise.SpecialOffer.CsoId);
                }
            }
            else
            {
                if(_selectedCruise.SpecialOffer!=null)
                {
                    string deleteCOQuery = @"delete from mk_tbCruiseSpecialOffers where CSO_ID=@p0";deleteCOQuery.ExecuteNonQuery(_selectedCruise.SpecialOffer.CsoId);
                }
            }
        }

        #endregion
        private void clbRegions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var id = (clbRegions.SelectedItem as ItRegion).ID;
            CheckCLBState(e.NewValue, id, _deletedRegionsIDs, _insertedRegionsIDs);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            _insertedActionsIDs.Clear();
            _insertedRegionsIDs.Clear();
        }
        void ApplyChanges()
        {
            SqlTransaction sqlTransaction = WorkWithData.TsConnection.BeginTransaction();
            try
            {
                if (_access == AccessRigts.All || _access == AccessRigts.Regions)
                {
                    DeleteDeselectedRegions(sqlTransaction);
                    InsertAddedRegions(sqlTransaction);
                }
                if (_access == AccessRigts.All || _access == AccessRigts.Actions)
                {
                    DeleteDeselectedActions(sqlTransaction);
                    InsertAddedActions(sqlTransaction);

                }
                //
                sqlTransaction.Commit();
                GetActions();
               //GetActionsByCruise(_selectedCruise.Package, _selectedCruise.SailDate);
                
                UpdateCruiseSpecOffer();
                _deletedActionsIDs.Clear();

                _insertedActionsIDs.Clear();
                
                MessageBox.Show("Изменения внесены успешно", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DataException dataException)
            {
                Messages.Error(dataException.Message);
            }
            catch (SqlException exception)
            {
                sqlTransaction.Rollback();
                MessageBox.Show("В ходе операции возникла ошибка: "+exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void cbCruiseDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCruise = (cbCruiseDate.SelectedItem as CruiseView).CruiseLink;
            GetSelectedCruise();
            
        }
        void CheckCLBState(CheckState checkState, long ID, List<long> deletedIDs, List<long> insertedIDs)
        {
            try
            {
                if (checkState == CheckState.Checked)
                {
                    if (deletedIDs.Contains(ID))
                    {
                        deletedIDs.Remove(ID);
                    }
                    else
                        if (!insertedIDs.Contains(ID))
                            insertedIDs.Add(ID);
                }
                if (checkState == CheckState.Unchecked)
                {
                    if (insertedIDs.Contains(ID))
                    {
                        insertedIDs.Remove(ID);
                    }
                    else
                        if (!deletedIDs.Contains(ID))
                            deletedIDs.Add(ID);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void clbActions_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            var id = (clbActions.Items[e.Index] as CruiseAction).ID;
            var ca = _cruiseActions.First<CruiseAction>(c => c.ID == id);
            if (ca.ChekState == CheckActionState.Lock) return;
            ca.Checked = !ca.Checked;
            if (ca.Checked) ca.ChekState = CheckActionState.Insert;
            else ca.ChekState = CheckActionState.Delete;
            //CheckCLBState(e.NewValue,id,deletedActIDs,insertedActIDs);
        }
        private void btnRemoveAction_Click(object sender, EventArgs e)
        {

            TreeNode item = tvAction.SelectedNode;
            if ((item == null) || (item.Tag == null))
            {
                MessageBox.Show("Акция не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }if (GetChanges())
            {
                if (MessageBox.Show("Были внесены изменения их следует подтвердить, сохранить?", "Сохранить изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ApplyChanges();
                }
            }
            if (!Messages.Question(@"Произвести удаление "+item.Text+"?"))
                return;
            var dt = WorkWithData.GetDataTable(@"select distinct actionId,package from CruiseActions where actionId = "+Convert.ToInt32(item.Tag));
            if (dt.Rows.Count > 1)
                if (MessageBox.Show(@"Эта акция используется в других круизах, продолжить удаление?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            using (SqlCommand com = new SqlCommand(@"delete from CruiseActions where actionId=@id", WorkWithData.TsConnection))
            {
                com.Parameters.AddWithValue("@id",Convert.ToInt32( item.Tag));
                com.ExecuteNonQuery();
            }
            //item.DeleteActionFromBase(WorkWithData.TsConnection);
            //WorkWithData.DeleteActionFromBase(item.ID);
            //cruiseActions.First(a => a.ID == item.ID).ChekState=ChekState.Delete;
            GetActions();//UpdateCLBActionsCheck();

            UpdateCLBActionsCheck();


        }
        private void btnAddAction_Click(object sender, EventArgs e)
        {
            if (GetChanges())
            {
                if (MessageBox.Show("Были внесены изменения их следует подтвердить, сохранить?", "Сохранить изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ApplyChanges();
            }
            string t, url;
            t = url = string.Empty;
            int v = int.MinValue;
            DateTime? dBeg =null, dEnd = null;
            if (!FormEditAction.EditAction(ref t, ref url,ref v,ref dBeg,ref dEnd)) return;
            if (v == int.MinValue) v = FormVisibleType.GetVisibleMask(v);
            var action = new CruiseAction(0, t, url,v,dBeg,dEnd,null,_synchronizer);
            action.InsertActionToBase(WorkWithData.TsConnection);
            //WorkWithData.InsertActionToBase(action.Text, action.Url,v,dBeg,dEnd);
            //UpdateCLBActionsCheck();
            GetActions();

        }
        void UpdateCLBActionsCheck()//Установка не сохраненных галок при обновлении dgvActions
        
        {
            GetActions();
            //GetActionsByCruise(_pack, _selectedCruise.SailDate);
        }
        private void btnEditActions_Click(object sender, EventArgs e)
        {
            var node =tvAction.SelectedNode;
            if ((node == null) || (node.Tag == null))
            {
                MessageBox.Show(@"Акция не выбрана", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetChanges())
            {
                if (MessageBox.Show(@"Были внесены изменения их следует подтвердить перед добавлением, сохранить?", @"Сохранить изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ApplyChanges();
            }
            DataRow actinRow =
                WorkWithData.GetDataTable(@"select * from Actions where action_id=" + Convert.ToInt32(node.Tag)).Rows[0];
            CruiseAction item = new CruiseAction(actinRow.Field<int>("action_id"),actinRow.Field<string>("action_text"),actinRow.Field<string>("action_URL"),actinRow.Field<int>("action_visible_type"),actinRow.Field<DateTime?>("action_date_beg"),actinRow.Field<DateTime?>("action_date_end"),actinRow.Field<int?>("sort_order"),null);
            var t = item.Text;
            var url = item.Url;
            int v = item.Visiblity;
            DateTime? dBeg = item.DateBegin;
            DateTime? dEnd = item.DateEnd;
            if (!FormEditAction.EditAction(ref t, ref url,ref v,ref dBeg,ref dEnd)) return;
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
        Image LoadMap(Image b)
        {
            Stream data;
            OpenFileDialog oDialog = new OpenFileDialog();
            oDialog.Filter = @"images (*.bmp,*.jpg)|*.bmp;*.jpg";
            if (oDialog.ShowDialog() == DialogResult.OK)
                try
                {

                    if ((data = oDialog.OpenFile()) != null)
                    {
                        _mapImagePath = oDialog.FileName;
                        
                        using (data)
                        {
                            return new Bitmap(data);
                        }
                    }
                }
                catch (Exception)
                {
                    return b;
                }
            return b;
        }
        void SaveImage()
        {
            try
            {
                if (pbMap.Image != pbMap.ErrorImage && _mapImagePath != string.Empty)
                {
                    if (!WorkWithData.FTPMapUpload(_mapImagePath, _selectedCruise.CruiseItinerery.ID.ToString()))
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Сохранение прошло успешно", "Успех", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно сохранить изображение, произошла ошибка " + ex.Message, "Ошибка", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
            }
        }

        
        private void btnRegeonRedactor_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRedactorRegeon RegRedactor = new FormRedactorRegeon();
            RegRedactor.ShowDialog();
            GetRegions();
            this.Show();
            
        }

     

        private void tvRegions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //if (e.Node.Checked && (e.Node.Parent==null))
            //{
            //  foreach (TreeNode sel in e.Node.Nodes)
            //{
            //    sel.Checked = true;}

            //e.Node.Checked = false;
            //}
            if (e.Node.Checked)
            {
                if (_deletedRegionsIDs.IndexOf(Convert.ToInt64(e.Node.Tag)) != -1)
                {
                    _deletedRegionsIDs.Remove(Convert.ToInt32(e.Node.Tag));
                }
                else
                {
                    _insertedRegionsIDs.Add(Convert.ToInt32(e.Node.Tag));
                }
            }
            if (!e.Node.Checked)
            {
                if (_insertedRegionsIDs.IndexOf(Convert.ToInt64(e.Node.Tag)) != -1)
                {
                    _insertedRegionsIDs.Remove(Convert.ToInt32(e.Node.Tag));
                }
                else
                {
                    _deletedRegionsIDs.Add(Convert.ToInt32(e.Node.Tag));
                }
            }

        }

        private void tvAction_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked && (e.Node.Parent==null))
            {
                e.Node.Checked = false;
            }
            foreach (TreeNode node in tvAction.Nodes.Find(Convert.ToString(e.Node.Tag),true))
            {
                if (node.Checked != e.Node.Checked)
                {
            //e.Node.Checked = false;
            //}

            if (e.Node.Checked )
            {
                if (_deletedRegionsIDs.IndexOf(Convert.ToInt64(e.Node.Tag)) != -1)
                {
                    _deletedRegionsIDs.Remove(Convert.ToInt32(e.Node.Tag));
                }
                else
                {
                    _insertedRegionsIDs.Add(Convert.ToInt32(e.Node.Tag));
                    node.Checked = e.Node.Checked;
                }
            }
            if (e.Node.Checked && !(_insertedActionsIDs.IndexOf(Convert.ToInt32(e.Node.Tag)) != -1))
            {
                if (_deletedActionsIDs.IndexOf(Convert.ToInt32(e.Node.Tag))!=-1)
                {
                    _deletedActionsIDs.Remove(Convert.ToInt32(e.Node.Tag));
                }
                else
                {
                    _insertedActionsIDs.Add(Convert.ToInt32(e.Node.Tag));
                }
            }
            if (!e.Node.Checked && !(_deletedActionsIDs.IndexOf(Convert.ToInt32(e.Node.Tag)) != -1))
            {
                if (_insertedActionsIDs.IndexOf(Convert.ToInt32(e.Node.Tag)) != -1)
                {
                    _insertedActionsIDs.Remove(Convert.ToInt32(e.Node.Tag));
                }
                else
                {
                    _deletedActionsIDs.Add(Convert.ToInt32(e.Node.Tag));
                }
            }
                }
            }
            if (!e.Node.Checked )
            {
                if (_insertedRegionsIDs.IndexOf(Convert.ToInt64(e.Node.Tag)) != -1)
                {
                    _insertedRegionsIDs.Remove(Convert.ToInt32(e.Node.Tag));
                }
                else
                {
                    _deletedRegionsIDs.Add(Convert.ToInt32(e.Node.Tag));
                }
            }


        }

        private void ChekUpdate()
        {
            DataTable RegionByItinerary =
                WorkWithData.GetDataTable(@"select * from regionsbyitenary where itenary=" +
                                          _selectedCruise.CruiseItinerery.ID.ToString());
            foreach (DataRow row in RegionByItinerary.Rows)
            {
                if (tvRegions.Nodes.Find(Convert.ToString(row.Field<double>("key_if_region")), true).Count()>0)
                {
                TreeNode selNode = tvRegions.Nodes.Find(Convert.ToString(row.Field<double>("key_if_region")), true)[0];

                    selNode.Checked = true;

                }
            }
            _insertedRegionsIDs.Clear();
        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshMap_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        
    }
    public struct SpecialOffer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Visible { get; set; }
    }
}
