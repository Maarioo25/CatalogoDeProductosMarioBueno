using CatálogoDeProductos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatálogoDeProductos.Repositories
{
    public class ProductoRepository : IRepository<ProductoModel>
    {
        List<ProductoModel> _productos = new List<ProductoModel>(
            new ProductoModel[] {
                new ProductoModel (1,"Producto 1","Descripción del producto 1", 100, 1),
                new ProductoModel (2,"Producto 2","Descripción del producto 2", 200, 2),
                new ProductoModel (3,"Producto 3","Descripción del producto 3", 300, 3),
                new ProductoModel (4,"Producto 4","Descripción del producto 4", 400, 4),
                new ProductoModel (5,"Producto 5","Descripción del producto 5", 500, 5),
            }
            );

        public List<ProductoModel> GetAll()
        {
            return _productos;
        }

        public ProductoModel? GetById(int id)
        {
            return _productos.Find(p => p.Id == id);
        }

        public void Add(ProductoModel clase)
        {
            _productos.Add( clase );
        }

        public void Delete(ProductoModel clase)
        {
            _productos.Remove(clase);
        }

        public void Update(ProductoModel clase)
        {
            _productos[_productos.FindIndex(p => p.Id == clase.Id)] = clase;
        }
    }
}
