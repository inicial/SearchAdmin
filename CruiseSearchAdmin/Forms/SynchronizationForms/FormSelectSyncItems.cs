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
    public partial class FormSelectSyncItems : ProjectForm
    {
        private IEnumerable<CbItem> _cbItems; 
        public FormSelectSyncItems()
        {
            InitializeComponent();

        }

        public static bool SelectsyncItems(SynchronizebleItemCollection synchronizebleItems)
        {
            using (var f = new FormSelectSyncItems())
            {
                f._cbItems = synchronizebleItems.Select(c=>new CbItem(c));
                f.cblItems.DataSource = f._cbItems.ToList();
                f.cblItems.DisplayMember = "Name";
                return f.ShowDialog() == DialogResult.OK;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private class CbItem
        {
            private ISynchronizeble item;
            public string Name { get { return item.Text; } }
            public bool Checked { get { return item.ItemChecked; } set { item.ItemChecked = value; } }
            public CbItem(ISynchronizeble sItem)
            {
                item = sItem;
            }
        }

        private void cblItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var clb = (CheckedListBox) sender;
            var item = clb.Items[e.Index] as CbItem;
            if (item == null) return;
            item.Checked = e.NewValue == CheckState.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSelectSyncItems_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < cblItems.Items.Count; i++)
            {
                var item = cblItems.Items[i] as CbItem;
                cblItems.SetItemChecked(i, item.Checked);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            CheckedForItems(true);
        }

        private void CheckedForItems(bool check)
        {
            for (int i = 0; i < cblItems.Items.Count; i++)
            {
                cblItems.SetItemChecked(i,check);
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cblItems.Items.Count; i++)
            {
                if (cblItems.GetItemChecked(i))
                cblItems.SetItemChecked(i, false);
                else cblItems.SetItemChecked(i, true);
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            CheckedForItems(false);
        }

    }
}
