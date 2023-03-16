using System.Collections.Generic;

namespace ConnorBourbon.Models
{
  public class Tag
  {
    public int TagId { get; set; }
    public string Title { get; set; }
    public List<BourbonTag> JoinEntities { get; }
  }
}