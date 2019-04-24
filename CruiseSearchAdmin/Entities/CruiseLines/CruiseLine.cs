using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CruiseSearchAdmin.Entities.Ships;
using CruiseSearchAdmin.Entities.SyncModel;

namespace CruiseSearchAdmin.Entities.CruiseLines
{
    [Serializable]
    public class CruiseLine:IActiveRecord 
    {
        public int ID { get; set; }
        public string Currency { get; set; }
        public int Class { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public string Code { get; set; }
        public string Mnemo { get; set; }
        public string ClassName { get; set; }
        public bool Visible { get; set; }
        public string URL { get; set; }
        public ShipsCollection Ships {get; private set; }
        public CruiseLineSetting Settings { get; set; }
        public SqlConnection Connection {
            get { if (_connection.State != ConnectionState.Open)_connection.Open();
                return _connection;
            }
        }
        private SqlConnection _connection;
        public CruiseLine(int id,string nameEn,string code,string mnemo,string currency,int cls,SqlConnection connection)
        {
            ID = id;
            EnName = nameEn;
            Code = code;
            Mnemo = mnemo;
            Currency = currency.Trim();
            Class = cls;
            Ships = new ShipsCollection();
            _connection = connection;
            Ships.GetItemsForCruiseLine(id, connection);
            Settings = CruiseLineSetting.ReadSetingsFrom(this,WorkWithData.MasterConnection);
        }

        public CruiseLine(DataRow dr, SqlConnection connection)
            : this(dr.Field<byte>("id"), dr["name_en"].ToString(), dr["code"].ToString(), dr["mnemo"].ToString(),dr["currency"].ToString(), dr.Field<int>("class"), connection)
        {
            RuName = dr["name_ru"].ToString();
            Visible = dr.Field<bool>("visible");
            URL = dr["redirect"].ToString();
            ClassName = dr["classname"].ToString();
        }

        public void Insert()
        {
            string insertQuery =
                @"insert into CruiseLines(mnemo,code,name_ru,name_en,visible,redirect,class,currency) values(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
            insertQuery.ExecuteNonQuery(Connection,Mnemo,Code,RuName,EnName,Visible,URL,Class,Currency);
        }

        public void Update()
        {
            string updateQuery =
                @"update CruiseLines set mnemo=@p0,code=@p1,name_ru=@p2,name_en=@p3,visible=@p4,redirect=@p5,class=@p6,currency=@p7 where id=@p8";
            updateQuery.ExecuteNonQuery(Connection, Mnemo, Code, RuName, EnName, Visible, URL, Class, Currency,ID);
        }

        public void Delete()
        {
            string deleteQuery = @"delete from CruiseLines where id=@p0";
            deleteQuery.ExecuteNonQuery(Connection,ID);
        }

        internal void GetShips()
        {
            Ships.GetItemsForCruiseLine(ID, Connection);
        }
    }
}
