using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CruiseSearchAdmin.HelperClasses;
using DxHelpersLib;

namespace CruiseSearchAdmin.Entities.SyncModel
{
    public class Synchronizer
    {
        private SyncBaseProccessor[] _syncProccessors;
        public SyncBaseProccessor[] SyncProccessors { get { return _syncProccessors; } }
        private SqlConnection _senderConnection;
        public SqlConnection SenderConnection { get { return _senderConnection; } }
        public SynchronizebleItemCollection SyncItems { get; private set; }
        public Synchronizer(SynchronizebleItemCollection items,SqlConnection senderCon)
        {
            if (items != null)
                SyncItems = items;
            _senderConnection = senderCon;
            GetSyncBases();
            
        }
        private int GetSyncBases()
        {
            var syncBasesTable = WorkWithData.GetDataTable(@"select * from mk_tbSyncBases",_senderConnection);
            _syncProccessors = new SyncBaseProccessor[syncBasesTable.Rows.Count];
            for (int i = 0; i < syncBasesTable.Rows.Count; i++)
            {
                DataRow sbr = syncBasesTable.Rows[i];
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(_senderConnection.ConnectionString);
                sb.DataSource = sbr["SB_IP"].ToString();
                try
                {
                    sb.Password = SecurityHelper.GetSuperUserPassword;
                    sb.UserID = "sa";
                }
                catch
                {
                    if(Program.AccessController.IsAccess(AccessRigt.SyncAccess))
                    Messages.Information(
                        "Подключение sa не удалось, некоторые возможности синхронизации могут работать не корректно");

                }
                SqlConnection reciverConnection = new SqlConnection(sb.ConnectionString);
                _syncProccessors[i] = new SyncBaseProccessor(sbr.Field<int>("SB_UID"), sbr["SB_NAME"].ToString(), _senderConnection, reciverConnection);
            }
            return _syncProccessors.Length;
        }

        public bool SelectBaseProccessors(){
            if (_syncProccessors == null || _syncProccessors.Length < 1) return false;
                foreach (SyncBaseProccessor syncProccessor in _syncProccessors.Where(sp=>sp.IsEnable))
                {
                    syncProccessor.TryAddSyncItems(SyncItems);
                }
            return true;
        }
        public bool Syncronize()
        {
            if (_syncProccessors == null) return false;
            foreach (SyncBaseProccessor syncBaseProccessor in _syncProccessors.Where(sp => sp.IsEnable))
            {
                syncBaseProccessor.PerformSynchronization();
            }
            return true;
        }

        public void RemoveSyncItem(SyncRecord sRecord)
        {
            sRecord.DeleteSyncRecord(_senderConnection, true);
            foreach (var syncBaseProccessor in _syncProccessors)
            {
                sRecord.DeleteSyncRecord(syncBaseProccessor.ToConnection,false);
            }
        }

     }
}