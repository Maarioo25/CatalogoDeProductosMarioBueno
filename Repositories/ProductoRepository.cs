using CatálogoDeProductos.Data;
using CatálogoDeProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatálogoDeProductos.Repositories;

public class ProductoRepository(AppDbContext context) : IRepository<Producto>
{
    private readonly AppDbContext _context = context;
    public void Add(Producto item)
    {
        _context.Add(item);
        _context.SaveChanges();
    }

    public void Delete(Producto item)
    {
        _context.Remove(item);
        _context.SaveChanges();
    }

    public Producto Get(int id) => _context.Productos.ToList<Producto>().Find(c => c.Id == id);

    public IEnumerable<Producto> GetAll() => _context.Productos.ToList();

    public void Update(Producto item)
    {
        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();
    }
}
