using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConnorBourbon.Models
{
  public class Bourbon
  {
    public int BourbonId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public Brand Brand { get; set; }
    public int BrandId { get; set; }
    public List<BourbonTag> JoinEntities { get; }
    public ApplicationUser User { get; set; }
  }
}
