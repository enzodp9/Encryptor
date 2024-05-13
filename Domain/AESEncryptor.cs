using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public class AESEncryptor : Encryptor
    {
        public AESEncryptor() : base("AES") { }

        public override string Encrypt(string someString, string key)
        {
            byte[] result;
            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.Key = Encoding.UTF8.GetBytes(key);
                aesAlgorithm.IV = new byte[aesAlgorithm.BlockSize / 8];
                ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor();
                using (MemoryStream msEncryptor = new MemoryStream())
                {
                    using (CryptoStream csEncryptor = new CryptoStream(msEncryptor, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncryptor = new StreamWriter(csEncryptor))
                        {
                            swEncryptor.Write(someString);
                        }
                        result = msEncryptor.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(result);
        }

        public override string Decrypt(string someString, string key)
        {
            byte[] encrypted = Convert.FromBase64String(someString);
            string decrypted = null;
            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.Key = Encoding.UTF8.GetBytes(key);
                aesAlgorithm.IV = new byte[aesAlgorithm.BlockSize / 8];
                ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor();
                using (MemoryStream msDecryptor = new MemoryStream(encrypted))
                {
                    using (CryptoStream csDecryptor = new CryptoStream(msDecryptor, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecryptor = new StreamReader(csDecryptor))
                        {
                            decrypted = srDecryptor.ReadToEnd();
                        }
                    }
                }
            }
            return decrypted;
        }
    }
}
