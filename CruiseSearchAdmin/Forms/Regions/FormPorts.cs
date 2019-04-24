using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using DevExpress.Data.Filtering.Helpers;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Regions
{
    public partial class FormPorts : ProjectForm
    {
        private int _id_region;
        private DataTable _ports;
        public FormPorts(int id_region)
        {
            InitializeComponent();
            GetPort();
            _id_region = id_region;
        }

        
        void GetPort()
        {string selPorts = @"SELECT [id]
                                ,[code]
                                ,[name_en]
                                ,[visible]
                                ,[id_region]
                                 FROM [dbo].[Seaports]   
                                 where ([id_crline] is NULL ) and([parent] is NULL)and([visible]=1)
                                 order by name_en";
            _ports =WorkWithData.GetDataTable(selPorts);
            LbPort.DataSource = _ports;LbPort.DisplayMember = "name_en";
            LbPort.ValueMember = "id";
        }

        private void btbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string addPort = @"insert into port_by_regions(id_port,id_region) values (@p0,@p1)";
                addPort.ExecuteNonQuery(LbPort.SelectedValue,_id_region);
            }
            catch 
            {
                Messages.Error("Этот порт уже привязан к этому региону");
            }
            
        }

        private void tbFilterPort_TextChanged(object sender, EventArgs e)
        {
            if (!tbFilterPort.Text.Equals( string.Empty))
            {

                DataTable results=new DataTable();
                results.Clear();
                results = _ports.Clone();
                
                for(int i=0;i<_ports.Rows.Count;i++)
                {
                    DataRow dataRow = _ports.Rows[i];
                    if (dataRow.Field<string>("name_en").ToLower().IndexOf(tbFilterPort.Text.ToLower()) != -1)
                    {
                        results.Rows.Add(dataRow.ItemArray);
                    }
                    }
                LbPort.DataSource = results;
                LbPort.DisplayMember = "name_en";
                LbPort.ValueMember = "id";
                LbPort.Refresh();
            }
            
            else
            {   
                LbPort.DataSource = _ports;
                LbPort.DisplayMember = "name_en";
                LbPort.ValueMember = "id";
                LbPort.Refresh();
            }
            
        }
    }
}
