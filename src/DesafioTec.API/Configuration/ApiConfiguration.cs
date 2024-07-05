using DesafioTec.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioTec.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddEnvConfig(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        public static void AddDbContextConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DesafioTecDb>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }

        public static void UseConfigureDevEnvironmentConfig(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger();
        }

        public static void UseSecurityConfig(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
        }
    }
}
