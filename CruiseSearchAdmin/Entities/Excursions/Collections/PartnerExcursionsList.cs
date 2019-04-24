using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CruiseSearchAdmin.Entities
{
    public class PartnerExcursionsList:List<PartnerExcursion>
    {
       

        public Excursion Excursion { get; private set; }
        public PartnerExcursionsList(Excursion excursion)
        {
            Excursion = excursion;
        }

        public bool GetPartnerExcursions(SqlConnection con)
        {
            this.Clear();
            var tbPartners = WorkWithData.GetDataTable(@"select PR_KEY,PR_FULLNAME as PR_NAME from Partners",
                                                       WorkWithData.MasterConnection);
            var tbPartnerExcursions =
                WorkWithData.GetDataTable(
                    @"select pe.PE_UID as PE_UID,pe.EX_UID as EX_UID,ex.EX_NAME as EX_NAME,pe.CL_MNEMO as CL_MNEMO,cl.name_en as CL_NAME,pe.PE_PRKEY as PR_KEY from [mk_tbPartnerExcursions] as pe
                                                                        LEFT JOIN mk_tbExcursions as ex ON ex.EX_UID=pe.EX_UID
                                                                        LEFT JOIN CruiseLines as cl on cl.mnemo=pe.CL_MNEMO",
                    con);
            this.AddRange(from DataRow pEx in tbPartnerExcursions.Rows
                              where pEx.Field<int?>("EX_UID")==Excursion.ID
                          select new PartnerExcursion(pEx) { PartnerName = (from DataRow p in tbPartners.Rows where p.Field<int?>("PR_KEY")==pEx.Field<int?>("PR_KEY") select p["PR_NAME"].ToString()).FirstOrDefault() });
            
            return true;
        }

        public void DeleteAll(SqlConnection connection)
        {
            this.ForEach(p=>p.DeletePartnerExcursion(connection));
        }
    }
}