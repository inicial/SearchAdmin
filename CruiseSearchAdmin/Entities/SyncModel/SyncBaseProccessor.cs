using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CruiseSearchAdmin.Entities.SyncModel
{
    public class SyncBaseProccessor
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public bool IsEnable { get; set; }
        public SynchronizebleItemCollection SyncInsItems { get { return _syncInsItems; } }
        public SynchronizebleItemCollection SyncUpdItems { get { return _syncUpdItems; } }
        private readonly SqlConnection _senderConnection;
        private readonly SqlConnection _reciverConnection;
        private  SynchronizebleItemCollection _syncInsItems;
        private  SynchronizebleItemCollection _syncUpdItems;
        private List<SyncData> _syncData;
        public List<SyncData> SyncDataItems
        {
            get
            {
                if (_syncData == null)
                {
                    _syncData = new List<SyncData>();
                    var dt = WorkWithData.GetDataTable(string.Format(@"select * from mk_tbSyncItems where SI_DATABASE = {0}", ID),FromConnection);//Check SyncRecords in connected base
                    _syncData.AddRange(from DataRow r in dt.Rows select new SyncData(r.Field<int>("SI_ID"), r.Field<int>("SI_TYPE"), true, r.Field<int>("SI_DESTID")));
                    dt = WorkWithData.GetDataTable(string.Format(@"select * from mk_tbSyncItems join mk_tbSyncBases on SI_DATABASE=SB_UID where SB_IP like '{0}'",FromConnection.DataSource),ToConnection);//Chech SyncRecords in target base
                    _syncData.AddRange(from DataRow r in dt.Rows select new SyncData(r.Field<int>("SI_DESTID"), r.Field<int>("SI_TYPE"), false, r.Field<int>("SI_ID")));
                }
                return _syncData;}
        }

        public  SqlConnection FromConnection { get { if (_senderConnection.State != ConnectionState.Open) _senderConnection.Open();return _senderConnection; } }
        public SqlConnection ToConnection { get { if (_reciverConnection.State != ConnectionState.Open) _reciverConnection.Open(); return _reciverConnection; } }
        
        public SyncBaseProccessor(int id,string name,SqlConnection senderCon,SqlConnection reciverCon)
        {
            _senderConnection = senderCon;
            _reciverConnection = reciverCon;
            ID = id;
            Name = name;
            IsEnable = true;
        }
        
        public bool TryAddSyncItems(SynchronizebleItemCollection syncItems)
        {
            _syncInsItems = syncItems.CreateCollectionFromInstance();
            _syncUpdItems = syncItems.CreateCollectionFromInstance();
            foreach (ISynchronizeble item in syncItems)
            {
                if(!item.ItemChecked)continue;
                var sd = SyncDataItems.Where(s => s.Id == item.ID && s.Type == item.SyncItemType);
                if (!sd.Any())
                {
                    _syncInsItems.Add(item);
                }
                else 
                {
                    _syncUpdItems.Add(item);
                }
            }
            if (!_syncInsItems.Any() && !_syncUpdItems.Any()) return false;
            return true;
        }

        public void ResetSyncData()
        {
            _syncData = null;
        }

        public bool PerformSynchronization()
        {
            var res = PerformForInsert() && PerformFoUpdate();
            _syncData = null;
            return res;
        }
        private bool PerformForInsert()
        {
            if (SyncInsItems == null) return false;
            foreach (ISynchronizeble syncItem in SyncInsItems)
            {
                var syncRecord = syncItem.Synchronize(this, SynchronyzeMethod.Insert);
                if (syncRecord == null) continue;
                syncRecord.InsertSyncRecord(FromConnection);
            }
            return true;
        }
        private bool PerformFoUpdate()
        {
            if (SyncUpdItems == null) return false;
            foreach (ISynchronizeble syncItem in SyncUpdItems)
            {
                syncItem.Synchronize(this, SynchronyzeMethod.Update);
            }
            return true;
        }

        public int GetUpdatingItemId(int senderId,int senderType)//Get item ID from reciver data base
        {
            var sd = SyncDataItems.Where(si => si.Id == senderId && si.Type == senderType);
            _syncData = null;
            if(sd==null)throw new NullReferenceException("Не удалось получить данные по синхронизации");
            if (!sd.Any())
                throw new ArgumentException(string.Format("Объект с идентификатором {0} типа {1} не существует", senderId,
                                                          senderType));
            
            return sd.First().DestId;
        }

        public struct SyncData
        {
            public readonly int Id;
            public readonly int Type;
            public bool IsSenderBaseItem;
            public int DestId;
            public SyncData(int id,int type,bool isSender,int destId)
            {
                Id = id;
                Type = type;
                IsSenderBaseItem = isSender;
                DestId = destId;
            }
        }
    }
}