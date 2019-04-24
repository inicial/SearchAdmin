//#define TEST
using System;
using System.Diagnostics;
using System.Windows.Forms;
using CruiseSearchAdmin.Forms.Excursions.EditPartner;
using CruiseSearchAdmin.Forms.HandCruises;
using CruiseSearchAdmin.Forms.Visa;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin
{
    static class Program
    {
        public static AccessController AccessController;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(!FormLogin.Login(args)) Environment.Exit(0);
            AccessController = new AccessController(WorkWithData.TsConnection);
            try
            {
                Debug.WriteLine(WorkWithData.TsConnection.ConnectionString);
                Debug.WriteLine(WorkWithData.MasterConnection.ConnectionString);
#if !TEST
                Application.Run(new FormMain());
                
#else
                //FormVisaInfo.ShowVisasInfo();
                
               if (WorkWithData.InitConnection(args))
               {
                   FormEditHandCruise frm = new FormEditHandCruise();
                   frm.Show();
               }
                #endif
            }catch (Exception exception)
            {
                Messages.Error(string.Format("Ошибка в работе приложения\nMessage:{0}",exception.ToString()));
            }
        }
    }
}
