using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.Regions
{
    public partial class FormPortsByRegion : ProjectForm
    {

       
        private int _id_region;
        private DataTable portsByRegion;
        public FormPortsByRegion(int id_region)
        {
            InitializeComponent();
            GetPortsByRegion(id_region);
            _id_region = id_region;
        }

        public void GetPortsByRegion(int id_region)
        {
            string selports = @"select regions.name_ru as regionname,seaports.name_en as portname,id_port,port_by_regions.id_region
                                  from port_by_regions 
                                  join seaports on id_port=seaports.id
                                  join regions on port_by_regions.id_region=regions.id  
                                  where port_by_regions.id_region=" + id_region.ToString() + " order by portname ";
            portsByRegion = WorkWithData.GetDataTable(selports);
            lbPortByregion.DataSource = portsByRegion;
            lbPortByregion.DisplayMember = "portname";
            lbPortByregion.ValueMember = "id_port";
            Text = "Порты региона " + WorkWithData.GetDataTable(@"select  name_ru from regions where id="+id_region.ToString()).Rows[0].Field<string>("name_ru");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string delport = @"delete from port_by_regions where (id_port=@p0)and(id_region=@p1)";
            delport.ExecuteNonQuery(WorkWithData.TsConnection,lbPortByregion.SelectedValue,_id_region);
            GetPortsByRegion(_id_region);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormPorts Ports =new FormPorts(_id_region);
            this.Hide();
            Ports.ShowDialog();
            this.Show();
            GetPortsByRegion(_id_region);
        }
    }

    

}

