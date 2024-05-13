using Encriptador.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Encriptador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptorController : ControllerBase
    {
        private readonly IEncryptorServices _encryptorServices;

        public EncryptorController(IEncryptorServices encryptorServices)
        {
            _encryptorServices = encryptorServices;
        }

        [HttpGet("encrypt")]
        public String Encrypt(String encryptorName, String text, String key)
        {
            return _encryptorServices.Encrypt(encryptorName, text, key);
        }

        [HttpGet("decrypt")]
        public Task<String> Decrypt(String encryptorName, String text, String key)
        {
            switch (encryptorName)
            {
                case "AES":
                    return Task.FromResult(_encryptorServices.AESDecrypt(text, key));
                case "Cesar":
                    return Task.FromResult(_encryptorServices.CesarDecrypt(text, key));
                case "DES":
                    return Task.FromResult(_encryptorServices.DESDecrypt(text, key));
                case "TDES":
                    return Task.FromResult(_encryptorServices.TripleDESDecrypt(text, key));
                case "Null":
                    return Task.FromResult(_encryptorServices.NullDecrypt(text));
                default:
                    return Task.FromResult("Invalid encryptor name");
            }
        }



    }
}
