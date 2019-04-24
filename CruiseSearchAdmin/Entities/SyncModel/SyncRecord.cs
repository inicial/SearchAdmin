using System;
using System.Data.SqlClient;

namespace CruiseSearchAdmin.Entities.SyncModel
{
    public class SyncRecord
    {
        public int Id { get; private set; }
        public int BaseId { get; private set; }
        public int ItemType { get; private set; }
        public int DestinationId { get; private set; }
        private string _baseIp;
        public SyncRecord(int id, int bId, int itemType, int destId,string ip)
        {
            Id = id;
            BaseId = bId;
            ItemType = itemType;
            DestinationId = destId;
            _baseIp = ip;
        }

        public void InsertSyncRecord(SqlConnection connection)
        {
            const string syncRecordInsertString = @"insert into mk_tbSyncItems values(@p0,@p1,@p2,@p3)";
            syncRecordInsertString.ExecuteNonQuery(connection, this.Id, this.ItemType, this.BaseId, this.DestinationId);
        }

        public void DeleteSyncRecord(SqlConnection connection, bool ownBase)
        {
            if (ownBase)
            {
                const string syncRecordDeleteString =
                    @"delete from mk_tbSyncItems where SI_ID = @p0 and SI_TYPE = @p1";
                syncRecordDeleteString.ExecuteNonQuery(connection, this.Id, this.ItemType);
            }
            else
            {
                const string syncRecordDeleteString =
                    @"delete from mk_tbSyncItems where SI_DESTID = @p0 and SI_TYPE = @p1 and SI_DATABASE in (select SB_UID from mk_tbSyncBases where SB_IP like @p2)";
                syncRecordDeleteString.ExecuteNonQuery(connection, this.Id, this.ItemType,this._baseIp);
            }
        }
    }
}