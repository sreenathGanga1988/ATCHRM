using ATCHRM.Transactions.PayrollTransaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for MainPayrollTransactionTest and is intended
    ///to contain all MainPayrollTransactionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainPayrollTransactionTest
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
        ///A test for getholidaynumberforperiod
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ATCHRM.exe")]
        public void getholidaynumberforperiodTest()
        {
            MainPayrollTransaction_Accessor target = new MainPayrollTransaction_Accessor(); // TODO: Initialize to an appropriate value
            int empid = 765; // TODO: Initialize to an appropriate value
            DateTime fromdate = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime todate = new DateTime(); // TODO: Initialize to an appropriate value
            fromdate = DateTime.Parse("01-01-2013");
            todate = DateTime.Parse("01-01-2014");
            target.getholidaynumberforperiod(empid, fromdate.Date , todate.Date);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
