using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Eventing.Data;

public sealed class EventingDbContextFactory : IDesignTimeDbContextFactory<EventingDbContext>
{
    // Only used for EF Core migrations in .NET Aspire.
    private const string ConnectionString = "Host=localhost;Port=5432;Database=eventingdb;Username=eventinguser;Password=eventing123";
    
    public EventingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EventingDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);

        return new EventingDbContext(optionsBuilder.Options);
    }
}