using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CruiseSearchAdmin.Entities.SyncModel;

namespace CruiseSearchAdmin.Entities
{
    [Serializable]
    [DebuggerDisplay("ID = {ID},Text = {Text},Id_group={id_group}")]
    public class CruiseAction:ISynchronizeble
    {
        
        public int? ID { get; set; }
        public string Text { get; set; }
        public int SyncItemType
        {
            get { return (int)SyncItemsTypeEnum.CRUISE_ACTION_SYNC_ID; }
        }
        public bool ItemChecked { get; set; }
        public string Url { get; set; }
        public int? SortOrder { get; set; }
        private Synchronizer Synchronizer { get; set; }
        public string Group { get; set; }
        public int Id_group { get; set; }
        public CheckActionState ChekState
        {
            get { return _checkState; }
            set
            {
                if (Text[Text.Length - 1] != '*') Text += "*"; else Text = Text.Remove(Text.Length - 1);
                _checkState = value;
            }
        }
        private CheckActionState _checkState =CheckActionState.None;
        public bool Checked { get; set; }
        public int Visiblity { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }

        private CruiseAction(int id, string group, int id_group, string text, int visiblity, DateTime? dBeg, DateTime? dEnd, int? sortOrder)
        {
            ID = id;
            Text = text;
            Visiblity = visiblity;
            DateBegin = dBeg;
            DateEnd = dEnd;
            SortOrder = sortOrder;
            Group = group;
            Id_group = id_group;
        }

        private CruiseAction(int id, string text,int visiblity,DateTime? dBeg,DateTime? dEnd,int? sortOrder)
        {
            ID = id;
            Text = text;
            Visiblity = visiblity;
            DateBegin = dBeg;
            DateEnd = dEnd;
            SortOrder = sortOrder;
        }
        public CruiseAction(int id, string text, string url, int visiblity, DateTime? dBeg, DateTime? dEnd, int? sortOrder,Synchronizer sync)
            : this(id, text, visiblity, dBeg, dEnd, sortOrder,sync)
        {
            Url = url;
        }

        public CruiseAction(int id, string text, int visiblity, DateTime? dBeg, DateTime? dEnd, int? sortOrder,
                            Synchronizer sync)
            : this(id, text, visiblity, dBeg, dEnd, sortOrder)
        {
            Synchronizer = sync;
        }
        
        public CruiseAction(int id, string group, int id_group,string text, int visiblity, DateTime? dBeg, DateTime? dEnd, int? sortOrder, Synchronizer sync)
            : this(id, text, visiblity, dBeg, dEnd, sortOrder)
        {
            Synchronizer = sync;
            Group = group;
            Id_group = id_group;
        }
        [Obsolete("Use CruiseActionsCollection method GetItems")]
        public static IEnumerable<CruiseAction> GetActions(SqlConnection con)
        {
            var synchronizer = new Synchronizer(null,con);
            var dt = WorkWithData.GetDataTable(@"select * from Actions order by action_text",con);
            return (from DataRow dataRow in dt.Rows let id = Convert.ToInt32(dataRow["action_id"]) let text = dataRow["action_text"].ToString() let url = dataRow["action_URL"] != DBNull.Value ? dataRow["action_URL"].ToString() : string.Empty let v = Convert.ToInt32(dataRow["action_visible_type"]) let dbeg = dataRow.Field<DateTime?>("action_date_beg") let dend = dataRow.Field<DateTime?>("action_date_end") let sortOrder = dataRow.Field<int?>("sort_order") select new CruiseAction(id, text, url, v, dbeg, dend, sortOrder, synchronizer)).ToList();
        }

        public override string ToString()
        {
            return Text;
        }

