using CatálogoDeProductos.Data;
using CatálogoDeProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatálogoDeProductos.Repositories;

public class CategoriaRepository(AppDbContext context) : IRepository<Categoria>
{
    private readonly AppDbContext _context = context;
    public void Add(Categoria item)
    {
        _context.Add(item);
        _context.SaveChanges();
    }

    public void Delete(Categoria item)
    {
        _context.Remove(item);
        _context.SaveChanges();
    }

    public Categoria Get(int id) => _context.Categorias.ToList<Categoria>().Find(c => c.Id == id);

    public IEnumerable<Categoria> GetAll() => _context.Categorias.ToList();

    public void Update(Categoria item)
    {
        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();
    }


}
