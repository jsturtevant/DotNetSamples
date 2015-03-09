using System;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetSamples
{
    [TestClass]
    public class SecureStringSamples
    {
        [TestMethod]
        public void SecureStringCompare()
        {
            var secureString = new SecureString();
            secureString.AppendChar('s');
            secureString.AppendChar('e');
            secureString.AppendChar('c');
            secureString.AppendChar('u');
            secureString.AppendChar('r');
            secureString.AppendChar('e');

            // test to compare strings.
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Instance is read-only")]
        public void SecureStringIsReadOnly()
        {
            var secureString = new SecureString();
            secureString.AppendChar('s');
            secureString.AppendChar('e');
            secureString.AppendChar('c');
            secureString.AppendChar('u');
            secureString.AppendChar('r');
            secureString.AppendChar('e');

            secureString.MakeReadOnly();

            Assert.IsTrue(secureString.IsReadOnly());
            // will throw.
            secureString.AppendChar('d');
        }

        [TestMethod]
        public void SecurestringCanChangeCharaters()
        {
            var secureString = new SecureString();
            secureString.AppendChar('s');
            secureString.AppendChar('e');
            secureString.AppendChar('c');
            secureString.AppendChar('u');
            secureString.AppendChar('r');
            secureString.AppendChar('e');

            secureString.InsertAt(0,'t');
            
            // test to see that first character is t
        }
    }
}
