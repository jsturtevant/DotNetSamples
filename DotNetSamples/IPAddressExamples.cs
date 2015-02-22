using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetSamples
{
    [TestClass]
    public class IPAddressExamples
    {
        [TestMethod]
        public void ParseIPAddress()
        {
            IPAddress address;

            Assert.IsTrue(IPAddress.TryParse("10.2.12.123", out address));
            Assert.IsFalse(IPAddress.TryParse("10.2.12.1234", out address));
        }

        [TestMethod]
        public void IsLoopback()
        {
            IPAddress loopbackAddress = IPAddress.Parse("127.0.0.1");
            Assert.IsTrue(IPAddress.IsLoopback(loopbackAddress));
            
            IPAddress ipAddress = IPAddress.Parse("77.2.4.66");
            Assert.IsFalse(IPAddress.IsLoopback(ipAddress));
        }

        [TestMethod]
        public void IsIPV6()
        {
            IPAddress ipv6Address = IPAddress.Parse("2001:0db8:85a3:0000:0000:8a2e:0370:7334");
            Assert.AreEqual(AddressFamily.InterNetworkV6 , ipv6Address.AddressFamily);

            ipv6Address = IPAddress.Parse("2001:db8:85a3::8a2e:370:7334");
            Assert.AreEqual(AddressFamily.InterNetworkV6, ipv6Address.AddressFamily);
        }

        [TestMethod]
        public void Ipv4Tov6()
        {
            IPAddress ipv4Address = IPAddress.Parse("10.3.5.156");
            IPAddress ipv6Address = ipv4Address.MapToIPv6();
            Assert.AreEqual(AddressFamily.InterNetworkV6, ipv6Address.AddressFamily);

          
        }

        [TestMethod]
        public void Ipv6Tov4()
        {
            IPAddress ipv6Address = IPAddress.Parse("2001:0db8:85a3:0000:0000:8a2e:0370:7334");
            IPAddress ipv4Address = ipv6Address.MapToIPv4();
            Assert.AreEqual(AddressFamily.InterNetwork, ipv4Address.AddressFamily);
        }


    }
}
