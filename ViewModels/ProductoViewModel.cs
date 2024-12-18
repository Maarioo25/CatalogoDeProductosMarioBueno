using CatálogoDeProductos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatálogoDeProductos.ViewModels
{
    internal class ProductoViewModel : ViewModelBase
    {
        private ProductoModel _producto;
        private List<ProductoModel> _productos;

        public ProductoViewModel()
        {
            _producto = new ProductoModel();
            _productos = new List<ProductoModel> {
                new ProductoModel { Id = 1, Nombre = "Producto 1", Descripcion = "Descripción del producto 1", Precio = 100, Categoria = new CategoriaModel { Id = 1, Nombre = "Categoría 1", Descripcion = "Descripción de la categoría 1" , Productos = null} },
                new ProductoModel { Id = 2, Nombre = "Producto 2", Descripcion = "Descripción del producto 2", Precio = 200, Categoria = new CategoriaModel { Id = 2, Nombre = "Categoría 2", Descripcion = "Descripción de la categoría 2" , Productos = null} },
                new ProductoModel { Id = 3, Nombre = "Producto 3", Descripcion = "Descripción del producto 3", Precio = 300, Categoria = new CategoriaModel { Id = 3, Nombre = "Categoría 3", Descripcion = "Descripción de la categoría 3" , Productos = null} },
                new ProductoModel { Id = 4, Nombre = "Producto 4", Descripcion = "Descripción del producto 4", Precio = 400, Categoria = new CategoriaModel { Id = 4, Nombre = "Categoría 4", Descripcion = "Descripción de la categoría 4" , Productos = null} },
                new ProductoModel { Id = 5, Nombre = "Producto 5", Descripcion = "Descripción del producto 5", Precio = 500, Categoria = new CategoriaModel { Id = 5, Nombre = "Categoría 5", Descripcion = "Descripción de la categoría 5" , Productos = null} }
            };

        }

        public ProductoModel Producto
        {
            get => _producto;
            set
            {
                if (_producto != value)
                {
                    _producto = value;
                    OnPropertyChanged(nameof(Producto));
                }
            }
        }

        public List<ProductoModel> Productos
        {
            get => _productos;
            set
            {
                if (_productos != value)
                {
                    _productos = value;
                    OnPropertyChanged(nameof(Productos));
                }
            }
        }

        public void AgregarProducto(Object Producto)
        {
            _productos.Add((ProductoModel)Producto);
            OnPropertyChanged(nameof(Productos));
        }

        public void EliminarProducto(Object Producto)
        {
            _productos.Remove((ProductoModel)Producto);
            OnPropertyChanged(nameof(Productos));
        }
    }
}
