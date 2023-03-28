using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConnorBourbon.Models
{
  public class BourbonContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Bourbon> Bourbons { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Distillery> Distilleries { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<BourbonTag> BourbonTag { get; set; }

    public BourbonContext(DbContextOptions options) : base(options) { }
  }
}