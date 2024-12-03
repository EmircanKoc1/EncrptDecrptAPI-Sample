using EncryptDecryptAPI.Models.AES;

namespace EncryptDecryptAPI.Services.Interfaces
{
    public interface IAESService
    {
        AESEncryptResponseModel Encrypt(string? key, string? IV, string data);
        AESDecryptResponseModel Decrypt(string key, string IV, string data);

    }
}
