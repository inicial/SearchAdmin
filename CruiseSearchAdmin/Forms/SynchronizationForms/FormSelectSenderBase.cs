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

namespace CruiseSearchAdmin.Forms.SynchronizationForms
{
    public partial class FormSelectSenderBase : ProjectForm
    {
        private SqlConnection _connection;
        private FormSelectSenderBase()
        {
            InitializeComponent();
        }

        public static string GetDataSourceString(SqlConnection connection)
        {
            using (var f = new FormSelectSenderBase())
            {
                f._connection = connection;
                if(f.ShowDialog()!=DialogResult.OK)return null;
                return f.cbBases.SelectedValue == null ? null : f.cbBases.SelectedValue.ToString();
            }
        }

        private void FormSelectSenderBase_Load(object sender, EventArgs e)
        {
            var dt = WorkWithData.GetDataTable(@"SELECT SB_UID,SB_IP,SB_NAME FROM mk_tbSyncBases",_connection);
            cbBases.DataSource = dt;
            cbBases.ValueMember = "SB_IP";
            cbBases.DisplayMember = "SB_NAME";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
