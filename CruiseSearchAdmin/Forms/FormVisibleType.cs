using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms
{
    public partial class FormVisibleType : ProjectForm
    {
        private int _visibleMask;
        private int _itemVisMask;
        private FormVisibleType()
        {
            InitializeComponent();
            GetVisTypes();
        }

        void GetVisTypes()
        {
            var dt = WorkWithData.GetDataTable(@"select  VT_TEXT, VT_MASK from mk_tbVisibleTypes order by VT_TEXT");
            clbVisibleTypes.DataSource = dt;
            clbVisibleTypes.DisplayMember = "VT_TEXT";
            clbVisibleTypes.ValueMember =  "VT_MASK";
        }

        public static int GetVisibleMask(int mask)
        {
            using(var f = new FormVisibleType())
            {
                f._itemVisMask = mask;
                for (int i = 0; i < f.clbVisibleTypes.Items.Count; i++)
                {
                    DataRow item = ((DataRowView)f.clbVisibleTypes.Items[i]).Row;
                    if ((item.Field<int>("VT_MASK") & f._itemVisMask) != 0) f.clbVisibleTypes.SetItemChecked(i, true);
                }
                if (f.ShowDialog() == DialogResult.OK)
                    return f._visibleMask;
                return mask;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            foreach (DataRowView selectedItem in clbVisibleTypes.CheckedItems)
            {
                _visibleMask |= selectedItem.Row.Field<int>("VT_MASK");
            }
            Close();
        }

        private void FormVisibleType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(sender, e);
        }
    }
}
