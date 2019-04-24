using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;

namespace CruiseSearchAdmin.Forms.Spec
{
    public partial class FormRooms : ProjectForm
    {
        private DataTable _rooms;
        public FormRooms(DataTable rooms)
        {
            InitializeComponent();
            _rooms = rooms;
            dgvRooms.DataSource = _rooms;
            updateDataGrid();
        }

        void updateDataGrid()
        {
            foreach (DataGridViewColumn column in dgvRooms.Columns)
            {
                switch (column.Name.ToLower())
                {
                    case  "roomcategory":
                    {
                        column.HeaderText = "Категория каюты";
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    }
                        break;
                    default:
                    {
                        column.Visible = false;
                    }
                        break;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in _rooms.Rows)
            {
                row["selected"] = false;
            }
            Close();
        }

        private void dgvRooms_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow selroom = ((DataGridView)sender).Rows[e.RowIndex];
            if (selroom == null) return;
            selroom.Cells["selected"].Value
                = !(Convert.ToBoolean(selroom.Cells["selected"].Value));
            dgvRooms.InvalidateRow(e.RowIndex);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvRooms_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow selCruise = ((DataGridView)sender).Rows[e.RowIndex];
            if (selCruise == null) return;
            if (Convert.ToBoolean(selCruise.Cells["selected"].Value))
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            }
            else
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Silver;
            }
        }
    }
}
