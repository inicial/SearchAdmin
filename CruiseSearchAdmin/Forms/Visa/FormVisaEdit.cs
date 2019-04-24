using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Forms.Excursions;
using CruiseSearchAdmin.HelperClasses;
using CruiseSearchAdmin.DataBaseEntities;

namespace CruiseSearchAdmin.Forms.Visa
{
    public partial class FormVisaEdit : ProjectForm
    {
        private VisaDataContext _visaDataContext;
        private DataBaseEntities.lanta_visa_dna _visa;
        public FormVisaEdit()
        {
            InitializeComponent();
        }

        private void DataInit()
        {
            cbCountry.DataSource = _visaDataContext.tbl_Countries.OrderBy(c=>c.CN_NAME);
            cbCountry.DisplayMember = "CN_NAME";            
            cbPartner.DisplayMember = "PR_NAME";
            cbService.DisplayMember = "SL_NAME";
            var index = 0;
            if (_visa.tbl_Country != null)
            {
                index = cbCountry.FindString(_visa.tbl_Country.CN_NAME);
                cbCountry.SelectedIndex = index;
            }
            if(_visa.lv_shengen !=null)
            chbShengen.Checked = _visa.lv_shengen == 1;
            
            
            // cbPartner.DataSource = _visaDataContext.tbl_Partners.Where(p => _visaDataContext.tbl_Costs.Where(c => c.CS_PRKEY == p.PR_KEY && c.CS_SVKEY == sl.SL_SVKEY && c.CS_CODE.ToString() == sl.SL_CODE).Any());
            //cbPartner.DataSource = _visaDataContext.tbl_Partners.OrderBy(p => p.PR_NAME);

            
            if (_visa.ServiceList!=null)
            {
                cbService.DataSource = _visaDataContext.ServiceLists.Where(s => s.SL_SVKEY == 5 && s.SL_CNKEY == ((tbl_Country)cbCountry.SelectedItem).CN_KEY).OrderBy(s => s.SL_NAME);
                index = cbService.FindString(_visa.ServiceList.SL_NAME);
                cbService.SelectedIndex = index;
            }
            if(_visa.lv_unyse!=null)
            
            
            if (_visa.tbl_Partner != null)
            {
                try
                {
                    ServiceList sl = cbService.SelectedItem as ServiceList;
                    //cbPartner.DataSource = _visaDataContext.tbl_Partners.OrderBy(p => p.PR_NAME);
                    cbPartner.DataSource =
                        _visaDataContext.tbl_Partners.Where(
                            p =>
                            _visaDataContext.tbl_Costs.Where(
                                c => c.CS_PRKEY == p.PR_KEY && c.CS_SVKEY == sl.SL_SVKEY && c.CS_CODE == sl.SL_KEY)
                                            .Count() > 0);
                    index = cbPartner.FindString(_visa.tbl_Partner.PR_NAME);
                    cbPartner.SelectedIndex = index;

                }
                catch (Exception)
                {

                }

            }
            cbCruiseLines.DataSource = WorkWithData.GetDataTable("select mnemo,name_ru from CruiseLines");
            cbCruiseLines.DisplayMember = "name_ru";
            cbCruiseLines.ValueMember = "mnemo";
            if (_visa.lv_brandcode != null)
            {
                cbCruiseLines.SelectedValue = _visa.lv_brandcode;
            }
            else
            {
                cbCruiseLines.SelectedIndex = -1;
            }
            chbUnuse.Checked = _visa.lv_unyse==1;
        }

        public static bool EditVisa(VisaDataContext visaDataContext,DataBaseEntities.lanta_visa_dna visa)
        {
            using (var f = new FormVisaEdit())
            {
                f._visaDataContext = visaDataContext;f._visa = visa;
                f.DataInit();
                return f.ShowDialog()==DialogResult.OK;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _visa.tbl_Country = cbCountry.SelectedItem as tbl_Country;
            _visa.ServiceList = cbService.SelectedItem as ServiceList;
            _visa.tbl_Partner = cbPartner.SelectedItem as tbl_Partner;
            _visa.lv_shengen = chbShengen.Checked ? 1 : 0;
            _visa.lv_unyse = chbUnuse.Checked ? 1 : 0;
            _visa.lv_brandcode = cbCruiseLines.SelectedIndex == -1 ? null :(string) cbCruiseLines.SelectedValue;
            DialogResult = DialogResult.OK;
            Close();}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ApplyFilter(string fltrStr,ComboBox comboBox)
        {
            comboBox.SelectedIndex = comboBox.FindString(fltrStr);
        }

        private void tbCountryFiltr_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(tbCountryFiltr.Text,cbCountry);
        }

        private void tbPartnerFiltr_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(tbPartnerFiltr.Text, cbPartner);
        }

        private void tbServiceFiltr_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(tbServiceFiltr.Text, cbService);
        }

        private void cbPartner_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceList sl = cbService.SelectedItem as ServiceList;
            cbPartner.DataSource = _visaDataContext.tbl_Partners.Where(p=>_visaDataContext.tbl_Costs.Where(c=>c.CS_PRKEY==p.PR_KEY&&c.CS_SVKEY==sl.SL_SVKEY&&c.CS_CODE==sl.SL_KEY).Any());
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e){
            cbService.DataSource = _visaDataContext.ServiceLists.Where(s => s.SL_SVKEY == 5 && s.SL_CNKEY==((tbl_Country)cbCountry.SelectedItem).CN_KEY).OrderBy(s => s.SL_NAME);
        }

    }
}
