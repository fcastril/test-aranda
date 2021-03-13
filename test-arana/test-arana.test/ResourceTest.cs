using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_arana.wpf.Class;
using Xunit;

namespace test_arana.test
{
    [TestClass]
    public class ResourceTest
    {
        [TestMethod]
        public void TestSO()
        {
            string result = "Windows";
            string SO = Resources.GetSO().Split('|')[0];
            Assert.AreEqual(SO, result);
        }
        [TestMethod]
    
        public void TestMachineName()
        {
            string MachineName = Resources.GetMachine();
            string Result = "DESKTOP-9I4VG9C";

            Assert.AreEqual(MachineName, Result);

        }
        [TestMethod]
        public void TestIP()
        {
            string IP = Resources.GetIP();
            string Result = "192.168.1.4";

            Assert.AreEqual(IP, Result);
        }
    }
}
