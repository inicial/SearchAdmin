using System.Data;
using System.Data.SqlClient;
using CruiseSearchAdmin.Entities;

namespace CruiseSearchAdmin.Forms.CruiseSearchSettings
{
    public class CruiseSearchSetting:IActiveRecord
    {
        private readonly SqlConnection _connection;
        public int ID { get; private set; }
        public string ParamName { get; set; }
        public int Value { get; set; }
        public string SqlQuery { get; set; }

        public CruiseSearchSetting(string pName,int value,SqlConnection connection)
        {
            _connection = connection;
            ParamName = pName;
            Value = value;
        }

        public CruiseSearchSetting(DataRow row,SqlConnection connection):this(row["CSS_PARAMNAME"].ToString(),row.Field<int>("CSS_VALUE"),connection)
        {
            ID = row.Field<int>("CSS_Key");
            SqlQuery = row["CSS_Query"].ToString();
        }


        public void Insert()
        {
            string insertQuery = @"insert into mk_CruiseSearchSettings values(@p0,@p1,@p2)";
            insertQuery.ExecuteNonQuery(_connection,ParamName,Value,SqlQuery);
        }

        public void Update()
        {
            string updateQuery =
                @"update mk_CruiseSearchSettings set CSS_PARAMNAME=@p0,CSS_VALUE=@p1,CSS_QUERY=@p2 where CSS_Key=@p3";
            updateQuery.ExecuteNonQuery(_connection,ParamName,Value,SqlQuery,ID);
        }

        public void Delete()
        {
            string deleteQuery = @"delete from mk_CruiseSearchSettings where CSS_Key = @p0";
            deleteQuery.ExecuteNonQuery(_connection,ID);
        }
    }
}