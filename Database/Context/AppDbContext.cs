using GeoPet.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoPet.Database.Context;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Address> Addresses { get; set; } = default!;
  public DbSet<Pet> Pets { get; set; } = default!;
  public DbSet<Sitter> Sitters { get; set; } = default!;

}