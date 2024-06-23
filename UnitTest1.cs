using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test5.Controllers;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException (typeof(Exception))]
        public void TestMethod1()
        {
            AutorizationController controller = new AutorizationController();
            controller.Autorization("", "");
        }
        [TestMethod]
        public void TestMethod2()
        {
            AutorizationController controller1 = new AutorizationController();
            controller1.Autorization("Test2", "Test2");
        }
    }
}
