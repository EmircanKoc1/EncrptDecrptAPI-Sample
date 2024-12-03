using EncrptDecrptAPI.Services.Interfaces;

namespace EncrptDecrptAPI.Services.Implementations
{
    public class Base64Service : IBase64Service
    {
        public byte[] ConvertFromString(string str)
            => Convert.FromBase64String(str);

        public string ConvertToString(byte[] arr)
            => Convert.ToBase64String(arr);
    }
}
