using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.Itinerary
{
    public partial class FormChangeRegion : ProjectForm
    {
        List<Region> regions = new List<Region>();
        private Region? selectedRegion;
        public FormChangeRegion()
        {
            InitializeComponent();
            btnOk.Click += (s, e) =>
            {
                DialogResult = DialogResult.OK;
                Close();
            };
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
            chbVisStateReg.CheckStateChanged += (s, e) =>
                                                    {
                                                        cbRegions.DataSource = null;
                                                        cbRegions.DataSource = GetRegions(!chbVisStateReg.Checked);
                                                        cbRegions.DisplayMember = "Name_ru";
                                                        cbRegions.ValueMember = "ID";
                                                        if(cbRegions.Items.Count<1)
                                                        {
                                                            selectedRegion = null;
                                                            return;
                                                        }
                                                        cbRegions.SelectedIndex = 0;
                                                        selectedRegion = (Region)cbRegions.SelectedItem;
                                                    };
            cbRegions.SelectionChangeCommitted += (s, e) => { selectedRegion = (Region)cbRegions.SelectedItem; };
            cbRegions.DataSource = GetRegions(visible: true);
            cbRegions.DisplayMember = "Name_ru";
            cbRegions.ValueMember = "ID";
            cbRegions.SelectedIndex = 0;
            selectedRegion = (Region)cbRegions.SelectedItem;
        }
        public static Region? ChangeRegion()
        {
            using (var f = new FormChangeRegion())
            {
                return f.ShowDialog() == DialogResult.OK ? f.selectedRegion : null;
            }
        }

        List<Region> GetRegions(bool visible)
        {
            var dt =
                WorkWithData.GetDataTable(
                    @"select [id] ,[code],[name_ru],[name_en],[visible] from [Regions] where [cruise_line_id] is NULL and [Parent] is NULL order by name_ru");
            List<Region> res = new List<Region>();

            res.AddRange(from DataRow r in dt.Rows where r.Field<bool>("visible") == visible select new Region() { Code = r.Field<string>("code"), ID = r.Field<long>("id"), Name_en = (r["name_en"] == DBNull.Value ? string.Empty : r["name_en"].ToString()), Name_ru = (r["name_ru"] == DBNull.Value ? string.Empty : r["name_ru"].ToString()), Visible = r.Field<bool>("visible") });
            return res;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }


    public struct Region
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Name_ru { get; set; }
        public string Name_en { get; set; }
        public bool Visible { get; set; }
    }
}
