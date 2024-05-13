namespace Encriptador.Services
{
    public interface IEncryptorServices
    {
        public string AESEncrypt(string someString, string key);
        public string AESDecrypt(string someString, string key);
        public string CesarEncrypt(string someString, string displacement);
        public string CesarDecrypt(string someString, string displacement);
        public string DESEncrypt(string someString, string key);
        public string DESDecrypt(string someString, string key);
        public string TripleDESEncrypt(string someString, string key);
        public string TripleDESDecrypt(string someString, string key);
        public string NullEncrypt(string someString);
        public string NullDecrypt(string someString);
        public string Encrypt(string encryptorName, string someString, string key);
        public string Decrypt(string encryptorName, string someString, string key);
    }
}
