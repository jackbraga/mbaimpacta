using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VidaAutistaDotnet.Application.Interfaces;
using VidaAutistaDotnet.Application.Mappings;
using VidaAutistaDotnet.Application.Services;
using VidaAutistaDotnet.Domain.Interfaces;
using VidaAutistaDotnet.Infra.Data;
using VidaAutistaDotnet.Infra.Data.Repositories;


namespace VidaAutistaDotnet.Infra.IoC
{
  public static class DependencyInjection
  {

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
      IConfiguration configuration)
    {
      services.AddScoped<ICalendarioRepository, CalendarioRepository>();
      services.AddScoped<ICalendarioService, CalendarioService>();

      
      services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
      
      services.AddScoped<IConnectionFactory, DefaultMySqlConnectionFactory>();

      return services;
    }

  }
}
