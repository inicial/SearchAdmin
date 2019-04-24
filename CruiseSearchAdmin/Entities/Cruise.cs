using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CruiseSearchAdmin.Entities.CruiseLines;
using CruiseSearchAdmin.Entities.Ships;

namespace CruiseSearchAdmin.Entities
{
    [Serializable]
    public class Cruise
    {        
        public string Package { get; set; }
        public DateTime SailDate { get; set; }
        public string Duration { get; set; }
        public DeparturePort DepPort { get; set; }
        public Itinerary CruiseItinerery { get; set; }
        public CruiseLine CruiseLn { get; set; }
        public Ship Ship { get; set; }
        public List<ItRegion> Regions { get; set; }
        public CruiseActionsCollection Actions { get; set; }
        public CruisSpecialOffer SpecialOffer { get; set; }

        

        public Cruise(DataRow dr)
        {SpecialOffer = null;
            Actions = new CruiseActionsCollection();
            Regions = new List<ItRegion>();
            //Bonuses = new List<CruiseBonus>();
            Package = dr["package"] != DBNull.Value ? dr["package"].ToString().TrimEnd() : String.Empty;
            SailDate = Convert.ToDateTime(dr["sailDate"]);
            Duration = dr["duration"] != DBNull.Value ? dr["duration"].ToString() : string.Empty;
            string[] depArgs = new string[3];
            depArgs[0] = dr["sp_code"] != DBNull.Value ? dr["sp_code"].ToString() : String.Empty;
            depArgs[1] = dr["sp_name_en"] != DBNull.Value ? dr["sp_name_en"].ToString() : String.Empty;
            depArgs[2] = dr["sp_name_ru"] != DBNull.Value ? dr["sp_name_ru"].ToString() : String.Empty;
            int depParent = dr["sp_parent"] != DBNull.Value ? Convert.ToInt32(dr["sp_parent"]) : 0;
            DepPort = new DeparturePort(depArgs,depParent);
            int itId = dr["itinerary"] != DBNull.Value ? Convert.ToInt32(dr["itinerary"]) : 0;
            string itText = dr["Itinerary_Text"].ToString();
            CruiseItinerery = new Itinerary(itId,itText);
            int crLnId = dr["CruiseLine_ID"]==DBNull.Value?0:Convert.ToInt32(dr["CruiseLine_ID"]);
            string[] crlArgs = new string[4];
            crlArgs[0] = dr["CL_Name_en"] != DBNull.Value ? dr["CL_Name_en"].ToString() : String.Empty;
            crlArgs[1] = dr["mnemo"] != DBNull.Value ? dr["mnemo"].ToString() : String.Empty;
            crlArgs[2] = dr["currency"] != DBNull.Value ? dr["currency"].ToString() : String.Empty;
            crlArgs[3] = dr["cl_code"] != DBNull.Value ? dr["cl_code"].ToString() : String.Empty;
            int crLnCls = dr["class"] != DBNull.Value ? Convert.ToInt32(dr["class"]) : 0;
            CruiseLn = new CruiseLine(crLnId,crlArgs[0],crlArgs[3],crlArgs[1],crlArgs[2],crLnCls,WorkWithData.TsConnection);
            string shipN  = dr["S_Name_en"] != DBNull.Value ? dr["S_Name_en"].ToString() : String.Empty;
            int id = dr["s_id"] != DBNull.Value ? Convert.ToInt32(dr["s_id"]) : 0;
            string sCode = dr["s_code"] != DBNull.Value ? dr["s_code"].ToString() : String.Empty;
            Ship = new Ship(id,shipN,crLnId,sCode,null);
        }
    }
    [Serializable]
    public struct NameBox
    {
        public string RU;
        public string EN;
    }
    public class DopPaket
    {
        public int id;
        public string name;
        public DopPaket()
        {
            
        }
        public override String ToString()
        {
            return name;
        }
    }
    public class CruisSpecialOffer
    {
        public int CsoId;
        public int? SoId;
        public int? CsoBaseCost;
        public int? temp;
        public int? city;
        public int? country;
        public double? time_fly;
        public int? cost_fly;
        public int? paket;


    }
    public class CruiseView
    {
        public Cruise CruiseLink { get; set; }
        public string Package { get; set; }
        public DateTime SailDate { get; set; }
        public string DepPortEN { get; set; }
        public string DepPortRU { get; set; }
        public string CrLnEN { get; set; }
        public string CrLnRU { get; set; }
        public string Currency { get; set; }
        public int Class { get; set; }
        public string ShipEN { get; set; }
        public string Duration { get; set; }
        public string Itinerary { get; set; }
        public IEnumerable<ItRegion> Regions { get; set; }
        public CruiseActionsCollection Actions { get; set; }
        //public List<CruiseBonus> Bonuses { get; set; }
        public CruisSpecialOffer SpecialOffer { get; set; }
        public CruiseView(Cruise cruise)
        {
            CruiseLink = cruise;
            Package = cruise.Package;
            SailDate = cruise.SailDate;
            DepPortEN = cruise.DepPort.Name.EN;
            DepPortRU = cruise.DepPort.Name.RU;
            Duration = cruise.Duration;
            Itinerary = cruise.CruiseItinerery.Text;
            CrLnEN = cruise.CruiseLn.EnName;
            Currency = cruise.CruiseLn.Currency;Class = cruise.CruiseLn.Class;
            ShipEN = cruise.Ship.Name;
            Regions = cruise.Regions;
            Actions = cruise.Actions;
            //Bonuses = cruise.Bonuses;
        }
    }
}
