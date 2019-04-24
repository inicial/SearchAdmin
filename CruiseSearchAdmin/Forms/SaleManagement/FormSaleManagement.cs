using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Entities.Ships;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.SaleManagement
{
    public partial class FormSaleManagement : ProjectForm{
        DiscountCollection _discounts = new DiscountCollection();
        CruiseLinesCollection _cruiseLines = new CruiseLinesCollection();
        private FormSaleManagement()
        {
            InitializeComponent();
        }
        public static void SaleManagement()
        {
            using(var f = new FormSaleManagement())
            {
                f.ShowDialog();
            }
        }

        private void FormSaleManagement_Load(object sender, EventArgs e)
        {
            _discounts.GetItems(WorkWithData.TsConnection);
            _cruiseLines.GetItems(WorkWithData.TsConnection);
            //_cruiseLines.AddRange(from DataRow row in WorkWithData.GetCruiseLinesTable().Rows select  new CruiseLine(row.Field<byte>("id"),"",row["mnemo"].ToString(),"",0));
            gcDiscount.DataSource = _discounts.Container;
        }

        private void gvDiscount_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var selectedDiscount = gvDiscount.GetRow(e.RowHandle) as Discount;
        }

        private void gvDiscount_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(btnEdit,e);
            //var hRs = gvDiscount.GetSelectedRows();
            //Discount discount ;
            //if (hRs.Length > 0)
            //    discount = gvDiscount.GetRow(hRs[0]) as Discount;
            //else return;
            //string n = discount.Text??string.Empty;
            //int? clid = null;
            //if(discount.CruiseLine!=null)
            //{
            //    clid = discount.CruiseLine.ID;
            //}
            //int? shipId = null;
            //if(discount.Ship!=null)
            //{
            //    shipId = discount.Ship.ID;
            //}
            //int val = discount.Value;
            //int? ccid = null;
            //if(discount.CabinClass!=null)
            //{
            //    ccid = discount.CabinClass.ID;
            //}
            //int? itid = null;
            //if(discount.Itinerary!=null)
            //{
            //    itid = discount.Itinerary.ID;
            //}
            //DateTime? rdb = discount.DateBegin;
            //DateTime? rde = discount.DateEnd;
            //DateTime? rsdb = discount.SaleDateBegin;
            //DateTime? rsde = discount.SaleDateEnd;
            //int? actid = null;
            //if(discount.Action!=null)
            //{
            //    actid = discount.Action.ID;
            //}
            //long? regid = null;
            //if(discount.Region!=null)
            //{
            //    regid = discount.Region.ID;
            //}
            //int? priority = discount.Priority;
            //if (!FormEditDiscount.EditDiscount(ref n, ref clid, ref shipId, ref val, ref ccid, ref itid, ref rdb, ref rde, ref rsdb, ref rsde, ref actid, ref regid, ref priority)) return;
            //string clcode = null;
            //if(clid!=null)
            //    clcode = _cruiseLines.Find<CruiseLine>(cl => cl.ID == clid).Mnemo;

            //discount.Text = n;
            //if (clid != null)
            //{
            //    discount.CruiseLine = new CruiseLine(clid.GetValueOrDefault(-1), "","", clcode, "", 0,WorkWithData.TsConnection);
            //}
            //if (shipId != null)
            //{
            //    discount.Ship = new Ship(shipId.GetValueOrDefault(-1), "", 0, "",null);
            //}
            //discount.Value = val;
            //if (ccid != null)
            //{
            //    discount.CabinClass = new Discount.CabinCls() { ID = ccid.GetValueOrDefault(-1) };
            //}
            //if (itid != null)
            //{
            //    discount.Itinerary = new Entities.Itinerary(itid.GetValueOrDefault(-1), "");
            //}
            //if (actid != null)
            //{
            //    discount.Action = new CruiseAction(actid.GetValueOrDefault(-1), "", 0, null, null, null, null);
            //}
            //if (regid != null)
            //{
            //    discount.Region = new ItRegion(regid.GetValueOrDefault(-1), "");
            //}
            //discount.DateBegin = rdb;
            //discount.DateEnd = rde;
            //discount.SaleDateBegin = rsdb;
            //discount.SaleDateEnd = rsde;
            //discount.Priority = priority;
            //discount.UpdateDiscount(WorkWithData.TsConnection);
            //RefreshGC();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var hRs = gvDiscount.GetSelectedRows();
            Discount discount;
            if (hRs.Length > 0)
                discount = gvDiscount.GetRow(hRs[0]) as Discount;
            else return;
            if(!Messages.Question("Удалить выбранный элемент?"))return;
            discount.DeleteDicscount(WorkWithData.TsConnection);
            RefreshGC();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string n = string.Empty;
            int? clid = null;
            int? shipId = null;
            int val = 0;
            int? ccid = null;
            int? itid = null;
            
            DateTime? rdb = null;DateTime? rde = null;
            DateTime? rsdb = null;
            DateTime? rsde = null;
            int? actid = null;
            long? regid = null;
            int? priority = null;
            if (!FormEditDiscount.EditDiscount(ref n, ref clid, ref shipId, ref val, ref ccid, ref itid, ref rdb, ref rde, ref rsdb, ref rsde, ref actid, ref regid,ref priority)) return;
            string clcode = null;
            if (clid != null)
                clcode = _cruiseLines.Find<CruiseLine>(cl => cl.ID == clid).Mnemo;
            var discount = new Discount()
                {
                    CruiseLine = new CruiseLine(0, "", "",clcode, "", 0,WorkWithData.TsConnection),
                    Ship = new Ship(shipId.GetValueOrDefault(-1), "", 0, "",null),
                    Value = val,
                    CabinClass = new Discount.CabinCls() {ID = ccid.GetValueOrDefault(-1)},
                    Itinerary = new Entities.Itinerary(itid.GetValueOrDefault(-1), ""),
                    Action = new CruiseAction(actid.GetValueOrDefault(-1), "", 0, null, null, null, null),
                    DateBegin = rdb,
                    DateEnd = rde,
                    Region = new ItRegion(regid.GetValueOrDefault(-1), ""),
                    SaleDateBegin = rsdb,
                    SaleDateEnd = rsde,
                    Priority = priority,
                    Text = n
                };
            discount.InsertDiscount(WorkWithData.TsConnection);
           RefreshGC();
        }
        void RefreshGC()
        {
            _discounts.GetItems(WorkWithData.TsConnection);
            gcDiscount.RefreshDataSource();
        }

        private void btnEdit_Click(object sender, EventArgs e){
            var hRs = gvDiscount.GetSelectedRows();
            Discount discount;
            if (hRs.Length > 0)
                discount = gvDiscount.GetRow(hRs[0]) as Discount;
            else
            {
                Messages.Error("Сначала следует выбрать услугу");
                return;
            }
            string n = discount.Text ?? string.Empty;
            int? clid = null;
            if (discount.CruiseLine != null)
            {
                clid = discount.CruiseLine.ID;
            }
            int? shipId = null;
            if (discount.Ship != null)
            {
                shipId = discount.Ship.ID;
            }
            int val = discount.Value;
            int? ccid = null;
            if (discount.CabinClass != null)
            {
                ccid = discount.CabinClass.ID;
            }
            int? itid = null;
            if (discount.Itinerary != null)
            {
                itid = discount.Itinerary.ID;
            }
            DateTime? rdb = discount.DateBegin;
            DateTime? rde = discount.DateEnd;
            DateTime? rsdb = discount.SaleDateBegin;
            DateTime? rsde = discount.SaleDateEnd;
            int? actid = null;
            if (discount.Action != null)
            {
                actid = discount.Action.ID;
            }
            long? regid = null;
            if (discount.Region != null)
            {
                regid = discount.Region.ID;
            }
            int? priority = discount.Priority;
            if (!FormEditDiscount.EditDiscount(ref n, ref clid, ref shipId, ref val, ref ccid, ref itid, ref rdb, ref rde, ref rsdb, ref rsde, ref actid, ref regid,ref priority)) return;
            string clcode = null;
            if (clid != null)
                clcode = _cruiseLines.Find<CruiseLine>(cl => cl.ID == clid).Mnemo;
            discount.Text = n;
            if (clid != null)
            {
                discount.CruiseLine = new CruiseLine(clid.GetValueOrDefault(-1),"","",clcode,"",0,WorkWithData.TsConnection);
            }
            if (shipId != null)
            {
                discount.Ship = new Ship(shipId.GetValueOrDefault(-1),"",0,"",null);
            }
            discount.Value = val;
            if (ccid != null)
            {
                discount.CabinClass = new Discount.CabinCls(){ID = ccid.GetValueOrDefault(-1)};
            }
            if (itid != null)
            {
                discount.Itinerary = new Entities.Itinerary(itid.GetValueOrDefault(-1),"");
            }
            if (actid != null)
            {
                discount.Action = new CruiseAction(actid.GetValueOrDefault(-1),"",0,null,null,null,null);
            }
            if (regid != null)
            {
                discount.Region = new ItRegion(regid.GetValueOrDefault(-1),"");
            }
            discount.DateBegin = rdb;
            discount.DateEnd = rde;
            discount.SaleDateBegin = rsdb;
            discount.SaleDateEnd = rsde;
            discount.Priority = priority;
            discount.UpdateDiscount(WorkWithData.TsConnection);
            RefreshGC();
        }
        private void btnCopy_Click(object sender, EventArgs e){
            var hRs = gvDiscount.GetSelectedRows();
            Discount discount;
            if (hRs.Length > 0)
                discount = gvDiscount.GetRow(hRs[0]) as Discount;
            else
            {
                Messages.Error("Сначала следует выбрать услугу");
                return;
            }
            string n = discount.Text==null? string.Empty:discount.Text+"_Копия";
            int? clid = null;
            if (discount.CruiseLine != null)
            {
                clid = discount.CruiseLine.ID;
            }
            int? shipId = null;
            if (discount.Ship != null)
            {
                shipId = discount.Ship.ID;
            }
            int val = discount.Value;
            int? ccid = null;
            if (discount.CabinClass != null)
            {
                ccid = discount.CabinClass.ID;
            }
            int? itid = null;
            if (discount.Itinerary != null)
            {
                itid = discount.Itinerary.ID;
            }
            DateTime? rdb = discount.DateBegin;
            DateTime? rde = discount.DateEnd;
            DateTime? rsdb = discount.SaleDateBegin;
            DateTime? rsde = discount.SaleDateEnd;
            int? actid = null;
            if (discount.Action != null)
            {
                actid = discount.Action.ID;
            }
            long? regid = null;
            if (discount.Region != null)
            {
                regid = discount.Region.ID;
            }
            int? priority = discount.Priority;
            if (!FormEditDiscount.EditDiscount(ref n, ref clid, ref shipId, ref val, ref ccid, ref itid, ref rdb, ref rde, ref rsdb, ref rsde, ref actid, ref regid,ref priority)) return;
            string clcode = null;
            if (clid != null)
                clcode = _cruiseLines.Find<CruiseLine>(cl => cl.ID == clid).Code;
            var discountCopy = new Discount()
            {
                CruiseLine = new CruiseLine(0, "", "",clcode, "", 0,WorkWithData.TsConnection),
                Ship = new Ship(shipId.GetValueOrDefault(-1), "", 0, "",null),
                Value = val,
                CabinClass = new Discount.CabinCls() { ID = ccid.GetValueOrDefault(-1) },
                Itinerary = new Entities.Itinerary(itid.GetValueOrDefault(-1), ""),
                Action = new CruiseAction(actid.GetValueOrDefault(-1), "", 0, null, null, null, null),
                DateBegin = rdb,
                DateEnd = rde,
                Region = new ItRegion(regid.GetValueOrDefault(-1), ""),
                SaleDateBegin = rsdb,
                SaleDateEnd = rsde,
                Priority = priority,
                Text = n
            };
            discountCopy.InsertDiscount(WorkWithData.TsConnection);
            RefreshGC();
        }

    }
}
