using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.CountryForSeaports
{
    public partial class SeaportsVisa : ProjectForm
    {
        private DataTable _seaports,_countrys;
        List<country> _coutnries = new List<country>();
        private DataSet _visaCo;
        class country
        {
            public int id;
            public string DislayMember;
            public  country(int _id,string dislayMember)
            {
                id = _id;
                DislayMember = dislayMember;
            }

            public override string ToString()
            {
                return DislayMember;
            }
        }
        
        public SeaportsVisa()
        {
            InitializeComponent();
            lbCountry.Enabled = false;
            GetDate();
            GetFilter();
        
        }

        void GetFilter()
        {
            _coutnries.Add(new country(-1, "Все"));
            _coutnries.Add(new country(0, "Без страны"));
            foreach (DataRow countr in _countrys.Rows)
            {
                _coutnries.Add(new country(countr.Field<int>("CN_KEY"), countr.Field<string>("CN_NAME")));
            }
            cbCounry.DataSource = _coutnries;
          //  cbCounry.DisplayMember = "DislayMember";
        }
        public void GetDate()
        {
            _seaports = WorkWithData.GetDataTable("select id,name_ru,name_en,Who_Change_Country,Why_change_Country,id_contry_master from seaports where id_crline is null order by name_en", WorkWithData.TsConnection);
            _countrys = WorkWithData.GetDataTable("select '    Виза не нужна'as CN_NAME,-2 as CN_KEY union select CN_NAME,CN_KEY from tbl_country where CN_KEY <>0 order by CN_NAME ", WorkWithData.MasterConnection);
            dgvSeaports.DataSource = _seaports;
            lbCountry.DataSource = _countrys;
            
            lbCountry.DisplayMember = "CN_NAME";
            lbCountry.ValueMember = "CN_KEY";
            
            UpdateDataGridView();
            //cbCounry.ValueMember = "id";
        }

        private void SetFilter()
        {
            var rez = _seaports.Select();
            String select = string.Empty;
            country sel = cbCounry.SelectedValue as country;
            if (tbName.Text != string.Empty)
            {
                select=select+string.Format("(name_ru like '%{0}%' or name_en like '%{0}%')", tbName.Text);
            }
            if (sel.id != 0 && sel.id!=-1)
            {
                if (select != string.Empty)
                {
                    select = select + " and ";
                }
                select = select + "id_contry_master= " + sel.id.ToString() + " ";
                
            }
            else
            {
                if (sel.id == 0)
                {
                    if (select != string.Empty)
                    {
                        select = select + " and ";
                    }
                    select = select + "isnull(id_contry_master,0) =  0";
                }
            }
            rez = _seaports.Select(select);
            DataTable newTable = _seaports.Clone();
            
            foreach (DataRow row  in rez)
            {
                newTable.Rows.Add(row.ItemArray);
            }
            dgvSeaports.DataSource = newTable;
        }

        void UpdateDataGridView()
        {
            foreach (DataGridViewColumn colunm in dgvSeaports.Columns)
            {
                switch (colunm.Name.ToLower())
                {
                    case "name_ru":
                        {
                            colunm.HeaderText = "Русское название";
                            colunm.DisplayIndex = 0;
                            colunm.Width = (dgvSeaports.Width - 1)/4;

                        }
                        break;
                    case "name_en":
                        {
                            colunm.HeaderText = "Латинское название название";
                            colunm.DisplayIndex = 1;
                            colunm.Width =  (dgvSeaports.Width - 1)/4;
                        }
                        break;

                    case "who_change_country":
                        {
                            colunm.HeaderText = "Менеджер";
                            colunm.DisplayIndex = 2;
                            colunm.Width = (dgvSeaports.Width - 1) / 4;
                        }break;
                    case "why_change_country":
                        {
                            colunm.HeaderText = "Дата смены страны";
                            colunm.DisplayIndex = 3;
                            colunm.DefaultCellStyle.Format = "dd.MM.yy";
                            colunm.Width = (dgvSeaports.Width - 1) / 4;
                        }
                        break;
                    default:
                        {
                            colunm.Visible = false;

                        }
                        break;
                }
            }
        }
        private void SeaportsVisa_Load(object sender, EventArgs e)
        {

        }

        private void dgvSeaports_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSeaports.SelectedRows.Count > 0)
            {
                lbCountry.SelectedValue = dgvSeaports.SelectedRows[0].Cells["id_contry_master"].Value;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void cbCounry_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFilter();
        }private void btnOK_Click(object sender, EventArgs e)
        {
            int key =Convert.ToInt32( dgvSeaports.SelectedRows[0].Cells["id"].Value);
            string userName = WorkWithData.GetUserName();
            string upd = String.Format(@"update seaports set id_contry_master ={0} ,Why_change_Country = GetDate(),Who_Change_Country ='{2}' where id ={1} ", lbCountry.SelectedValue, key,userName);
            upd.ExecuteNonQuery();
            GetDate();
            SetFilter();
            lbCountry.Enabled = false;
            dgvSeaports.Enabled = true;
        }

        private void dgvSeaports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbCountry.Enabled = true;
            dgvSeaports.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lbCountry.Enabled = false;
            dgvSeaports.Enabled = true;
        }
    }
}
