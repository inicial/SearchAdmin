using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.HandCruises
{
    public partial class FormEditHandItinerary : ProjectForm
    {
        private string _pak;
        private DateTime _sail;
        private string _brand;
        private DataTable _steps;
        public FormEditHandItinerary(string pak,DateTime sail,string brand)
        {
            InitializeComponent();
            _pak = pak;
            _sail = sail;
            _brand = brand;
            GetDate();
        }
        
        void GetDate()
        {
            string sel = string.Format(@"SELECT Temp_Itinerary.[Id] as itid
                                        ,[Package]
                                        ,[sailDate]
                                        ,[activityDate]
                                        ,[arrival]
                                        ,[depature]
                                        ,[barandCode]
                                        ,[PortCode]
                                        ,[Description]
                                        ,seaports.name_en
                                         FROM [Temp_Itinerary]
                                         inner join CruiseLines on barandCode =mnemo 
											inner join Seaports on PortCode = Seaports.code 
											and Seaports.id_crline = CruiseLines.id
                                         where [Package] = '{0}' and [sailDate] ='{1}' order by activityDate", _pak,_sail.Date.ToString(new CultureInfo("en-US")));
            _steps = WorkWithData.GetDataTable(sel);
            dgvItenerary.DataSource = _steps;
            UpdateDataGrid();
        }
        void UpdateDataGrid()
        {
            foreach (DataGridViewColumn column in dgvItenerary.Columns)
            {
                switch (column.Name.ToLower())
                {
                    case "activitydate":
                        column.HeaderText = "День активности";
                        column.DisplayIndex = 0;
                        break;
                    case "arrival":
                        column.HeaderText = "Время захода";
                        column.DisplayIndex = 2;
                        break;
                    case "depature":
                        column.HeaderText = "Время выхода";
                        column.DisplayIndex = 3;
                        break;
                    case "name_en":
                        column.HeaderText = "Порт";
                        column.DisplayIndex = 1;
                        break;
                    case "description":
                        column.HeaderText = "Описание";
                        column.DisplayIndex = 4;
                        break;
                    default:
                        column.Visible = false;
                        break;

                }
            }}
       
        private void btnAddStep_Click(object sender, EventArgs e)
        {
            FormAddHandSteps frm = new FormAddHandSteps(_pak,_sail,_brand);
            Hide();
            frm.ShowDialog();
            GetDate(); 
            Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRemoveStep_Click(object sender, EventArgs e)
        {
            string dele = string.Format("delete from Temp_Itinerary where id = {0} ",dgvItenerary.SelectedRows[0].Cells["itid"].Value.ToString());
            dele.ExecuteNonQuery();
            GetDate(); 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            FormAddHandSteps frm = new FormAddHandSteps(int.Parse(dgvItenerary.SelectedRows[0].Cells["itid"].Value.ToString()),_brand);
            Hide();
            frm.ShowDialog();
            GetDate();
            Show();}
    }
}
