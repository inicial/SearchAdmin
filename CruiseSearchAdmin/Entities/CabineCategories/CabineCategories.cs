using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;

namespace CruiseSearchAdmin.Entities.CabineCategories
{
    public class CabineCategories:IActiveRecord
    {
        public int ID { get; set; }
        public int ship_id { get; set; }
        public string nameShip { set; get; }
        public string code { get; set; }
        public string name_ru { get; set; }
        public string name_en { get; set; }
        public string description { get; set; }
        public string in_out { get; set; }
        public bool visable { get; set; }
        public int class_id { get; set; }
        public string classname { get; set; }
        public int maxpax { get; set; }


        public CabineCategories(int id,int id_ship,string Code,string Name_ru,string Name_en,string Description,string In_out,bool Visable,int Class_id,int Maxpax,SqlConnection Connection)
        {
            ID = id;
            ship_id = id_ship;
            code = Code;
            name_ru = Name_ru;
            name_en = Name_en;
            description = Description;
            in_out = In_out;
            visable = Visable;
            class_id = Class_id;
            maxpax = Maxpax;
            _connection = Connection;

        }


        public CabineCategories(SqlConnection Connection)
        {
            _connection = Connection;
        }

        public CabineCategories(DataRow cabinRow,SqlConnection Connection):
            this(cabinRow.Field<short>("id"), cabinRow.Field<int>("ship_id"), cabinRow["code"].ToString(), cabinRow["name_ru"].ToString(), cabinRow["name_en"].ToString(),cabinRow["description"].ToString(),cabinRow["in_out"].ToString(),cabinRow.Field<bool>("visible"),cabinRow.Field<byte>("class_id"),cabinRow.Field<int>("maxpax"),Connection)
        {
            nameShip = cabinRow["nameship"].ToString();
            classname = cabinRow["cabinclass"].ToString();

        }
        public SqlConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open) _connection.Open();
                return _connection;
            }
        }

        private SqlConnection _connection;

        public void Insert()
        {
            string insertQuery =
                @"insert into CabinCategories(ship_id,code,name_ru,name_en,description,in_out,visible,class_id,maxpax) values(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
            insertQuery.ExecuteNonQuery(Connection,ship_id,code,name_ru,name_en,description,in_out,visable,class_id,maxpax);
        }

        public void Update()
        {
            string updateQuery =
                @"update CabinCategories set ship_id=@p0,code=@p1,name_ru=@p2,name_en=@p3,description=@p4,in_out=@p5,visible=@p6,class_id=@p7,maxpax=@p8 where id=@p9";
            updateQuery.ExecuteNonQuery(Connection, ship_id, code, name_ru, name_en, description, in_out, visable, class_id, maxpax,ID);
        }

        public void Delete()
        {
            string deleteQuery = @"delete from CabinCategories where id=@p0";
            deleteQuery.ExecuteNonQuery(Connection, ID);
        }
    }
}
