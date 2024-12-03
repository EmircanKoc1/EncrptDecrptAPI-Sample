using EncrptDecrptAPI.Models.Response;
using EncrptDecrptAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EncrptDecrptAPI.Endpoints
{
    public static class AESEndpoints
    {

        public static void MapAESEndpoints(this WebApplication app)
        {

            app.MapPost("encrpt", (
                [FromServices] IAESService _aesService,
                 [FromBody] AESEncryptRequestModel requestModel) =>
            {
                var responseObject = _aesService.Encrypt(requestModel.Key, requestModel.IV, requestModel.data);

                return responseObject.isSuccess
                ? Results.Ok(responseObject)
                : Results.BadRequest(responseObject);


            }).WithTags("Aes Methods")
              .Produces<AESEncryptResponseModel>((int)HttpStatusCode.OK)
              .Produces<AESEncryptResponseModel>((int)HttpStatusCode.BadRequest);



            app.MapPost("decrpt", (
                  [FromServices] IAESService _aesService,
                  [FromBody] AESDecryptRequestModel requestModel) =>
            {
                AESDecryptResponseModel? responseObject = _aesService.Decrypt(requestModel.Key, requestModel.IV, requestModel.data);

                return responseObject.isSuccess
                ? Results.Ok(responseObject)
                : Results.BadRequest(responseObject);

            }).WithTags("Aes Methods")
            .Produces<AESDecryptResponseModel>((int)HttpStatusCode.OK)
            .Produces<AESDecryptResponseModel>((int)HttpStatusCode.BadRequest);

        }



    }
}
