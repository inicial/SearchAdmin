using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Regions
{
    public partial class FormEditRegion : ProjectForm
    {
        private bool _action;
        private int _id_select;
        private int? _id_parent;
        
        
        
        public FormEditRegion(int? id_parent)
        {
            InitializeComponent();
            
            SelRegeons();
            _id_parent = id_parent;
            if (_id_parent == null)
            {
                cbRegions.Enabled = false;
                //btnPorts.Enabled = false;
            }
            else
            {
                DataRow selParentRow;
                String selParent = @"select id,parent from regions where id="+_id_parent.ToString();
                selParentRow = WorkWithData.GetDataTable(selParent).Rows[0];
                //cbRegions.SelectedIndex = 0;
                _id_parent = id_parent;
                if (selParentRow.Field<int?>("parent") != null)
                {
                    _id_parent = selParentRow.Field<int?>("parent");
                }
                
                cbRegions.Enabled = true;
                btnPorts.Enabled = true;
                cbRegions.SelectedValue = _id_parent;
            }

            _action=false;
            
        }
        
        public void SelRegeons()
        {
            DataTable selRegTable;
            string selReg = @"select id,name_ru from regions where parent is null order by ordrer";
            selRegTable = WorkWithData.GetDataTable(selReg);
            cbRegions.DataSource = selRegTable;
            cbRegions.ValueMember = "id";
            cbRegions.DisplayMember = "name_ru";
        }

        public FormEditRegion(int? id_parent,int id_select)
        {
            InitializeComponent();
            _id_parent = id_parent;
            _id_select = id_select;
            _action = true;
            SelRegeons();
            if (_id_parent == null)
            {
                cbRegions.Enabled = false;
                //btnPorts.Enabled = false;
            }
            else
            {
               cbRegions.SelectedValue = _id_parent; 
            }
            
            string selReg = @"select id,name_ru,name_en,code,visible from regions where id="+_id_select.ToString();
            DataRow selRegRow = WorkWithData.GetDataTable(selReg).Rows[0];
            tbNameRu.Text = selRegRow.Field<string>("name_ru");
            tbNameEn.Text = selRegRow.Field<string>("name_en");
            tbCode.Text = selRegRow.Field<string>("code");
            chbVisible.Checked = selRegRow.Field<bool>("visible");

        }



        public FormEditRegion()
        {
            InitializeComponent();
            btnOk.Click += (s, e) =>
                               {
                                   if (tbNameRu.Text.Equals(string.Empty))
                                       Messages.Error("Поле русское название не может  быть пустым");
                                   DialogResult = DialogResult.OK;
                                   Close();
                               };
            btnCancel.Click += (s, e) =>
                                   {
                                       DialogResult = DialogResult.Cancel;
                                       Close();
                                   };
        }
        

       

        private void btnPorts_Click(object sender, EventArgs e)
        {
            if (!_action)
            {
              Messages.Error("Сначала добавте регион");  
            }
            else
            {
                //if (_id_parent == null)
                //{
                //   Messages.Error("Это основной регион"); 
                //}
                //else
                //{
                    FormPortsByRegion portsByRegion = new FormPortsByRegion(_id_select);
                    this.Hide();
                    portsByRegion.ShowDialog();
                    this.Show();

                //}
    
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbNameRu.Text == string.Empty)
            {
                Messages.Error("Имя не может быть пустым");
                return;
            }
            
            
            
            if (_action)
            {
                if (!cbRegions.Enabled||(Convert.ToInt16(cbRegions.SelectedValue)==0))
                {
                    _id_parent = null;
                }
                else
                {
                    _id_parent = Convert.ToInt32(cbRegions.SelectedValue);
                }
                string updRegion = @"update regions set name_ru=@p0,name_en=@p1,code=@p2,visible=@p3,parent=@p4 where id=@p5 ";
                updRegion.ExecuteNonQuery(WorkWithData.TsConnection,tbNameRu.Text,tbNameEn.Text,tbCode.Text,chbVisible.Checked,_id_parent,_id_select);
            }
            else
            {   //Добавление нового региона
                int parent;
                if (!cbRegions.Enabled||(Convert.ToInt16(cbRegions.SelectedValue)==0))
                {
                    _id_parent = null;
                }
                else
                {
                    _id_parent = Convert.ToInt32(cbRegions.SelectedValue);
                }
                if (_id_parent == null)
                {
                    parent = 0;
                }
                else
                {
                    parent =Convert.ToInt32( _id_parent);
                }
                String insRegion = @"declare @maxorder int 
                                    select @maxorder=MAX(ordrer) from regions where (isnull(parent,0) = @p0)
                                    insert into regions(name_ru,name_en,parent,ordrer,visible) 
                                    values (@p1,@p2,@p3,isnull(@maxorder+1,1),@p4)";
                insRegion.ExecuteNonQuery(WorkWithData.TsConnection,parent,tbNameRu.Text,tbNameEn.Text,_id_parent,chbVisible.Checked);
                
            }
            Close();
        }

       }
}
