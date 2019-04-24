using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using CruiseSearchAdmin.Entities.SyncModel;

namespace CruiseSearchAdmin.Entities
{
    [DebuggerDisplay("ID = {ID},Text = {Text}")]
    public class Excursion : ISynchronizeble
    {
        
        public SyncRecord Synchronize(SyncBaseProccessor baseProccessor, SynchronyzeMethod sMethod)
        {
            switch (sMethod)
            {

                case SynchronyzeMethod.Insert:
                    return SynchronizeInserting(baseProccessor);
                case SynchronyzeMethod.Update:
                    SynchronizeUpdating(baseProccessor);
                    return null;
                default:
                    return null;
            }
        }

        private Synchronizer synchronizer;
        public int SyncItemType
        {
            get { return (int)SyncItemsTypeEnum.EXCURSION_SYNC_ID; }
        }
        public int? ID { get; set; }
        public string Text { get; set; }
        public bool ItemChecked { get; set; }
        public int? PortID { get; set; }
        public string PortName { get; set; }
        public int? DurationID { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public void RemoveSyncBinding(Synchronizer synchronizer)
        {
            SyncRecord sr = new SyncRecord(this.ID.GetValueOrDefault(), 0, this.SyncItemType, 0, synchronizer.SenderConnection.DataSource);
            synchronizer.RemoveSyncItem(sr);
        }

       
        public PartnerExcursionsList PartnerExcursions { get; private set; }
        public Excursion()
        {
            ID = null;
            Text = Duration = Description = string.Empty;
            PartnerExcursions = new PartnerExcursionsList(this);
        }

        public Excursion(Synchronizer sync)
            : this()
        {
            synchronizer = sync;
        }

        private SyncRecord SynchronizeInserting(SyncBaseProccessor baseProccessor)
        {
            var connection = baseProccessor.ToConnection;
            var destId = this.InsertExcursion(connection);
            if (destId == null || this.ID == null) return null;
            GetPartnerExcursions(baseProccessor.FromConnection);

            foreach (var partnerExcursion in PartnerExcursions)
            {
                partnerExcursion.ExUid = destId;
                int? peDestId = partnerExcursion.InsertPartnerExcursion(connection);
                if (peDestId == null) continue;
                partnerExcursion.GetFees(baseProccessor.FromConnection);
                partnerExcursion.GetDates(baseProccessor.FromConnection);
                partnerExcursion.Fees.PartnerExcursion.Uid = peDestId;
                partnerExcursion.Fees.InsertAll(connection);
                partnerExcursion.Dates.PartnerExcursion.Uid = peDestId;
                partnerExcursion.Dates.UpdateDates(connection);
            }
            return new SyncRecord(this.ID.Value, baseProccessor.ID, this.SyncItemType, destId.Value, baseProccessor.FromConnection.DataSource);
        }

        private void SynchronizeUpdating(SyncBaseProccessor baseProccessor)
        {
            SqlConnection destConnection = baseProccessor.ToConnection;
            SqlConnection senderConnection = baseProccessor.FromConnection;
            var excurs = new ExcursionsCollection();
            excurs.GetItems(destConnection);
            if (!excurs.Any<Excursion>()) return;
            Excursion excursion = excurs.First<Excursion>(e => e.ID == baseProccessor.GetUpdatingItemId(this.ID.Value, this.SyncItemType));

            excursion.GetPartnerExcursions(destConnection);
            excursion.PartnerExcursions.ForEach(p =>
                {
                    p.GetDates(destConnection);
                    p.GetFees(destConnection);
                });
            excursion.DeleteAllPartnerExcursions(destConnection);
            this.GetPartnerExcursions(senderConnection);
            {
                this.PartnerExcursions.ForEach(pe =>
                    {
                        pe.ExUid = excursion.ID;
                        int? peDestId = pe.InsertPartnerExcursion(destConnection);
                        pe.GetDates(senderConnection);
                        pe.GetFees(senderConnection);
                        pe.Fees.PartnerExcursion.Uid = peDestId;
                        pe.Fees.InsertAll(destConnection);
                        pe.Dates.PartnerExcursion.Uid = peDestId;
                        pe.Dates.UpdateDates(destConnection);
                    });
            }
            this.UpdateExcursionForId(destConnection, baseProccessor.GetUpdatingItemId(this.ID.Value, this.SyncItemType));
        }

        public int? InsertExcursion(SqlConnection connection)
        {
            using (
                 SqlCommand com =
                     new SqlCommand(
                         @"insert into [dbo].[mk_tbExcursions](EX_NAME,SEAPORT_ID,ED_ID,EX_DESCRIPTION) OUTPUT inserted.EX_UID values(@p0,@p1,@p2,@p3)", connection)
                 )
            {
                
                com.Parameters.AddWithValue("@p0", this.Text);
                com.Parameters.AddWithValue("@p1", this.PortID);
                com.Parameters.AddWithValue("@p2", this.DurationID ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@p3", this.Description);
                object retVal = com.ExecuteScalar();
                int? result = null;
                if (retVal != DBNull.Value)
                {
                    result = (Int32)retVal;
                }
                return result;
            }
        }

        public void UpdateExcursion(SqlConnection connection)
        {
            UpdateExcursionForId(connection, this.ID.Value);
        }

        private void UpdateExcursionForId(SqlConnection connection, int id)
        {
            const string updateExcursionQuery = @"update [dbo].[mk_tbExcursions] set EX_NAME=@p0,SEAPORT_ID=@p1,ED_ID=@p2,EX_DESCRIPTION=@p3 where EX_UID=@p4";
            updateExcursionQuery.ExecuteNonQuery(connection, this.Text, this.PortID, this.DurationID, this.Description, id);
        }

        public void DeleteExcursion(SqlConnection connection)
        {
            const string deleteExcursionQuery = @"delete from [dbo].[mk_tbExcursions] where [EX_UID] = @p0";
            deleteExcursionQuery.ExecuteNonQuery(connection, this.ID);
            RemoveSyncBinding(synchronizer);
        }

        public bool GetPartnerExcursions(SqlConnection connection)
        {
            return PartnerExcursions.GetPartnerExcursions(connection);
        }

        public void DeleteAllPartnerExcursions(SqlConnection connection)
        {
            PartnerExcursions.DeleteAll(connection);
        }
    }

}