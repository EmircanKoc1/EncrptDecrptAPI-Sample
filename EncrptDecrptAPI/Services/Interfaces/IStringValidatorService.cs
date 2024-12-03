namespace EncryptDecryptAPI.Services.Interfaces
{
    public interface IStringValidatorService
    {
        bool isNullOrEmpty(string value);

        bool isNullOrWhiteSpace(string value);

        bool isValid(string value);
    }
}
