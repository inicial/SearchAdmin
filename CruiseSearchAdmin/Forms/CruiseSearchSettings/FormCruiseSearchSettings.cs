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

namespace CruiseSearchAdmin.Forms.CruiseSearchSettings
{
    public partial class FormCruiseSearchSettings : ProjectForm
    {
        private SqlConnection _connection;
        private CruiseSearchSetting _selectedSetting;
        private CruiseSearchSettingsCollection _csSettings = new CruiseSearchSettingsCollection();
        public FormCruiseSearchSettings()
        {
            InitializeComponent();
            btnSqlQueryEdit.Enabled = tbParamName.Enabled = Program.AccessController.IsAdmin();
        }
        public static void EditCruseSearchSettings(SqlConnection connection)
        {
            using (var f =new FormCruiseSearchSettings())
            {
                f._connection = connection;
                f.GetData();
                f.ShowDialog();
            }
        }

        private void GetData()
        {
            _csSettings.GetItems(_connection);
            lbSettings.SetDataSource(_csSettings,"ID","ParamName");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tbQueryResult;
            gbEdit.Enabled = true;
            _selectedSetting = lbSettings.SelectedItem as CruiseSearchSetting;
            if (_selectedSetting == null) {
                gbEdit.Enabled = false;
                return;
            }
            tbParamName.Text = _selectedSetting.ParamName;
            if (_selectedSetting.SqlQuery == string.Empty) { 
                cbValues.Enabled = false;
                cbValues.DataSource=null;
                return;
            }
            try
            {
                tbQueryResult = WorkWithData.GetDataTable(_selectedSetting.SqlQuery, _connection);
            }
            catch (SqlException)
            {
                Messages.Error("Ошибка запроса, возможно sql запрос привязанный к данной настройке не корректен");
                return;
            }
            
            cbValues.SetDataSource(tbQueryResult,"ID","NAME");
            cbValues.SelectedValue = _selectedSetting.Value;
            cbValues.Enabled = true;
        }

        private void tbParamName_TextChanged(object sender, EventArgs e)
        {
           
        }

       

        private void cbValues_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cbValues.SelectedValue != null)
                _selectedSetting.Value = (int) cbValues.SelectedValue;
            if (tbParamName.Enabled)
                _selectedSetting.ParamName = tbParamName.Text;
            _selectedSetting.Update();
        }

        private void btnSqlQueryEdit_Click(object sender, EventArgs e)
        {
            FormSqlQueryEdit.EditSqlQuery(_selectedSetting);
            GetData();
        }

        private void cbValues_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
