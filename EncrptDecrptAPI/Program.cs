using EncryptDecryptAPI.Endpoints;
using EncryptDecryptAPI.Services.Implementations;
using EncryptDecryptAPI.Services.Interfaces;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi("v1");
builder.Services.AddOpenApi("v2");

builder.Services.AddSingleton<IAESService, AESService>();
builder.Services.AddSingleton<IStringValidatorService, StringValidatorService>();
builder.Services.AddSingleton<IEncodingService, UTF8EncodingService>();
builder.Services.AddSingleton<IRandomNumberGeneratorService, RandomNumberGeneratorService>();
builder.Services.AddSingleton<IBase64Service, Base64Service>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTheme(ScalarTheme.BluePlanet);
    });
    //-->  <host>/scalar/<v1 or v2>
}

app.MapAESEndpoints();

app.UseHttpsRedirection();


app.Run();
