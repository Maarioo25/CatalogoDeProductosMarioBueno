using CatálogoDeProductos.Models;
using CatálogoDeProductos.Repositories;

namespace CatálogoDeProductos.Services;

internal class CategoriaService : IRepositoryService<Categoria>
{
    private readonly IRepository<Categoria> _repositorioDeCategorias;

    public CategoriaService(IRepository<Categoria> repositorioDeCategorias)
    {
        _repositorioDeCategorias = repositorioDeCategorias;
    }

    public void Add(Categoria item) => _repositorioDeCategorias.Add(item);

    public void Delete(Categoria item) => _repositorioDeCategorias.Delete(item);

    public Categoria Get(int id) => _repositorioDeCategorias.Get(id);

    public IEnumerable<Categoria> GetAll() => _repositorioDeCategorias.GetAll();

    public void Update(Categoria item) => _repositorioDeCategorias.Update(item);
}
