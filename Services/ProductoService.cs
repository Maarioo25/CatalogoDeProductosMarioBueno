using CatálogoDeProductos.Models;
using CatálogoDeProductos.Repositories;

namespace CatálogoDeProductos.Services;

internal class ProductoService : IRepositoryService<Producto>
{
    private readonly IRepository<Producto> _repositorioDeProductos;

    public ProductoService(IRepository<Producto> repositorioDeProductos)
    {
        _repositorioDeProductos = repositorioDeProductos;
    }

    public void Add(Producto item) => _repositorioDeProductos.Add(item);

    public void Delete(Producto item) => _repositorioDeProductos.Delete(item);

    public Producto Get(int id) => _repositorioDeProductos.Get(id);

    public IEnumerable<Producto> GetAll() => _repositorioDeProductos.GetAll();

    public void Update(Producto item) => _repositorioDeProductos.Update(item);
}
