using System;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms
{
    public partial class FormSetName : ProjectForm
    {
       
        private FormSetName()
        {
            InitializeComponent();
            tbName.TextChanged += (s, e) => { if (tbName.Text == string.Empty) epBonus.SetError(tbName, "Поле не заполнено"); else epBonus.Clear(); };
            tbName.KeyPress += (s, e) => { if (e.KeyChar == Convert.ToChar(13)) btnOK_Click(btnOK,e); };
        }
        void btnOK_Click(object sender, EventArgs e)
        {
            if (tbName.Text != string.Empty)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                if (Messages.Question("Название не может быть пустым, выйти без сохранения?")) 
                    this.Close();
            }
        }

        static public bool GetName(ref string s)
        {
            using (var f = new FormSetName())
            {
                f.tbName.Text = s ?? string.Empty;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    s = f.tbName.Text;
                    return true;
                }
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); 
        }
       
    }
}
