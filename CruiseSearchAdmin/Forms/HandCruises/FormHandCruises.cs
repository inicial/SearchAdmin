using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Forms.Spec;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.HandCruises
{
    public partial class FormHandCruises : ProjectForm
    {
        private DataTable _cruises;
        private DataTable _ships;
        private DataTable _crLines;
        private string _crLine =null;

        public FormHandCruises()
        {
            InitializeComponent();
            GetFilterDate();
            GetDate();
            cbCrLine.Visible = true;

        }
        public FormHandCruises(string brand)
        {
            InitializeComponent();
            GetDate();
            GetFilterDate();
            cbCrLine.Visible = false;
            cbCrLine.SelectedValue = brand;
            _crLine = brand;
            cbCrLine_SelectedIndexChanged(null,null);
        }
 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void UpdateDataGrid()
        {
            foreach (DataGridViewColumn column in dgvCruises.Columns)
            {
                switch (column.Name.ToLower())
                {
                    case "package":
                        {
                            column.HeaderText = "Код круиза";
                            column.DisplayIndex = 1;
                            column.Width = 2 * dgvCruises.Width/ 9;

                        }
                        break;
                    case "saildate":
                        {
                            column.HeaderText = "Дата";
                            column.DisplayIndex = 0;
                            column.Width = 2 * dgvCruises.Width/ 9;

                        }
                        break;
                    case "shipname":{
                            column.HeaderText = "Лайнер";
                            column.DisplayIndex = 2;
                            column.Width = 5*dgvCruises.Width/9;
                    }
                        break;
                    default:
                        column.Visible = false;
                        break;
                }

            }
        }

        private void GetDate()
        {
           string sel =  @"SELECT 
                                                [Package]
                                                ,[BrandCode]
                                                ,[SailDate]
                                                ,ships.name_en as shipname
                                                 ,Ship_id
                                                 FROM [Temp_Cruises] inner join ships on Temp_Cruises.Ship_id = ships.id  ";
            
           
            if ((cbCrLine.SelectedValue.ToString() != "*") && (cbCrLine.SelectedValue as string != null))
            {
                sel = "select * from (" + sel + ") as table1 where table1.BrandCode ='" + cbCrLine.SelectedValue.ToString() + "'";
            }
            if ((cbShips.SelectedValue.ToString() != "0" )&&(cbShips.Enabled))
            {
                sel = "select * from (" + sel + ") as table2 where table2.Ship_id =" + cbShips.SelectedValue.ToString();
            }
            _cruises = WorkWithData.GetDataTable(sel); 
            dgvCruises.DataSource = _cruises;
            UpdateDataGrid();
        }
        private void GetFilterDate()
        {
            //_ships = WorkWithData.GetDataTable(@"select name_en,id,code from Ships");
           // 
            _crLines = WorkWithData.GetDataTable(@"select name_en,mnemo from CruiseLines");
            _crLines.Rows.Add("All", "*");
            cbCrLine.DataSource = _crLines;
            cbCrLine.DisplayMember = "name_en";
            cbCrLine.ValueMember = "mnemo";
            cbCrLine.SelectedValue = "*";
            

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
           // Messages.Information("Данная функция находится в разработке!");
            if (dgvCruises.SelectedRows.Count < 1)
            {
                Messages.Error("Сначало выберете круиз!");
                return;
            }
            FormNewDate ndate = new FormNewDate(dgvCruises.SelectedRows[0].Cells["Package"].Value.ToString(), Convert.ToDateTime(dgvCruises.SelectedRows[0].Cells["SailDate"].Value));
            ndate.ShowDialog();
            GetDate();}

        private void btn_Click(object sender, EventArgs e)
        {
            //Messages.Information("Данная функция находится в разработке!");
           if (dgvCruises.SelectedRows.Count < 1)
           {
               Messages.Error("Сначало выберете круиз!");
               return;
           }
            if (!Messages.Question("Вы уверены что хотите удалить выбранный круиз?"))
            {
                return;}
            SqlCommand com = new SqlCommand("mk_delete_temp_cruise",WorkWithData.TsConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Saildate",
                                        Convert.ToDateTime(dgvCruises.SelectedRows[0].Cells["SailDate"].Value));
            com.Parameters.AddWithValue("@package", dgvCruises.SelectedRows[0].Cells["Package"].Value);
            com.ExecuteNonQuery();
            GetDate();
        }
        private void btnAddCruise_Click(object sender, EventArgs e)
        {
            FormEditHandCruise frm = new FormEditHandCruise();
            frm.ShowDialog();
            GetDate();

        }
        
        void GetShips()
        {
            _ships = WorkWithData.GetDataTable(@"select sh.name_en,sh.id,sh.code from ships as sh join CruiseLines as cr on cr.id = sh.cruise_line_id where mnemo ='" + cbCrLine.SelectedValue.ToString() + "'");
            _ships.Rows.Add("All", 0, "ALL");
            cbShips.DataSource = _ships;
            cbShips.DisplayMember = "name_en";
            cbShips.ValueMember = "id";
            cbShips.SelectedValue = 0;
            cbShips.Enabled = true;

        }

        private void cbCrLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCrLine.SelectedValue.ToString() == "*")
            {
                cbShips.Enabled = false;

            }
            else
            {
                GetShips(); 
            }
            
            GetDate();
        }

        private void cbShips_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDate();
        }

        private void btnEditItenerary_Click(object sender, EventArgs e)
        {
            if (dgvCruises.SelectedRows.Count < 1)
            {
                Messages.Error("Сначало выберете круиз!");
                return;
            }
            FormEditHandItinerary itinerary = new FormEditHandItinerary(dgvCruises.SelectedRows[0].Cells["Package"].Value.ToString(), Convert.ToDateTime(dgvCruises.SelectedRows[0].Cells["SailDate"].Value), dgvCruises.SelectedRows[0].Cells["BrandCode"].Value.ToString());
            itinerary.ShowDialog();
        }

        private void btnEditPrice_Click(object sender, EventArgs e)
        {
            if (dgvCruises.SelectedRows.Count < 1)
            {
                Messages.Error("Сначало выберете круиз!");
                return;
            }
            FormEditHandPrice price = new FormEditHandPrice(dgvCruises.SelectedRows[0].Cells["Package"].Value.ToString(), Convert.ToDateTime(dgvCruises.SelectedRows[0].Cells["SailDate"].Value), Convert.ToInt32(dgvCruises.SelectedRows[0].Cells["Ship_id"].Value), dgvCruises.SelectedRows[0].Cells["BrandCode"].Value.ToString());
            price.ShowDialog();
        }

        private void btnEditCruise_Click(object sender, EventArgs e)
        {
            string packege;
            DateTime sailDateTime;
            FormCruises.EditCruises(out packege, out sailDateTime);
            SqlCommand com1 =
                new SqlCommand(@"select distinct roomCategory from CruisesCache where saildate=@p1 and package=@p2  ",
                    WorkWithData.TsConnection);
            com1.Parameters.AddWithValue("@p1", sailDateTime);
            com1.Parameters.AddWithValue("@p2", packege);
            SqlDataAdapter ad = new SqlDataAdapter(com1);
            DataTable _rooms = new DataTable();

            DataColumn col = _rooms.Columns.Add("selected", typeof(Boolean));
            col.DefaultValue = false;
            ad.Fill(_rooms);

            FormRooms rooms = new FormRooms(_rooms);
            rooms.ShowDialog();
            DataRow[] roomRows = _rooms.Select("selected=true");
            if (roomRows.Count() < 1) return;

            // Копирование круиза в таблицы Temp
            string shipCode = string.Empty, brandCode = string.Empty;
            using (
                SqlCommand com =
                    new SqlCommand("select brandCode,shipCode from  CRUISES where package=@p0 and sailDate = @p2 ",
                                   WorkWithData.TsConnection))
            {
                com.Parameters.AddWithValue("@p0", packege);
                com.Parameters.AddWithValue("@p2", sailDateTime);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    shipCode = dt.Rows[0].Field<string>("shipCode");
                    brandCode = dt.Rows[0].Field<string>("brandCode");

                }


            }
            int idCrline =0;
            string crLineCode = string.Empty;
            using (
                SqlCommand com =
                    new SqlCommand("select id,code from  CruiseLines where mnemo=@p0 ",
                                   WorkWithData.TsConnection))
            {
                com.Parameters.AddWithValue("@p0", brandCode);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    crLineCode = dt.Rows[0].Field<string>("code");
                    idCrline = dt.Rows[0].Field<byte>("id");

                }


            }
            int shipId =0;
            using (
                SqlCommand com =
                    new SqlCommand("select id from  Ships where code=@p0 and cruise_line_id = @p2  ",
                                   WorkWithData.TsConnection))
            {
                com.Parameters.AddWithValue("@p0", shipCode);
                com.Parameters.AddWithValue("@p2", idCrline);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count >= 1)
                {

                    shipId = dt.Rows[0].Field<int>("id");

                }


            }
            DataTable _pack;
            _pack = WorkWithData.GetDataTable(@"SELECT [BrandCode]
                                                         ,[MaxPac]
                                                FROM [Temp_Package] 
                                                where BrandCode ='" + brandCode + "' " +string.Format(@"update Temp_Package set MaxPac = (select max(MaxPac) from Temp_Package where BrandCode='{0}')+1 where BrandCode='{0}' ", brandCode));
            if (_pack.Rows.Count < 1)
            {
                string insQu = string.Format("insert into Temp_Package(BrandCode,MaxPac) values ('{0}',1) ", brandCode);
                insQu.ExecuteNonQuery();
                _pack = WorkWithData.GetDataTable(@"SELECT [BrandCode]
                                                         ,[MaxPac]
                                                FROM [Temp_Package] 
                                                where BrandCode ='" + brandCode + "' " + string.Format(@"update Temp_Package set MaxPac = (select max(MaxPac) from Temp_Package where BrandCode='{0}')+1 where BrandCode='{0}' ", brandCode));

            }
            //DataTable _code = WorkWithData.GetDataTable(@"select code from CruiseLines where mnemo='" + cbCrLine.SelectedValue.ToString() + "'");
            string packe = crLineCode + string.Format("{0:d6}", _pack.Rows[0].Field<int>("MaxPac"));
            using (SqlCommand com = new SqlCommand(@"insert into Temp_cruises (Package,BrandCode,SailDate,Ship_id,OnBegin,OnEnd)  values(@pak,@brand,@date,@ship,GetDate(),@date)", WorkWithData.TsConnection))
            {
                com.Parameters.AddWithValue("@pak", packe);
                com.Parameters.AddWithValue("@brand", brandCode);
                com.Parameters.AddWithValue("@date", sailDateTime);
                com.Parameters.AddWithValue("@ship", shipId);
                com.ExecuteNonQuery(); 
            }
            String insertItinerary = @"insert into Temp_Itinerary(Package,sailDate,activityDate,arrival,depature,barandCode,PortCode) 
            SELECT @newPak
            ,[sailDate]
            ,[activityDate] 
            ,substring(ltrim(rtrim(arrival)),1,5)
            ,substring(ltrim(rtrim(departure)),1,5)
            ,@brand
            ,locCode
            FROM [dbo].[Itinerary]
            where package=@p0 and sailDate = @p1";
            using (SqlCommand com = new SqlCommand(insertItinerary,WorkWithData.TsConnection))
            {
                com.Parameters.AddWithValue("@newPak", packe);
                com.Parameters.AddWithValue("@brand", brandCode);
                com.Parameters.AddWithValue("@p0", packege);
                com.Parameters.AddWithValue("@p1", sailDateTime);
                com.ExecuteNonQuery();
            }

            string insertPrice = @"INSERT INTO	[Temp_CruisesCache](	
		[package]
      ,[sailDate]
      ,[roomCategory]
      ,[brandCode]
      ,[shipCode]
      ,[guest_1_Price]
      ,[guest_2_Price]
      ,[guest_1_2]
      ,[guest_3_4]
      ,[guest_3_4_gratuity]
      ,[childPrice]
      ,[childPriceGratuity]
      ,[singlePrice]
      ,[nonCommPrice]
      ,[Fee] 
      ,[pansion])
      
SELECT TOP 1 
		@NewPak
      ,[sailDate]
      ,[roomCategory]
      ,[brandCode]
      ,[shipCode]
      ,[guest_1_Price]
      ,[guest_2_Price]
      ,[guest_1_2]
      ,[guest_3_4]
      ,[guest_3_4_gratuity]
      ,[childPrice]
      ,[childPriceGratuity]
      ,[singlePrice]
      ,[nonCommPrice]
      ,[Fee]
      ,isnull(pansion,0)
  FROM [CruisesCache]
  where package =@pr1 and sailDate = @pr2 and roomCategory = @pr3";
            foreach (DataRow roomRow in roomRows)
            {
                using (SqlCommand com = new SqlCommand(insertPrice, WorkWithData.TsConnection))
                {
                    com.Parameters.AddWithValue("@newPak", packe);
                    com.Parameters.AddWithValue("@brand", brandCode);
                    com.Parameters.AddWithValue("@pr1", packege);
                    com.Parameters.AddWithValue("@pr2", sailDateTime);
                    com.Parameters.AddWithValue("@pr3", roomRow.Field<string>("roomCategory"));
                    com.ExecuteNonQuery();
                }
            }
            FormEditHandCruise frm = new FormEditHandCruise(packe, sailDateTime);
            frm.ShowDialog();
            FormEditHandPrice price = new FormEditHandPrice(packe,sailDateTime,shipId,brandCode);
            price.ShowDialog();
            GetDate();
            }

        private void btnEditCruise_Click_1(object sender, EventArgs e)
        {
            if (dgvCruises.SelectedRows.Count < 1)
            {
                Messages.Error("Сначало выберете круиз!");
                return;
            }
            FormEditHandCruise frm = new FormEditHandCruise(dgvCruises.SelectedRows[0].Cells["Package"].Value.ToString(), Convert.ToDateTime(dgvCruises.SelectedRows[0].Cells["SailDate"].Value));
            frm.ShowDialog();
            GetDate();
        }
    }}
