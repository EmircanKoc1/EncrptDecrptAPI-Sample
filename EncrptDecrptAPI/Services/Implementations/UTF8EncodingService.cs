using EncryptDecryptAPI.Services.Interfaces;
using System.Text;

namespace EncryptDecryptAPI.Services.Implementations
{
    public class UTF8EncodingService : IEncodingService
    {
        public string ConvertToString(byte[] data)
            => Encoding.UTF8.GetString(data);


        public byte[] ConvertToBytes(string data)
            => Encoding.UTF8.GetBytes(data);

    }
}
