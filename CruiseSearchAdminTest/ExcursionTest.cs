using CruiseSearchAdmin.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CruiseSearchAdmin.Entities.SyncModel;
using System.Linq;
using System.Data.SqlClient;

namespace CruiseSearchAdminTest
{
    
    
    /// <summary>
    ///This is a test class for ExcursionTest and is intended
    ///to contain all ExcursionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExcursionTest
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
        ///A test for Synchronize
        ///</summary>
        [TestMethod()]
        public void SynchronizeInsertTest()
        {
            ExcursionsCollection collection = new ExcursionsCollection();
            collection.GetItems(TestHelper.McConnection);
            if(!collection.Any<Excursion>())Assert.Fail("Collection is empty");
            Excursion target = collection.Last<Excursion>(); 
            Synchronizer s = new Synchronizer(collection,TestHelper.McConnection);
            s.SelectBaseProccessors();
            SynchronyzeMethod sMethod = SynchronyzeMethod.Insert;
            target.Synchronize(s.SyncProccessors.Last(), sMethod).InsertSyncRecord(TestHelper.McConnection);
        }
        [TestMethod()]
        public void SynchronizeUpdateTest()
        {
            ExcursionsCollection collection = new ExcursionsCollection();
            collection.GetItems(TestHelper.McConnection);
            if (!collection.Any<Excursion>()) Assert.Fail("Collection is empty");
            Excursion target = collection.Last<Excursion>();
            Synchronizer s = new Synchronizer(collection, TestHelper.McConnection);
            s.SelectBaseProccessors();
            SynchronyzeMethod sMethod = SynchronyzeMethod.Update;
            target.Synchronize(s.SyncProccessors.Last(), sMethod);
        }
        /// <summary>
        ///A test for DeleteExcursion
        ///</summary>
        [TestMethod()]
        public void DeleteExcursionTest(){ExcursionsCollection collection = new ExcursionsCollection();
            collection.GetItems(TestHelper.EvConnection);
            if (!collection.Any<Excursion>()) Assert.Fail("Collection is empty");
            Excursion target = collection.Last<Excursion>();
            target.DeleteExcursion(TestHelper.EvConnection);
            collection.GetItems(TestHelper.EvConnection);
            Assert.IsFalse(collection.Any<Excursion>());
           
        }
    }
}
