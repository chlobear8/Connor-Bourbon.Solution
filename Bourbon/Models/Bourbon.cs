namespace ConnorBourbon.Models;

public class Bourbon
{
    public int BourbonId { get; set; }
    public string Name { get; set; }
    public Brand Brand { get; set; }
    public int BrandId { get; set; }
}
