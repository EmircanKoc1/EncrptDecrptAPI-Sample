﻿namespace EncrptDecrptAPI.Services.Interfaces
{
    public interface IEncodingService
    {

        byte[] ConvertToBytes(string data);
        string ConvertToString(byte[] data);

    }
}