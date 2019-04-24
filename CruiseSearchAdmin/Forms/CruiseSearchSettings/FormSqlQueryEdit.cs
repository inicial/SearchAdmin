using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.CruiseSearchSettings
{
    public partial class FormSqlQueryEdit : ProjectForm
    {
        private CruiseSearchSetting _clSetting;
        public FormSqlQueryEdit()
        {
            InitializeComponent();
        }

        public static void EditSqlQuery(CruiseSearchSetting csSetting)
        {
            using (var f= new FormSqlQueryEdit())
            {
                f.tbQuery.Text = csSetting.SqlQuery;
                f._clSetting = csSetting;
                f.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _clSetting.SqlQuery = tbQuery.Text;
            _clSetting.Update();
            Close();
        }
    }
}
