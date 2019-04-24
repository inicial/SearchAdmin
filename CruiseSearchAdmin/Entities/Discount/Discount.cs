using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Entities.Ships;
using CruiseSearchAdmin.Entities.SyncModel;

namespace CruiseSearchAdmin.Entities
{
    [DebuggerDisplay("ID = {ID},Text = {Text}")]
    public class Discount : ISynchronizeble
    {
        
        private Synchronizer _synchronizer;
        public SyncRecord Synchronize(SyncBaseProccessor baseProccessor, SynchronyzeMethod sMethod)
        {
            switch (sMethod)
            {
                case SynchronyzeMethod.Insert:
                    {
                        int? destId = InsertDiscount(baseProccessor.ToConnection);
                        if (destId == null) return null;
                        return new SyncRecord(this.ID.GetValueOrDefault(), baseProccessor.ID, this.SyncItemType, destId.Value, baseProccessor.FromConnection.DataSource);
                    }
                case SynchronyzeMethod.Update:
                    {
                        UpdateDiscountForId(baseProccessor.ToConnection,baseProccessor.GetUpdatingItemId(this.ID.Value,this.SyncItemType));
                        return null;
                    }
                default:
                    return null;
            }
        }

        public int SyncItemType
        {
            get { return (int)SyncItemsTypeEnum.DISCOUNT_SYNC_ID; }
        }
        public int? ID { get; set; }

        public string Text { get; set; }
        public void RemoveSyncBinding(Synchronizer synchronizer)
        {
            SyncRecord sr = new SyncRecord(this.ID.GetValueOrDefault(), 0, this.SyncItemType, 0, synchronizer.SenderConnection.DataSource);
            synchronizer.RemoveSyncItem(sr);
        }

