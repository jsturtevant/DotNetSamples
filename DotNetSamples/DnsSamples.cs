using System;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetSamples
{
    [TestClass]
    public class DnsSamples
    {
        [TestMethod]
        public void DnsReturnsIpAddresses()
        {
            IPAddress[] ipAddresses = Dns.GetHostAddresses("jamessturtevant.com");

            Assert.AreEqual("162.255.119.254", ipAddresses.First().ToString());
        }

        [TestMethod]
        public void DnsReturnsHostAddress()
        {
            // May fail if IP changes
            IPHostEntry hostEntry = Dns.GetHostEntry("192.30.252.131");

            Assert.AreEqual("github.com", hostEntry.HostName);
        }

        [TestMethod]
        public void DnsLocalhost()
        {
            string localHostName = Dns.GetHostName();

            //name will change depending on the computer you are on
            Assert.IsNotNull(localHostName);
        }
    }
}
