using Microsoft.EntityFrameworkCore;
using PetsApi.Models;

namespace PetsApi.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Publication> Publications { get; set; }
    public DbSet<Comment> Comments { get; set; }
  }
}