using Microsoft.EntityFrameworkCore;
using _NET.Models;

namespace _NET.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {
    
  }
  public DbSet<Category> Categories { get; set; }
}