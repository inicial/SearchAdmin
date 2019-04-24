using System;
using System.Data;
using System.Data.SqlClient;

namespace CruiseSearchAdmin.Entities
{
    public class PartnerExcursion
    {
        public int? Uid { get; set; }
        public int? ExUid { get; set; }
        public string ExName { get; set; }
        public int? PartnerKey { get; set; }
        public string PartnerName { get; set; }
        public string ClMnemo { get; set; }
        public string ClName { get; set; }
        public PartnerExcursionFeesList Fees { get; private set; }
        public PartnerExcursionDatesList Dates { get; private set; }
       public PartnerExcursion()
       {
           Uid = null;
           Fees = new PartnerExcursionFeesList(this);
           Dates = new PartnerExcursionDatesList(this);
       }

        public PartnerExcursion(DataRow row):this()
        {
            Uid = row.Field<int?>("PE_UID");
            ExUid = row.Field<int?>("EX_UID");
            ExName = row["EX_NAME"].ToString();
            ClMnemo = row["CL_MNEMO"].ToString();
            ClName = row["CL_NAME"].ToString();
            PartnerKey = row.Field<int?>("PR_KEY");
            //PartnerName = row["PR_NAME"].ToString();
            
        }

        public void UpdatePartnerExcursion(SqlConnection connection)
        {
            const string updatePartnerExcursions =
                @"UPDATE mk_tbPartnerExcursions SET EX_UID=@p0,PE_PRKEY=@p1,CL_MNEMO=@p2 WHERE PE_UID=@p3";
            updatePartnerExcursions.ExecuteNonQuery(connection,this.ExUid, this.PartnerKey, this.ClMnemo, this.Uid);
        }

        public void DeletePartnerExcursion(SqlConnection connection)
        {
            const string deletePartnerExcursionsQuery = @"delete from mk_tbPartnerExcursions where PE_UID=@p0";
            GetFees(connection);
            Fees.DeleteAll(connection);
            GetDates(connection);
            Dates.DeleteAll(connection);
            deletePartnerExcursionsQuery.ExecuteNonQuery(connection,this.Uid);
        }

        public int? InsertPartnerExcursion(SqlConnection connection)
        {
            using (
                SqlCommand com =
                    new SqlCommand(@"INSERT INTO mk_tbPartnerExcursions(EX_UID,PE_PRKEY,CL_MNEMO) VALUES(@p0,@p1,@p2)",
                                   connection))
            {
                com.Parameters.AddWithValue("@p0",this.ExUid);
                com.Parameters.AddWithValue("@p1",this.PartnerKey??(object)DBNull.Value);
                com.Parameters.AddWithValue("@p2",this.ClMnemo??(object)DBNull.Value);
                com.ExecuteNonQuery();
                com.CommandText = @"SELECT IDENT_CURRENT('mk_tbPartnerExcursions')";
                int? retVal = null;
                object res = com.ExecuteScalar();
                if (res != DBNull.Value)
                {
                    retVal = Int32.Parse(res.ToString());
                }
                return retVal;

            }
        }

        public bool GetFees(SqlConnection connection)
        {
            return Fees.GetFees(connection);
        }

        public bool GetDates(SqlConnection connection)
        {
            return Dates.GetDates(connection);
        }

        public bool UpdateDates(SqlConnection connection)
        {
           return Dates.UpdateDates(connection);
        }
    }

}