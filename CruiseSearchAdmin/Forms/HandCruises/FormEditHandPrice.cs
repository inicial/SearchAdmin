using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.HandCruises
{
    public partial class FormEditHandPrice : ProjectForm
    {
       
        private string _pak;
        private DateTime _saildate;
        private DataTable _cabinCategorys,_pansionsType;
        private string _ship;
        private string _selroom;
        private int _shipid;
        private string _brand;
        

        public FormEditHandPrice(string pack,DateTime saildate,int ship_id,string brand)
        {
            InitializeComponent();
            _pak = pack;
            _saildate = saildate;
            _shipid = ship_id;
            _ship = WorkWithData.GetDataTable(@"select code from ships where id="+ship_id.ToString()).Rows[0].Field<string>("code");
            _brand = brand;
            GetPansionTypes();
            //UpdateCabins();
            GetDate();
            dgvCabins_SelectionChanged(null,null);
            
        }
        void GetPansionTypes()
        {
            _pansionsType = WorkWithData.GetDataTable(@"SELECT  [id]
            ,[pansion]
            ,[order_pans]
            FROM [dbo].[Type_pansion]");
            cbPansion.DataSource = _pansionsType;
            cbPansion.DisplayMember = "pansion";
            cbPansion.ValueMember = "id";
            cbPansion.SelectedValue = 0;
        }
        void GetDate()
        {

            _cabinCategorys = WorkWithData.GetDataTable(@"select code as roomcategory  from CabinCategories where ship_id=" + _shipid.ToString());
//        _prices = WorkWithData.GetDataTable(String.Format(@"select 
//       [package]//      ,[sailDate]
//      ,[roomCategory]
//      ,[brandCode]
//      ,[shipCode]
//      ,[guest_1_Price] as guest_1_Price
//      ,[guest_2_Price] as guest_2_Price
//      ,[guest_1_2] as guest_1_2
//      ,[guest_3_4]as guest_3_4
//      ,[guest_3_4_gratuity] as guest_3_4_gratuity
//      ,[childPrice] as childPrice
//      ,[childPriceGratuity] as childPriceGratuity
//      ,[singlePrice] as singlePrice
//      ,[nonCommPrice] as nonCommPrice
//      ,[Fee] as Fee from Temp_CruisesCache where package='{0}' and sailDate='{1}' and pansion ={2}  order by roomCategory ", _pak, _saildate.Date.ToString(new CultureInfo("en-US")),cbPansion.SelectedValue));
            //dgvCabins.DataSource = _prices;
            dgvCabins.DataSource = _cabinCategorys;
            
            UpdateDataGrid();

        }
         void UpdateDataGrid()
         {
             foreach(DataGridViewColumn column in dgvCabins.Columns)
             {
                 switch (column.Name.ToLower())
                 {
                     case "roomcategory" :
                         column.HeaderText = "Категория каюты";
                         break;
                     default :
                         column.Visible = false;
                         break;
                 }
                 
             }
         }
         
        void UpdateCabins()
        {
            DataTable _cabins;
            _cabins = WorkWithData.GetDataTable(@"select code from CabinCategories where ship_id="+_shipid.ToString());
            foreach (DataRow row in _cabins.Rows)
            {
                DataTable _rezult = WorkWithData.GetDataTable(String.Format(@"select package from Temp_CruisesCache where package='{0}' and sailDate='{1}' and roomCategory='{2}'", _pak, _saildate.Date.ToString(new CultureInfo("en-US")), row.Field<string>("code")));
                if (_rezult.Rows.Count < 1)
                {
                    SqlCommand com = new SqlCommand(@"insert into Temp_CruisesCache(package,sailDate,roomCategory,brandCode,shipcode) values (@pak,@date,@room,@brand,@ship)",WorkWithData.TsConnection);
                    com.Parameters.AddWithValue("@pak", _pak);
                    com.Parameters.AddWithValue("@ship", _ship);
                    com.Parameters.AddWithValue("@brand", _brand);
                    com.Parameters.AddWithValue("@date", _saildate.Date);
                    com.Parameters.AddWithValue("@room", row.Field<string>("code"));
                    com.ExecuteNonQuery();
                }
            }
        }


        private void BtnCancal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //foreach (var VARIABLE in this.Controls)
            //{
            //    TextBox sBox = VARIABLE as TextBox;
            //    if (sBox != null)
            //    {
            //        if (sBox.Text == string.Empty)
            //        {
            //            sBox.Text = "0.00";
            //        }
            //        decimal va;
            //        if (!Decimal.TryParse(sBox.Text, out va))
            //        {
            //            Messages.Error("Неправельно заведена цена");
            //            return;}
            //    }
            //}
            string update = @"mk_Hand_Price_Refresh";
            SqlCommand com = new SqlCommand(update,WorkWithData.TsConnection);
            com.CommandType = CommandType.StoredProcedure;
            if (tbGuest1.Text != string.Empty)
            {
                   com.Parameters.AddWithValue("@gues1",Convert.ToDecimal(tbGuest1.Text));  
            }
            else
            {
                com.Parameters.AddWithValue("@gues1", DBNull.Value);
            }
            if (tbGuest2.Text != string.Empty)
            {
                com.Parameters.AddWithValue("@gues2", Convert.ToDecimal(tbGuest2.Text));
            }
            else
            {
                com.Parameters.AddWithValue("@gues2", DBNull.Value);
            }
            if (tbGuest1_2G.Text != string.Empty)
            {
                com.Parameters.AddWithValue("@guest1_2", Convert.ToDecimal(tbGuest1_2G.Text));}
            else
            {
                com.Parameters.AddWithValue("@guest1_2", DBNull.Value);
            }
            if (tbGuest3_4.Text != string.Empty)
            {
                com.Parameters.AddWithValue("@guest3_4", Convert.ToDecimal(tbGuest3_4.Text));
            }
            else
            {
                com.Parameters.AddWithValue("@guest3_4", DBNull.Value);
            }
            if (tbGuest3_4G.Text != string.Empty)
            {
                com.Parameters.AddWithValue("@grat3_4", Convert.ToDecimal(tbGuest3_4G.Text));
            }
            else
            {
                com.Parameters.AddWithValue("@grat3_4", DBNull.Value);
            }
            if (tbChild.Text != string.Empty)
            {
                com.Parameters.AddWithValue("@child", Convert.ToDecimal(tbChild.Text));
            }
            else
            {
                com.Parameters.AddWithValue("@child", DBNull.Value);
            }
            if (tbGhildG.Text != string.Empty)
            {
                com.Parameters.AddWithValue("@childgrat", Convert.ToDecimal(tbGhildG.Text));
            }
            else
            {
                com.Parameters.AddWithValue("@childgrat", DBNull.Value);
            }
            if (tbSingle.Text != string.Empty)
            {
                com.Parameters.AddWithValue("@single", Convert.ToDecimal(tbSingle.Text));
            }
            else
            {
                com.Parameters.AddWithValue("@single", DBNull.Value);
            }
            if (tbNonComm.Text != string.Empty)
            {
                com.Parameters.AddWithValue("@noncom", Convert.ToDecimal(tbNonComm.Text));
            }
            else
            {
                com.Parameters.AddWithValue("@noncom", DBNull.Value);
            }
            if (tbFee.Text != string.Empty)
            {
                com.Parameters.AddWithValue("@fee", Convert.ToDecimal(tbFee.Text));}
            else
            {
                com.Parameters.AddWithValue("@fee", DBNull.Value);
            }
            foreach (SqlParameter par in com.Parameters)
            {
                if ((par.ParameterName != "@pak") && (par.ParameterName != "@date") && (par.ParameterName != "@room"))
                {
                    par.DbType = DbType.Decimal;
                }
            }
            com.Parameters.AddWithValue("@pansion", cbPansion.SelectedValue);
            com.Parameters.AddWithValue("@pak", _pak);
            com.Parameters.AddWithValue("@date", _saildate.Date);
            com.Parameters.AddWithValue("@room", _selroom);
            com.ExecuteNonQuery();
            label11.Visible = false;
            GetDate();


        }

        private void dgvCabins_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCabins.SelectedRows.Count<1) return;
            DataTable _prices = WorkWithData.GetDataTable(String.Format(@"select 
       [package]
      ,[sailDate]
      ,[roomCategory]
      ,[brandCode]
      ,[shipCode]
      ,[guest_1_Price] as guest_1_Price
      ,[guest_2_Price] as guest_2_Price
      ,[guest_1_2] as guest_1_2
      ,[guest_3_4]as guest_3_4
      ,[guest_3_4_gratuity] as guest_3_4_gratuity
      ,[childPrice] as childPrice
      ,[childPriceGratuity] as childPriceGratuity
      ,[singlePrice] as singlePrice
      ,[nonCommPrice] as nonCommPrice
      ,[Fee] as Fee from Temp_CruisesCache where package='{0}' and sailDate='{1}' and pansion ={2}  and roomCategory ='{3}'", _pak, _saildate.Date.ToString(new CultureInfo("en-US")), cbPansion.SelectedValue, dgvCabins.SelectedRows[0].Cells["roomcategory"].Value.ToString()));
            if (_prices.Rows.Count > 0)
            {
                DataRow rowselect = _prices.Rows[0];
                
                tbGuest1.Text = rowselect["guest_1_Price"].ToString();
                tbGuest1_2G.Text = rowselect["guest_1_2"].ToString();
                tbGuest2.Text = rowselect["guest_2_Price"].ToString();
                tbGuest3_4.Text = rowselect["guest_3_4"].ToString();
                tbGuest3_4G.Text = rowselect["guest_3_4_gratuity"].ToString();
                tbChild.Text = rowselect["childPrice"].ToString();
                tbGhildG.Text = rowselect["childPriceGratuity"].ToString();
                tbSingle.Text = rowselect["singlePrice"].ToString();
                tbNonComm.Text = rowselect["nonCommPrice"].ToString();
                tbFee.Text = rowselect["Fee"].ToString();
            }
            else
            {

                tbGuest1.Text = string.Empty;
                tbGuest1_2G.Text = string.Empty;
                tbGuest2.Text = string.Empty;
                tbGuest3_4.Text = string.Empty;
                tbGuest3_4G.Text = string.Empty;
                tbChild.Text = string.Empty;
                tbGhildG.Text = string.Empty;
                tbSingle.Text = string.Empty;
                tbNonComm.Text = string.Empty;
                tbFee.Text = string.Empty;}

            _selroom = dgvCabins.SelectedRows[0].Cells["roomcategory"].Value.ToString();
            label11.Visible = false;


        }

        private void tbGuest1_TextChanged(object sender, EventArgs e)
        {
            label11.Visible = true;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            FormRecalcCruise frmrecalc = new FormRecalcCruise(_pak,_saildate);
            frmrecalc.ShowDialog();
            GetDate();
        }

        private void tbGuest1_Leave(object sender, EventArgs e)
        {
            tbGuest2.Text = tbGuest1.Text;}
        }
}
