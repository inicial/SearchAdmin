using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CruiseSearchAdmin.Entities
{
    public class PartnerExcursionFeesList:List<PartnerExcursionFee>
    {
        public PartnerExcursion PartnerExcursion { get; private set; }
        
        public PartnerExcursionFeesList(PartnerExcursion partnerExcursion)
        {
            PartnerExcursion = partnerExcursion;
        }

        public bool GetFees(SqlConnection connection)
        {
            var query = string.Format(@"select * from mk_tbPartnerExcursionsFee where PE_UID = {0}", PartnerExcursion.Uid);
            this.Clear();
            this.AddRange((from DataRow r in WorkWithData.GetDataTable(query,connection).Rows select new PartnerExcursionFee(r)).ToList());
            return true;
        }
        public void InsertAll(SqlConnection connection)
        {
            this.ForEach(f => f.InsertToBaseForPeId(connection,PartnerExcursion.Uid));
        }

        public void DeleteAll(SqlConnection connection)
        {
            this.ForEach(f=>f.DeleteFromBase(connection));
        }
    }
}