using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Encriptador.Services
{
    class EncryptorServices: IEncryptorServices
    {
        private EncryptorsFactory encryptors = EncryptorsFactory.Instance();

        public string AESEncrypt(string someString, string key)
        {
            return encryptors.GetEncryptor("AES").Encrypt(someString, key);
        }
        public string AESDecrypt(string someString, string key)
        {
            return encryptors.GetEncryptor("AES").Decrypt(someString, key);
        }
        public string CesarEncrypt(string someString, string displacement)
        {
            return encryptors.GetEncryptor("Cesar").Encrypt(someString, displacement);
        }
        public string CesarDecrypt(string someString, string displacement)
        {
            return encryptors.GetEncryptor("Cesar").Decrypt(someString, displacement);
        }
        public string DESEncrypt(string someString, string key)
        {
            return encryptors.GetEncryptor("DES").Encrypt(someString, key);
        }
        public string DESDecrypt(string someString, string key)
        {
            return encryptors.GetEncryptor("DES").Decrypt(someString, key);
        }
        public string TripleDESEncrypt(string someString, string key)
        {
            return encryptors.GetEncryptor("TDES").Encrypt(someString, key);
        }
        public string TripleDESDecrypt(string someString, string key)
        {
            return encryptors.GetEncryptor("TDES").Decrypt(someString, key);
        }
        public string NullEncrypt(string someString)
        {
            return encryptors.GetEncryptor("Null").Encrypt(someString, null);
        }
        public string NullDecrypt(string someString)
        {
            return encryptors.GetEncryptor("Null").Decrypt(someString, null);
        }

        public string Encrypt(string encryptorName, string someString, string key)
        {
            return encryptors.GetEncryptor(encryptorName).Encrypt(someString, key);
        }

        public string Decrypt(string encryptorName, string someString, string key)
        {
            return encryptors.GetEncryptor(encryptorName).Decrypt(someString, key);
        }
    }
}
