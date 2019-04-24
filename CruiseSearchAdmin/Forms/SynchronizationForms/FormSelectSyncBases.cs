using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities.SyncModel;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.SynchronizationForms
{
    public partial class FormSelectSyncBases : ProjectForm
    {
        private SyncBaseProccessor[] _syncBaseProccessors;
        private FormSelectSyncBases()
        {
            InitializeComponent();
        }

        public static bool SelectSyncBases(SyncBaseProccessor[] syncBaseProccessors)
        {
            using (var f = new FormSelectSyncBases())
            {
                f._syncBaseProccessors = syncBaseProccessors;
                return f.ShowDialog() == DialogResult.OK;
            }
        }

        private void FormSelectSyncBases_Load(object sender, EventArgs e)
        {
            chlbSyncBases.DataSource = _syncBaseProccessors;
            chlbSyncBases.DisplayMember = "Name";
            for (int i = 0; i < chlbSyncBases.Items.Count; i++)
            {
                var item = chlbSyncBases.Items[i] as SyncBaseProccessor;
                chlbSyncBases.SetItemChecked(i,item.IsEnable);
            }
        }

        private void chlbSyncBases_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = ((CheckedListBox)sender).Items[e.Index] as SyncBaseProccessor;
            if (item == null) return;
            item.IsEnable = e.NewValue == CheckState.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
