using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Entities.SyncModel;

namespace CruiseSearchAdmin.Entities
{
    
    public class CruiseActionsCollection : SynchronizebleItemCollection,IEnumerable<CruiseAction>

    {
        public override bool GetItems(SqlConnection connection)
        {
            this.Clear();
            var synchronizer = new Synchronizer(null, connection);
            var dt = WorkWithData.GetDataTable(@"select * from Actions order by action_text", connection);
            var items = (from DataRow dataRow in dt.Rows 
                         let id = Convert.ToInt32(dataRow["action_id"]) 
                         let text = dataRow["action_text"].ToString() 
                         let url = dataRow["action_URL"] != DBNull.Value ? dataRow["action_URL"].ToString() : string.Empty 
                         let v = Convert.ToInt32(dataRow["action_visible_type"])
                         let dbeg = dataRow.Field<DateTime?>("action_date_beg") 
                         let dend = dataRow.Field<DateTime?>("action_date_end") 
                         let sortOrder = dataRow.Field<int?>("sort_order") 
                         select new CruiseAction(id, text, url, v, dbeg, dend, sortOrder, synchronizer));
            this.AddRange(items);
            if (this.Count < 1) return false;
            return true;
        }

        public override SynchronizebleItemCollection CreateCollectionFromInstance()
        {
            return new CruiseActionsCollection();
        }

        IEnumerator<CruiseAction> IEnumerable<CruiseAction>.GetEnumerator()
        {
            return GetActEnumerator();
        }
        private IEnumerator<CruiseAction> GetActEnumerator()
        {
            IEnumerator ie = base.GetEnumerator();
            while (ie.MoveNext())
            {
                yield return (CruiseAction)ie.Current;
            }
        }

        

    }
}