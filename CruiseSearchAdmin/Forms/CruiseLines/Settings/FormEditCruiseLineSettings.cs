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
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.CruiseLines.Settings
{
    public partial class FormEditCruiseLineSettings : ProjectForm
    {
        private CruiseLineSetting _cruiseLineSetting;
        private SqlConnection _connection = WorkWithData.MasterConnection;
        private WorkMode _workMode;
        private CruiseLine _cruiseLine;
        public FormEditCruiseLineSettings()
        {
            InitializeComponent();
        }

        public static void SetCruiseLineSettings(CruiseLineSetting cruiseLineSetting,CruiseLine cruiseLine)
        {
            using (var f = new FormEditCruiseLineSettings())
            {
                f._cruiseLineSetting = cruiseLineSetting;
                f._cruiseLine = cruiseLine;
                f.GetData();
                f.ShowDialog();
            }
        }

        private void ChangeWorkMode(WorkMode wm)
        {
            _workMode = wm;
            if (wm == WorkMode.None)
            {
                gbEdit.Enabled = false;
                btnRemove.Enabled = false;
                btnAdd.Enabled = true;
                btnOk.Enabled = false;
                btnCancel.Text = "Назад";
            }
            else
            {
                btnAdd.Enabled = false;
                gbEdit.Enabled = true;
                btnOk.Enabled = true;
                btnCancel.Text = "Отмена";
            }
        }

        private void GetData()
        {
            cbCity.SetDataSource(WorkWithData.GetDataTable(@"select CT_KEY,CT_NAME from CityDictionary where CT_CNKEY=1111111", _connection), "CT_KEY", "CT_NAME");
            cbPartner.SetDataSource(WorkWithData.GetDataTable(@"Select PR_KEY,PR_FULLNAME from tbl_Partners where PR_KEY in (select PTP_PRkey from PrtTypesToPartners  where PTP_PTId in (4,5))", _connection), "PR_KEY", "PR_FULLNAME");
            if (_cruiseLineSetting == null)
            {
               ChangeWorkMode(WorkMode.None);
                return;
            }
            ChangeWorkMode(WorkMode.Edit);
            cbCity.SelectedIndex = cbCity.FindString(_cruiseLineSetting.CityName);
            cbPartner.SelectedIndex = cbPartner.FindString(_cruiseLineSetting.PartnerName);
            tbCommition.Text = _cruiseLineSetting.Comision.ToString("F2");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _cruiseLineSetting = new CruiseLineSetting(_cruiseLine,_connection);
           ChangeWorkMode(WorkMode.Add);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!Messages.Question("Произвести удаление?")) return;
            _cruiseLineSetting.Delete();
            ChangeWorkMode(WorkMode.None);
        }

        private void tbCityFltr_TextChanged(object sender, EventArgs e)
        {
            epFormError.Clear();
            cbCity.SelectedIndex = cbCity.FindString(tbCityFltr.Text == string.Empty ? _cruiseLineSetting.CityName : tbCityFltr.Text);
        }

        private void tbPartnerFiltr_TextChanged(object sender, EventArgs e)
        {
            epFormError.Clear();
            cbPartner.SelectedIndex = cbPartner.FindString(tbPartnerFiltr.Text == string.Empty ? _cruiseLineSetting.PartnerName : tbPartnerFiltr.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ComboBoxSelectionIsValid(cbCity) || !ComboBoxSelectionIsValid(cbPartner) || !UDValueIsNum()) return;
            int cityId = (int)cbCity.SelectedValue;
            int prId = (int) cbPartner.SelectedValue;
            _cruiseLineSetting.CityId = cityId;
            _cruiseLineSetting.PartnerId = prId;
            _cruiseLineSetting.Comision = float.Parse(tbCommition.Text);
            if (_workMode == WorkMode.Add)
            {
                _cruiseLineSetting.Insert();
            }
            else
            {
                _cruiseLineSetting.Update();
            }
            Close();
        }

        private bool UDValueIsNum()
        {
            if (tbCommition.Text == string.Empty)
            {
                epFormError.SetError(tbCommition,"Неверное значение!");
                return false;
            }
            return true;
        }

        private bool ComboBoxSelectionIsValid(ComboBox comboBox)
        {
            if (comboBox.SelectedValue == null)
            {
                epFormError.SetError(comboBox,@"Неверное значение!");
                return false;
            }
            return true;
        }
    }
}
