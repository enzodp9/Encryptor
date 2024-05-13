using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Domain
{
    public class TripleDESEncryptor : Encryptor
    {
        public TripleDESEncryptor() : base("TDES") { }

        public override string Encrypt(string someString, string key)
        {
            byte[] result;
            using (TripleDES TDESAlgorithm = TripleDES.Create())
            {
                byte[] aKey = Encoding.UTF8.GetBytes(key);
                byte[] iv = new byte[TDESAlgorithm.BlockSize / 8];
                TDESAlgorithm.Key = aKey;
                TDESAlgorithm.IV = iv;
                ICryptoTransform encryptor = TDESAlgorithm.CreateEncryptor(TDESAlgorithm.Key, TDESAlgorithm.IV);
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
            using (TripleDES TDESAlgorithm = TripleDES.Create())
            {
                byte[] aKey = Encoding.UTF8.GetBytes(key);
                byte[] iv = new byte[TDESAlgorithm.BlockSize / 8];
                TDESAlgorithm.Key = aKey;
                TDESAlgorithm.IV = iv;
                ICryptoTransform decryptor = TDESAlgorithm.CreateDecryptor(TDESAlgorithm.Key, TDESAlgorithm.IV);
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
