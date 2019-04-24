using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CruiseSearchAdmin.Forms.HandCruises
{
    public partial class FormNewDate : Form
    {
        private string _pak;
        private DateTime _sail;

        public FormNewDate(string pak,DateTime sail)
        {
            InitializeComponent();
            _pak = pak;
            _sail = sail;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("mk_copy_temp_cruise",WorkWithData.TsConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Package",_pak );
            command.Parameters.AddWithValue("@Saildate",_sail.Date);
            command.Parameters.AddWithValue("@NewSaildate", dtNewDate.Value.Date);
            command.ExecuteNonQuery();
        }
    }
}