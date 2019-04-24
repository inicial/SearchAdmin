using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.Ships;
using CruiseSearchAdmin.Entities.SyncModel;
using CruiseSearchAdmin.Forms.Ships;
using lanta.SQLConfig;
using System.Runtime.Serialization.Formatters.Binary;

namespace CruiseSearchAdmin
{
    public static class WorkWithData
    {

        public static SqlConnection TsConnection { get { if (tsCon.State == ConnectionState.Closed) tsCon.Open(); return tsCon; } }//Main Total Services DB Connection 
        public static SqlConnection MasterConnection { get { if (masterCon.State == ConnectionState.Closed) masterCon.Open(); return masterCon; } }//Main Lanta DB Connection
        private static SqlConnection tsCon;
        private static SqlConnection masterCon;

        

#if DEBUG
        private const string SELECT_CRUISES =
          @"Select  cr.package,cr.sailDate,cr.duration,cr.isRussianGroup,SP.code as sp_code,SP.name_en as sp_name_en,SP.name_ru as sp_name_ru,
                    SP.parent as sp_parent,cr.itinerary,
                   cl.id as CruiseLine_ID,cl.code as cl_code,cl.name_ru as CL_Name_ru,cl.name_en as CL_Name_en,cl.class,cl.mnemo,cl.currency,
                   S.name_en as S_Name_en,S.code as s_code,S.name_ru as S_Name_ru,S.id as s_id, AI.itenary as Itinerary_Text
                from CRUISES as cr
                left outer join CruiseLines as cl on  cr.brandCode=cl.mnemo and cl.visible=1
                left join Ships as S on S.cruise_line_id=cl.id and S.code=cr.shipCode
                left join ALL_itenary as AI on AI.id=cr.itinerary
                left join Seaports as SP on SP.code = cr.departurePort and Sp.id_crline = cl.id where AI.id<>1542 --order by cr.sailDate";
#else
         private const string SELECT_CRUISES =
          @"Select cr.package,cr.sailDate,cr.duration,cr.isRussianGroup,SP.code as sp_code,SP.name_en as sp_name_en,SP.name_ru as sp_name_ru,
                    SP.parent as sp_parent,cr.itinerary,
                   cl.id as CruiseLine_ID,cl.code as cl_code,cl.name_ru as CL_Name_ru,cl.name_en as CL_Name_en,cl.class,cl.mnemo,cl.currency,
                   S.name_en as S_Name_en,S.code as s_code,S.name_ru as S_Name_ru,S.id as s_id, AI.itenary as Itinerary_Text
                from CRUISES as cr
                left outer join CruiseLines as cl on  cr.brandCode=cl.mnemo and cl.visible=1
                left join Ships as S on S.cruise_line_id=cl.id and S.code=cr.shipCode
                left join ALL_itenary as AI on AI.id=cr.itinerary
                left join Seaports as SP on SP.code = cr.departurePort and Sp.id_crline = cl.id where AI.id<>1542 --order by cr.sailDate";
#endif

        /// <summary> Set SQL connection
        /// </summary>
        /// <param name="args">[Login,Pass]</param>
        /// <returns></returns>
        internal static bool InitConnection(string[] args){
            bool cn_state;
            try
            {

#if DEBUG
                tsCon = LantaSQLConnection.Open_LantaSQLConnection("total_services_test", args[0], args[1], out cn_state);
                masterCon = LantaSQLConnection.Open_LantaSQLConnection("master_test", args[0], args[1], out cn_state);
#else
                tsCon = LantaSQLConnection.Open_LantaSQLConnection("total_services", args[0], args[1], out cn_state);
                masterCon = LantaSQLConnection.Open_LantaSQLConnection("master", args[0], args[1], out cn_state);
#endif

            }
            catch (Exception)
            {
                return false;
            }

            return cn_state;
        }

        /// <summary>
        /// Close SQLConnection
        /// </summary>
        internal static void CloseConnection()
        {
            LantaSQLConnection.Close_LantaSQLConnection(tsCon);
        }

