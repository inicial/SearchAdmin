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

namespace CruiseSearchAdmin.Forms.Excursions
{
    public partial class FormEditExcursion : ProjectForm
    {
        private string _name;
        private int _durationId;
        int?_seaportId;
        private int? _uId;
        private string _description, _durationName,_seaPortName;
        Dictionary<int,string> _excurDict = new Dictionary<int, string>(){{-1,"Нет"}};
        Dictionary<int, string> _feeDict = new Dictionary<int, string>() { { -1, "Нет" } };
        Dictionary<int, string> _transpDict = new Dictionary<int, string>() { { -1, "Нет" } };
        Dictionary<int, string> _durDict = new Dictionary<int, string>() { { -1, "Нет" } };
        private ExcursionsCollection _excursions;
        public FormEditExcursion()
        {
            InitializeComponent();
            GetData();
            
        }
        void GetData()
        {
            var dtExcursions = WorkWithData.GetDataTable(@"select [ED_KEY],[ED_NAME] from [ExcurDictionary]",WorkWithData.MasterConnection);
            FillDicrionary(_excurDict,dtExcursions);
            var dtFee =
                WorkWithData.GetDataTable(
                    @"SELECT [SL_KEY],[SL_NAME] FROM [ServiceList] where [sl_svkey] =3174 and [SL_CNKEY]=1111111",WorkWithData.MasterConnection);
            FillDicrionary(_feeDict, dtFee);
            var dtTransp = WorkWithData.GetDataTable(@"select [TR_KEY],[TR_NAME] from [Transport]",WorkWithData.MasterConnection);
            FillDicrionary(_transpDict, dtTransp);
            var dtDuration = WorkWithData.GetDataTable(@"select [ED_ID],[ED_TEXT] from [mk_tbExcursionDuration]", WorkWithData.TsConnection);
            FillDicrionary(_durDict, dtDuration);
        }
        static void FillDicrionary(Dictionary<int,string> dictionary,DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                dictionary.Add(row.Field<int>(0), row[1].ToString());
            }
        }

        void FillFields()
        {
            cbDuration.DataSource = new BindingSource(_durDict, null);
            cbDuration.DisplayMember = "Value";
            cbDuration.ValueMember = "Key";
            cbDuration.SelectedValue = _durationId;

            tbExName.Text = _name;
            tbDescription.Text = _description;
            tbSeaPort.Text = _seaPortName;
        }

        public static bool EditExcursion(Excursion excursion,ExcursionsCollection excursions)
        {
            using(var f = new FormEditExcursion())
            {
                f._uId = excursion.ID;
                f._name = excursion.Text;
               
                
                f._durationName = excursion.Duration;
                f._durationId = excursion.DurationID??-1;
                f._description = excursion.Description;
                f._seaPortName = excursion.PortName;
                f._seaportId = excursion.PortID;
                f._excursions = excursions;
                f.FillFields();
                if (f.ShowDialog() != DialogResult.OK) return false;
                excursion.Text = f._name;
                excursion.Duration = f._durationName;
                excursion.DurationID = f._durationId == -1 ? (int?)null : f._durationId;
                excursion.Description = f._description;
                excursion.PortName = f._seaPortName;
                excursion.PortID = f._seaportId;
                return true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(tbExName.Text.Equals(string.Empty))
            {
                Messages.Error("Название не может быть пустым");
                return;
            }
            _name = tbExName.Text;
            _durationId = cbDuration.Items.Count > 0 ? (int)cbDuration.SelectedValue : -1;
            _durationName = cbDuration.Items.Count > 0 ? cbDuration.Text:string.Empty;
            _description = tbDescription.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnChangePort_Click(object sender, EventArgs e)
        {
            Seaport port = FormSelectPort.SelectSeaPort();
            _seaportId = port.ID;
            _seaPortName = port.Name;
            tbSeaPort.Text = _seaPortName;
        }
    }
}
