using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CruiseSearchAdmin.Entities.SyncModel;
namespace CruiseSearchAdmin.Entities
{
    public class DiscountCollection:SynchronizebleItemCollection,IEnumerable<Discount>
    {
        private const string SELECT_DISCOUNT_INFO = @"select mrd.orderrules as [RULE_PRIORITY], mrd.id as [RULE_ID],mrd.Name as [RULE_NAME],cl.id as [CL_ID],cl.currency as [CL_CURRENCY],cl.class as [CL_CLASS],cl.name_en as [CL_NAME_EN],cl.mnemo as [CL_MNEMO],S.id as [S_ID],S.name_en as [S_NAME],S.cruise_line_id as [S_CLID],S.code as [S_CODE], mrd.[type] as [RULE_TYPE],mrd.value as [RULE_VALUE],CC.id as [CC_ID],CC.name as [CC_NAME],AI.id AS [AI_ID],AI.itenary as [AI_TEXT],mrd.Date_begin as [RULE_DATE_BEGIN],MRD.Date_end as [RULE_DATE_END],mrd.Sale_date_begin as [RULE_SALE_DATE_BEGIN],mrd.Sale_date_end as [RULE_SALE_DATE_END],Act.action_id as [ACT_ID],Act.action_text as [ACT_TEXT],ACT.action_URL as [ACT_URL],act.action_visible_type as [ACT_VISIBLE],Act.action_date_beg as [ACT_DATE_BEG], Act.action_date_end as [ACT_DATE_END],Act.sort_order as [SORT_ORDER],R.id as [R_ID],R.name_en as [R_NAME] 
				from Mk_rules_discont as mrd 
				left join CruiseLines as cl ON cl.mnemo like mrd.Brancode 
				left join Ships as S ON s.id=mrd.Ship_id
				left join CabinClasses as CC ON CC.id = mrd.CabinClass
				left join ALL_itenary as AI ON AI.id=mrd.Itenare
				left join Actions as Act ON Act.action_id=mrd.ActionID
				left join Regions as R ON R.id=mrd.RegionID";
        public override bool GetItems(SqlConnection connection)
        {
            this.Clear();
            var synchronizer = new Synchronizer(null, connection);
            this.AddRange(from DataRow dr in WorkWithData.GetDataTable(SELECT_DISCOUNT_INFO,connection).Rows select new Discount(dr,synchronizer));
            return true;
        }

        public override SynchronizebleItemCollection CreateCollectionFromInstance()
        {
            return new DiscountCollection();
        }

        IEnumerator<Discount> IEnumerable<Discount>.GetEnumerator()
        {
            return GetDiscountEnumerator();
        }

        public IEnumerator<Discount> GetDiscountEnumerator()
        {
            IEnumerator ie = base.GetEnumerator();
            while (ie.MoveNext())
            {
                yield return (Discount) ie.Current;
            }
        }

        public ArrayList Container
        { get { return InnerList; } }
    }
}