using DesafioTec.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.AddEnvConfig();
builder.ResolveDependencies();
builder.AddDbContextConfig();



var app = builder.Build();
app.UseConfigureDevEnvironmentConfig();
app.UseSecurityConfig();
app.Run();
