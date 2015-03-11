using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
            //  Could take input from console or another api
            var secureString = new SecureString();
            
            secureString.AppendChar('s');
            secureString.AppendChar('e');
            secureString.AppendChar('c');
            secureString.AppendChar('u');
            secureString.AppendChar('r');
            secureString.AppendChar('e');


            IntPtr secureStringPointer = IntPtr.Zero;
            try
            {
                // copy to unmanaged memory and decrypt
                secureStringPointer = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                
                // use the pointer with a function like Win32 API logon
                // full example (https://msdn.microsoft.com/en-us/library/system.runtime.interopservices.marshal.securestringtoglobalallocunicode(v=vs.110).aspx)
                // returnValue = LogonUser(userName, domainName, secureStringPointer, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(secureStringPointer);   
            }
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
