using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Regions
{
    public partial class FormRedactorRegeon : ProjectForm
    {
        private DataTable dtRegion;
        public FormRedactorRegeon()
        {
            InitializeComponent();
            SelRegeons();
        }

        private void SelRegeons()
        {
            string regSelect = @"declare @maxorder int 
                                select @maxorder=MAX(ordrer) from regions 
                                SELECT     id, code, case when parent IS not null then '---'+ name_ru else name_ru end as name_ru, name_en, visible, parent, ordrer
                                FROM         Regions as r
                                ORDER BY (select [ordrer] from regions where id = isnull(r. parent,r.id)), CASE WHEN parent IS NULL THEN ordrer ELSE ordrer + @maxorder END";
            dtRegion = WorkWithData.GetDataTable(regSelect);
            lbRegion.DataSource = dtRegion;
            lbRegion.DisplayMember = "name_ru";
            lbRegion.ValueMember = "id";
        }
       
        private void toolStripMenuItemAddRegion_Click(object sender, EventArgs e)
        {
            FormEditRegion formEditRegion = new FormEditRegion(null);
            this.Hide();
            formEditRegion.ShowDialog();
            this.Show();
            SelRegeons();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegionRemove_Click(object sender, EventArgs e)
        {
            if (!Messages.Question("Вы уверены что хотите удалить этот регион и все его подрегионы и привязанные к ним порты?"))return;
            string DeleteRegeon = @"delete from regions where id=@p0
                                    delete from regions where parent=@p0 
                                    delete from port_by_regions where id_region=@p0";
            DeleteRegeon.ExecuteNonQuery(WorkWithData.TsConnection,lbRegion.SelectedValue);
            SelRegeons();}

        private void btnRegionAdd_Click(object sender, EventArgs e)
        {
            FormEditRegion formEditRegion = new FormEditRegion(Convert.ToInt32(lbRegion.SelectedValue));
            this.Hide();
            formEditRegion.ShowDialog();
            this.Show();
            SelRegeons();
        }

        private void btnDoun_Click(object sender, EventArgs e)
        {
            int oder = dtRegion.Rows[lbRegion.SelectedIndex].Field<int>("ordrer");
            int? parent=dtRegion.Rows[lbRegion.SelectedIndex].Field<int?>("parent");
            if (parent==null)
            {
                parent = 0;
            }
            int id = Convert.ToInt32(lbRegion.SelectedValue);
            string downReg = @"declare @maxorder int 
                               select @maxorder=MAX(ordrer) from regions where (isnull(parent,0) = @p0) 
                               if @maxorder<>@p1
                               begin
                               update regions set ordrer=@p2 where (isnull(parent,0) = @p3) and (ordrer=@p4)
                               update regions set ordrer=@p5 where id=@p6 
                               END";
            downReg.ExecuteNonQuery(WorkWithData.TsConnection, parent, oder, oder, parent, oder + 1, oder + 1, id);
            SelRegeons();
            lbRegion.SelectedValue = id;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int oder = dtRegion.Rows[lbRegion.SelectedIndex].Field<int>("ordrer");
            int? parent = dtRegion.Rows[lbRegion.SelectedIndex].Field<int?>("parent");
            if (parent == null)
            {
                parent = 0;
            }
            int id = Convert.ToInt32(lbRegion.SelectedValue);
            
            string upReg = @"if @p0<>1 
                             begin
                             update regions set ordrer=@p0 where (isnull(parent,0) = @p1) and (ordrer=@p2)
                             update regions set ordrer=@p3 where id=@p4 
                             END";
            upReg.ExecuteNonQuery(WorkWithData.TsConnection, oder, parent, oder - 1, oder - 1, id);
            
            SelRegeons();
            lbRegion.SelectedValue = id;
        }

        private void btnRegionEdit_Click(object sender, EventArgs e)
        {
            

                FormEditRegion formEditRegion =
                    new FormEditRegion(dtRegion.Rows[lbRegion.SelectedIndex].Field<int?>("parent"),
                        Convert.ToInt32(lbRegion.SelectedValue));
                this.Hide();
                formEditRegion.ShowDialog();
                this.Show();
                SelRegeons();
            }

        private void ToolStripMenuItemAddPodRegeon_Click(object sender, EventArgs e)
        {
            btnRegionAdd_Click(sender, e); 
        }

       
    }
}