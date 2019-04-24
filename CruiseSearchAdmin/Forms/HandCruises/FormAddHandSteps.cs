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

namespace CruiseSearchAdmin.Forms.HandCruises
{
    public partial class FormAddHandSteps : Form
    {
        private string _pak;
        private DateTime _saildate;
        private string _brand;
        private bool _isAdd = true;
        private DataTable _typesDay;
        //private DateTime? _lastActivityDate = null;
        private int _idPort;
        public FormAddHandSteps(string pak,DateTime sail,string brand)
        {
            InitializeComponent();
            _pak = pak;
            _saildate = sail;
            DataTable max =
                WorkWithData.GetDataTable(
                    string.Format(
                        "select isnull(max(activityDate),'{1}') as date from Temp_Itinerary where Package ='{0}' and saildate ='{1}'", _pak, _saildate.Date.ToString(new CultureInfo("en-US"))));  
            dtActivity.Value = max.Rows[0].Field<DateTime>("date").Date.AddDays(1);
            _brand = brand;
            GetPorts();
            GetDate();}
        public FormAddHandSteps(int port,string brand)
        {
            InitializeComponent();
           // _pak = pak;
           // _saildate = sail;
            _brand = brand;
          //  _lastActivityDate = actitydate;
            _idPort = port;
            _isAdd = false;
            GetPorts();
            GetDate();
            SetStep();
        }
        void SetStep()
        {
            DataTable step = WorkWithData.GetDataTable(string.Format(@"SELECT top 1 [Id]
      ,[Package]
      ,[sailDate]
      ,[activityDate]
      ,[arrival]
      ,[depature]
      ,[barandCode]
      ,[PortCode]
      ,[DayType]
      ,[Description]
  FROM [dbo].[Temp_Itinerary] where id={0}",_idPort));
            if (step.Rows.Count > 0)
            {
                dtActivity.Value = step.Rows[0].Field<DateTime>("activityDate");
                cbPort.SelectedValue = step.Rows[0].Field<string>("PortCode");
                tbTimeArrival.Text = step.Rows[0].Field<string>("arrival");
                tbTimeDepature.Text = step.Rows[0].Field<string>("depature");
                rtbDescription.Text = step.Rows[0].Field<string>("Description");

                if (step.Rows[0].Field<string>("DayType") != null)
                {
                    string[] types = step.Rows[0].Field<string>("DayType").Split(',');
                    foreach (string type in types)
                    {
                        if (!string.IsNullOrEmpty(type))
                        {

                            object it = null;
                            
                            foreach (object item in clbDayType.Items)
                            {
                                if (((DataRowView) item)["TypeKey"].Equals(int.Parse(type)))
                                {
                                    it = item;
                                    break;
                                };
                            }
                            clbDayType.SetItemChecked(clbDayType.Items.IndexOf(it),true);}
                    }
                }
            }
        }
        void GetDate()
        {_typesDay = WorkWithData.GetDataTable(@"SELECT  [TypeKey],[TypeName]  FROM [dbo].[mk_TypesDay]");
            clbDayType.DataSource = _typesDay;
            clbDayType.ValueMember = "TypeKey";
            clbDayType.DisplayMember = "TypeName";
        }
        
        void GetPorts()
        {
            DataTable _ports = WorkWithData.GetDataTable(String.Format(@"select sp.code,sp.name_en 
            from Seaports as sp  inner join CruiseLines as cl on cl.id = sp.id_crline where mnemo = '{0}' order by sp.name_en", _brand));
            cbPort.DataSource = _ports;
            cbPort.DisplayMember = "name_en";
            cbPort.ValueMember = "code";
        }

        

        private void btnOk_Click(object sender, EventArgs e)
        {
            

            string dayTypes = string.Empty;
            foreach (DataRowView checkedItem in clbDayType.CheckedItems)
            {
                dayTypes +=(dayTypes==string.Empty?"":",")+checkedItem[("TypeKey")].ToString();
            }


            if (_isAdd)
            {
//Тут будет добавление шага
                string ins = @"INSERT INTO [Temp_Itinerary]
                        ([Package],
                        [sailDate],
                        [activityDate],
                        [arrival],
                        [depature],
                        [barandCode],
                        [PortCode],
                        [DayType],
                        [Description])
                        VALUES (@pak,@sail,@activity,@arrivel,@depature,@brand,@port,@dayType,@desc)";
                using (SqlCommand com = new SqlCommand(ins, WorkWithData.TsConnection))
                {
                    
                    com.Parameters.AddWithValue("@pak", _pak);
                    com.Parameters.AddWithValue("@sail", _saildate.Date);
                    com.Parameters.AddWithValue("@brand", _brand);
                    com.Parameters.AddWithValue("@activity", dtActivity.Value.Date);
                    com.Parameters.AddWithValue("@arrivel", tbTimeArrival.Text);
                    com.Parameters.AddWithValue("@depature", tbTimeDepature.Text);
                    com.Parameters.AddWithValue("@port", cbPort.SelectedValue);
                    if (dayTypes == string.Empty)
                    {
                        com.Parameters.AddWithValue("@dayType", DBNull.Value);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("@dayType", dayTypes);
                    }
                    com.Parameters.AddWithValue("@desc", rtbDescription.Text);
                    com.ExecuteNonQuery();
                }

            }
            else
            {
                //здесь будет измененине шага
                string upd = @"UPDATE [dbo].[Temp_Itinerary]
         SET      
      [activityDate] = @newActivity
      ,[arrival] = @arrivel
      ,[depature] = @depature
      ,[PortCode] = @newPort
      ,[DayType] = @dayType
      ,[Description] = @desc
      WHERE [Id] = @id ";

                using (SqlCommand com = new SqlCommand(upd, WorkWithData.TsConnection))
                {
                    
                   // com.Parameters.AddWithValue("@pak", _pak);
                   // com.Parameters.AddWithValue("@sail", _saildate.Date);
                   // com.Parameters.AddWithValue("@brand", _brand);
                    com.Parameters.AddWithValue("@newActivity", dtActivity.Value.Date);
                    com.Parameters.AddWithValue("@arrivel", tbTimeArrival.Text);
                    com.Parameters.AddWithValue("@depature", tbTimeDepature.Text);
                    com.Parameters.AddWithValue("@newPort", cbPort.SelectedValue);
                    if (dayTypes == string.Empty)
                    {
                        com.Parameters.AddWithValue("@dayType", DBNull.Value);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("@dayType", dayTypes);
                    }
                    com.Parameters.AddWithValue("@desc", rtbDescription.Text);
                    com.Parameters.AddWithValue("@id", _idPort);
                   // com.Parameters.AddWithValue("@lastPort", _lastPortCode);
                    com.ExecuteNonQuery();
                }
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
