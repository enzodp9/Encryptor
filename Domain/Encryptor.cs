using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class Encryptor: IEncryptor
    {
        protected String iName;

        public Encryptor(String name)
        {
            this.iName = name;
        }

  
        public abstract String Encrypt(String someString, String? key);
        public abstract String Decrypt(String someString, String? key);
    }
}
