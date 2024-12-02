namespace EncrptDecrptAPI.Services.Interfaces
{
    public interface IAESService
    {
        string Encrypt(string key, string IV, string data);
        string Decrypt(string key, string IV, string data);

    }
}
