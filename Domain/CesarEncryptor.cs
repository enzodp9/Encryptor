using System;
using System.Text;

namespace Domain
{
    public class CesarEncryptor : Encryptor
    {
        private int displacement;

        public CesarEncryptor() : base("Cesar") { }

        public override string Encrypt(string someString, string key)
        {
            this.displacement = Int32.Parse(key);
            string abc = "abcdefghijklmñnopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890_-+,#$%&/()=¿?¡!|,.;:{}[]";
            StringBuilder result = new StringBuilder();

            foreach (char character in someString)
            {
                int index = abc.IndexOf(character);
                if (index != -1)
                {
                    int newIndex = (index + this.displacement) % abc.Length;
                    result.Append(abc[newIndex]);
                }
                else
                {
                    result.Append(character);
                }
            }

            return result.ToString();
        }

        public override string Decrypt(string someString, string key)
        {
            this.displacement = Int32.Parse(key);
            string abc = "abcdefghijklmñnopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890_-+,#$%&/()=¿?¡!|,.;:{}[]";
            StringBuilder result = new StringBuilder();

            foreach (char character in someString)
            {
                int index = abc.IndexOf(character);
                if (index != -1)
                {
                    int newIndex = (index - this.displacement) % abc.Length;
                    if (newIndex < 0)
                    {
                        newIndex += abc.Length;
                    }
                    result.Append(abc[newIndex]);
                }
                else
                {
                    result.Append(character);
                }
            }

            return result.ToString();
        }
    }
}
