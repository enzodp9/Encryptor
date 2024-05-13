using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class NullEncryptor: Encryptor
    {
        public NullEncryptor(): base("Null") {}
        public override string Encrypt(string someString, string? key)
        {
            return someString;
        }
        public override string Decrypt(string someString, string? key)
        {
            return someString;
        }
    }
}
