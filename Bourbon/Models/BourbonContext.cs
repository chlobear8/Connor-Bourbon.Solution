using Microsoft.EntityFrameworkCore;

namespace Bourbon.Models
{
  public class BourbonContext : DbContext
  {
    public DbSet<Bourbon> Bourbons { get; set; }

    public BourbonContext(DbContextOptions options) : base(options) { }
  }
}