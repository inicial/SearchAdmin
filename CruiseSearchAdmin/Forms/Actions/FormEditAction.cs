using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Forms;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin
{
    public partial class FormEditAction : ProjectForm
    {
        private int _visibility = int.MinValue;
        public FormEditAction()
        {
            InitializeComponent();
            tbText.Select();
            dtpActBeg.Value = dtpActEnd.Value = DateTime.Now;
        }
        public static bool EditAction(ref string text, ref string url, ref int visiblity, ref DateTime? beginPeriod, ref DateTime? endPeriod)
        {
            using(var f= new FormEditAction())
            {
                return f.GetParams(ref text, ref url, ref visiblity, ref beginPeriod, ref endPeriod);
            }
        }
        bool GetParams(ref string text,ref string url,ref int visibility,ref DateTime? beginPeriod,ref DateTime? endPeriod)
        {
            tbText.Text = text;
            tbUrl.Text = url;
            _visibility = visibility;
            if (beginPeriod == null || endPeriod == null)
            {
                chbIsUnlim.Checked = true;
            }
            else
            {
                dtpActBeg.Value = beginPeriod.Value.Date;
                dtpActEnd.Value = endPeriod.Value.Date;
            }
            var res = ShowDialog() == DialogResult.OK;
                text = tbText.Text;
                url = tbUrl.Text;
            visibility = _visibility;
            if(chbIsUnlim.Checked)
            {
                beginPeriod = endPeriod = null;
            }
            else
            {
                beginPeriod = dtpActBeg.Value.Date;
                endPeriod = dtpActEnd.Value.Date;
            }
            return res;
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSetVisMask_Click(object sender, EventArgs e)
        {
            _visibility = FormVisibleType.GetVisibleMask(_visibility);
        }

        private void chbIsUnlim_CheckedChanged(object sender, EventArgs e)
        {
            dtpActBeg.Enabled = dtpActEnd.Enabled = !chbIsUnlim.Checked;
        }
        void dtpValueChanged(object sender, EventArgs e)
        {
            if (dtpActBeg.Value > dtpActEnd.Value) dtpActEnd.Value = dtpActBeg.Value;
        }

        private void FormEditAction_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnOK_Click(sender,e);
        }
    }
}
