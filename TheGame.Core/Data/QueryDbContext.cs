using Microsoft.EntityFrameworkCore;
using TheGame.Core.Entities;

namespace TheGame.Core.Data;

public class QueryDbContext : DbContext
{
    public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
}