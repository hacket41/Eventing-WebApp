using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Eventing.Data;

public sealed class EventingDbContextFactory : IDesignTimeDbContextFactory<EventingDbContext>
{
    // Only used for EF Core migrations in .NET Aspire.
    // You can temporarily set a valid connection string here 
    // when running `dotnet ef database update` outside of Aspire.
    private const string ConnectionString = "Host=localhost;Port=58924;Username=postgres;Password=7RqQ}4dNDhgKnX(QMrR7Wk;Database=eventing-db\n\n";
    
    public EventingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EventingDbContext>();
        optionsBuilder.UseNpgsql(ConnectionString);

        return new EventingDbContext(optionsBuilder.Options);
    }
}