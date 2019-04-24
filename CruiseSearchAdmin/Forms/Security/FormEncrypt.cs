using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.HelperClasses;
using CruiseSearchAdmin.EncriptionService;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms
{
    public partial class FormEncrypt : ProjectForm
    {
        public FormEncrypt()
        {
            InitializeComponent();
        }

        public static void ShowEncryptWindow()
        {
            using (var f = new FormEncrypt())
            {
                f.ShowDialog();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EncryptionServiceSoap encryptionService = new EncryptionServiceSoapClient();
            if (tbPass.Text == string.Empty)
                return;
            var t = tbPass.Text;
            string encryptedString = string.Empty;
            WaitForm.WaitInBackground("Генерация пароля", false,
                                      () => encryptedString = encryptionService.EncryptString(t));
            tbEncryptedPass.Text = encryptedString;
        }
    }
}
