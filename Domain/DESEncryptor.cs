using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public class DESEncryptor : Encryptor
    {
        public DESEncryptor() : base("DES") { }

        public override string Encrypt(string someString, string key)
        {
            byte[] result;
            using (DES DESAlgorithm = DES.Create())
            {
                byte[] vector = Encoding.UTF8.GetBytes(key);
                DESAlgorithm.Key = vector;
                DESAlgorithm.IV = vector;
                ICryptoTransform encryptor = DESAlgorithm.CreateEncryptor(DESAlgorithm.Key, DESAlgorithm.IV);
                using (MemoryStream msEncryptor = new MemoryStream())
                {
                    using (CryptoStream csEncryptor = new CryptoStream(msEncryptor, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(someString);
                        csEncryptor.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
                        csEncryptor.FlushFinalBlock();
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
            using (DES DESAlgorithm = DES.Create())
            {
                byte[] vector = Encoding.UTF8.GetBytes(key);
                DESAlgorithm.Key = vector;
                DESAlgorithm.IV = vector;
                ICryptoTransform decryptor = DESAlgorithm.CreateDecryptor(DESAlgorithm.Key, DESAlgorithm.IV);
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
