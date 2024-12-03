using EncrptDecrptAPI.Services.Interfaces;

namespace EncrptDecrptAPI.Services.Implementations
{
    public class StringValidatorService : IStringValidatorService
    {
        public bool isNullOrEmpty(string value)
           => string.IsNullOrEmpty(value);

        public bool isNullOrWhiteSpace(string value)
            => string.IsNullOrWhiteSpace(value);

        public bool isValid(string value)
            => !isNullOrWhiteSpace(value) && value.Length >= 16;
    }
}
