namespace EncryptDecryptAPI.Services.Interfaces
{
    public interface IRandomNumberGeneratorService
    {
        byte[] GetRandomNumber(int digitCount);

    }
}