        /// <summary>
        /// Returns DataTable or NULL
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns></returns>
        internal static DataTable GetDataTable(string query)
        {
            try
            {
                DataTable result = new DataTable("Table");
                using (SqlCommand com = new SqlCommand(query, tsCon))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                    dataAdapter.Fill(result);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal static DataTable GetDataTable(string query, SqlConnection con)
        {
            try
            {
                DataTable result = new DataTable("Table");
                using (SqlCommand com = new SqlCommand(query, con))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                    dataAdapter.Fill(result);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal static DataTable GetCruisesTable()//Получение круизов
        {
            return GetDataTable(SELECT_CRUISES);
        }

        static internal void GetRegionsByItinerary(this List<Cruise> cruises)//Получение регионов по маршруту
        {
            var dt = GetDataTable(string.Format(@"select * from 
                                                (select key_if_region as keyregion ,itenary as itenary from  regionsbyitenary  as rbi join regions  as r on r.id=rbi.key_if_region where itenary<>1542
                                                union 
                                                select rb.id_region as keyregion,pbi.id_iternary as itenary from ports_by_iternare as pbi inner join port_by_regions as rb on pbi.id_port=rb.id_port) as subregion 
                                                union 
                                                select Regions.parent as keyregion,subregion.itenary as itenary from Regions inner join (select key_if_region as keyregion ,itenary as itenary from  regionsbyitenary  as rbi join regions  as r on r.id=rbi.key_if_region where itenary<>1542
                                                union 
                                                select rb.id_region as keyregion,pbi.id_iternary as itenary from ports_by_iternare as pbi inner join port_by_regions as rb on pbi.id_port=rb.id_port) as subregion on regions.id=subregion.keyregion 
                                                where parent is not null "));
            var regs = (from DataRow row in dt.Rows select new ItRegion(row)).ToList();
            var regsDict = CreateRegionDictionary(regs);
            var filtredCruises = cruises.Where(c => c.CruiseItinerery.ID != 1542).ToList();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int index = 0; index < filtredCruises.Count; index++)
            {
                var filtredCruise = filtredCruises[index];
                //var regions = regs.Where(r => r.Itinerary == filtredCruise.CruiseItinerery.ID);
                var regions = regsDict.ContainsKey(filtredCruise.CruiseItinerery.ID)?regsDict[filtredCruise.CruiseItinerery.ID]:new List<ItRegion>();
                filtredCruise.Regions.AddRange(regions);
                Debug.WriteLine(string.Format("Iteration - {0} time - {1}",index,sw.Elapsed));
            }
            sw.Stop();
        } 

        private static Dictionary<int, List<ItRegion>> CreateRegionDictionary(IEnumerable<ItRegion> regs)
        {
            Dictionary<int, List<ItRegion>> dict = new Dictionary<int, List<ItRegion>>();
            foreach (var reg in regs)
            {
                if (!dict.ContainsKey(reg.Itinerary))
                {
                    dict.Add(reg.Itinerary, new List<ItRegion> {reg});
                }else
                {
                    dict[reg.Itinerary].Add(reg);
                }
            }
            return dict;
        }

        internal static DataTable GetRegionsByItineraryTable(int iD)
        {
            return GetDataTable(string.Format(@"select * from regionsbyitenary where itenary={0}", iD));
        }
        internal static DataTable GetSeaportRegionsTable()
        {
            return GetDataTable(@"select * from SeaportRegions");}

        internal static DataTable GetRegionsTable()
        {return GetDataTable(@"declare @maxorder int 
                                select @maxorder=MAX(ordrer) from regions 
                                SELECT     id, code, name_ru, name_en, visible, parent, ordrer
                                FROM         Regions as r 
                                ORDER BY (select [ordrer] from regions where id = isnull(r. parent,r.id)), CASE WHEN parent IS NULL THEN ordrer ELSE ordrer + @maxorder END ");
        }


        internal static void UpdateCruisePort(this IEnumerable<Cruise> cruises, SqlConnection connection)
        {
            var dt = GetDataTable(@"SELECT * FROM Seaports", connection);
            if (dt.Rows == null || dt.Rows.Count < 1) return;
            foreach (var cruise in cruises)
            {
                var ds = dt.Select(string.Format("id = {0}", cruise.DepPort.Parent));
                if (ds.Length < 1) return;
                var dr = ds[0];
                string[] depArgs = new string[3];
                depArgs[0] = dr["code"] != DBNull.Value ? dr["code"].ToString() : String.Empty;
                depArgs[1] = dr["name_en"] != DBNull.Value ? dr["name_en"].ToString() : String.Empty;
                depArgs[2] = dr["name_ru"] != DBNull.Value ? dr["name_ru"].ToString() : String.Empty;
                cruise.DepPort = new DeparturePort(depArgs, 0);
            }
        }

        internal static DataTable GetActionsByCruiseTable(string pack, DateTime dateTime)
        {
            return GetDataTable(string.Format(@"select * from CruiseActions where package='{0}' and sailDate='{1}'", pack, dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff")));
        }


        [Obsolete("Use CruiseLinesCollection methods")]
        internal static DataTable GetCruiseLinesTable()
        {
            return GetDataTable(@"SELECT * FROM CruiseLines order by name_en");
        }


        internal static DataTable GetSeaPortsTable(SqlConnection connection)
        {

              
           
				
            return GetDataTable(@"select  sp.id,sp.code,sp.name_en,sp.name_ru,parent,id_crline,id_region,crl.name_en as crl_name from SeaPorts as sp left join CruiseLines as crl ON crl.id=id_crline  where sp.visible=1 order by sp.name_en ", connection);


        }
        /// <summary>
        /// Checks permission on regions edit
        /// </summary>
        /// <returns></returns>
        public static bool GetPermissions()
        {
            var dt = GetDataTable(@"SELECT isnull(has_perms_by_name('dbo.regionsbyitenary', 'OBJECT', 'INSERT'), 0)");
            return Convert.ToInt32(dt.Rows[0][0]) == 1 ? true : false;
        }
        public static string GetCruiseMapPath(string itinerary)
        {
            lanta.SQLConfig.Config_XML configXml = new Config_XML(TypeFileConfig.tfcXML);
            string ftp = configXml.Get_Value("appSettings", "Ftp");
            string ftpLogin = configXml.Get_Value("appSettings", "ftpLogin");
            string ftpPass = configXml.Get_Value("appSettings", "ftpPass");
            string fName = itinerary + ".jpg";
            return String.Format("ftp://{0}:{1}@{2}/{3}", ftpLogin, ftpPass, ftp, fName);
        }

        internal static bool FTPMapUpload(string fileName, string itinerary)
        {

            File.Copy(fileName, Application.StartupPath + "/" + itinerary + ".jpg");
            fileName = Application.StartupPath + "/" + itinerary + ".jpg";
            FileInfo fileInf = new FileInfo(fileName);
            lanta.SQLConfig.Config_XML configXML = new Config_XML();
            string uri = string.Format(@"ftp://{0}/", configXML.Get_Value("appSettings", "Ftp"));
            FtpWebRequest reqFTP;
            string ftp = configXML.Get_Value("appSettings", "Ftp");
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftp + "/" + fileInf.Name));
            string ftpLogin = configXML.Get_Value("appSettings", "ftpLogin");
            string ftpPass = configXML.Get_Value("appSettings", "ftpPass");
            reqFTP.Credentials = new NetworkCredential(ftpLogin, ftpPass);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            // Сообщаем серверу о размере файла
            reqFTP.ContentLength = fileInf.Length;
            // Буффер в 2 кбайт
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // Файловый поток
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                // Читаем из потока по 2 кбайт
                contentLen = fs.Read(buff, 0, buffLength);
                // Пока файл не кончится
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // Закрываем потоки
                strm.Close();
                fs.Close();
                fileInf.Delete();
            }
            catch (Exception)
            {
                fs.Close();
                fileInf.Delete();
                return false;
            }
            return true;
        }
        public static string GetUserName()
        {
            string name = string.Empty;
            using (SqlCommand com = new SqlCommand("select isnull((select top 1 US_FullName from UserList where US_USERID =(select SUSER_SNAME())),'') as UserName",MasterConnection))
            {
                name = (string) com.ExecuteScalar();
            }
            return name;
        }
        /// <summary>
        /// string Extension execute string as SQL query 
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <param name="qParams">Array of parameters which have to being called "@pi" where "i" number of parameter from 0</param>
        internal static void ExecuteNonQuery(this String query, params object[] qParams)
        {
            try
            {
                if (tsCon.State == ConnectionState.Closed) tsCon.Open();
                using (SqlCommand com = new SqlCommand(query, tsCon))
                {

                    for (int i = 0; i < qParams.Length; i++)
                    {
                        var qParam = qParams[i];
                        if (qParam == null) qParam = DBNull.Value;
                        com.Parameters.AddWithValue("@p" + i, qParam);
                    }
                    com.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        internal static void ExecuteNonQuery(this String query, SqlConnection con, params object[] qParams)
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                using (SqlCommand com = new SqlCommand(query, con))
                {

                    for (int i = 0; i < qParams.Length; i++)
                    {
                        var qParam = qParams[i];
                        if (qParam == null) qParam = DBNull.Value;
                        com.Parameters.AddWithValue("@p" + i, qParam);
                    }
                    com.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        internal static void UpdateCruiseActions(this List<Cruise> cruises)
        {
            var dt =
                GetDataTable(
                    string.Format(
                        @" 
                        select  distinct * from CruiseActions join (select * from
                        (select Actions_visible_group.id as id_group ,Actions_visible_group.Name as group_name ,SUM(mk_tbVisibleTypes.VT_MASK)as summask from Actions_visible_group inner join dbo.mk_tbVisibleTypes on Actions_visible_group.id =mk_tbVisibleTypes.VT_id_group
                        group by Actions_visible_group.id,Actions_visible_group.Name)as grm inner join Actions as a on (a.action_visible_type & summask) >0
                        union
                        select 0 ,'Без группы',0,Actions.* from Actions where action_visible_type=0 or action_visible_type is null) as action_with_group 
                        ON action_with_group.action_id=CruiseActions.actionId where CruiseActions.sailDate>=dateadd(day,-1,getdate())"));
            foreach (var cruise in cruises.Where(c=>c.SailDate>=DateTime.Now.Date))
            {
                var drs = dt.Select(string.Format("package='{0}' and sailDate='{1}'", cruise.Package, cruise.SailDate.ToString("dd.MM.yyyy")));
                foreach (var dr in drs)
                {
                    var dbeg = dr.Field<DateTime?>("action_date_beg");
                    var dend = dr.Field<DateTime?>("action_date_end");
                    int id_group = dr.Field<int>("id_group");
                    string group = dr.Field<string>("group_name");
                    cruise.Actions.Add(new CruiseAction(Convert.ToInt32(dr["actionId"]),group,id_group, dr["action_text"].ToString(), Convert.ToInt32(dr["action_visible_type"]), dbeg, dend, dr.Field<int?>("sort_order"), new Synchronizer(null, tsCon)));
                }
            }
        }

        internal static Cruise GetCruise(string pacage, DateTime SailDate)
        {
            SqlCommand com = new SqlCommand(SELECT_CRUISES +"\n and package=@p0 and saildate=@p1",TsConnection);
            com.Parameters.AddWithValue("@p0", pacage);
            com.Parameters.AddWithValue("@p1", SailDate);
            SqlDataAdapter adapter =new SqlDataAdapter(com);
            DataTable dt =new DataTable();
            adapter.Fill(dt);
            Cruise cr=  new Cruise(dt.Rows[0]);
            com = new SqlCommand("select action_id,action_text,action_visible_type,action_date_beg,action_date_end,sort_order from actions inner join CruiseActions on actionid=action_id where package=@p0 and saildate =@p1",TsConnection);
            com.Parameters.AddWithValue("@p0", pacage);
            com.Parameters.AddWithValue("@p1", SailDate);
            adapter = new SqlDataAdapter(com);
            dt = new DataTable();
            adapter.Fill(dt);
            CruiseActionsCollection collection = new CruiseActionsCollection();
            foreach (DataRow row in dt.Rows)
            {
                int id = row.Field<int>("action_id");
                string text = row.Field<string>("action_text");
                int visible = row.Field<int>("action_visible_type");
                DateTime? date_beg = row.Field<DateTime?>("action_date_beg"),
                    date_end = row.Field<DateTime?>("action_date_end");
                int? sort_order = row.Field<int?>("sort_order");
                collection.Add(new CruiseAction(id,text,visible,date_beg,date_end,sort_order,null));
            }
            cr.Actions = collection;
            com = new SqlCommand("select * from Regions as t1 inner join  dbo.regionsbyitenary as t2 on t1.id =t2.key_if_region where itenary=@p0", TsConnection);
            com.Parameters.AddWithValue("@p0", cr.CruiseItinerery.ID); 
            adapter = new SqlDataAdapter(com);
            dt = new DataTable();
            adapter.Fill(dt);
           
            List<ItRegion> regions = new List<ItRegion>();
            foreach (DataRow row in dt.Rows)
            {
                long id = row.Field<long>("id");
                string n = row.Field<string>("name_en");

                regions.Add(new ItRegion(id,n));
            }
            cr.Regions = regions;
            
            //com = new SqlCommand("select *  from mk_tbCruiseSpecialOffers where C_PACKAGE =@p0 and C_SAILDATE = @p1",tsCon);
            //com.Parameters.AddWithValue("@p0", cr.Package);
            //com.Parameters.AddWithValue("@p1", cr.SailDate);
            //adapter = new SqlDataAdapter(com);
            //dt = new DataTable();
            //adapter.Fill(dt);//if (dt.Rows.Count>0)
            //{
            //    cr.SpecialOffer = new CruisSpecialOffer();
            //    cr.SpecialOffer.CsoId = dt.Rows[0].Field<int>("CSO_ID");
            //    cr.SpecialOffer.SoId = dt.Rows[0].Field<int>("SO_ID");
            //    cr.SpecialOffer.CsoBaseCost = dt.Rows[0].Field<int>("CSO_ID");
            //    cr.SpecialOffer.city = dt.Rows[0].Field<int>("N_city");cr.SpecialOffer.country = dt.Rows[0].Field<int>("N_country");
            //    cr.SpecialOffer.temp = dt.Rows[0].Field<int>("Temperature");
            //    cr.SpecialOffer.time_fly = dt.Rows[0].Field<double>("time_of_fly");
            //    cr.SpecialOffer.cost_fly = dt.Rows[0].Field<int>("Cost_of_fly");
            //    cr.SpecialOffer.paket = dt.Rows[0].Field<int>("Dop_paket"); 
            //}
            
            return cr;
        }

        internal static List<CruiseView> GetListCruiseView(string idShip, int idItinery, string idCrline)
        {
            SqlCommand com = new SqlCommand("select package,sailDate from cruises where itinerary=@p0 and shipCode=@p1 and brandCode =@p2 ", TsConnection);
            com.Parameters.AddWithValue("@p0", idItinery);
            com.Parameters.AddWithValue("@p1", idShip);
            com.Parameters.AddWithValue("@p2", idCrline);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<CruiseView> cruises =new List<CruiseView>();
            foreach (DataRow row in dt.Rows)
            {
                cruises.Add(new CruiseView(GetCruise(row.Field<string>("package"), row.Field<DateTime>("sailDate"))));
            }
            return cruises;
        }

        internal static void InsertRegionToDB(string code, string name_ru, string name_en, bool visible)
        {
            SqlTransaction transact = tsCon.BeginTransaction();
            long ID;
            try
            {
                if (tsCon.State == ConnectionState.Closed) tsCon.Open();
                using (SqlCommand com = new SqlCommand(@"insert into Regions(code,name_ru,name_en,visible) values(@code,@name_ru,@name_en,@visible)", tsCon, transact))
                {
                    com.Parameters.AddWithValue("@code", code);
                    com.Parameters.AddWithValue("@name_ru", name_ru);
                    com.Parameters.AddWithValue("@name_en", name_en);
                    com.Parameters.AddWithValue("@visible", visible);
                    com.ExecuteNonQuery();
                }
                if (code == string.Empty)
                {
                    using (SqlCommand com = new SqlCommand(@"SELECT MAX(id) FROM [Regions]", tsCon, transact))
                    {
                        ID = (long)com.ExecuteScalar();
                    }
                    using (SqlCommand com = new SqlCommand(@"update Regions set code=@code where id=@id", tsCon, transact))
                    {
                        com.Parameters.AddWithValue("@code", "r" + ID);
                        com.Parameters.AddWithValue("@id", ID);
                        com.ExecuteNonQuery();
                    }
                }
                transact.Commit();
            }
            catch (Exception)
            {
                transact.Rollback();
                throw;
            }

        }
        internal static void DeleteItineraryFromDB(long ID)
        {
            SqlTransaction transact = tsCon.BeginTransaction();
            try
            {
                using (
                    SqlCommand com = new SqlCommand(@"delete from regionsbyitenary where key_if_region=@id", tsCon,
                                                    transact))
                {
                    com.Parameters.AddWithValue("@id", ID);
                    com.ExecuteNonQuery();
                }
                using (
                   SqlCommand com = new SqlCommand(@"delete from regions where id=@id", tsCon,
                                                   transact))
                {
                    com.Parameters.AddWithValue("@id", ID);
                    com.ExecuteNonQuery();
                }
                transact.Commit();
            }
            catch (Exception)
            {
                transact.Rollback();
                throw;
            }

        }
       
        internal static void SetDataSource(this ListControl control, object dataSource, string valueMember, string displayMember)
        {
            control.DataSource = dataSource;
            control.ValueMember = valueMember;
            control.DisplayMember = displayMember;
            
        }

        internal static DataTable GetExcursionTypes()
        {
            return GetDataTable(@"select * from mk_tbExcursionTypes");
        }
        #region 'Obsolete'
        [Obsolete("Use ShipsCollection methods")]
        internal static DataTable GetShipsTable()
        {
            return GetDataTable(@"SELECT id AS ID,name_en as Name,cruise_line_id as CruiseLineID, code as Code,visible as Visible FROM ships");
        }
        [Obsolete("Use Ship method Update")]
        internal static void UpdateShip(Ship ship)
        {
            using (SqlCommand com = new SqlCommand(@"UPDATE ships SET cruise_line_id=@cli,code=@code,name_en=@ne,name_ru=@ne,visible=@vis WHERE id=@sid", TsConnection))
            {
                com.Parameters.AddWithValue("@cli", ship.CruiseLineID);
                com.Parameters.AddWithValue("@code", ship.Code);
                com.Parameters.AddWithValue("@ne", ship.Name);
                com.Parameters.AddWithValue("@vis", ship.Visible);
                com.Parameters.AddWithValue("@sid", ship.ID);
                com.ExecuteNonQuery();
            }
        }
        [Obsolete("Use Ship method Insert")]
        internal static void InsertShipToDB(Ship ship)
        {
            using (SqlCommand com = new SqlCommand(@"INSERT INTO ships(cruise_line_id,ship_class_id,code,name_ru,name_en,visible) VALUES(@cli,null,@code,@name,@name,@vis)", TsConnection))
            {
                com.Parameters.AddWithValue("@cli", ship.CruiseLineID);
                com.Parameters.AddWithValue("@code", ship.Code);
                com.Parameters.AddWithValue("@name", ship.Name);
                com.Parameters.AddWithValue("@vis", ship.Visible);
                com.Parameters.AddWithValue("@sid", ship.ID);
                com.ExecuteNonQuery();
            }
        }
        [Obsolete("Use ExcursionDatesList methods")]
        internal static DataTable GetExcursionDates(int pEId)
        {
            return GetDataTable(@"select ED_DATE from mk_tbPartnerExcursionDates where EL_UID = " + pEId);
        }
        [Obsolete("Use ExcursionDatesList methods")]
        internal static bool UpdateExcursionDates(int pEId, List<DateTime> dates)
        {
            SqlTransaction tran = TsConnection.BeginTransaction();
            try
            {
                using (SqlCommand com = new SqlCommand(@"delete from mk_tbPartnerExcursionDates where EL_UID = @uid", TsConnection, tran))
                {
                    com.Parameters.AddWithValue("@uid", pEId);
                    com.ExecuteNonQuery();
                }
                foreach (var date in dates)
                {
                    using (SqlCommand com = new SqlCommand(@"insert into mk_tbPartnerExcursionDates(EL_UID,ED_DATE) values(@uid,@date)", TsConnection, tran))
                    {
                        com.Parameters.AddWithValue("@uid", pEId);
                        com.Parameters.AddWithValue("@date", date);
                        com.ExecuteNonQuery();
                    }
                }
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }

        }
        private const string SELECT_DISCOUNT_INFO = @"select mrd.id as [RULE_ID],mrd.Name as [RULE_NAME],cl.id as [CL_ID],cl.currency as [CL_CURRENCY],cl.class as [CL_CLASS],cl.name_en as [CL_NAME_EN],cl.mnemo as [CL_MNEMO],S.id as [S_ID],S.name_en as [S_NAME],S.cruise_line_id as [S_CLID],S.code as [S_CODE], mrd.[type] as [RULE_TYPE],mrd.value as [RULE_VALUE],CC.id as [CC_ID],CC.name as [CC_NAME],AI.id AS [AI_ID],AI.itenary as [AI_TEXT],mrd.Date_begin as [RULE_DATE_BEGIN],MRD.Date_end as [RULE_DATE_END],mrd.Sale_date_begin as [RULE_SALE_DATE_BEGIN],mrd.Sale_date_end as [RULE_SALE_DATE_END],Act.action_id as [ACT_ID],Act.action_text as [ACT_TEXT],ACT.action_URL as [ACT_URL],act.action_visible_type as [ACT_VISIBLE],Act.action_date_beg as [ACT_DATE_BEG], Act.action_date_end as [ACT_DATE_END],Act.sort_order as [SORT_ORDER],R.id as [R_ID],R.name_en as [R_NAME] 
				from Mk_rules_discont as mrd 
				left join CruiseLines as cl ON cl.mnemo like mrd.Brancode 
				left join Ships as S ON s.id=mrd.Ship_id
				left join CabinClasses as CC ON CC.id = mrd.CabinClass
				left join ALL_itenary as AI ON AI.id=mrd.Itenare
				left join Actions as Act ON Act.action_id=mrd.ActionID
				left join Regions as R ON R.id=mrd.RegionID";
        [Obsolete("Use DiscountCollection methods")]
        internal static DataTable GetDiscountInfo()
        {
            return GetDataTable(SELECT_DISCOUNT_INFO);
        }
        [Obsolete("Use PartnerExcursionFeesCollection class method")]
        internal static DataTable GetPartnerExcurionsFee(int peId)
        {
            var query = string.Format(@"select * from mk_tbPartnerExcursionsFee where PE_UID = {0}", peId);
            return GetDataTable(query);
        }
        [Obsolete("Use method in CruiseAction Class")]
        internal static void UpdateActions(int iD, string text, string url, int visiblity, DateTime? dBeg, DateTime? dEnd)
        {
            using (SqlCommand com = new SqlCommand(@"UPDATE Actions SET action_text=@text,action_url=@url,action_visible_type=@act,action_date_beg=@dbeg,action_date_end=@dend where action_id=@id", tsCon))
            {
                com.Parameters.AddWithValue("@text", text);
                com.Parameters.AddWithValue("@url", url);
                com.Parameters.AddWithValue("@id", iD);
                com.Parameters.AddWithValue("@act", visiblity);
                object dbeg, dend;
                if (dBeg == null || dEnd == null)
                {
                    dbeg = dend = DBNull.Value;
                }
                else
                {
                    dbeg = dBeg;
                    dend = dEnd;
                }
                com.Parameters.AddWithValue("@dbeg", dbeg);
                com.Parameters.AddWithValue("@dend", dend);
                com.ExecuteNonQuery();
            }
        }
        [Obsolete("Use method in CruiseAction Class")]
        internal static void DeleteActionFromBase(int id)
        {
            using (SqlCommand com = new SqlCommand(@"delete from Actions where action_id=@id", tsCon))
            {
                com.Parameters.AddWithValue("@id", id);
                com.ExecuteNonQuery();
            }
        }
        [Obsolete("Use method in CruiseAction Class")]
        internal static void InsertActionToBase(string actText, string actURL, int vis, DateTime? dBeg, DateTime? dEnd)
        {
            using (SqlCommand com = new SqlCommand(@"insert into Actions (action_text,action_URL,action_visible_type,action_date_beg,action_date_end) values(@text,@url,@visible,@datebeg,@dateend)", tsCon))
            {
                com.Parameters.AddWithValue("@text", actText);
                var url = actURL;
                int v = vis;
                object dateb, datee;
                if (dBeg == null || dEnd == null)
                {
                    datee = dateb = DBNull.Value;
                }
                else
                {
                    dateb = dBeg;
                    datee = dEnd;
                }
                com.Parameters.AddWithValue("@url", url);
                com.Parameters.AddWithValue("@visible", v);
                com.Parameters.AddWithValue("@datebeg", dateb);
                com.Parameters.AddWithValue("@dateend", datee);
                com.ExecuteNonQuery();
            }

        }



        #endregion
    }
}
