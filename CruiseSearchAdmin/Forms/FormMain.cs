using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Forms;
using CruiseSearchAdmin.Forms.Actions;
using CruiseSearchAdmin.Forms.CruiseLines;
using CruiseSearchAdmin.Forms.CruiseSearchSettings;
using CruiseSearchAdmin.Forms.DopPak;
using CruiseSearchAdmin.Forms.Excursions;
using CruiseSearchAdmin.Forms.HandCruises;
using CruiseSearchAdmin.Forms.Itinerary;
using CruiseSearchAdmin.Forms.Regions;
using CruiseSearchAdmin.Forms.SaleManagement;
using CruiseSearchAdmin.Forms.Security;
using CruiseSearchAdmin.Forms.Ships;
using CruiseSearchAdmin.Forms.Spec;
using CruiseSearchAdmin.Forms.SynchronizationForms;
using CruiseSearchAdmin.Forms.Visa;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin
{
    public partial class FormMain : ProjectForm
    {
        public FormMain()
        {
            InitializeComponent();
            AccessInitilizaton();
            EventInitialization();
        }

        private void AccessInitilizaton()
        {var ac = Program.AccessController;
            if (ac.IsAdmin()) return;
            btnPassEncryption.Visible = false;
            btnAccessManagement.Visible = false;
            btnBonuses.Enabled = ac.IsAccess(AccessRigt.ActionsEditAccess);
            btnEditCruises.Enabled = ac.IsAccess(AccessRigt.CruiseEditAccess);
            btnSpec.Enabled = ac.IsAccess(AccessRigt.DiscountEditAccess) ;
            btnSprc.Enabled = ac.IsAccess(AccessRigt.DiscountEditAccess);
            btnSaleManagement.Enabled = ac.IsAccess(AccessRigt.DiscountEditAccess);
            btnExcursions.Enabled = ac.IsAccess(AccessRigt.ExcursionsEditAccess);
            btnSeaPorts.Enabled = ac.IsAccess(AccessRigt.PortsEditAccess);
            btnRegeons.Enabled = ac.IsAccess(AccessRigt.PortsEditAccess);
            btnVisaMenagement.Enabled = ac.IsAccess(AccessRigt.VisaEditAccess);
            btnCruiseLines.Enabled = ac.IsAccess(AccessRigt.ShipsEditAccess);
            btnCruiseSearchSettings.Enabled = ac.IsAccess(AccessRigt.CruiseSearchSettingsAccess);
            btnSyncActions.Enabled = ac.IsAccess(AccessRigt.SyncAccess)&&ac.IsAccess(AccessRigt.ActionsEditAccess);
            btnSyncDiscount.Enabled = ac.IsAccess(AccessRigt.SyncAccess) && ac.IsAccess(AccessRigt.DiscountEditAccess);
            btnSyncExcursions.Enabled = ac.IsAccess(AccessRigt.SyncAccess) && ac.IsAccess(AccessRigt.ExcursionsEditAccess); 
            

        }

        void EventInitialization()
        {
            btnExit.Click += (s, e) => Close();
            //btnSpec.Click += (s, e) =>
            //{
            //    this.Hide();
            //    FormHandCruisesCashe form = new FormHandCruisesCashe();
            //    form.ShowDialog();
            //    this.Show();
            //};
            btnEditCruises.Click += (s, e) =>
            {
                this.Hide();
                FormEditCruises.EditCruises();
                this.Show();
            };
            btnSeaPorts.Click += (s, e) =>
            {
                this.Hide();
                FormSeaPorts.EditSeaPorts();
                this.Show();
            };
            btnBonuses.Click += (s, e) =>
            {
                this.Hide();
                FormActionsMultiAdd.SetActionsSettings();
                this.Show();
            };
            btnExcursions.Click += (s, e) =>
            {
                this.Hide();
                FormExcursions.GetExcursions();
                this.Show();
            };
            btnSaleManagement.Click += (s, e) =>
            {
                this.Hide();
                FormSaleManagement.SaleManagement();
                this.Show();
            };
            btnCruiseLines.Click += (s, e) =>
            {
                this.Hide();
                FormCruiseLines.EditCruiseLines(WorkWithData.TsConnection);
                this.Show();
            };
            btnPassEncryption.Click += (s, e) =>
            {
                 this.Hide();
                 FormEncrypt.ShowEncryptWindow();
                 this.Show();
            };
            btnAccessManagement.Click += (s, e) =>
            {
                this.Hide();
                FormEditUsersAccessRights.EditAccessRights(); 
                this.Show();
            };
            btnVisaMenagement.Click += (s, e) =>
                {
                    this.Hide();
                    FormVisaInfo.ShowVisasInfo();
                    this.Show();
                };
            btnRegeons.Click += (s, e) =>
                {
                    this.Hide();
                    FormRedactorRegeon RegRedactor =new FormRedactorRegeon();
                    RegRedactor.ShowDialog();
                    this.Show();
                };
            btnCruiseSearchSettings.Click += (s, e) =>
            {
                this.Hide();
                FormCruiseSearchSettings.EditCruseSearchSettings(WorkWithData.MasterConnection);
                this.Show();
            };
        }private void FormMain_Load(object sender, EventArgs e)
        {
#if !DEBUG
            this.Text += " ver("+Application.ProductVersion+")";
#else
            this.Text += " ver(DEBUG)";
#endif
        }

        private void btnSyncActions_Click(object sender, EventArgs e)
        {
            Synchronization.PrepareSynchronization(new CruiseActionsCollection());
        }

        private void btnSyncExcursions_Click(object sender, EventArgs e)
        {
            Synchronization.PrepareSynchronization(new ExcursionsCollection());
        }

        private void btnSyncDiscount_Click(object sender, EventArgs e)
        {
            Synchronization.PrepareSynchronization(new DiscountCollection());
        }

        private void btnRegeons_Click(object sender, EventArgs e)
        {
       
        }

        private void btnSpec_Click(object sender, EventArgs e)
        {
            FormPakMultyAdd multypakAdd = new FormPakMultyAdd();
            multypakAdd.ShowDialog();
        }

        private void btnSprc_Click(object sender, EventArgs e)
        {
            FormHandCruisesCashe formHandCruises = new FormHandCruisesCashe();
            formHandCruises.ShowDialog();
        }


     
        

    }
}
