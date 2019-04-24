using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CruiseSearchAdmin.Entities.SyncModel;
namespace CruiseSearchAdmin.Entities
{
    public class ExcursionsCollection:SynchronizebleItemCollection,IEnumerable<Excursion>
    {
        public override bool GetItems(SqlConnection connection)
        {
            DataTable tbExcursions =
                WorkWithData.GetDataTable(
                    @"select [EX_UID],[EX_DESCRIPTION],[EX_NAME],[SEAPORT_ID],[mk_tbExcursions].[ED_ID],[ED_TEXT],[name_en] AS [SEAPORT_NAME] from [dbo].[mk_tbExcursions]
                            left join [mk_tbExcursionDuration] on [mk_tbExcursionDuration].ED_ID = [mk_tbExcursions].ED_ID
                            left join [Seaports] on [id]=[SEAPORT_ID]",
                   connection);
            this.Clear();
            this.AddRange(from DataRow r in tbExcursions.Rows select new Excursion(new Synchronizer(this,connection)){ID=r.Field<int?>("EX_UID"),Description = r["EX_DESCRIPTION"].ToString(),DurationID = r.Field<int?>("ED_ID"),Duration = r["ED_TEXT"].ToString(),PortID = r.Field<int?>("SEAPORT_ID"),PortName = r["SEAPORT_NAME"].ToString(),Text = r["EX_NAME"].ToString()});
            return true;
        }

        public override SynchronizebleItemCollection CreateCollectionFromInstance()
        {
            return new ExcursionsCollection();
        }

        IEnumerator<Excursion> IEnumerable<Excursion>.GetEnumerator()
        {
            return GetExEnumerator();
        }
        private IEnumerator<Excursion> GetExEnumerator()
        {
            IEnumerator ie = base.GetEnumerator();
            while (ie.MoveNext())
            {
                yield return (Excursion)ie.Current;
            }

        }
    }
}