using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {

      services.AddScoped<ITokenService, TokenService>();
      services.AddScoped<ITrainerRepository, TrainerRepository>();
      services.AddScoped<IHeroRepository, HeroRepository>();

      services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
 

      string connString = config.GetConnectionString("DefaultConnection");

      services.AddDbContext<DataContext>(options =>
      {
        options.UseSqlServer(connString);
      });
      return services;
    }
  }
}