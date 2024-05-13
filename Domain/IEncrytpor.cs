using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IEncryptor
    {
        public String Encrypt(String someString, String? key);
        public String Decrypt(String someString, String? key);
    }
}
