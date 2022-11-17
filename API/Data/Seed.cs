using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class Seed
  {
    public static async Task SeedUsers(DataContext context)
    {
      if (await context.Trainers.AnyAsync()) return;

      var trainersData = await System.IO.File.ReadAllTextAsync("Data/TrainersSeedData.json");
      var trainers = JsonSerializer.Deserialize<List<Trainers>>(trainersData);
      if (trainers == null) return;

      foreach (var trainer in trainers)
      {
        using var hmac = new HMACSHA512();
        trainer.UserName = trainer.UserName.ToLower();
        trainer.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("A12@baba"));
        trainer.PasswordSalt = hmac.Key;

        context.Trainers.Add(trainer);

      }

      await context.SaveChangesAsync();

      if (await context.Heroes.AnyAsync()) return;

      var heroesData = await System.IO.File.ReadAllTextAsync("Data/HeroesSeedData.json");
      var heroes = JsonSerializer.Deserialize<List<Heroes>>(heroesData);
      if (heroes == null) return;
      foreach (var heroe in heroes)
      {
        context.Heroes.Add(heroe);
      }

      await context.SaveChangesAsync();

    }
  }
}
