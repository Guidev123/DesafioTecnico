using DesafioTec.Business.Interfaces.Repository;
using DesafioTec.Business.Interfaces.Services;
using DesafioTec.Business.Interfaces;
using DesafioTec.Business.Notificacoes;
using DesafioTec.Business.Services;
using DesafioTec.Data.Repository;
using DesafioTec.Data;

namespace DesafioTec.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependencies(this WebApplicationBuilder builder)
        {
            //DATA
            builder.Services.AddScoped<DesafioTecDb>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

            //NOTIFICACOES
            builder.Services.AddScoped<INotificador, Notificador>();


            //SERVICES
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();

            //AUTOMAPPER
            builder.Services.AddAutoMapper(typeof(Program));
        }
    }
}