        public bool ItemChecked { get; set; }
        //public int ID { get; set; }
        //public string Name { get; set; }
        public CruiseLine CruiseLine { get; set; }
        public Ship Ship { get; set; }
        public int? Type { get; set; }
        public int Value { get; set; }
        public string StrValue { get; private set; }
        public CabinCls CabinClass { get; set; }public Itinerary Itinerary { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? SaleDateBegin { get; set; }
        public DateTime? SaleDateEnd { get; set; }
        public CruiseAction Action { get; set; }
        public ItRegion Region { get; set; }
        public int? Priority { get; set; }

        public Discount()
        {
            ID = null;
        }

        public Discount(DataRow row,Synchronizer sync):this()
        {
            ID = row.Field<int>("RULE_ID");
            Text = row.Field<string>("RULE_NAME") ?? "Название не определено";
            if(row["CL_ID"]!=DBNull.Value)
            {
                this.CruiseLine = new CruiseLine(row.Field<byte>("CL_ID"), row["CL_NAME_EN"].ToString(), row["CL_MNEMO"].ToString(), row["CL_MNEMO"].ToString(), row["CL_CURRENCY"].ToString(), row.Field<int>("CL_CLASS"), WorkWithData.TsConnection);
            }
            if(row["S_ID"]!=DBNull.Value)
            {
                this.Ship = new Ship(row.Field<int>("S_ID"), row["S_NAME"].ToString(), row.Field<byte>("S_CLID"),
                                     row["S_CODE"].ToString(),null);
            }
            this.Type = row.Field<int?>("RULE_TYPE");
            this.Value = row.Field<int>("RULE_VALUE");
            StrValue = Value + "%";
            if(row["CC_ID"]!=DBNull.Value)
            {
                this.CabinClass = new CabinCls() { ID = row.Field<byte>("CC_ID"), Name = row["CC_NAME"].ToString() };
            }
            if(row["AI_ID"]!=DBNull.Value){
                this.Itinerary = new Itinerary(row.Field<int>("AI_ID"),row["AI_TEXT"].ToString());
            }
            this.DateBegin = row.Field<DateTime?>("RULE_DATE_BEGIN");
            this.DateEnd = row.Field<DateTime?>("RULE_DATE_END");
            this.SaleDateBegin = row.Field<DateTime?>("RULE_SALE_DATE_BEGIN");
            this.SaleDateEnd = row.Field<DateTime?>("RULE_SALE_DATE_END");
            if (row["ACT_ID"]!=DBNull.Value)
            {
                this.Action= new CruiseAction(row.Field<int>("ACT_ID"),row["ACT_TEXT"].ToString(),row["ACT_URL"].ToString(),row.Field<int>("ACT_VISIBLE"),row.Field<DateTime?>("ACT_DATE_BEG"),row.Field<DateTime?>("ACT_DATE_END"),row.Field<int?>("SORT_ORDER"),null);
            }
            if (row["R_ID"]!=DBNull.Value)
            {
                this.Region = new ItRegion(row.Field<long>("R_ID"),row["R_NAME"].ToString());
            }
            this.Priority = row.Field<int?>("RULE_PRIORITY");
            _synchronizer = sync;

        }
        public class CabinCls
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        public int? InsertDiscount(SqlConnection connection)
        {
            using (
                SqlCommand com =
                    new SqlCommand(
                        @"INSERT INTO Mk_rules_discont(Brancode,Ship_id,type,value,CabinClass,itenare,Date_begin,Date_end,Sale_date_begin,Sale_date_end,actionID,RegionID,Name,orderrules) values(@p0,@p1,null,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)",
                        connection))
            {
                com.Parameters.AddWithValue("@p0", CruiseLine != null ? CruiseLine.Mnemo ?? (object)DBNull.Value : DBNull.Value);
                com.Parameters.AddWithValue("@p1", Ship==null||Ship.ID == -1 ? (object) DBNull.Value : Ship.ID);
                com.Parameters.AddWithValue("@p2", Value);
                com.Parameters.AddWithValue("@p3", CabinClass==null||CabinClass.ID == -1 ? (object)DBNull.Value : CabinClass.ID);
                com.Parameters.AddWithValue("@p4", Itinerary==null||Itinerary.ID == -1 ? (object)DBNull.Value : Itinerary.ID);
                com.Parameters.AddWithValue("@p5", DateBegin ?? (object) DBNull.Value);
                com.Parameters.AddWithValue("@p6", DateEnd ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@p7", SaleDateBegin ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@p8", SaleDateEnd ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@p9", Action==null||Action.ID==-1? (object)DBNull.Value:Action.ID);
                com.Parameters.AddWithValue("@p10", Region==null||Region.ID == -1 ? (object) DBNull.Value : Region.ID);
                com.Parameters.AddWithValue("@p11", Text??(object)DBNull.Value);
                com.Parameters.AddWithValue("@p12", Priority ?? (object)DBNull.Value);
                com.ExecuteNonQuery();
                com.CommandText = @"SELECT IDENT_CURRENT('Mk_rules_discont')";
                int? retVal = null;
                object res = com.ExecuteScalar();
                if (res != DBNull.Value)
                {
                    retVal = Int32.Parse(res.ToString());
                }
                return retVal;
            }
        }

        public void UpdateDiscount(SqlConnection connection)
        {
           UpdateDiscountForId(connection,this.ID.Value);
        }

        private void UpdateDiscountForId(SqlConnection connection, int id)
        {
            string updateDiscountRuleQuery =
               @"UPDATE Mk_rules_discont SET Brancode = @brand,Ship_id=@shipId,value=@val,CabinClass=@ccId,itenare=@itiId,Date_begin=@db,Date_end=@de,Sale_date_begin=@sdb,Sale_date_end=@sde,actionID=@actId,RegionID=@regId,Name=@name,orderrules=@priority where id=@id";
            using (SqlCommand com = new SqlCommand(updateDiscountRuleQuery, connection))
            {
                com.Parameters.AddWithValue("@brand", this.CruiseLine == null ? null : this.CruiseLine.Mnemo);
                com.Parameters.AddWithValue("@shipId", this.Ship == null ? (object)DBNull.Value : this.Ship.ID);
                com.Parameters.AddWithValue("@val", this.Value);
                com.Parameters.AddWithValue("@ccId", this.CabinClass == null ? (object)DBNull.Value : this.CabinClass.ID);
                com.Parameters.AddWithValue("@itiId", this.Itinerary == null ? (object)DBNull.Value : this.Itinerary.ID);
                com.Parameters.AddWithValue("@db", this.DateBegin ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@de", this.DateEnd ?? (object) DBNull.Value);
                com.Parameters.AddWithValue("@sdb", this.SaleDateBegin ?? (object) DBNull.Value);
                com.Parameters.AddWithValue("@sde", this.SaleDateEnd ?? (object) DBNull.Value);
                com.Parameters.AddWithValue("@actId", this.Action == null ? (object)DBNull.Value : this.Action.ID ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@regId", this.Region == null ? (object)DBNull.Value : this.Region.ID);
                com.Parameters.AddWithValue("@name",this.Text ?? (object) DBNull.Value);
                com.Parameters.AddWithValue("@priority", this.Priority ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@id", id);
                com.ExecuteNonQuery();

            }
        }

        public void DeleteDicscount(SqlConnection connection)
        {
            string deleteRuleQuery = @"delete from Mk_rules_discont where id=@p0";
            deleteRuleQuery.ExecuteNonQuery(connection,this.ID);
            RemoveSyncBinding(_synchronizer);
        }
    }
    
}