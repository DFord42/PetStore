using PetStore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace PetStore.Data;

public class ProductContext : DbContext
{
    public DbSet<ProductEntity> Products { get; set; }

    public string DbPath { get; }

    public ProductContext()
    {
        var path = Directory.GetCurrentDirectory();
        DbPath = System.IO.Path.Join(path, "products.db");
        Database.EnsureCreated();
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");


}

