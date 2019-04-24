using System.Collections;
using System.Data.SqlClient;
using System.Linq;

namespace CruiseSearchAdmin.DataBaseEntities
{
    partial class VisaDataContext
    {
        public IEnumerable GetVisasFullInfo()
        {
            return (from visa in lanta_visa_dnas
                    select
                        new
                            {
                                Country = visa.tbl_Country.CN_NAME,
                                ServiceName = visa.ServiceList.SL_NAME,
                                IsShengen = (visa.lv_shengen??0)!=0,
                                Disabled = (visa.lv_unyse??0)!=0,
                                Partner = visa.tbl_Partner.PR_NAME,
                                Visa = visa ,
                                Date = visa.ServiceList.tbl_Costs.OrderByDescending(c => c.CS_DATEEND).First(c => c.CS_PRKEY == visa.lv_prkey).CS_DATEEND,
                                user = visa.ServiceList.tbl_Costs.OrderByDescending(c => c.CS_DATEEND).First(c => c.CS_PRKEY == visa.lv_prkey).CS_UPDUSER,
                                crline = new SqlCommand(string.Format("select top 1 name_en from CruiseLines where mnemo='{0}'",visa.lv_brandcode),WorkWithData.TsConnection).ExecuteScalar()
                            });
            }

       
    }
}
