using System.Data;
using System.Data.SqlClient;

namespace CruiseSearchAdmin.Entities.CruiseLines
{
    public class CruiseLineSetting:IActiveRecord
    {
        private SqlConnection _connection;
        public CruiseLine CruiseLine { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public float Comision { get; set; }
        public CruiseLineSetting(CruiseLine cruiseLine,SqlConnection connection)
        {
            CruiseLine = cruiseLine;
            _connection = connection;
        }
        public CruiseLineSetting(CruiseLine cruiseLine, DataRow row,SqlConnection connection):this(cruiseLine,connection)
        {
            CityId = row.Field<int>("CLS_CTKEY");
            CityName = row["CT_NAME"].ToString();
            PartnerId = row.Field<int>("CLS_PRKEY");
            PartnerName = row["PR_FULLNAME"].ToString();
            Comision = row.Field<float>("CLS_COMISS");
            _connection = connection;
        }

        public static CruiseLineSetting ReadSetingsFrom(CruiseLine cruiseLine,SqlConnection connection)
        {
            var dt = WorkWithData.GetDataTable(@"select CLS_CTKEY,CT_NAME, CLS_PRKEY,PR_FULLNAME,CLS_COMISS from mk_CruiseLinesSettings as cls 
				left join CityDictionary as cd on cls.CLS_CTKEY=cd.CT_KEY
				left join tbl_Partners as prt on prt.PR_KEY=CLS_PRKEY
				where CLS_CLID=" + cruiseLine.ID,
                                               WorkWithData.MasterConnection);
            if (dt.Rows.Count < 1) return null;
            return new CruiseLineSetting(cruiseLine,dt.Rows[0],connection);
        }

        public void Update()
        {
            string queryUpdate = @"update mk_CruiseLinesSettings set CLS_CTKEY = @p0,CLS_PRKEY=@p1,CLS_COMISS=@p2 where CLS_CLID=@p3";
            queryUpdate.ExecuteNonQuery(_connection,CityId,PartnerId,Comision,CruiseLine.ID);
        }

        public void Delete()
        {
            string deleteQuery = @"delete from mk_CruiseLinesSettings where CLS_CLID=@p0";
            deleteQuery.ExecuteNonQuery(_connection,CruiseLine.ID);
        }

        public void Insert()
        {
            string insertQuery = @"insert into mk_CruiseLinesSettings(CLS_CLID,CLS_CTKEY,CLS_PRKEY,CLS_Comiss) values(@p0,@p1,@p2,@p3)";
            insertQuery.ExecuteNonQuery(_connection,CruiseLine.ID,CityId,PartnerId,Comision);
        }
    }
}