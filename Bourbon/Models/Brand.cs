namespace Bourbon.Models;

public class Brand
{
  public int BrandId { get; set; }
  public string Name { get; set; }
  public int DistilleryId { get; set; }
  public Distillery Distillery { get; set; }

}
