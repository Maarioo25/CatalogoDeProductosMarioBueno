using CatálogoDeProductos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatálogoDeProductos.Repositories
{
    public class CategoriaRepository : IRepository<CategoriaModel>
    {
        List<CategoriaModel> _categorias = new List<CategoriaModel>(
            new CategoriaModel[] {
                new CategoriaModel (1,"Categoria 1","Descripción de la categoría 1"),
                new CategoriaModel (2,"Categoria 2","Descripción de la categoría 2"),
                new CategoriaModel (3,"Categoria 3","Descripción de la categoría 3"),
                new CategoriaModel (4,"Categoria 4","Descripción de la categoría 4"),
                new CategoriaModel (5,"Categoria 5","Descripción de la categoría 5"),
            }
            );

        public void Add(CategoriaModel clase)
        {
            _categorias.Add(clase);
        }

        public void Delete(CategoriaModel clase)
        {
            _categorias.Remove(clase);
        }

        public List<CategoriaModel> GetAll()
        {
            return _categorias;
        }

        public CategoriaModel? GetById(int id)
        {
            return _categorias.Find(p => p.Id == id);
        }

        public void Update(CategoriaModel clase)
        {
            _categorias[_categorias.FindIndex(p => p.Id == clase.Id)] = clase;
        }
    }
}
