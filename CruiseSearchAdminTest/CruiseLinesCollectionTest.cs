using CruiseSearchAdmin.Entities.CruiseLines;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace CruiseSearchAdminTest
{
    
    
    /// <summary>
    ///This is a test class for CruiseLinesCollectionTest and is intended
    ///to contain all CruiseLinesCollectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CruiseLinesCollectionTest
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
        ///A test for GetItems
        ///</summary>
        [TestMethod()]
        public void GetItemsTest()
        {
            CruiseLinesCollection target = new CruiseLinesCollection();
            SqlConnection connection = TestHelper.McConnection; 
            bool actual = target.GetItems(connection);
            Assert.IsTrue(actual);
        }
    }
}
