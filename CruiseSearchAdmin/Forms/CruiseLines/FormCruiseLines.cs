using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Forms.CruiseLines.Settings;
using CruiseSearchAdmin.Forms.HandCruises;
using CruiseSearchAdmin.Forms.Ships;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.CruiseLines
{
    public partial class FormCruiseLines : ProjectForm
    {
        CruiseLinesCollection _cruiseLines = new CruiseLinesCollection();
        SqlConnection _connection = new SqlConnection();
        private WorkMode _workMode;
        private CruiseLine _selectedCruiseLine;
        public FormCruiseLines()
        {
            InitializeComponent();
        }

        public static void EditCruiseLines(SqlConnection connection)
        {
            using (var f = new FormCruiseLines())
            {
                f._connection = connection;
                f.GetData();
                f.ShowDialog();
            }
        }
        private void ChangeWorkMode(WorkMode wm)
        {
            gbMain.Enabled = !gbMain.Enabled;
            gbEdit.Enabled = !gbEdit.Enabled;
            btnClose.Enabled = !btnClose.Enabled;
            _workMode = wm;
        }
        private void GetData()
        {
            GetCruiseLines();
            cbClass.SetDataSource(WorkWithData.GetDataTable(@"select * from CruiseLineClass where visible=1",_connection),"id","name");
            cbCurrency.Items.Add("$");
            cbCurrency.Items.Add("Eu");
            cbCurrency.Items.Add("рб");
        }

        private void GetCruiseLines()
        {
            _cruiseLines.GetItems(_connection);
            lbCruiseLines.DataSource = null;
            lbCruiseLines.SetDataSource(_cruiseLines, "ID", "EnName");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeWorkMode(WorkMode.Edit);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            epFormError.Clear();
            ChangeWorkMode(WorkMode.None);
        }

        private void lbCruiseLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCruiseLine = lbCruiseLines.SelectedItem as CruiseLine;
            if (_selectedCruiseLine == null) return;
            GetCruiseLineData(_selectedCruiseLine);
            
        }

        private void GetCruiseLineData(CruiseLine cruiseLine)
        {
            tbNameEn.Text = cruiseLine.EnName;
            tbNameRu.Text = cruiseLine.RuName;
            tbMnemo.Text = cruiseLine.Mnemo;
            tbCode.Text = cruiseLine.Code;
            cbCurrency.SelectedIndex = cbCurrency.FindString(cruiseLine.Currency);
            tbURL.Text = cruiseLine.URL;
            cbClass.SelectedValue = cruiseLine.Class;
            chbDisableCL.Checked = !cruiseLine.Visible;
        }

        private void SetCruiseLineData(CruiseLine cruiseLine)
        {
            cruiseLine.EnName = tbNameEn.Text;
            cruiseLine.RuName = tbNameRu.Text;
            cruiseLine.Mnemo = tbMnemo.Text;
            cruiseLine.Code = tbCode.Text;
            cruiseLine.Currency = (string)cbCurrency.SelectedItem;
            cruiseLine.URL = tbURL.Text;
            cruiseLine.Class = (int) cbClass.SelectedValue;
            cruiseLine.Visible = !chbDisableCL.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxEmpty(tbNameEn) || CheckTextBoxEmpty(tbNameRu)||CheckCodeString()) return;
            SetCruiseLineData(_selectedCruiseLine);
            if (_workMode == WorkMode.Edit)
            {
                _selectedCruiseLine.Update();
            }
            else
            {
                _selectedCruiseLine.Insert();
            }
            epFormError.Clear();
            ChangeWorkMode(WorkMode.None);
            GetCruiseLines();
        }

        private bool CheckTextBoxEmpty(TextBox textBox)
        {
            if (textBox.Text == string.Empty)
            {
                epFormError.SetError(textBox, "Поле не должно быть пустым");
                return true;
            }
            return false;
        }
       
        private bool CheckCodeString()
        {
            if (_cruiseLines.Any(cl => cl.Code == tbCode.Text&&cl.ID!=_selectedCruiseLine.ID))
            {
                epFormError.SetError(tbMnemo, "Такое значение уже занято");
                return true;
            }
            if (tbCode.Text.Length <3 )
            {
                epFormError.SetError(tbMnemo, "Код должен быть меньше 3-х символов");
                return true;
            }
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _selectedCruiseLine = new CruiseLine(-1,"New Cruise Line","","","",0,_connection);
            GetCruiseLineData(_selectedCruiseLine);
            ChangeWorkMode(WorkMode.Add);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!Messages.Question("Удалить " + _selectedCruiseLine.EnName + "?")) return;
            _selectedCruiseLine.Delete();
            GetCruiseLines();
        }

        private void tbShips_Click(object sender, EventArgs e)
        {
            if (_selectedCruiseLine == null)
            {
                Messages.Error("Сначала следует выбрать компанию");
                return;
            }
            FormShips.ManageShips(_selectedCruiseLine);
            GetCruiseLines();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (_selectedCruiseLine == null)
            {
                Messages.Error("Сначала следует выбрать компанию");
                return;
            }
            FormEditCruiseLineSettings.SetCruiseLineSettings(_selectedCruiseLine.Settings,_selectedCruiseLine);
            GetCruiseLines();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddCruises_Click(object sender, EventArgs e)
        {
          FormHandCruises frm = new FormHandCruises();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbCruiseLines.SelectedItem == null)
            {
                Messages.Error("Сначало выберете круизную компанию!");
                return;
            }
            CruiseLine cr = lbCruiseLines.SelectedItem as CruiseLine;
            string com = string.Format(@"insert into mk_job_prices (crlines,date_job) values (@p0,@p1)");
            com.ExecuteNonQuery(cr.Mnemo,DateTime.Now);
        }

    }
}