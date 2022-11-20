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
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


      string connString = config.GetConnectionString("DefaultConnection");

      services.AddDbContext<DataContext>(options =>
      {
        options.UseSqlServer(connString);
        //options.UseNpgsql(connString);
      });
      return services;
    }
  }
}