using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin
{
    public partial class FormLogin : ProjectForm
    {
        
        private FormLogin()
        {
            InitializeComponent();
        }
        public static bool Login(string[] args)
        {

            if (args.Length > 1)
            {
                return WorkWithData.InitConnection(args);
            }

            using (var f = new FormLogin())
            {
                return f.ShowDialog() == DialogResult.OK;
            }
        }
       
        void InitConnection(string login,string pass)
        {
            if (!WorkWithData.InitConnection(new[] { login, pass }))
            {
                if (MessageBox.Show(
                    @"Не удалось установить подключение к базе, возможно введены неверные логин или пароль",
                    @"Ошибка подключения", MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error) == DialogResult.Cancel)
                {
                    DialogResult = DialogResult.Abort;
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        
        bool CheckError(Control cntrl)
        {
            if (cntrl.Text == String.Empty)
            {
                errProvider.SetError(cntrl, "Поле не может быть пустым");
                return true;
            }
            errProvider.Clear();
            return false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckError(tbLogin) || CheckError(tbPass))
                return;
            InitConnection(tbLogin.Text, tbPass.Text);
        }
        private void tbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbPass.Focus();
        }
        private void tbPass_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
                 btnOK_Click(sender,e);
        }
        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
