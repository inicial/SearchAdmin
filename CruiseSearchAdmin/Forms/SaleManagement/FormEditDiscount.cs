using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Entities.Ships;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;
using lanta.SQLConfig;

namespace CruiseSearchAdmin.Forms.SaleManagement
{

    public partial class FormEditDiscount : ProjectForm
    {
        string _name;
        private int _cruiseLineId;
        private int _shipId;
       
        private int _cabbinClass;
        private int _itineraryId;
        private DateTime _rdb, _rde, _rsdb, _rsde;
        private int _actionId;
        private long _regionId;
        private bool _noFilter;
        
        List<CruiseSearchAdmin.Entities.Itinerary>  _itineraries = new List<Entities.Itinerary>();
        List<CruiseSearchAdmin.Entities.Itinerary> _filteredItineraries = new List<Entities.Itinerary>();
        List<Cruise> _cruises = new List<Cruise>();
        ShipsCollection _ships = new ShipsCollection();
        public FormEditDiscount()
        {
            InitializeComponent();
        }public static bool EditDiscount(ref string name,ref int? cLId,ref int? sId,ref int value,ref int? cc,ref int? itineraryId,ref DateTime? rdb,ref DateTime? rde,ref DateTime? rsdb,ref DateTime? rsde,ref int? actionId,ref long? regionId,ref int? priority)
        {
            using(var f = new FormEditDiscount())
            {
                f._name = name;
                f._cruiseLineId = cLId.GetValueOrDefault(-1);
                f._shipId = sId.GetValueOrDefault(-1);
                f._cabbinClass = cc.GetValueOrDefault(-1);
                f._itineraryId = itineraryId.GetValueOrDefault(-1);
                f.nudValue.Value = value;
                f.nudPriority.Value = priority.GetValueOrDefault();
                if(itineraryId!=null)
                {
                    f.lbItinerary.Text = "Выбран маршрут № - " + f._itineraryId;
                }
                if(rdb==null || rde==null)
                {
                    f._noFilter = true;
                    f.chbDate.Checked = true;
                    f._noFilter = false;
                }
                f._rdb = rdb.GetValueOrDefault(DateTime.Now);
                f._rde = rde.GetValueOrDefault(DateTime.Now);
                if (rsdb == null || rsde == null)
                {
                    f._noFilter = true;
                    f.chbSDate.Checked = true;
                    f._noFilter = false;
                }
                f._rsdb = rsdb.GetValueOrDefault(DateTime.Now);
                f._rsde = rsde.GetValueOrDefault(DateTime.Now);
                f._regionId = regionId.GetValueOrDefault(-1);
                f._actionId = actionId.GetValueOrDefault(-1);

                var res = f.ShowDialog() == DialogResult.OK;
                if (!res) return false;

                name = f.tbName.Text;

                if ((int)f.cbCruiseLine.SelectedValue != -1)
                {
                    cLId = ((int) f.cbCruiseLine.SelectedValue);
                }
                else
                {
                    cLId = null;
                }
                if ((int)f.cbShip.SelectedValue != -1)
                {
                    sId = (int) f.cbShip.SelectedValue;
                }
                else
                {
                    sId = null;
                }
                value = (int) f.nudValue.Value;
                priority = (int)f.nudPriority.Value == 0 ? (int?)null : (int)f.nudPriority.Value;
                if ((int)f.cbCabinClass.SelectedValue != -1)
                {
                    cc = (int) f.cbCabinClass.SelectedValue;
                }
                else
                {
                    cc = null;
                }
                if (f._itineraryId != -1)
                {
                    itineraryId = f._itineraryId;
                }
                else
                {
                    itineraryId = null;
                }
                if(f.chbDate.Checked)
                {
                    rdb = rde = null;
                }
                else{
                    rdb = f.dtpBegin.Value.Date;
                    rde = f.dtpEnd.Value.Date;
                }
                if(f.chbSDate.Checked)
                {
                    rsdb = rsde = null;
                }
                else
                {
                    rsdb = f.dtpSaleBegin.Value.Date;
                    rsde = f.dtpSaleEnd.Value.Date;
                }
                if((int)f.cbActions.SelectedValue!=-1)
                {
                    actionId = (int)f.cbActions.SelectedValue;
                }
                else
                {
                   actionId = null; 
                }
                if ((long)f.cbRegion.SelectedValue != -1)
                {
                    regionId = (long) f.cbRegion.SelectedValue;
                }
                else
                {
                    regionId = null;
                }
                return true;
            }
        }
        void GetData()
        {
            _noFilter = true;
            WaitForm.WaitInBackground("Загрузка даных", false, () =>
            {
                _itineraries.AddRange(from DataRow r in WorkWithData.GetDataTable("select * from All_itenary").Rows select new Entities.Itinerary(r.Field<int>("id"), r["itenary"].ToString()));
                _cruises.AddRange(from DataRow r in WorkWithData.GetCruisesTable().Rows select new Cruise(r));
            });tbName.Text = _name;
            _ships.GetItems(WorkWithData.TsConnection);
            _ships.Insert(0, new Ship(-1, "Все", 0, "",null));
            var tmpCruiseLines = new CruiseLinesCollection();
            tmpCruiseLines.GetItems(WorkWithData.TsConnection);// (from DataRow row in WorkWithData.GetCruiseLinesTable().Rows select new CruiseLine(row.Field<byte>("id"), row["name_en"].ToString(), "", "", 0)).ToList();
            tmpCruiseLines.Insert(0,new CruiseLine(-1,"Все","","","",0,WorkWithData.TsConnection));
            cbCruiseLine.SetDataSource(tmpCruiseLines, "ID", "EnName");
            cbCruiseLine.SelectedValue = _cruiseLineId;

            if (cbShip.DataSource == null)
            {
                cbShip.SetDataSource(_ships, "ID", "Name");}
            cbShip.SelectedValue = _shipId;
            Config_XML conf = new Config_XML(TypeFileConfig.tfcXML);
            int ccCount = 0;
            try
            {
                var r = conf.Get_Value("appSettings", "CC");
                ccCount = int.Parse(conf.Get_Value("appSettings", "CC"));
            }
            catch
            {
            }
            string ccQuery;
            if(ccCount>0)
                ccQuery = @"select * from CabinClasses where id<=" + ccCount;
            else
            {
                ccQuery = @"select * from CabinClasses";
            }

            var tmpCabinClasses = (from DataRow r in WorkWithData.GetDataTable(ccQuery).Rows
                                   select new Discount.CabinCls() {ID = r.Field<byte>("id"), Name = r["name"].ToString()}).ToList();
            tmpCabinClasses.Insert(0,new Discount.CabinCls(){ID=-1,Name = "Нет"});
            cbCabinClass.SetDataSource(tmpCabinClasses, "ID","Name");
            cbCabinClass.SelectedValue = _cabbinClass;

            var tmpActions = (from DataRow r in WorkWithData.GetDataTable(@"select * from Actions").Rows
                              select
                                  new CruiseAction(r.Field<int>("action_id"), r["action_text"].ToString(), -1, null,
                                                   null,null,null)).ToList();
            tmpActions.Insert(0,new CruiseAction(-1,"Нет",-1,null,null,null,null));
            cbActions.SetDataSource(tmpActions, "ID","Text");
            cbActions.SelectedValue = _actionId;

            var tmpRegions = (from DataRow r in WorkWithData.GetRegionsTable().Rows select new ItRegion((int)r.Field<long>("id"),r["name_ru"].ToString())).ToList();
            tmpRegions.Insert(0,new ItRegion(-1,"Нет"));
            cbRegion.SetDataSource(tmpRegions,"ID","Name");
            cbRegion.SelectedValue = _regionId;

            //nudValue.Value = _value;
            //nudPriority.Value = _priority;
            dtpBegin.Value = _rdb;
            dtpEnd.Value = _rde;
            dtpSaleBegin.Value = _rsdb;
            dtpSaleEnd.Value = _rsde;
            _noFilter = false;
            FilterItineraries();
            
        }
        private void FormEditDiscount_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void cbCruiseLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedClId = (((ComboBox)sender).SelectedItem as CruiseLine).ID; 
            if (selectedClId == -1) 
            {
                cbShip.SetDataSource(_ships, "ID", "Name");
              return; 
            }
            cbShip.SetDataSource(_ships.Where(s => s.CruiseLineID == selectedClId||s.ID==-1).ToList(), "ID", "Name");
        }

