using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace CruiseSearchAdmin.Entities.Ships
{
    [Serializable]
    [DebuggerDisplay("ID = {ID},Name = {Name}")]
    public class Ship:IActiveRecord
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CruiseLineID { get; set; }
        public string Code { get; set; }
        public bool Visible { get; set; }
        public string CruiseLineName { get; set; }
        private SqlConnection _connection;
        public Ship(int id, string n, int crlid, string code,SqlConnection connection) : this(id, n, crlid, code, true,connection){}

        public Ship(int id, string n, int crlid, string code, bool visible,SqlConnection connection)
        {
            ID = id;
            Name = n;
            CruiseLineID = crlid;
            Code = code;
            Visible = visible;
            _connection = connection;
        }
        public Ship(DataRow dr,SqlConnection connection):this(dr.Field<int>("id"),dr["name_en"].ToString(),dr.Field<byte>("cruise_line_id"),dr["code"].ToString(),dr.Field<bool>("visible"),connection)
        {
        }

        public void Insert()
        {
            using (SqlCommand com = new SqlCommand(@"INSERT INTO ships(cruise_line_id,ship_class_id,code,name_ru,name_en,visible) VALUES(@cli,null,@code,@name,@name,@vis)", _connection))
            {
                com.Parameters.AddWithValue("@cli", this.CruiseLineID);
                com.Parameters.AddWithValue("@code", this.Code);
                com.Parameters.AddWithValue("@name", this.Name);
                com.Parameters.AddWithValue("@vis", this.Visible);
                com.Parameters.AddWithValue("@sid", this.ID);
                com.ExecuteNonQuery();
            }
        }

        public void Update()
        {
            using (
                SqlCommand com =
                    new SqlCommand(
                        @"UPDATE ships SET cruise_line_id=@cli,code=@code,name_en=@ne,name_ru=@ne,visible=@vis WHERE id=@sid",
                        _connection))
            {
                com.Parameters.AddWithValue("@cli", this.CruiseLineID);
                com.Parameters.AddWithValue("@code", this.Code);
                com.Parameters.AddWithValue("@ne", this.Name);
                com.Parameters.AddWithValue("@vis", this.Visible);
                com.Parameters.AddWithValue("@sid", this.ID);
                com.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            string deleteQuery = @"delete from ships where id = @p0";
            deleteQuery.ExecuteNonQuery(_connection,ID);
        }

    }
}
