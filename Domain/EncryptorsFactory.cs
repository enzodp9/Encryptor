using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class EncryptorsFactory
    {
        private static EncryptorsFactory instance;
        private Dictionary<String,IEncryptor> encryptors = new Dictionary<string, IEncryptor>();
        private EncryptorsFactory()
        {
            IEncryptor nullEncryptor = new NullEncryptor();
            IEncryptor AESEncryptor = new AESEncryptor();
            IEncryptor cesarEncryptor = new CesarEncryptor();
            IEncryptor DESEncryptor = new DESEncryptor();
            IEncryptor TDESEncryptor = new TripleDESEncryptor();
            encryptors.Add("Null", nullEncryptor);
            encryptors.Add("AES", AESEncryptor);
            encryptors.Add("Cesar", cesarEncryptor);
            encryptors.Add("DES", DESEncryptor);
            encryptors.Add("TDES", TDESEncryptor);
        }
        public static EncryptorsFactory Instance()
        {
            if (instance == null)
            {
                instance = new EncryptorsFactory();
            }
            return instance;
        }

        public IEncryptor GetEncryptor(String name)
        {
            IEncryptor encryptor = new NullEncryptor();
            foreach (KeyValuePair<String, IEncryptor> kvp in this.encryptors)
            {
                if (kvp.Key == name)
                {
                    encryptor = kvp.Value;
                    break;
                }
            }
            return encryptor;
        }
    }
}
