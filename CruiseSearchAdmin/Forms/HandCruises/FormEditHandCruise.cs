using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.HandCruises
{
    public partial class FormEditHandCruise : Form
    {
        private bool _flagadd;
        private string _pack;
        private DateTime _saildate;
        
        public FormEditHandCruise()
        {
            InitializeComponent();
            GetCrLines();
            _flagadd = true;
            dtpOnBegin.Value = DateTime.Now;
            cbCrLine_SelectedIndexChanged(null,null);
        }
        public FormEditHandCruise(string pack,DateTime saildate )
        {
            InitializeComponent();
            GetCrLines();
            _flagadd = false;
               _pack = pack;
            _saildate = saildate;
            dtSailDate.Value = _saildate.Date;
            dtSailDate.Enabled = false;
            cbCrLine.Enabled = false;
            cbShips.Enabled = false;
            //Заполнение полей
            string select = @"SELECT [ID]
                            ,[Package]
                            ,[BrandCode]
                            ,[SailDate]
                            ,[Ship_id]
                            ,[OnBegin]
                            ,[OnEnd]
                            FROM [dbo].[Temp_Cruises] where Package =@pr0 and SailDate = @pr1 ";
            using (SqlCommand com = new SqlCommand(select,WorkWithData.TsConnection))
            {
                com.Parameters.AddWithValue("@pr0", _pack);
                com.Parameters.AddWithValue("@pr1", _saildate);
                SqlDataAdapter adapter = new SqlDataAdapter(com);

                DataTable dt = new DataTable();
                adapter.Fill(dt);cbCrLine.SelectedValue = dt.Rows[0].Field<string>("BrandCode");
                GetShips();
                cbShips.SelectedValue = dt.Rows[0].Field<int>("Ship_id");
                dtSailDate.Value = dt.Rows[0].Field<DateTime>("SailDate");
                dtpOnBegin.Value = dt.Rows[0].Field<DateTime>("OnBegin");
                dtpOnEnd.Value = dt.Rows[0].Field<DateTime>("OnEnd");
                tbCode.Text = dt.Rows[0].Field<string>("Package");
            }
            dtSailDate.Enabled = false;
            cbCrLine.Enabled = false;
            cbShips.Enabled = false;
        }

        void GetCrLines()
        {
            cbCrLine.DataSource = WorkWithData.GetDataTable(@"Select mnemo,name_en from CruiseLines");
            cbCrLine.DisplayMember = "name_en";
            cbCrLine.ValueMember = "mnemo";
        }

        void GetShips()
        {
            
            cbShips.DataSource = WorkWithData.GetDataTable(@"select sh.name_en,sh.id from ships as sh join CruiseLines as cr on cr.id = sh.cruise_line_id where mnemo ='"+cbCrLine.SelectedValue.ToString()+"'");
            cbShips.DisplayMember = "name_en";
            cbShips.ValueMember = "id";
            cbShips.Enabled = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Добавление круиза
            if (_flagadd)
            {
                SqlCommand com = new SqlCommand(@"insert into Temp_cruises (Package,BrandCode,SailDate,Ship_id,OnBegin,OnEnd)  values(@pak,@brand,@date,@ship,@OnBegin,@OnEnd)", WorkWithData.TsConnection);
                com.Parameters.AddWithValue("@pak", tbCode.Text);
                com.Parameters.AddWithValue("@brand", cbCrLine.SelectedValue.ToString());
                com.Parameters.AddWithValue("@date", dtSailDate.Value.Date);
                com.Parameters.AddWithValue("@ship", cbShips.SelectedValue.ToString());
                com.Parameters.AddWithValue("@OnBegin", dtpOnBegin.Value.Date);
                com.Parameters.AddWithValue("@OnEnd", dtpOnEnd.Value.Date);
                com.ExecuteNonQuery();
                string incPack = string.Format(@"update Temp_Package set MaxPac = (select max(MaxPac) from Temp_Package where BrandCode='{0}')+1 where BrandCode='{0}' ", cbCrLine.SelectedValue.ToString());
                incPack.ExecuteNonQuery();
                FormEditHandItinerary itinerary = new FormEditHandItinerary(tbCode.Text, dtSailDate.Value, cbCrLine.SelectedValue.ToString());
                itinerary.ShowDialog();
                FormEditHandPrice price = new FormEditHandPrice(tbCode.Text, dtSailDate.Value, Convert.ToInt32(cbShips.SelectedValue.ToString()), cbCrLine.SelectedValue.ToString());
                price.ShowDialog();}
            else
            {

                SqlCommand com = new SqlCommand(@"update Temp_cruises set OnBegin= @OnBegin,OnEnd= @OnEnd   where Package  = @pak and SailDate = @date ", WorkWithData.TsConnection);
                com.Parameters.AddWithValue("@pak", tbCode.Text);
                com.Parameters.AddWithValue("@date", dtSailDate.Value.Date);
                //com.Parameters.AddWithValue("@ship", cbShips.SelectedValue.ToString());
                com.Parameters.AddWithValue("@OnBegin", dtpOnBegin.Value.Date);
                com.Parameters.AddWithValue("@OnEnd", dtpOnEnd.Value.Date);
                com.ExecuteNonQuery();

            }
            Close();
        }

        private void cbCrLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCrLine.SelectedValue as DataRowView != null) return;
            DataTable _pack;
            _pack = WorkWithData.GetDataTable(@"SELECT [BrandCode]
                                                         ,[MaxPac]
                                                FROM [Temp_Package] 
                                                where BrandCode ='"+cbCrLine.SelectedValue.ToString()+"'");
            if (_pack.Rows.Count < 1)
            {
                string insQu = string.Format("insert into Temp_Package(BrandCode,MaxPac) values ('{0}',1) ", cbCrLine.SelectedValue.ToString());
                insQu.ExecuteNonQuery();
                _pack = WorkWithData.GetDataTable(@"SELECT [BrandCode]
                                                         ,[MaxPac]
                                                FROM [Temp_Package] 
                                                where BrandCode ='" + cbCrLine.SelectedValue.ToString() + "'");

            }
            DataTable _code = WorkWithData.GetDataTable(@"select code from CruiseLines where mnemo='" + cbCrLine.SelectedValue.ToString() + "'");
            tbCode.Text = _code.Rows[0].Field<string>("code") + string.Format("{0:d6}",_pack.Rows[0].Field<int>("MaxPac"));
            GetShips();

        }

        private void dtSailDate_ValueChanged(object sender, EventArgs e)
        {
            dtpOnEnd.Value = dtSailDate.Value;
        }
    }
}
