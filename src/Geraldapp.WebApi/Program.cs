using Geraldapp.WebApi.Config;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureWebApplication();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();
app.ConfigureApplication();

app.Run();