using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Excursions.EditPartner
{
    public partial class FormSelectCity : ProjectForm
    {
        
        public int _cityId = -1;
        public int _countryId = -1;
        private DataTable tbCountries;
        private DataTable tbCities;
        protected FormSelectCity()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData(){
            tbCountries = WorkWithData.GetDataTable("SELECT [CN_KEY],[CN_NAME] FROM Country order by CN_NAME", WorkWithData.MasterConnection);
            tbCities = WorkWithData.GetDataTable("SELECT [CT_KEY],[CT_NAME],[CT_CNKEY] FROM CityDictionary order by CT_NAME", WorkWithData.MasterConnection);
            cbCountry.SetDataSource(tbCountries,"CN_KEY","CN_NAME");
            cbCity.SetDataSource(tbCities,"CT_KEY","CT_NAME");
            cbCity.SelectedIndex = cbCountry.SelectedIndex = 0;
        }

        public static bool SelectCity(out int countryId,out int cityId)
        {
            using (var f = new FormSelectCity())
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    cityId = -1;
                    countryId = -1;
                    return false;
                }
                cityId = f._cityId;
                countryId = f._countryId;
                return true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                _cityId = (int)(cbCity.SelectedValue);
                _countryId = (int)(cbCountry.SelectedValue);
               
            }
            catch (Exception)
            {
                Messages.Error("Не выбран город или страна");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbCity.SetDataSource(tbCities.Select(string.Format(@"CT_CNKEY = {0}",cbCountry.SelectedValue)).CopyToDataTable(),"CT_KEY","CT_NAME");
        }
    }
}
