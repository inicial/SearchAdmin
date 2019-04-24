using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CruiseSearchAdmin.HelperClasses
{
    public class ProjectForm: Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
           
            foreach (Control control in Controls)
            {
                FindChildDgvControl(control);
            }
        }
        void FindChildDgvControl(Control control)
        {
            var ctrl = control as DataGridView;
            if(ctrl!=null)
            {
                ctrl.AllowUserToAddRows = ctrl.AllowUserToDeleteRows = ctrl.AllowUserToResizeRows = false;
                ctrl.DefaultCellStyle.ForeColor = Color.Black;
                ctrl.DefaultCellStyle.SelectionBackColor = Color.Silver;
                ctrl.DefaultCellStyle.SelectionForeColor = Color.Black;
                ctrl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ctrl.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else
            foreach (Control c in control.Controls)
            {
                FindChildDgvControl(c);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            this.SuspendLayout();
            // 
            // ProjectForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectForm";
            this.ResumeLayout(false);

        }
    }
}
