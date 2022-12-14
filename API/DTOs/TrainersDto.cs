using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
  public class TrainerDto
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string KnownAs { get; set; }
    public string Gender { get; set; }
    public string City { get; set; }
    public string Picture { get; set; }
  }
}