        private void cbEnableIti_CheckedChanged(object sender, EventArgs e)
        {
            dgvItinerary.Visible = cbEnableIti.Checked;
            FilterItineraries();
            if (!cbEnableIti.Checked)
            {
                _itineraryId = -1;
                lbItinerary.Text = "Маршрут не выбран";

                while (this.Height > 540)
                {
                    this.Height -= 10;
                    Thread.Sleep(10);
                }
            }
            else
            {
                while (this.Height < 640)
                {
                    this.Height += 10;
                    Thread.Sleep(10);
                }
            }
            
        }
        private void cbShip_SelectedIndexChanged(object sender, EventArgs e)
        {
           FilterItineraries();
        }
        void FilterItineraries()
        {
            if (_noFilter || !cbEnableIti.Checked) return;
            List<Cruise> filtredCruises =_cruises.ToList();
            if(!chbDate.Checked)
                filtredCruises = _cruises.Where(c => c.SailDate >= dtpBegin.Value.Date && c.SailDate <= dtpEnd.Value.Date).ToList();
            if (cbShip.SelectedItem != null)
            {
                int selectedSid = (int) (cbShip).SelectedValue;
                if (selectedSid != -1)
                    filtredCruises =
                        filtredCruises.Where(c => c.Ship.ID == selectedSid).ToList();
            }
            if (cbCruiseLine.SelectedItem != null)
            {
                var selectedClId = (int) (cbCruiseLine.SelectedValue);
                if (selectedClId != -1)
                {

                    filtredCruises =
                        filtredCruises.Where(c => c.CruiseLn.ID == selectedClId).ToList();
                }
            }
            
            List<Entities.Itinerary> itineraries = new List<Entities.Itinerary>();
            WaitForm.WaitInBackground("Фильтр маршрутов", false, () =>
                                                                    {
                                                                        itineraries = (from itinerary in _itineraries
                                                                                       from filtredCruise in
                                                                                           filtredCruises
                                                                                       where
                                                                                           itinerary.ID ==
                                                                                           filtredCruise.CruiseItinerery
                                                                                               .ID
                                                                                       select itinerary).ToList();
                                                                        itineraries = itineraries.Distinct().ToList();
                                                                    });
            

            dgvItinerary.DataSource = itineraries;
            RefreshGrid();
        }

