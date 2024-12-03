using EncrptDecrptAPI.Models.Response;

namespace EncrptDecrptAPI.Services.Interfaces
{
    public interface IAESService
    {
        AESEncryptResponseModel Encrypt(string? key, string? IV, string data);
        AESDecryptResponseModel Decrypt(string key, string IV, string data);

    }
}
