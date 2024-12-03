using EncryptDecryptAPI.Models.AES;
using EncryptDecryptAPI.Services.Interfaces;
using System.Security.Cryptography;

namespace EncryptDecryptAPI.Services.Implementations
{
    public class AESService(
        IEncodingService _encodingService,
        IRandomNumberGeneratorService _randomNumberGeneratorService,
        IStringValidatorService _stringValidatorService,
        IBase64Service _base64Service) : IAESService
    {
        public AESEncryptResponseModel Encrypt(string? key, string? IV, string data)
        {
            using var aes = Aes.Create();

            if (!_stringValidatorService.isValid(key))
                aes.Key = _randomNumberGeneratorService.GetRandomNumber(16);
            else
                aes.Key = _encodingService.ConvertToBytes(key);

            if (!_stringValidatorService.isValid(IV))
                aes.IV = _randomNumberGeneratorService.GetRandomNumber(16);
            else
                aes.IV = _encodingService.ConvertToBytes(IV);



            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            using (var writer = new StreamWriter(cryptoStream))
            {
                writer.Write(data);
            }


            var base64AesKey = _base64Service.ConvertToString(aes.Key);
            var base64AesIV = _base64Service.ConvertToString(aes.IV);
            var base64EncryptedData = _base64Service.ConvertToString(memoryStream.ToArray());

            return new AESEncryptResponseModel(base64AesKey, base64AesIV, base64EncryptedData, true);

        }

        public AESDecryptResponseModel Decrypt(string key, string IV, string data)
        {

            if (!_stringValidatorService.isValid(IV) || !_stringValidatorService.isValid(key))
                return new AESDecryptResponseModel(string.Empty, false);

            using var aes = Aes.Create();

            aes.Key = _base64Service.ConvertFromString(key);
            aes.IV = _base64Service.ConvertFromString(IV);

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            var base64EncryptedDataBytes = _base64Service.ConvertFromString(data);
            using var memoryStream = new MemoryStream(base64EncryptedDataBytes);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            string? decryptedData;
            using var reader = new StreamReader(cryptoStream);
            {
                decryptedData = reader.ReadToEnd();
            }

            return new AESDecryptResponseModel(decryptedData, true);

        }
    }
}
