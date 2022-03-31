using Microsoft.EntityFrameworkCore;

namespace Zoo.Models
{
  public class ZooContext : DbContext
  {
    public ZooContext(DbContextOptions<ZooContext> options)
        : base(options)
    {

    }

    

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Animal>()
        .HasData(
            new Animal { AnimalId = 1, Name = "Gary", Species = "Goose", Age = 13, Gender = "Female"},
            new Animal { AnimalId = 2, Name = "Terry", Species = "Tiger", Age = 4, Gender = "Male"},
            new Animal { AnimalId = 3, Name = "Lawrence", Species = "Lion", Age = 5, Gender = "Male"},
            new Animal { AnimalId = 4, Name = "Gary2", Species = "Goose", Age = 6, Gender = "Male"},
            new Animal { AnimalId = 5, Name = "Penelope", Species = "Peacock", Age = 39, Gender = "Female"},
            new Animal { AnimalId = 6, Name = "Zane", Species = "Zebra", Age = 25, Gender = "Male"},
            new Animal { AnimalId = 7, Name = "Marcus", Species = "Meerkat", Age = 4, Gender = "Male"},
            new Animal { AnimalId = 8, Name = "Zoie", Species = "Zebra", Age = 13, Gender = "Female"},
            new Animal { AnimalId = 9, Name = "Sydney", Species = "Snake", Age = 6, Gender = "Female"},
            new Animal { AnimalId = 10, Name = "Karen", Species = "Kimodo Dragon", Age = 19, Gender = "Female"}
            );
  }
  public DbSet<Animal> Animals { get; set; }
  }
}