namespace Bourbon.Models
{
    public class Bourbon
    {
        public int BourbonId { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public Juice Juice { get; set; }
        public int JuiceId { get; set; }
    }
}