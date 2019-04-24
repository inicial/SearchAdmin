using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.SyncModel;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Forms.SynchronizationForms
{
    public class Synchronization
    {
        private SqlConnection _sqlConnection;
        private Synchronizer _syncronizer;
        private SynchronizebleItemCollection syncItems { get; set; }

        public static void PrepareSynchronization(SynchronizebleItemCollection collection)
        {
            Synchronization sync = new Synchronization();
            bool res = sync.SetConnection(WorkWithData.TsConnection) && sync.GetSyncData(collection) && sync.Perform();
            if (!res) Messages.Information("Синхронизация отменена");
        }

        public bool SetConnection(SqlConnection connection)
        {
            if (!Messages.Question("Выбрать другую базу для синхронизации?"))
            {
                SetSenderBase(connection);
                return true;
            }
            return ChangeSenderBase(connection);

        }
        private bool ChangeSenderBase(SqlConnection connection)
        {
            string dataSource = FormSelectSenderBase.GetDataSourceString(connection);
            if (dataSource == null) return false;
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connection.ConnectionString)
                {
                    DataSource = dataSource
                };
             try
             {
                 sb.Password = SecurityHelper.GetSuperUserPassword;
                 sb.UserID = "sa";
             }
            catch
            {
                if (
                    !Messages.Question(
                        "Подключение sa не удалось, синхронизация будет проводиться от вашего пользователя, продолжить?"))
                    return false;
            }
            _sqlConnection = new SqlConnection(sb.ConnectionString);
            return true;
        }
        private void SetSenderBase(SqlConnection connection)
        {
            _sqlConnection = connection;
        }
        public bool GetSyncData(SynchronizebleItemCollection syncCollection)
        {
            syncItems = syncCollection;
            if (_sqlConnection == null) throw new NullReferenceException("Не задано подключение, следует вызвать ChangeSenderBase или SetSenderBase");
            if(_sqlConnection.State!=ConnectionState.Open)_sqlConnection.Open();
            return syncItems.GetItems(_sqlConnection)&&FormSelectSyncItems.SelectsyncItems(syncItems)&&CreateSynchronizer()&&SelectSyncBases();
        }
        private bool CreateSynchronizer()
        {
            if (syncItems == null) throw new NullReferenceException("Не заданы объекты для синхронизации, следует задать объекты для синхронизации");
            if (syncItems.Count<1) return false;
            _syncronizer = new Synchronizer(syncItems,_sqlConnection);
            return true;
        }
        private bool SelectSyncBases()
        {
            if(_syncronizer==null)throw new NullReferenceException("Не удалось создать Syncronizer");
            if(!FormSelectSyncBases.SelectSyncBases(_syncronizer.SyncProccessors))return false;
            _syncronizer.SelectBaseProccessors();
            return true;
        }
        public bool Perform()
        {
            bool syncResult = true;
            WaitForm.WaitInBackground("Идет синхронизация", false, () => { syncResult = _syncronizer.Syncronize(); });
            if (!syncResult) { Messages.Error("Ошибка во время синхронизации");
                return false;
            }
            Messages.Information("Синхронизация прошла успешно");
           return true;
        }

    }
}