using CatálogoDeProductos.Models;
using CatálogoDeProductos.Repositories;
using System.Collections.Generic;

namespace CatálogoDeProductos.ViewModels
{
    internal class ProductoViewModel
    {
        private ProductoRepository _repositorio;
        public ProductoViewModel()
        {
            _repositorio = new ProductoRepository();
        }

        public List<ProductoModel> ObtenerProductos()
        {
            return _repositorio.GetAll();
        }

        public ProductoModel? ObtenerProductoPorId(int id)
        {
            return _repositorio.GetById(id);
        }

        public void AgregarProducto(ProductoModel producto)
        {
            if (_repositorio.GetById(producto.Id) == null)
            {
                _repositorio.Add(producto);
            }
            else
            {
                _repositorio.Update(producto);
            }
        }

        public void EliminarProducto(ProductoModel producto)
        {
            if (_repositorio.GetById(producto.Id) != null)
            {
                _repositorio.Delete(producto);
            }
        }

        public void EditarProducto(ProductoModel producto)
        {
            if (_repositorio.GetById(producto.Id) != null)
            {
                _repositorio.Update(producto);
            }
        }
    }
}
