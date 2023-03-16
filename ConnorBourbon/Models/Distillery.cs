namespace ConnorBourbon.Models
{
  public class Distillery
  {
    public int DistilleryId { get; set; }
    public string Name { get; set; }
    public List<Brand> Brands {get; set;}
  }
}
