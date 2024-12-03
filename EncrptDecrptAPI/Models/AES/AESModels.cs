namespace EncrptDecrptAPI.Models.Response;

public record AESEncryptResponseModel(string Key, string IV, string encryptedValue, bool isSuccess);

public record AESEncryptRequestModel(string? Key, string? IV, string data);


public record AESDecryptResponseModel(string Data, bool isSuccess);
public record AESDecryptRequestModel(string Key, string IV, string data);