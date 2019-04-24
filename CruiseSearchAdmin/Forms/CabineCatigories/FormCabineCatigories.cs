using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using CruiseSearchAdmin.Entities.CabineCategories;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.CabineCatigories
{
    public partial class FormCabineCatigories : ProjectForm
    {
        const string SELCT_CABIN_CLASSES = @"SELECT  [id], [name]  FROM [dbo].[CabinClasses] where id != 5 order by [order] ";
        const string SELECT_CABIN_CATEGORIES = @"SELECT [dbo].[CabinCategories].[id]
            ,[dbo].[CabinCategories].[ship_id]
            ,[dbo].[Ships].[name_en] as nameship
            ,[dbo].[CabinCategories].[code]
            ,[dbo].[CabinCategories].[name_ru]
            ,[dbo].[CabinCategories].[name_en]
            ,[dbo].[CabinCategories].[description]
            ,[dbo].[CabinCategories].[in_out]
            ,[dbo].[CabinCategories].[visible]
            ,[dbo].[CabinCategories].[class_id]
            ,case when ([dbo].[CabinCategories].[class_id] = 5) then '' else [dbo].[CabinClasses].[name] end as 'cabinclass'
            ,isnull([dbo].[CabinCategories].[maxpax],0) as maxpax
            FROM [dbo].[CabinCategories] 
            join [dbo].[Ships] on [dbo].[CabinCategories].[ship_id]=[dbo].[Ships].[id] 
            join [dbo].[CabinClasses] on [dbo].[CabinCategories].[class_id]=[dbo].[CabinClasses].[id]
            where [dbo].[Ships].[id]=@p0";
        private CabineCategories _cabine;
        private SqlConnection _connection;
        private int _idShip;
        public FormCabineCatigories(int idShips)
        {
            InitializeComponent();
            _idShip = idShips;
            SelCabin();
            this.Text = "Каюты" + ' ' + WorkWithData.GetDataTable(@"select name_en from ships where id= " + _idShip.ToString()).Rows[0].Field<string>("name_en");
            UpdateCabinGrid();
            CBIn_Out.Items.Add("I");
            CBIn_Out.Items.Add("O");
            SqlDataAdapter daClassCabin = new SqlDataAdapter(SELCT_CABIN_CLASSES, _connection);
            var cabClass = new DataTable();
            daClassCabin.Fill(cabClass);
            CBCabinClass.DataSource = cabClass;
            CBCabinClass.DisplayMember = "name";
            CBCabinClass.ValueMember = "id";
        }

        private void SelCabin()
        {
            _connection = WorkWithData.TsConnection;


            SqlDataAdapter daCabineCategories = new SqlDataAdapter();
            daCabineCategories.SelectCommand = new SqlCommand(SELECT_CABIN_CATEGORIES, _connection);
            daCabineCategories.SelectCommand.Parameters.Add("p0", SqlDbType.Int, 32);
            daCabineCategories.SelectCommand.Parameters[0].Value = _idShip;
            DataTable cabineDataTable = new DataTable();
            daCabineCategories.Fill(cabineDataTable);
            List<CabineCategories> CabinCatList = (from DataRow r in cabineDataTable.Rows select new CabineCategories(r, _connection)).ToList();
            dgvCabines.DataSource = CabinCatList;
        }

        void UpdateCabinGrid()
        {
            foreach (DataGridViewColumn column in dgvCabines.Columns)
            {
                switch (column.Name.ToLower())
                {
                    case "code":
                        {
                            column.HeaderText = "Код каюты";
                            column.MinimumWidth = dgvCabines.Width / 3 - 30;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DisplayIndex = 0;
                        }
                        break;
                    case "name_en":
                        {
                            column.HeaderText = "Наименование каюты";
                            column.MinimumWidth = dgvCabines.Width / 3 - 30;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DisplayIndex = 1;
                        }
                        break;
                    case "classname":
                        {
                            column.HeaderText = "Класс каюты";
                            column.MinimumWidth = dgvCabines.Width / 3 - 30;
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            column.DisplayIndex = 2;
                        }
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (ECodCabine.Text.Length >= 10)
            //{
            //    e.KeyChar = Convert.ToChar(0);
            //};
        }
        private void btnAddCabine_Click(object sender, EventArgs e)
        {
            gbInfo.Text = "Добавление каюты";
            gbInfo.Enabled = true;
            gbInfo.Tag = 1;
            EEn_Name.Text = string.Empty;
            ERu_Name.Text = string.Empty;
            ECodCabine.Text = string.Empty;
            EMaxPax.Text = string.Empty;
            EDescriptor.Text = string.Empty;
            EVisable.Checked = false;
            CBIn_Out.SelectedIndex = 1;
            CBCabinClass.SelectedIndex = 1;
            dgvCabines.Enabled = false;
        }

        private void btnEditCabine_Click(object sender, EventArgs e)
        {
            dgvCabines.Enabled = false;
            if (dgvCabines.SelectedRows.Count < 1)
            {
                Messages.Error("Сначало выберете каюту");
            }
            else
            {
                _cabine = dgvCabines.SelectedRows[0].DataBoundItem as CabineCategories;
                gbInfo.Text = "Изменение" + ' ' + _cabine.name_en;
                gbInfo.Enabled = true;
                gbInfo.Tag = 0;
                EEn_Name.Text = _cabine.name_en;
                ERu_Name.Text = _cabine.name_ru;
                CBCabinClass.SelectedValue = _cabine.class_id; ECodCabine.Text = _cabine.code;
                EMaxPax.Text = Convert.ToString(_cabine.maxpax);
                EDescriptor.Text = _cabine.description; EVisable.Checked = _cabine.visable;
                CBIn_Out.SelectedIndex = _cabine.in_out.ToLower().Equals("i") ? 0 : 1;
                try
                {
                    CBCabinClass.SelectedItem = _cabine.class_id;
                }
                catch (Exception)
                {
                    Debug.WriteLine("Все плохо!!!");
                    CBCabinClass.SelectedIndex = -1;
                    throw;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbInfo.Enabled = false;
            dgvCabines.Enabled = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CBCabinClass.SelectedIndex == (-1))
            {
                Messages.Error("Сначало выберите класс каюты");
                return;
            }
            if (EMaxPax.Text == string.Empty)
            {
                Messages.Error("Сначало заполните количество человек");return;
            }
            _cabine = new CabineCategories(0, _idShip, ECodCabine.Text, ERu_Name.Text, EEn_Name.Text, EDescriptor.Text, CBIn_Out.SelectedItem.ToString(), EVisable.Checked, Convert.ToInt32(CBCabinClass.SelectedValue), Convert.ToInt32(EMaxPax.Text), _connection);
            if (gbInfo.Text == "Добавление каюты")
            {
                _cabine.Insert();
            }
            else
            {
                CabineCategories cab = dgvCabines.SelectedRows[0].DataBoundItem as CabineCategories;
                _cabine.ID = cab.ID;
                _cabine.Update();
            }
            gbInfo.Enabled = false;
            SelCabin();
            dgvCabines.Enabled = true;
        }


        private void dvgCabines_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvCabines.SelectedRows.Count < 1) return;
            _cabine = dgvCabines.SelectedRows[0].DataBoundItem as CabineCategories;
            EEn_Name.Text = _cabine.name_en;
            ERu_Name.Text = _cabine.name_ru;
            ECodCabine.Text = _cabine.code;
            EMaxPax.Text = Convert.ToString(_cabine.maxpax);
            EDescriptor.Text = _cabine.description;
           
            EVisable.Checked = _cabine.visable ;
            CBCabinClass.SelectedValue = _cabine.class_id;
            CBIn_Out.SelectedIndex = _cabine.in_out.ToLower().Equals("i") ? 0 : 1;
            try
            {
                CBCabinClass.SelectedItem = _cabine.class_id;
            }
            catch (Exception)
            {
                CBCabinClass.SelectedIndex = -1;
                throw;
            }

        }

        private void btnRemoveCabine_Click(object sender, EventArgs e)
        {
            if (dgvCabines.SelectedRows.Count < 1) return;
            _cabine = dgvCabines.SelectedRows[0].DataBoundItem as CabineCategories;
            _cabine.Delete();
            SelCabin();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}