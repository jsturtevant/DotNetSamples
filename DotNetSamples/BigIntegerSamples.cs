using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetSamples
{
    [TestClass]
    public class BigIntegerSamples
    {
        [TestMethod]
        public void BigIntegerAddsJustLikeInteger()
        {
            var x = new BigInteger(1);
            var y = new BigInteger(200);

            var z = x + y;

            Assert.AreEqual(201, z);
        }

        [TestMethod]
        public void BigIntegerCreatedWithByte()
        {
            var bytes = new byte[] {1, 2, 34, 45, 12, 54, 23, 42, 88, 45, 45, 45, 12};

            var x = new BigInteger(bytes);
            
            Trace.WriteLine(x);
            Assert.IsInstanceOfType(x, typeof(BigInteger));
        }

        [TestMethod]
        public void BigIntegerCreatedWithMaxValue()
        {
            var x = BigInteger.Multiply(Int32.MaxValue, 99999);

            Trace.WriteLine(x);
            Assert.IsInstanceOfType(x, typeof(BigInteger));
        }

        [TestMethod]
        public void BigIntegerCreatedWithString()
        {
            string googol = "1".PadRight(100, '0');
            var x = BigInteger.Parse(googol);

            Trace.WriteLine(x);
            Assert.IsInstanceOfType(x, typeof(BigInteger));
        }
    }
}