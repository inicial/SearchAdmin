using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Entities.SyncModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace CruiseSearchAdminTest
{
    
    
    /// <summary>
    ///This is a test class for CruiseActionTest and is intended
    ///to contain all CruiseActionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CruiseActionTest
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
        ///A test for DeleteActionFromBase
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CruiseSearchAdmin.exe")]
        public void DeleteActionFromBaseTest()
        {
            int id = 380;
            CruiseAction target = new CruiseAction(id, "", 0, null, null, 0, new Synchronizer(null, TestHelper.EvConnection));
            SqlConnection con = TestHelper.EvConnection; 
            target.DeleteActionFromBase(con);
            
        }



        /// <summary>
        ///A test for SyncItemType
        ///</summary>
        [TestMethod()]
        public void SyncItemTypeTest()
        {
            int id = 0; 
            string text = string.Empty; 
            int visiblity = 0; 
            Nullable<DateTime> dBeg = new Nullable<DateTime>(); 
            Nullable<DateTime> dEnd = new Nullable<DateTime>(); 
            Nullable<int> sortOrder = new Nullable<int>(); 
            CruiseAction target = new CruiseAction(id, text, visiblity, dBeg, dEnd, sortOrder,null);
            int actual;
            int expect = 2;
            actual = target.SyncItemType;
            Assert.AreEqual(expect,actual,"Все пиздато");
        }
    }
}
