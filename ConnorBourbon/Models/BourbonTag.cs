namespace ConnorBourbon.Models
{
  public class BourbonTag
  {       
    public int BourbonTagId { get; set; }
    public int BourbonId { get; set; }
    public Bourbon Bourbon { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
  }
}