        void RefreshGrid()
        {
            
            foreach(DataGridViewColumn c in dgvItinerary.Columns)
            {
                var n = c.Name.ToLower();
                switch(n)
                {
                    case "id":
                        {
                            c.Width = 40;
                        }
                        break;
                    case "text":
                        {
                            c.HeaderText = "Маршрут";
                            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBegin.Value > dtpEnd.Value) dtpEnd.Value = dtpBegin.Value;
            FilterItineraries();
        }

        private void dtpSale_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSaleBegin.Value > dtpSaleEnd.Value) dtpSaleEnd.Value = dtpSaleBegin.Value;
        }

        private void dgvItinerary_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void cbDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpBegin.Enabled = dtpEnd.Enabled = !((CheckBox) sender).Checked;
            FilterItineraries();
        }

        private void chbSDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpSaleBegin.Enabled = dtpSaleEnd.Enabled = !((CheckBox)sender).Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(tbName.Text.Equals(string.Empty))
            {
                Messages.Error("Название не должно быть пустым");
                return;
            }this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvItinerary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRows = ((DataGridView)sender).SelectedRows;
            if (selectedRows.Count < 1) return;
            var selectedRow = selectedRows[0];
            _itineraryId = (int)selectedRow.Cells["ID"].Value;
            lbItinerary.Text = "Выбран маршрут № - " + _itineraryId;
        }
    }
}
