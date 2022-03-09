
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpcInject();

var app = builder.Build();

app.UseGrpcInject();

app.Run();


