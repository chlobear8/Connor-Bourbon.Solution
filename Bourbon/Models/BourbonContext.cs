using Microsoft.EntityFrameworkCore;

namespace ConnorBourbon.Models;

public class BourbonContext : DbContext
{
  public DbSet<Bourbon> Bourbons { get; set; }
  public DbSet<Brand> Brands { get; set; }
  public DbSet<Distillery> Distilleries { get; set; }
  public DbSet<Juice> JuiceTypes { get; set; }

  public BourbonContext(DbContextOptions options) : base(options) { }
}