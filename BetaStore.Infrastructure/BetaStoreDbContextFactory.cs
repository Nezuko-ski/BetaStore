using BetaStore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class BetaStoreDbContextFactory : IDesignTimeDbContextFactory<BetaStoreDbContext>
{
    public BetaStoreDbContext CreateDbContext(string[] args)
    {
        // Configure the DbContext here
        var optionsBuilder = new DbContextOptionsBuilder<BetaStoreDbContext>();
        optionsBuilder.UseSqlServer("Data Source=LAPTOP-GAA1RH4E;Initial Catalog=betastore-db;Integrated Security=True;TrustServerCertificate=True");

        return new BetaStoreDbContext(optionsBuilder.Options);
    }
}
