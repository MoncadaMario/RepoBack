using RepoBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace RepoBackEnd.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>().ToTable("usuarios");
        modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("nombre");
        modelBuilder.Entity<Usuario>().Property(u => u.Correo).HasColumnName("correo");
        modelBuilder.Entity<Usuario>().Property(u => u.Contrasena).HasColumnName("contrasena");
        

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Producto>().ToTable("productos");
        modelBuilder.Entity<Producto>().Property(u => u.Nombre).HasColumnName("nombre");
        modelBuilder.Entity<Producto>().Property(u => u.Categoria).HasColumnName("categoria");
        modelBuilder.Entity<Producto>().Property(u => u.Precio).HasColumnName("precio");
        modelBuilder.Entity<Producto>().Property(u => u.Cantidad).HasColumnName("cantidad");
    }

}