        public SyncRecord Synchronize(SyncBaseProccessor baseProccessor, SynchronyzeMethod sMethod)
        {
            switch (sMethod)
            {
                    case SynchronyzeMethod.Insert:
                    {
                        int? destId = InsertActionToBase(baseProccessor.ToConnection);
                        if (destId == null) return null;
                        return new SyncRecord(this.ID.GetValueOrDefault(), baseProccessor.ID, this.SyncItemType, destId.Value, baseProccessor.FromConnection.DataSource);
                    }
                    
                    case SynchronyzeMethod.Update:
                    {
                        var newId = baseProccessor.GetUpdatingItemId(this.ID.GetValueOrDefault(), this.SyncItemType);
                        UpdateActionForId(baseProccessor.ToConnection,newId);
                        DeleteCruiseActions(newId,baseProccessor.ToConnection);
                        var cruiseActions =
                            WorkWithData.GetDataTable(@"select * from CruiseActions where actionId=" + this.ID,
                                                      baseProccessor.FromConnection);
                        foreach (DataRow row in cruiseActions.Rows)
                        {
                            row["actionId"] = newId;
                            string insertCruiseActionsQuery = @"insert into CruiseActions values(@p0,@p1,@p2)";
                            insertCruiseActionsQuery.ExecuteNonQuery(baseProccessor.ToConnection,row[0],row[1],row[2]);
                        }      
                        return null;
                    }
                   
                default:
                    return null;
            }
           
        }

        private void DeleteCruiseActions(int id,SqlConnection con)
        {
            string deleteCruiseActionsQuery = @"delete from CruiseActions where actionId = @p0";
            deleteCruiseActionsQuery.ExecuteNonQuery(con,id);
        }

        public int? InsertActionToBase(SqlConnection con)
        {
            using (SqlCommand com = new SqlCommand(@"insert into Actions (action_text,action_URL,action_visible_type,action_date_beg,action_date_end,sort_order) OUTPUT inserted.action_id values(@text,@url,@visible,@datebeg,@dateend,@sortOrder)", con))
            {
                com.Parameters.AddWithValue("@text", Text);
                var url = Url;
                int v = Visiblity;
                object dateb, datee;
                if (DateBegin == null || DateEnd == null)
                {
                    datee = dateb = DBNull.Value;
                }
                else
                {
                    dateb = DateBegin;
                    datee = DateEnd;
                }
                com.Parameters.AddWithValue("@url", url??(object)DBNull.Value);
                com.Parameters.AddWithValue("@visible", v);
                com.Parameters.AddWithValue("@datebeg", DateBegin ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@dateend", DateEnd ?? (object)DBNull.Value);
                com.Parameters.AddWithValue("@sortOrder", SortOrder ?? (object)DBNull.Value);
                object returnedValue = com.ExecuteScalar();
                int? result = null;
                if(returnedValue!=DBNull.Value)
                {
                    result = (Int32)returnedValue;
                }
                return result;
            }

        }
        public void DeleteActionFromBase(SqlConnection con)
        {
            using (SqlCommand com = new SqlCommand(@"delete from Actions where action_id=@id", con))
            {
                com.Parameters.AddWithValue("@id", this.ID);
                com.ExecuteNonQuery();
            }
            RemoveSyncBinding(Synchronizer);
        }
        public void UpdateAction(SqlConnection con)
        {
            UpdateActionForId(con, ID.GetValueOrDefault());
        }

        private void UpdateActionForId(SqlConnection con, int id)
        {
            using (SqlCommand com = new SqlCommand(@"UPDATE Actions SET action_text=@text,action_url=@url,action_visible_type=@act,action_date_beg=@dbeg,action_date_end=@dend where action_id=@id", con))
            {
                com.Parameters.AddWithValue("@text", Text);
                com.Parameters.AddWithValue("@url", Url);
                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@act", Visiblity);
                object dbeg, dend;
                if (DateBegin == null || DateEnd == null)
                {
                    dbeg = dend = DBNull.Value;
                }
                else
                {
                    dbeg = DateBegin;
                    dend = DateEnd;
                }
                com.Parameters.AddWithValue("@dbeg", dbeg);
                com.Parameters.AddWithValue("@dend", dend);
                com.ExecuteNonQuery();
            }
        }

        public void RemoveSyncBinding(Synchronizer synchronizer)
        {
            SyncRecord sr = new SyncRecord(this.ID.GetValueOrDefault(),0,this.SyncItemType,0,synchronizer.SenderConnection.DataSource);
            synchronizer.RemoveSyncItem(sr);
        }

        
    }
    [Serializable]
    public enum CheckActionState
    {
        None, Insert, Delete,Lock
    }

}
