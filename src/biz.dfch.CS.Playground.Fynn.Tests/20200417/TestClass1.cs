using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Playground.Fynn.Tests._20200417
{
    [TestClass]
    public class TestClass1
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("TestInitialize1");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Debug.WriteLine("ClassInitialize1");
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Debug.WriteLine("AssemblyInitialize1");
        }

        [TestMethod]
        public void UnitTest1()
        {
            Debug.WriteLine("UnitTest1");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("TestCleanup1");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Debug.WriteLine("ClassCleanup1");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Debug.WriteLine("AssemblyCleanup1");
        }
    }
}
