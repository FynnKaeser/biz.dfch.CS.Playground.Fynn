using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20200417
{
    [TestClass]
    public class TestClass2
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("TestInitialize2");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Debug.WriteLine("ClassInitialize2");
        }

        [TestMethod]
        public void UnitTest2()
        {
            Debug.WriteLine("UnitTest2");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("TestCleanup2");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Debug.WriteLine("ClassCleanup2");
        }
    }
}