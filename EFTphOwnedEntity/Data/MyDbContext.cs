using EFTphOwnedEntity;
using EFTphOwnedEntity.Model;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Cat> Cats { get; set; }


    public string ConnectionString { get; }

    public MyDbContext()
    {
        ConnectionString = "Data Source=.\\MSSQLSERVER01;Initial Catalog=EFTphOwnedEntity;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(ConnectionString);


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>().OwnsOne(
            animal => animal.Legs, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
                ownedNavigationBuilder.OwnsOne(b => b.Current);
                ownedNavigationBuilder.OwnsOne(b => b.Prior);
            }).OwnsOne(
            animal => animal.Torso, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
                ownedNavigationBuilder.OwnsOne(b => b.Current);
                ownedNavigationBuilder.OwnsOne(b => b.Prior);
            }).OwnsOne(
            animal => animal.Head, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
                ownedNavigationBuilder.OwnsOne(b => b.Current);
                ownedNavigationBuilder.OwnsOne(b => b.Prior);
            })
            .HasDiscriminator(s => s.Type)
            .HasValue<Dog>(Enums.AnimalType.Cat)
            .HasValue<Cat>(Enums.AnimalType.Dog);
    }

}
