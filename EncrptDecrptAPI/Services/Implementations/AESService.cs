using EncrptDecrptAPI.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EncrptDecrptAPI.Services.Implementations
{
    public class AESService : IAESService
    {
        public string Encrypt(string key, string IV, string data)
        {
            using var aes = Aes.Create();

            aes.IV = Encoding.UTF8.GetBytes(IV);
            aes.Key = Encoding.UTF8.GetBytes(key);

            using var encrptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encrptor, CryptoStreamMode.Write);
            using var writer = new StreamWriter(cryptoStream);

            writer.Write(data);

            return Convert.ToBase64String(memoryStream.ToArray());

        }

        public string Decrypt(string key, string IV, string data)
        {

            using var aes = Aes.Create();

            aes.IV = Encoding.UTF8.GetBytes(IV);
            aes.Key = Encoding.UTF8.GetBytes(key);

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream(Convert.FromBase64String(data));
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd();

        }
    }
}
