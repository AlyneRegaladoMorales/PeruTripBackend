using Microsoft.EntityFrameworkCore;

namespace C_Data.Context;

public class AppDbContext:DbContext
{
    public AppDbContext()
    {
        
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Para una base de datos remota
        //var connectionString = "server=viaduct.proxy.rlwy.net;port=37660;user=root;password=BH3c2BefCgC3e64CA3DG4FCCbcc1EEFB;database=railway";
        
        //Para una base de datos local
        var connectionString = "Server=127.0.0.1,3306;Uid=root;Pwd=c0mpl1ces;Database=perutrip;";
    }
    
}