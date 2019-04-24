using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CruiseSearchAdmin.Entities
{
    public class PartnerExcursionDatesList : List<DateTime>
    {
        public PartnerExcursion PartnerExcursion { get; private set; }
        public PartnerExcursionDatesList(PartnerExcursion partnerExcursion)
        {
            PartnerExcursion = partnerExcursion;
        }

        public bool GetDates(SqlConnection connection)
        {
            this.Clear();
            this.AddRange((from DataRow dr in WorkWithData.GetDataTable(@"select ED_DATE from mk_tbPartnerExcursionDates where PE_UID = " + PartnerExcursion.Uid, connection).Rows select dr.Field<DateTime>(0)).ToList());
            return true;
        }

        public bool UpdateDates(SqlConnection connection)
        {
            SqlTransaction tran = connection.BeginTransaction();
            try
            {
                using (SqlCommand com = new SqlCommand(@"delete from mk_tbPartnerExcursionDates where PE_UID = @uid", connection, tran))
                {
                    com.Parameters.AddWithValue("@uid", PartnerExcursion.Uid);
                    com.ExecuteNonQuery();
                }
                foreach (var date in this)
                {
                    using (SqlCommand com = new SqlCommand(@"insert into mk_tbPartnerExcursionDates(PE_UID,ED_DATE) values(@uid,@date)", connection, tran))
                    {
                        com.Parameters.AddWithValue("@uid", PartnerExcursion.Uid);
                        com.Parameters.AddWithValue("@date", date);
                        com.ExecuteNonQuery();
                    }
                }
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
        }

        public void DeleteAll(SqlConnection connection)
        {
            using (SqlCommand com = new SqlCommand(@"delete from mk_tbPartnerExcursionDates where PE_UID = @uid", connection))
            {
                com.Parameters.AddWithValue("@uid", PartnerExcursion.Uid);
                com.ExecuteNonQuery();
            }
        }

        public new void Remove(DateTime dateTime)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if((this[i].Date == dateTime.Date)&&(this[i].Hour==dateTime.Hour)&&(this[i].Minute==dateTime.Minute))
                    base.Remove(this[i]);
            }
        }
    }
}