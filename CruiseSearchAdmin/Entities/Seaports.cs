using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DxHelpersLib;

namespace CruiseSearchAdmin.Entities
{
    [Serializable]
    public class Seaport
    {
        public int ID { get; set; }
        public string Code { get { return code; } set { ItemState = EditState.Update; code = value; } }
        public string Name { get { return name; } set { ItemState = EditState.Update; name = value; } }
        public string Name_ru { get { return name_ru; } set { ItemState = EditState.Update; name_ru = value; } }
        public int? ParentID { get { return parentId; } set { ItemState = EditState.Update; parentId = value; } }
        public int? CruiseLineID { get { return cruiseLineId; } set { ItemState = EditState.Update; cruiseLineId = value; } }
        public int? RegionID { get { return regionId; } set { ItemState = EditState.Update; regionId = value; } }
        public string CruiseLineName { get { return cruiseLineName; } set { ItemState = EditState.Update; cruiseLineName = value; } }
        internal EditState ItemState { get; private set; }

        private string code;
        private string name;
        private string name_ru;
        private int? parentId;
        private int? cruiseLineId;
        private string cruiseLineName;
        private int? regionId;

        private readonly string oldCode;
        private readonly string oldName;
        private readonly string oldName_ru;
        private readonly int? oldParentId;
        private readonly int? oldCcruiseLineId;
        private readonly string oldCruiseLineName;
        private readonly int? oldRegionId;

        public Seaport(DataRow dr)
        {
            ID = Convert.ToInt32(dr["id"]);
            code = oldCode = dr["code"].ToString();
            name = oldName = dr["name_en"].ToString();
            name_ru = oldName_ru = dr["name_ru"].ToString();
            if (dr["parent"] == DBNull.Value)
                parentId=oldParentId = null;
            else parentId = oldParentId = Convert.ToInt32(dr["parent"]);
            if (dr["id_crline"] == DBNull.Value)
                cruiseLineId = oldCcruiseLineId = null;
            else cruiseLineId = oldCcruiseLineId = Convert.ToInt32(dr["id_crline"]);
            if (dr["id_region"] == DBNull.Value)
                regionId = oldRegionId = null;
            else regionId = oldRegionId = Convert.ToInt32(dr["id_region"]);
            cruiseLineName = oldCruiseLineName = dr["crl_name"] == DBNull.Value ? null : dr["crl_name"].ToString();
            
            ItemState = EditState.None;
        }
        public Seaport(string p_code,string p_name,string p_name_ru,int? p_parentid,int? p_cruiselineid,int? p_regionid,string p_cruiselinename)
        {
            code = oldCode = p_code;
            name = oldName = p_name;
            name_ru = oldName_ru = p_name_ru;
            parentId = oldParentId = p_parentid;
            cruiseLineId = oldCcruiseLineId = p_cruiselineid;
            regionId = oldRegionId = p_regionid;
            cruiseLineName = oldCruiseLineName = p_cruiselinename;
            ItemState = EditState.Insert;
        }
        public void ResetChanges()
        {
            code = oldCode;
            name = oldName;
            name_ru = oldName_ru;
            parentId = oldParentId;
            cruiseLineId = oldCcruiseLineId;
            cruiseLineName = oldCruiseLineName;
            regionId = oldRegionId;
            ItemState = EditState.None;
        }

        public bool Update(SqlConnection con)
        {
            if(ItemState==EditState.None) return true;
            string command = string.Empty;
            if (ItemState == EditState.Insert)
                command =
                        @"insert into seaports(code,name_en,name_ru,visible,parent,id_crline,id_region) values(@code,@name,@name_ru,1,@parent,@crline,@region)";
            if(ItemState == EditState.Update)
                command=
                        @"update seaports set code=@code,name_en=@name,name_ru=@name_ru,parent=@parent,id_crline=@crline,id_region=@region where id=@id";
            using (SqlCommand com = new SqlCommand(command,con))
            {
               if(ItemState == EditState.Update || ItemState ==EditState.Insert )
                    {
                        com.Parameters.AddWithValue("@code", code);
                        com.Parameters.AddWithValue("@name", name);
                        com.Parameters.AddWithValue("@name_ru", name_ru);
                        com.Parameters.AddWithValue("@parent", parentId==null?DBNull.Value:(object)parentId);
                        com.Parameters.AddWithValue("@crline", cruiseLineId==null?DBNull.Value:(object)cruiseLineId);
                        com.Parameters.AddWithValue("@region", regionId==null?DBNull.Value:(object)regionId);
                    }
               if (ItemState == EditState.Update)
                    {
                        com.Parameters.AddWithValue("@id", ID);
                    }
               com.ExecuteNonQuery();
               ItemState = EditState.None;
            }
            return true;
        }
       

        
        public bool  Delete(SqlConnection con)
        {
            ItemState = EditState.Delete;
            string command = @"update seaports set parent=null where parent=@parent";
            using (SqlTransaction transact = con.BeginTransaction())
            {
                try
                {
                    using (SqlCommand com = new SqlCommand(command, con))
                    {

                        com.Transaction = transact;
                        com.Parameters.AddWithValue("@parent", ID);
                        com.ExecuteNonQuery();

                    }
                    command = @"delete from seaports where id=@id";
                    using (SqlCommand com = new SqlCommand(command, con))
                    {

                        com.Transaction = transact;
                        com.Parameters.AddWithValue("@id", ID);
                        com.ExecuteNonQuery();

                    }
                    transact.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transact.Rollback();
                    Messages.Error("Удаление прервано возникла ошибка" + ex.Message);
                    return false;
                }
            }

        }
    }
    enum EditState
    {None,Insert,Delete,Update}
}
