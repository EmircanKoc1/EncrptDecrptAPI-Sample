namespace EncryptDecryptAPI.Services.Interfaces
{
    public interface IBase64Service
    {
        string ConvertToString(byte[] arr);
        byte[] ConvertFromString(string str);

    }
}
