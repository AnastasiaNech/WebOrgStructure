using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebSiteOrgStructure.Models;

namespace OnlyOrgStructure.Data;
public class DbContextConfigurer : DbContext
{
    public DbContextConfigurer(DbContextOptions<DbContextConfigurer> options) : base(options)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source = USER-PC\SQLEXPRESS; Initial Catalog = OnlyDb; User ID = na; Password = 1234; TrustServerCertificate = true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Department>().ToTable("Departments");
        modelBuilder.Entity<User>().ToTable("Users");
        base.OnModelCreating(modelBuilder);

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }

}

