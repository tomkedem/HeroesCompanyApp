using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;

namespace API.Controllers
{
  public class AccountController : BaseApiController
  {
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;
    public AccountController(DataContext context, ITokenService tokenService)
    {
      _tokenService = tokenService;
      _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
      if (await UserExist(registerDto.Username)) return BadRequest("Username is taken");

      using var hmac = new HMACSHA512();

      var user = new Trainers
      {
        UserName = registerDto.Username.ToLower(),
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        PasswordSalt = hmac.Key
      };

      _context.Trainers.Add(user);
      await _context.SaveChangesAsync();
      return new UserDto
      {
        Username = user.UserName,
        Token = _tokenService.CreateToken(user)
      };
    }
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
      var user = await _context.Trainers
          .SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
      if (user == null) return Unauthorized("Invalid username");

      using var hmac = new HMACSHA512(user.PasswordSalt);

      var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

      for (int i = 0; i < computeHash.Length; i++)
      {
        if (computeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
      }

      return new UserDto
      {
        Id = user.Id,
        Username = user.UserName,
        Picture = user.Picture,
        Token = _tokenService.CreateToken(user)
      };

    }
    private async Task<bool> UserExist(string userName)
    {
      return await _context.Trainers.AnyAsync(x => x.UserName == userName.ToLower());
    }
  }
}