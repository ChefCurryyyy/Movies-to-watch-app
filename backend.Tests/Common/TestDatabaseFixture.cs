using DotNet.Testcontainers.Builders;
using Microsoft.EntityFrameworkCore;
using MoviesToWatchApp.Backend.Data;
using Testcontainers.PostgreSql;

namespace Backend.Tests;

public class TestDatabaseFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithDatabase("test_db")
        .WithUsername("user")
        .WithPassword("password")
        .Build();

    public AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(_dbContainer.GetConnectionString())
            .Options;
        
        return new AppDbContext(options);
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        using var context = CreateContext();
        await context.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync() => await _dbContainer.StopAsync();
}
