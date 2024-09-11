using Microsoft.EntityFrameworkCore;
using TheGame.Core.Entities;

namespace TheGame.Core.Data;

public class CommandDbContext : DbContext
{
    public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
}