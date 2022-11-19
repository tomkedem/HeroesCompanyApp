using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
  public class RegisterDto
  {
    [Required]
    public string Username { get; set; }
    
   [Required]
   [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "At least 8 charts with ▪ One capital letter ▪ One digit ▪ One non-alphanumeric char")]
    public string Password { get; set; }
  }
}