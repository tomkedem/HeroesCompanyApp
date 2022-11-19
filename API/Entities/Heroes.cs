using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
  
  public class Heroes
  {
   
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Ability { get; set; }
    public DateTime StartedToTrain { get; set; }
    public string SuitColor { get; set; }
    public float StartingPower { get; set; }
    public float CurrentPower { get; set; }
    public string Picture { get; set; }
    public int TrainerId { get; set; } 
    public DateTime TrainingDate { get; set; }
    public int TotalTrainingToday { get; set; } 
  }
}