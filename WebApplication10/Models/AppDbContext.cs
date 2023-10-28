using System.Data.Entity;
using WebApplication10.Models;

public class AppDbContext : DbContext
{
    public DbSet<Rezervari> Rezervari { get; set; }
    public DbSet<AdaugareTrotinete> AdaugareTrotinete { get; set; }
    public DbSet<AdaugareTrotinete> GesionareTrotinete { get; set; }

}
