using CruiseSearchAdmin.Entities;
using CruiseSearchAdmin.Forms.SynchronizationForms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CruiseSearchAdmin.Entities.SyncModel;
using System.Linq;
namespace CruiseSearchAdminTest
{
    
    
    /// <summary>
    ///This is a test class for SynchronizationTest and is intended
    ///to contain all SynchronizationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SynchronizationTest
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
        ///A test for GetSyncItems
        ///</summary>
        [TestMethod()]
        public void GetSyncItemsTest()
        {
            Synchronization target = new Synchronization(); 
            target.SetConnection(TestHelper.McConnection);
            SynchronizebleItemCollection syncCollection = new CruiseActionsCollection();
            syncCollection.GetItems(TestHelper.McConnection);
            bool actual = target.GetSyncData(syncCollection);
            Assert.IsTrue(actual);
            Assert.IsTrue(syncCollection.Any(ci=>ci.ItemChecked));
        }

        /// <summary>
        ///A test for Perform
        ///</summary>
        [TestMethod()]
        public void PerformTest()
        {
            Synchronization target = new Synchronization();
            target.SetConnection(TestHelper.McConnection);
            target.GetSyncData(new CruiseActionsCollection());
            bool actual;
            actual = target.Perform();
            Assert.IsTrue(actual);
        }
    }
}
