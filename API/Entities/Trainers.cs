using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
  public class Trainers
  {
    public int Id { get; set; }
    public string UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string KnownAs { get; set; }
    public string Gender { get; set; }
    public string City { get; set; }
    public string Picture { get; set; }

  }
}