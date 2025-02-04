using CatálogoDeProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatálogoDeProductos.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public required virtual DbSet<Producto> Productos { get; set; }
    public required virtual DbSet<Categoria> Categorias { get; set; }

}
