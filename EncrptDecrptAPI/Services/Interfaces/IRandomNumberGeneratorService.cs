namespace EncrptDecrptAPI.Services.Interfaces
{
    public interface IRandomNumberGeneratorService
    {
        byte[] GetRandomNumber(int digitCount);

    }
}
