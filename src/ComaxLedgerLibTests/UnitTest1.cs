using CommunAxiom.Ledger.ComaxProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComaxLedgerLibTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHash()
        {
            var val = ComaxLedgerHelper.Hash("myholding1");
            Assert.AreEqual("046c0cd0aee203c2e691c2c91eb7c34808d2e0bb66604a9474d0f7d88af1d8a978effd0cb35ba0a073602d3586db04058e5c05f28a196105617f9145a9799cfa", val);
        }


    }
}