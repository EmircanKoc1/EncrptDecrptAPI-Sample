using EncrptDecrptAPI.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi("v1");
builder.Services.AddOpenApi("v2");


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTheme(ScalarTheme.BluePlanet);
    });
    //-->  host/scalar/<v1 or v2>
}

app.MapAESEndpoints();

app.UseHttpsRedirection();


app.Run();
