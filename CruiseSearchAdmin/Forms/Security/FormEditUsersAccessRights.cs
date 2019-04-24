using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Security
{
    public partial class FormEditUsersAccessRights : ProjectForm
    {
        private const int SYNC_IDX = 0;
        private const int CRUISE_EDIT_IDX = 1;
        private const int SHIPS_EDIT_IDX = 2;
        private const int PORTS_EDIT_IDX = 3;
        private const int ACTIONS_EDIT_IDX = 4;
        private const int EXCURSIONS_EDIT_IDX = 5;
        private const int SALE_MANAGE_IDX = 6;
        private const int VISA_MANAGE_IDX = 7;
        private const int CRUISE_SEARCH_SETTINGS_IDX = 8;
        ArrayList _accesses = new ArrayList();
        AccessController _accessController = new AccessController(WorkWithData.TsConnection);
        private bool _manualChecked;
        private string _selectedPrincipal;
        public FormEditUsersAccessRights()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            _accesses.Add(new { Text = "Синхронизация", DBRoleName="csaSynchronizator"});
            _accesses.Add(new { Text = "Редактирование круизов", DBRoleName = "csaCruiseEditor" });
            _accesses.Add(new { Text = "Редактирование лайнеров", DBRoleName = "csaShipsEditor" });
            _accesses.Add(new { Text = "Редактирование портов", DBRoleName = "csaPortsEditor" });
            _accesses.Add(new { Text = "Редактирование акций", DBRoleName = "csaActionsEditor" });
            _accesses.Add(new { Text = "Редактирование экскурсий", DBRoleName = "csaExcursionsEditor" });
            _accesses.Add(new { Text = "Управление продажами", DBRoleName = "csaDiscountEditor" });
            _accesses.Add(new { Text = "Управление визами", DBRoleName = "csaVisaEditor" });
            _accesses.Add(new { Text = "Настройки круизного поиска", DBRoleName = "csaCruiseSearchSettingsEditor" });
            chlbRights.DataSource = _accesses;
            chlbRights.DisplayMember = "Text";
            chlbRights.ValueMember = "DBRoleName";

            DataTable dt = WorkWithData.GetDataTable("select * from sys.database_principals where type like 's' order by name");
            lbUsers.DataSource = dt;
            lbUsers.DisplayMember = lbUsers.ValueMember = "name";
        }

        public static void EditAccessRights()
        {
            using (var f = new FormEditUsersAccessRights())
            {
                f.ShowDialog();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _manualChecked = false;
            var lbUsrs = sender as ListBox;
            chlbRights.Enabled = true;
            _selectedPrincipal = (lbUsrs.SelectedItem as DataRowView).Row["name"].ToString();
            if (_accessController.IsAdmin(_selectedPrincipal))
            {
                for (int index = 0; index < chlbRights.Items.Count; index++)
                {
                    chlbRights.SetItemChecked(index, true);
                }
                chlbRights.Enabled = false;
            }
            chlbRights.SetItemChecked(SYNC_IDX, _accessController.IsAccess(AccessRigt.SyncAccess, _selectedPrincipal));
            chlbRights.SetItemChecked(CRUISE_EDIT_IDX, _accessController.IsAccess(AccessRigt.CruiseEditAccess, _selectedPrincipal));
            chlbRights.SetItemChecked(SHIPS_EDIT_IDX, _accessController.IsAccess(AccessRigt.ShipsEditAccess, _selectedPrincipal));
            chlbRights.SetItemChecked(ACTIONS_EDIT_IDX, _accessController.IsAccess(AccessRigt.ActionsEditAccess, _selectedPrincipal));
            chlbRights.SetItemChecked(EXCURSIONS_EDIT_IDX, _accessController.IsAccess(AccessRigt.ExcursionsEditAccess, _selectedPrincipal));
            chlbRights.SetItemChecked(PORTS_EDIT_IDX, _accessController.IsAccess(AccessRigt.PortsEditAccess, _selectedPrincipal));
            chlbRights.SetItemChecked(SALE_MANAGE_IDX, _accessController.IsAccess(AccessRigt.DiscountEditAccess, _selectedPrincipal));
            chlbRights.SetItemChecked(VISA_MANAGE_IDX, _accessController.IsAccess(AccessRigt.VisaEditAccess, _selectedPrincipal));
            chlbRights.SetItemChecked(CRUISE_SEARCH_SETTINGS_IDX, _accessController.IsAccess(AccessRigt.CruiseSearchSettingsAccess, _selectedPrincipal));
            _manualChecked = true;
        }

        private void chlbRights_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!_manualChecked) return;
            if (_selectedPrincipal == null) return;
            var role = chlbRights.SelectedValue.ToString();
            string action;
            switch (e.NewValue)
            {
                case CheckState.Checked:
                    {
                        action = "sp_addrolemember";
                    }
                    break;
                case CheckState.Unchecked:
                    {
                        action = "sp_droprolemember";
                    }
                    break;
                default:
                    return;
            }
            string sqlQuery = string.Format(@"{0} @p0, @p1", action);
            try
            {
                sqlQuery.ExecuteNonQuery(WorkWithData.TsConnection, role, _selectedPrincipal);
            }
            catch
            {
                Messages.Error("Данная роль отсутствует в базе!!!");
            }
        }
    }

}
