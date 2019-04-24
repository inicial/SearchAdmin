using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms
{
    public partial class FormSeaPortAdd : ProjectForm
    {
        private List<Seaport> _seaPorts;
        private DataTable _regions;
        public FormSeaPortAdd(List<Seaport> seaPorts, DataTable regions, DataTable crlines)
        {
            InitializeComponent();
            cbItemCrLine.DisplayMember = "name_en";
            cbItemCrLine.ValueMember = "id";
            var dt = crlines.Copy();
            dt.Rows.RemoveAt(0);
            cbItemCrLine.DataSource = dt;

            cbItemRegion.DisplayMember = "name";
            cbItemRegion.ValueMember = "id";
            var regDT = regions.Copy();
            regDT.Rows.RemoveAt(0);
            cbItemRegion.DataSource = regDT;

            _seaPorts = seaPorts;
            _regions = regions.Copy();
        }
        public static void AddSeaport(List<Seaport> seaPorts, DataTable regions, DataTable crlines)
        {
            using (var f = new FormSeaPortAdd(seaPorts, regions, crlines))
            {
                f.ShowDialog();
            }
        }

        private void tbOK_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void tbCancel_Click(object sender, EventArgs e)
        {
            if (Messages.Question("Выйти без сохранения?")) Close();
            else SaveChanges();
        }
        void SaveChanges()
        {
            if (tbName_ru.Text == string.Empty || tbCode.Text == string.Empty) { Messages.Error("Поля не должны быть пустыми"); return; }
            string name = tbname_en.Text;
            string name_ru = tbName_ru.Text;
            string code = tbCode.Text;
            int? crlineID = null;
            string crlinename = null;
            if (cbItemCrLine.SelectedValue != DBNull.Value)
            {
                crlineID = Convert.ToInt32(cbItemCrLine.SelectedValue);
                crlinename = cbItemCrLine.Text;
            }
            int? regionid = null;
            if (cbItemRegion.SelectedValue != DBNull.Value)
            {
                regionid = Convert.ToInt32(cbItemRegion.SelectedValue);
            }
            if (new Seaport(code, name,name_ru, parentID, crlineID, regionid, crlinename).Update(WorkWithData.TsConnection))
            {
                Messages.Information("Порт добавлен");
                Close();
                return;
            }
            Messages.Error("Создание нового порта не удалось");

        }
        int? parentID = null;
        string parentname = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (FormSeaPortsParent.GetParentPortID(out parentID, out parentname, _seaPorts, _regions))
                tbParent.Text = parentname;
        }
    }
}
