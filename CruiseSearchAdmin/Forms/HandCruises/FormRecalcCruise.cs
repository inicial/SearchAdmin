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
    public partial class FormRecalcCruise : Form
    {
        private string _pakege;
        private DateTime _saildate;
        public FormRecalcCruise(string pak,DateTime sail)
        {
            InitializeComponent();
            _pakege = pak;
            _saildate = sail;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            string nachalo = "update Temp_CruisesCache Set ";
            string updatestring = nachalo;
            if (tb3_4AdCoef.Text != string.Empty)
            {
                updatestring += "[guest_3_4] = guest_1_Price * " + (Convert.ToDouble(tb3_4AdCoef.Text)/100).ToString().Replace(",",".");
            }
            if (tbChildCoef.Text != string.Empty)
            {
                if (updatestring == nachalo)
                {
                    updatestring += "[childPrice] = guest_1_Price * " + (Convert.ToDouble(tbChildCoef.Text) / 100).ToString().Replace(",",".");
                }
                else
                {
                    updatestring += ",[childPrice] = guest_1_Price * " + (Convert.ToDouble(tbChildCoef.Text) / 100).ToString().Replace(",", ".");
                }
            }
            if (tbSingleCoef.Text != string.Empty)
            {
                if (updatestring == nachalo)
                {
                    updatestring += "[singlePrice] = guest_1_Price * " + (Convert.ToDouble(tbSingleCoef.Text) / 100).ToString().Replace(",", ".");
                }
                else
                {
                    updatestring += ",[singlePrice] = guest_1_Price * " + (Convert.ToDouble(tbSingleCoef.Text) / 100).ToString().Replace(',', '.');
                }
            }
            updatestring += " where  package=@pak and sailDate=@date";
            using (SqlCommand com = new SqlCommand(updatestring,WorkWithData.TsConnection))
            {
                com.Parameters.AddWithValue("@date", _saildate);
                com.Parameters.AddWithValue("@pak", _pakege);
                com.ExecuteNonQuery();
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }}
