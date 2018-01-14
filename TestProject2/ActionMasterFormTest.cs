using ATCHRM.Action;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject2
{
    
    
    /// <summary>
    ///This is a test class for ActionMasterFormTest and is intended
    ///to contain all ActionMasterFormTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ActionMasterFormTest
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
        ///A test for randomtimecreator
        ///</summary>
        [TestMethod()]
        public void randomtimecreatorTest()
        {
            ActionMasterForm target = new ActionMasterForm(); // TODO: Initialize to an appropriate value
            DateTime fromtime = DateTime.Now; // TODO: Initialize to an appropriate value
            DateTime totime = fromtime.AddMinutes (20); // TODO: Initialize to an appropriate value
            DateTime expected = DateTime.Now;  // TODO: Initialize to an appropriate value
            DateTime actual;
            actual = target.randomtimecreator(fromtime, totime);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
