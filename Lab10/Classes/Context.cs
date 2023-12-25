using Microsoft.EntityFrameworkCore;
using Lab10.Structures;

namespace Lab10.Classes;

public class TickersContext : DbContext
{
    public DbSet<Tickers> Tickers { get; set; }
    public DbSet<Prices> Prices { get; set; }
    public DbSet<TodayCondition> TodayCondition { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=localhost;user=test_user;password=password;database=Tickers;", 
            new MySqlServerVersion(new Version(8, 0, 35))
        );
    }
}