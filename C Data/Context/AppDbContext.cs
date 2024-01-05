using C_Data.Model;
using Microsoft.EntityFrameworkCore;

namespace C_Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Rol> Rols { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Para una base de datos remota
        //var connectionString = "server=viaduct.proxy.rlwy.net;port=37660;user=root;password=BH3c2BefCgC3e64CA3DG4FCCbcc1EEFB;database=railway";
        
        //Para una base de datos local
        var connectionString = "Server=127.0.0.1,3306;Uid=root;Pwd=c0mpl1ces;Database=perutrip;";
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Rol>().ToTable("Rol");
        builder.Entity<Rol>().HasKey(p => p.id);
        builder.Entity<Rol>().Property(p => p.rol).IsRequired().HasMaxLength(20);
        
        builder.Entity<Usuario>().ToTable("Usuario");
        builder.Entity<Usuario>().HasKey(p => p.id);
        builder.Entity<Usuario>().Property(p => p.correo).IsRequired().HasMaxLength(20);
        builder.Entity<Usuario>().Property(p => p.contrasena).IsRequired().HasMaxLength(20);
        builder.Entity<Usuario>().Property(p => p.estado).IsRequired().HasMaxLength(20);
        builder.Entity<Usuario>().Property(p => p.fechaCreacion).HasDefaultValue(DateTime.Now);
        builder.Entity<Usuario>().Property(p => p.rolId).IsRequired();
        builder.Entity<Usuario>()
            .HasOne(p => p.rol)
            .WithMany(p => p.listaUsuarios)
            .HasForeignKey(p => p.rolId);
    }
    
}