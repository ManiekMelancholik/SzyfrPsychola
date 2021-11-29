using System;
using System.Collections.Generic;
using System.Text;

namespace SzyfrPsychola.Tests
{
    internal class CipherTest : TestClass
    {
        public string TestStringA;
        public string TestStringB;
        CipherTest(string s1 = "ABCDEFGHIJKLMNOPRSTUWYZ", string s2= "abcdefghijklmnoprstuwyz")
        {
            this.TestStringA = s1;
            this.TestStringB = s2;
        }
        public override bool Test(char c)
        {
            return true;
        }
    }
}
