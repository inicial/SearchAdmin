using System.Data;
using System;
using System.Data.SqlClient;

namespace CruiseSearchAdmin.Entities
{
    public class PartnerExcursionFee: ICloneable
    {
        public int ID { get; private set; }
        public int PEId { get; set; }
        public int ExcursionTypeId { get; set; }
        public int? AdultId { get; set; }
        public int? ChildId { get; set; }
        public int? TransportId { get; set; }
        public int? AdultFee { get; set; }
        public int? ChildFee { get; set; }
        public PartnerExcursionFee(int peid)
        {
            ID = -1;
            PEId = peid;
            ExcursionTypeId = 1;
        }
        
        public PartnerExcursionFee(DataRow row)
        {
            ID = row.Field<int>("PEF_ID");
            PEId = row.Field<int>("PE_UID");
            ExcursionTypeId = row.Field<int>("ET_UID");
            AdultId = row.Field<int?>("PEF_ADULT_ID");
            ChildId = row.Field<int?>("PEF_CHILD_ID");
            TransportId = row.Field<int?>("PEF_TRANSPORT");
            AdultFee = row.Field<int?>("PEF_ADULT_FEE");
            ChildFee = row.Field<int?>("PEF_CHILD_FEE");
        }

        public void InsertToBase(SqlConnection connection)
        {
            InsertToBaseForPeId(connection, PEId);
        }

        public void InsertToBaseForPeId(SqlConnection connection, int? id)
        {
            if(id==null)return;
            string insertQuery = @"insert into mk_tbPartnerExcursionsFee(PE_UID,ET_UID,PEF_ADULT_FEE,PEF_CHILD_FEE,PEF_ADULT_ID,PEF_CHILD_ID,PEF_TRANSPORT) values(@p0,@p1,@p2,@p3,@p4,@p5,@p6)";
            insertQuery.ExecuteNonQuery(connection, id, ExcursionTypeId, AdultFee, ChildFee, AdultId, ChildId, TransportId);
        
        }

        public void UpdateInBase(SqlConnection connection)
        {
            string updateQueryString =
                @"update mk_tbPartnerExcursionsFee set ET_UID=@p0,PEF_ADULT_FEE=@p1,PEF_CHILD_FEE=@p2,PEF_ADULT_ID=@p3,PEF_CHILD_ID=@p4,PEF_TRANSPORT=@p5 where PEF_ID=@p6";
            updateQueryString.ExecuteNonQuery(connection,ExcursionTypeId, AdultFee, ChildFee, AdultId, ChildId, TransportId, ID);
        }
        public void DeleteFromBase(SqlConnection connection)
        {
            string deleteQueryString = @"delete from mk_tbPartnerExcursionsFee where PEF_ID=@p0";
            deleteQueryString.ExecuteNonQuery(connection,ID);
        }

        public object Clone()
        {
            return new PartnerExcursionFee(PEId){ID = -1,AdultFee = this.AdultFee,AdultId = this.AdultId,ChildFee = this.ChildFee,ChildId = this.ChildId,ExcursionTypeId = this.ExcursionTypeId,TransportId = this.TransportId};
        }
    }
}