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

namespace CruiseSearchAdmin.Forms.Excursions.EditPartner
{
    public partial class FormEditPartnerExcursionsFee : ProjectForm
    {
        private PartnerExcursion _partnerExcursion;
        private int _countryId;
        private int _cityId;
        public FormEditPartnerExcursionsFee()
        {
            InitializeComponent();
           
        }
        static public bool SetExcursionsFee(PartnerExcursion partnerExcursion,int countryId, int cityId)
        {
            using (var f = new FormEditPartnerExcursionsFee())
            {
                f._partnerExcursion = partnerExcursion;
                f._countryId = countryId;
                f._cityId = cityId;
                return f.ShowDialog() == DialogResult.OK;
            }
        }
        void GetData()
        {
            glueExType.DataSource = WorkWithData.GetExcursionTypes();
            glueExType.DisplayMember = "ET_DESCRIPTION";
            glueExType.ValueMember = "ET_UID";
            DataTable servicesdt =
               WorkWithData.GetDataTable(string.Format(
                   @"select [ED_KEY] as [SL_KEY],[ED_NAME] as [SL_NAME] from ExcurDictionary where ED_CNKEY = {0} and ED_CTKEY={1}",_countryId,_cityId), WorkWithData.MasterConnection);
            
            DataTable servicefeesdt =
                WorkWithData.GetDataTable(
                    @"SELECT [SL_KEY],[SL_NAME] FROM [ServiceList] where [sl_svkey] =3174 and [SL_CNKEY]=1111111",WorkWithData.MasterConnection);
            
            glueAdult.DataSource = servicesdt.Copy();
            glueAdultFee.DataSource = servicefeesdt.Copy();
            glueChild.DataSource = servicesdt.Copy();
            glueChildFee.DataSource = servicefeesdt.Copy();

            glueAdult.DisplayMember = glueAdultFee.DisplayMember = glueChild.DisplayMember = glueChildFee.DisplayMember = "SL_NAME";
            glueAdult.ValueMember = glueAdultFee.ValueMember = glueChild.ValueMember = glueChildFee.ValueMember = "SL_KEY";

            glueTransport.DataSource = WorkWithData.GetDataTable(@"select [TR_KEY],[TR_NAME] from [Transport]",WorkWithData.MasterConnection);
            glueTransport.DisplayMember = "TR_NAME";
            glueTransport.ValueMember = "TR_KEY";
            GetPartnerExcursionsFee();
        }

        void GetPartnerExcursionsFee()
        {
            _partnerExcursion.GetFees(WorkWithData.TsConnection);
        }

        private void FormEditPartnerExcursionsFee_Load(object sender, EventArgs e)
        {
            DxHelpersLib.WaitForm.WaitInBackground("Загрузка данных", false, GetData);
            dgcPartnerExcursionsFee.DataSource = _partnerExcursion.Fees;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (PartnerExcursionFee pef in dgcPartnerExcursionsFee.DataSource as PartnerExcursionFeesList)
            {
                pef.UpdateInBase(WorkWithData.TsConnection);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var pef = new PartnerExcursionFee(_partnerExcursion.Uid.GetValueOrDefault());
            pef.InsertToBase(WorkWithData.TsConnection);
            GetPartnerExcursionsFee();
            dgcPartnerExcursionsFee.RefreshDataSource();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var selPefIdx = gvPExFee.GetSelectedRows();
            foreach (int i in selPefIdx)
            {
                var pef = gvPExFee.GetRow(i) as PartnerExcursionFee;
                if(pef==null)continue;
                pef.DeleteFromBase(WorkWithData.TsConnection);
            }
            GetPartnerExcursionsFee();
            dgcPartnerExcursionsFee.RefreshDataSource();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var selPefIdx = gvPExFee.GetSelectedRows();
            foreach (int i in selPefIdx)
            {
                var pef = gvPExFee.GetRow(i) as PartnerExcursionFee;
                if (pef == null) continue;
                pef.UpdateInBase(WorkWithData.TsConnection);
                var clone = (PartnerExcursionFee)pef.Clone();
                clone.InsertToBase(WorkWithData.TsConnection);
            }
            GetPartnerExcursionsFee();
            dgcPartnerExcursionsFee.RefreshDataSource();
        }
    }
}
