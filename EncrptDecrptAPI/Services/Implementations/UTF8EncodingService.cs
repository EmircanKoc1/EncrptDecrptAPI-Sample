using EncrptDecrptAPI.Services.Interfaces;
using System.Text;

namespace EncrptDecrptAPI.Services.Implementations
{
    public class UTF8EncodingService : IEncodingService
    {
        public string ConvertToString(byte[] data)
            => Encoding.UTF8.GetString(data);


        public byte[] ConvertToBytes(string data)
            => Encoding.UTF8.GetBytes(data);

    }
}
