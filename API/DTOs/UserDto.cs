using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
  public class UserDto
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Picture { get; set; }
    public string Token { get; set; }

  }
}