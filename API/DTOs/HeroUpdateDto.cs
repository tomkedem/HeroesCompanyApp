using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
  public class HeroUpdateDto
  {
    public Guid Id { get; set; }
    public int TrainerId { get; set; }
    public DateTime TrainingDate { get; set; }
    public int TotalTrainingToday { get; set; }
    public float CurrentPower { get; set; }

  }
}