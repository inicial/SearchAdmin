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
using CruiseSearchAdmin.HelperClasses;
using DevExpress.Utils.OAuth;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Spec
{
    public partial class FormHandCruisesCashe : Form
    {
        private DataTable bak,_handCruises = new DataTable();

        private DataRow _selectedCruise;
        private SqlCommand selectCommand;
        private SqlCommand bakSeCommand;
        private SqlDataAdapter bakAdapter;
        private DataTable bakTable;
        private SqlDataAdapter adapter;
        private DataGridViewRow sel_row;
        private bool flag = true;
        private const string SELECT_HANDCRUISESCASHE = @"SELECT hcc.[package]
                                                            ,hcc.[sailDate]
                                                            ,hcc.[roomCategory]
                                                            ,cl.name_en as crlinename
                                                            ,sh.name_en as shipname
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
                                                          ,cr.duration
                                                     FROM [dbo].[HandCruisesCache] as hcc
                                                     inner join Cruises as cr on cr.package=hcc.package and cr.sailDate=hcc.sailDate
                                                     inner join CruiseLines as cl on hcc.brandCode=cl.mnemo
                                                     inner join Ships as sh on sh.cruise_line_id=cl.id and sh.code=hcc.shipCode          
                                                     order by  hcc.package,hcc.sailDate ,hcc.roomCategory ";
        private const string UPDATE_HANDCRUISES = @"update [dbo].[HandCruisesCache] set [guest_1_Price] =@p0
                                                            ,[guest_2_Price] =@p1
                                                            ,[guest_1_2] =@p2
                                                            ,[guest_3_4] =@p3
                                                            ,[guest_3_4_gratuity] =@p4 
                                                            ,[childPrice]=@p5
                                                            ,[childPriceGratuity]=@p6
                                                            ,[singlePrice]=@p7
                                                            ,[nonCommPrice]=@p8
                                                            ,[Fee]=@p9 where [package]=@p10 and [sailDate]=@p11 and [roomCategory]=@p12 ";


        public FormHandCruisesCashe()
        {
            InitializeComponent();
            GetData();
            GetBak();
        }

        private void GetBak()
        {
            bakSeCommand = new SqlCommand(@"select * from HandCruisesCache", WorkWithData.TsConnection);
            bakAdapter = new SqlDataAdapter(bakSeCommand);
            bakTable = new DataTable();
            bakAdapter.Fill(bakTable);
            SqlCommandBuilder builder = new SqlCommandBuilder(bakAdapter);
        }

        private void GetData()
        {
            if (selectCommand == null)
            {
                selectCommand = new SqlCommand(SELECT_HANDCRUISESCASHE, WorkWithData.TsConnection);
            }
            if (adapter == null)
            {
                adapter = new SqlDataAdapter(selectCommand);
            }
            adapter.Fill(_handCruises); 
            bak = _handCruises.Copy();
            dgvCruises.DataSource = _handCruises;
           
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            foreach (DataGridViewColumn column in dgvCruises.Columns)
            {
                switch (column.Name.ToLower())
                {
                    case "saildate":
                    {
                        column.HeaderText = "Дата";
                        column.ReadOnly = true;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 0;

                    }
                        break;
                    case "roomcategory":
                    {
                        column.HeaderText = "Категория каюты";
                        column.ReadOnly = true;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 3;
                    }
                        break;

                    case "crlinename":
                    {
                        column.HeaderText = "Круизная компания";
                        column.ReadOnly = true;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 1;
                    }
                        break;
                    case "shipname":
                    {
                        column.HeaderText = "Лайнер";
                        column.ReadOnly = true;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 2;
                    }
                        break;
                    case "duration":
                    {
                        column.HeaderText = "Продолжительность";
                        column.ReadOnly = true;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 4;
                    }
                        break;


                    case "guest_1_price":
                    {
                        column.HeaderText = "Цена на одного";
                        column.ReadOnly = false;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 5;

                    }
                        break;
                    case "guest_2_price":
                    {
                        column.HeaderText = "Цена за второго";
                        column.ReadOnly = false;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 6;

                    }
                        break;
                    case "guest_1_2":
                    {
                        column.HeaderText = "Чаевые";
                        column.ReadOnly = false;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 7;

                    }
                        break;
                    case "guest_3_4":
                    {
                        column.HeaderText = "3-4 взрослый";
                        column.ReadOnly = false;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 8;

                    }
                        break;

                    case "childprice":
                    {
                        column.HeaderText = "3-4 ребенок";
                        column.ReadOnly = false;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 10;

                    }
                        break;
                    case "singleprice":
                    {
                        column.HeaderText = "Одноместное размещение";
                        column.ReadOnly = false;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 12;

                    }
                        break;
                    case "noncommprice":
                    {
                        column.HeaderText = "Портовый сбор";
                        column.ReadOnly = false;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 13;

                    }
                        break;
                    case "fee":
                    {
                        column.HeaderText = "Налоги и сборы";
                        column.ReadOnly = false;
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        column.DisplayIndex = 14;

                    }
                        break;

                    default:
                    {
                        column.Visible = false;
                    }
                        break;


                }
                dgvCruises.ReadOnly = false;
                dgvCruises.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dgvCruises.EditMode = DataGridViewEditMode.EditOnEnter;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            flag = false;
            string packege;
            DateTime sailDateTime;
            FormCruises.EditCruises(out packege, out sailDateTime);
            SqlCommand com =
                new SqlCommand(@"select distinct roomCategory from CruisesCache where saildate=@p1 and package=@p2  ",
                    WorkWithData.TsConnection);
            com.Parameters.AddWithValue("@p1", sailDateTime);
            com.Parameters.AddWithValue("@p2", packege);
            SqlDataAdapter ad = new SqlDataAdapter(com);
            DataTable _rooms = new DataTable();

            DataColumn col = _rooms.Columns.Add("selected", typeof (Boolean));
            col.DefaultValue = false;
            ad.Fill(_rooms);

            FormRooms rooms = new FormRooms(_rooms);
            rooms.ShowDialog();
            DataRow[] roomRows = _rooms.Select("selected=true");
            if (roomRows.Count() < 1) return;
            foreach (var roomRow in roomRows)
            {
                SqlCommand com1 = new SqlCommand(@" 
INSERT INTO HandCruisesCache
SELECT TOP 1 [package]
           , [sailDate]
           , [roomCategory]
           , [brandCode]
           , [shipCode]
           , isnull([guest_1_Price],0.00)
           , isnull([guest_2_Price],0.00)
           , isnull([guest_1_2],0.00)
           , isnull([guest_3_4],0.00)
           , isnull([guest_3_4_gratuity],0.00)
           , isnull([childPrice],0.00)
           , isnull([childPriceGratuity],0.00)
           , isnull([singlePrice],0.00)
           , isnull([nonCommPrice],0.00)
           , isnull([Fee],0.00)
FROM
  [dbo].[CruisesCache]
WHERE
  saildate = @p1
  AND package = @p2
  AND roomCategory = @p3
  AND [guest_1_Price] = (SELECT min([guest_1_Price])

                         FROM
                           [dbo].[CruisesCache]
                         WHERE
                           saildate = @p1
                           AND package = @p2
                           AND roomCategory = @p3)", WorkWithData.TsConnection);
                com1.Parameters.AddWithValue("@p1", sailDateTime);
                com1.Parameters.AddWithValue("@p2", packege);
                com1.Parameters.AddWithValue("@p3", roomRow["roomCategory"].ToString());
                com1.ExecuteNonQuery();
            }
            _handCruises.Rows.Clear();
            adapter.Fill(_handCruises);
            bak = _handCruises.Copy();
            dgvCruises.DataSource = _handCruises;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCruises.SelectedCells.Count < 1)
            {
                Messages.Error("Выберете сначало спецпродложение!");
                return;
            }
            _selectedCruise = _handCruises.Rows[dgvCruises.SelectedCells[0].RowIndex];
            SqlCommand com =
                new SqlCommand(
                    @"delete from HandCruisesCache where package=@p0 and sailDate =@p1 and roomCategory=@p2 ",
                    WorkWithData.TsConnection);
            com.Parameters.AddWithValue("@p0", _selectedCruise.Field<string>("package"));
            com.Parameters.AddWithValue("@p1", _selectedCruise.Field<DateTime>("sailDate"));
            com.Parameters.AddWithValue("@p2", _selectedCruise.Field<string>("roomCategory"));
            com.ExecuteNonQuery();
            _handCruises.Rows.Clear();
            adapter.Fill(_handCruises);
            bak = _handCruises.Copy();
            dgvCruises.DataSource = _handCruises;
            flag = false;


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow sel_row in dgvCruises.Rows)
            {
                if (sel_row.Index > bak.Rows.Count - 1) return;
                if ((Convert.ToDecimal(sel_row.Cells["guest_1_Price"].Value) !=
                     bak.Rows[sel_row.Index].Field<Decimal>("guest_1_Price"))
                    ||
                    (Convert.ToDecimal(sel_row.Cells["guest_2_Price"].Value) !=
                     bak.Rows[sel_row.Index].Field<Decimal>("guest_2_Price"))
                    ||
                    (Convert.ToDecimal(sel_row.Cells["guest_1_2"].Value) !=
                     bak.Rows[sel_row.Index].Field<Decimal>("guest_1_2"))
                    ||
                    (Convert.ToDecimal(sel_row.Cells["guest_3_4"].Value) !=
                     bak.Rows[sel_row.Index].Field<Decimal>("guest_3_4"))
                    ||
                    (Convert.ToDecimal(sel_row.Cells["guest_3_4_gratuity"].Value) !=
                     bak.Rows[sel_row.Index].Field<Decimal>("guest_3_4_gratuity"))
                    ||
                    (Convert.ToDecimal(sel_row.Cells["childPrice"].Value) !=
                     bak.Rows[sel_row.Index].Field<Decimal>("childPrice"))
                    ||
                    (Convert.ToDecimal(sel_row.Cells["childPriceGratuity"].Value) !=
                     bak.Rows[sel_row.Index].Field<Decimal>("childPriceGratuity"))
                    ||
                    (Convert.ToDecimal(sel_row.Cells["singlePrice"].Value) !=
                     bak.Rows[sel_row.Index].Field<Decimal>("singlePrice"))
                    || (Convert.ToDecimal(sel_row.Cells["nonCommPrice"].Value) !=
                        bak.Rows[sel_row.Index].Field<Decimal>("nonCommPrice"))
                    || (Convert.ToDecimal(sel_row.Cells["Fee"].Value) !=
                        bak.Rows[sel_row.Index].Field<Decimal>("Fee")))
                {
                    SqlCommand com = new SqlCommand(UPDATE_HANDCRUISES, WorkWithData.TsConnection);

                    flag = false;

                    decimal? guest_1_Price = Convert.ToDecimal(sel_row.Cells["guest_1_Price"].Value),
                        guest_2_Price = Convert.ToDecimal(sel_row.Cells["guest_2_Price"].Value),
                        guest_1_2 = Convert.ToDecimal(sel_row.Cells["guest_1_2"].Value),
                        guest_3_4 = Convert.ToDecimal(sel_row.Cells["guest_3_4"].Value),
                        guest_3_4_gratuity = Convert.ToDecimal(sel_row.Cells["guest_3_4_gratuity"].Value),
                        childPrice = Convert.ToDecimal(sel_row.Cells["childPrice"].Value),
                        childPriceGratuity = Convert.ToDecimal(sel_row.Cells["childPriceGratuity"].Value),
                        singlePrice = Convert.ToDecimal(sel_row.Cells["singlePrice"].Value),
                        nonCommPrice = Convert.ToDecimal(sel_row.Cells["nonCommPrice"].Value),
                        Fee = Convert.ToDecimal(sel_row.Cells["Fee"].Value);
                    string package = sel_row.Cells["package"].Value.ToString(),
                        roomCategory = sel_row.Cells["roomCategory"].Value.ToString();
                    DateTime sailDate = Convert.ToDateTime(sel_row.Cells["sailDate"].Value);

                    com.Parameters.AddWithValue("@p0", guest_1_Price);
                    com.Parameters.AddWithValue("@p1", guest_2_Price);

                    com.Parameters.AddWithValue("@p2", guest_1_2);

                    com.Parameters.AddWithValue("@p3", guest_3_4);
                    com.Parameters.AddWithValue("@p4", guest_3_4_gratuity);
                    com.Parameters.AddWithValue("@p5", childPrice);
                    com.Parameters.AddWithValue("@p6", childPriceGratuity);
                    com.Parameters.AddWithValue("@p7", singlePrice);
                    com.Parameters.AddWithValue("@p8", nonCommPrice);
                    com.Parameters.AddWithValue("@p9", Fee);
                    com.Parameters.AddWithValue("@p10", package);
                    com.Parameters.AddWithValue("@p11", sailDate);
                    com.Parameters.AddWithValue("@p12", roomCategory);
                    com.ExecuteNonQuery();
                }
            }
            bakTable.Rows.Clear();
            bakAdapter.Fill(bakTable);
            flag = true;

        }



        private void dgvCruises_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCruises.SelectedCells.Count < 1)
            {
                return;
            }
            if (_handCruises.Rows.Count < (dgvCruises.SelectedCells[0].RowIndex + 1))
            {
                btnAdd_Click(sender, e);
            }
            else
            {
                sel_row = dgvCruises.SelectedCells[0].OwningRow;
            }

        }

        private void dgvCruises_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            flag = false;
        }

        private void btnRollba_Click(object sender, EventArgs e)
        {
            bakAdapter.Update(bakTable);
            _handCruises.Rows.Clear();
            adapter.Fill(_handCruises);
            dgvCruises.DataSource = _handCruises;
            flag = true;
        }

        private void FormHandCruisesCashe_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!flag)
            {
                if (Messages.Question("Есть несохраненные изменения!\nХотите сохранить?"))
                {
                    btnEdit_Click(sender,e);
                    flag = true;
                }
                else
                {
                    bakAdapter.Update(bakTable);
                }
            }
        }
    }
}
