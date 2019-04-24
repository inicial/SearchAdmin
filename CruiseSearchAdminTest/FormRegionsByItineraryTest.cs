using System.Diagnostics;
using CruiseSearchAdmin;
using CruiseSearchAdmin.Forms.Itinerary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CruiseSearchAdmin.Entities;
using System.Collections.Generic;

namespace CruiseSearchAdminTest
{
    
    
    /// <summary>
    ///This is a test class for FormRegionsByItineraryTest and is intended
    ///to contain all FormRegionsByItineraryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FormRegionsByItineraryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetRegions
        ///</summary>
        [TestMethod()]
        public void GetRegionsTest()
        {
            WorkWithData.InitConnection(new string[]{"rpovolotsky","qw123456789"});Debug.WriteLine("Connection");
            Cruise cruise = null; // TODO: Initialize to an appropriate value
            List<CruiseView> cruises = null; // TODO: Initialize to an appropriate value
            FormRegionsByItinerary target = new FormRegionsByItinerary(cruise, cruises); // TODO: Initialize to an appropriate value
            target.GetRegions();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetSettings
        ///</summary>
        [TestMethod()]
        public void GetSettingsTest()
        {
            var selectCruise =
                @"Select top 1 cr.package,cr.sailDate,cr.duration,cr.isRussianGroup,SP.code as sp_code,SP.name_en as sp_name_en,SP.name_ru as sp_name_ru,
                    SP.parent as sp_parent,cr.itinerary,
                   cl.id as CruiseLine_ID,cl.code as cl_code,cl.name_ru as CL_Name_ru,cl.name_en as CL_Name_en,cl.class,cl.mnemo,cl.currency,
                   S.name_en as S_Name_en,S.code as s_code,S.name_ru as S_Name_ru,S.id as s_id, AI.itenary as Itinerary_Text
                from CRUISES as cr
                left outer join CruiseLines as cl on  cr.brandCode=cl.mnemo and cl.visible=1
                left join Ships as S on S.cruise_line_id=cl.id and S.code=cr.shipCode
                left join ALL_itenary as AI on AI.id=cr.itinerary
                left join Seaports as SP on SP.code = cr.departurePort and Sp.id_crline = cl.id where AI.id<>1542 order by cr.sailDate";
            Cruise cruise = new Cruise(WorkWithData.GetDataTable(selectCruise,TestHelper.McConnection).Rows[0]); // TODO: Initialize to an appropriate value
          
            List<CruiseView> cruises = new List<CruiseView>( ); // TODO: Initialize to an appropriate value
            FormRegionsByItinerary.GetSettings(cruise, cruises);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
