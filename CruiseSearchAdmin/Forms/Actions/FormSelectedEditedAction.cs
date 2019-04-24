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

namespace CruiseSearchAdmin.Forms.Actions
{
    public partial class FormSelectedEditedActions : ProjectForm
    {
        private int _actionId = -1;
        public FormSelectedEditedActions(CruiseActionsCollection actions)
        {
            InitializeComponent();
            cbActions.DataSource = actions;
            cbActions.DisplayMember = "Text";
            cbActions.ValueMember = "ID";
            cbActions.SelectedIndex = 0;
            _actionId = (int) cbActions.SelectedValue;
            cbActions.SelectionChangeCommitted += (s, e) => { _actionId = (int) cbActions.SelectedValue; };
            btnOK.Click += (s, e) =>
                               {
                                   DialogResult = DialogResult.OK;
                                   Close();
                               };
            btnCancel.Click +=(s,e)=>  Close();
        }
        static public int GetDeletedBonus(CruiseActionsCollection actions)
        {
            if (actions.Count < 1) return -1;
            using (var f = new FormSelectedEditedActions(actions))
            {
                
                if (f.ShowDialog() == DialogResult.OK)
                    return f._actionId;
                return -1;
            }
        }

        
    }
}
