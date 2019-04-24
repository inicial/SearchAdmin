using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Forms.Excursions.EditPartner;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.Excursions
{
    public partial class FormEditPartnerExcursion : ProjectForm
    {
        private PartnerExcursion _partnerExcursion;
        private PartnerExcursionsList _partnerExcursions;
        private ExcursionsCollection _excursions;
        Dictionary<string, string> _cruiseLines = new Dictionary<string, string>() {{ "-1", "Нет" }};
        //Dictionary<int, string> _transport = new Dictionary<int, string>() { { -1, "Нет" } };
        KeyValuePair<int,string> _partner = new KeyValuePair<int, string>(-1,string.Empty);
        KeyValuePair<int,string> _seaPort = new KeyValuePair<int, string>(-1,string.Empty);
        public FormEditPartnerExcursion()
        {
            InitializeComponent();
        }

        static public bool EditPartnerExcursion(PartnerExcursion partnerExcursion,ExcursionsCollection excursions,PartnerExcursionsList partnerExcursions)
        {
            using(var f = new FormEditPartnerExcursion())
            {
                f._partnerExcursion = partnerExcursion;
                f._excursions = excursions;
                f._partnerExcursions = partnerExcursions;
                f._partner = new KeyValuePair<int, string>(partnerExcursion.PartnerKey??-1, partnerExcursion.PartnerName);
                if (f.ShowDialog() != DialogResult.OK) return false;
                return true;
            }
        }

        void GetData()
        {
            var dtCruseLines = WorkWithData.GetDataTable(@"SELECT mnemo,name_en FROM cruiselines ORDER BY name_en");
            foreach (DataRow row in dtCruseLines.Rows)
            {
                _cruiseLines.Add(row["mnemo"].ToString(),row["name_en"].ToString());
            }
            //var dtTransport = WorkWithData.GetDataTable(@"SELECT TR_KEY,TR_NAME FROM lanta.dbo.transport");
            //foreach (DataRow row in dtTransport.Rows)
            //{
            //    _transport.Add(row.Field<int>(0),row[1].ToString());
            //}
        }

        private void FormEditPartnerExcursion_Load(object sender, EventArgs e)
        {
            var ex = _excursions.Find<Excursion>(x => x.ID == _partnerExcursion.ExUid);
            _seaPort = new KeyValuePair<int, string>(ex.PortID??-1,ex.PortName);
            tbPort.Text = _seaPort.Value;
            ChangeSeaPort(_seaPort.Key);
            //cbExcursions.SelectedValue = _partnerExcursion.ExUid;
            GetData();
            cbCruiseLine.DataSource = new BindingSource(_cruiseLines,null);
            //cbTransport.DataSource = new BindingSource(_transport, null);
            cbCruiseLine.ValueMember = "Key";
            cbCruiseLine.DisplayMember = "Value";
            if (_partner.Key != -1)
                tbPartner.Text = _partner.Value;
            cbExcursions.SelectedValue = _partnerExcursion.ExUid??-1;
            cbCruiseLine.SelectedValue = string.IsNullOrEmpty(_partnerExcursion.ClMnemo) ? "-1" : _partnerExcursion.ClMnemo;
            //cbTransport.SelectedValue = _partnerExcursion.TransportId??-1;
        }

        private void btnChangePort_Click(object sender, EventArgs e)
        {
            var sPort = FormSelectPort.SelectSeaPort();
            if(sPort==null)return;
            _seaPort = new KeyValuePair<int, string>(sPort.ID,sPort.Name);
            tbPort.Text = _seaPort.Value;
            ChangeSeaPort(_seaPort.Key);
        }
        void ChangeSeaPort(int? seaPortId)
        {
            cbExcursions.DataSource = _excursions.Where((Excursion ex) => ex.PortID == seaPortId).ToList();
            cbExcursions.ValueMember = "ID";
            cbExcursions.DisplayMember = "Text";}

        private void btnChangePartner_Click(object sender, EventArgs e)
        {
            int prKey;
            string prName;
            if (!FormSelectPartner.SelectPartner(out prKey, out prName))return;
            _partner = new KeyValuePair<int, string>(prKey,prName);
            tbPartner.Text = _partner.Value;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            _partnerExcursion.ExUid = (int) cbExcursions.SelectedValue;
            _partnerExcursion.ExName = cbExcursions.Name;
            if(_partnerExcursions.Count(pe => pe.ExUid==_partnerExcursion.ExUid&&pe.PartnerKey==_partner.Key&&(pe.Uid!=_partnerExcursion.Uid||_partnerExcursion.Uid==null))>0)
            {
                Messages.Error("В одной экскурсии не может быть 2-х одинаковых партнеров!");
                return;
            }
            if(_partner.Key==-1)
            {
                Messages.Error("Сначала следует выбрать партнера");
                return;
            }
            _partnerExcursion.PartnerKey = _partner.Key;
            _partnerExcursion.PartnerName = _partner.Value;
            _partnerExcursion.ClMnemo = cbCruiseLine.SelectedValue.ToString().Equals("-1") ? null : cbCruiseLine.SelectedValue.ToString();
            _partnerExcursion.ClName = cbCruiseLine.SelectedValue.ToString().Equals("-1")?null:cbCruiseLine.Text;
            if (!_hasService)
            {
                int cityId;
                int countryId;
                if (!FormSelectCity.SelectCity(out countryId, out cityId)) return;
                FormEditPartnerExcursionsFee.SetExcursionsFee(_partnerExcursion,countryId,cityId);
            }
            // _partnerExcursion.TransportId = (int)cbTransport.SelectedValue == -1 ? (int?)null : (int)cbTransport.SelectedValue;
           // _partnerExcursion.TransportName = (int)cbTransport.SelectedValue == -1 ?null:cbTransport.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool _hasService;
        private void btnServices_Click(object sender, EventArgs e)
        {
            int cityId;
            int countryId;
            if (!FormSelectCity.SelectCity(out countryId,out cityId)) return;
            FormEditPartnerExcursionsFee.SetExcursionsFee(_partnerExcursion,countryId,cityId);
            _hasService = true;
        }}
}
