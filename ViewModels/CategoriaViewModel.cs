using CatálogoDeProductos.Models;
using CatálogoDeProductos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatálogoDeProductos.ViewModels
{
    internal class CategoriaViewModel
    {
        private CategoriaRepository _repositorio;

        public CategoriaViewModel()
        {
            _repositorio = new CategoriaRepository();
        }

        public List<CategoriaModel> ObtenerCategorias()
        {
            return _repositorio.GetAll();
        }

        public CategoriaModel? ObtenerCategoriaPorId(int id)
        {
            return _repositorio.GetById(id);

        }

        public void AgregarCategoria(CategoriaModel categoria)
        {
            if (_repositorio.GetById(categoria.Id) == null)
            {
                _repositorio.Add(categoria);
            }
            else
            {
                _repositorio.Update(categoria);
            }
        }

        public void EliminarCategoria(CategoriaModel categoria)
        {
            if (_repositorio.GetById(categoria.Id) != null)
            {
                _repositorio.Delete(categoria);
            }
        }

        public void EditarCategoria(CategoriaModel categoria)
        {
            if (_repositorio.GetById(categoria.Id) != null)
            {
                _repositorio.Update(categoria);
            }
        }

        List<ProductoModel>? ObtenerProductosDeCategoria(int idCategoria)
        {
            CategoriaModel categoria = ObtenerCategoriaPorId(idCategoria);
            if (categoria != null)
            {
                return categoria.Productos;
            }
            else
            {
                return null;

            }
        }

        void agregarProductoACategoria(int idCategoria, ProductoModel producto)
        {
            CategoriaModel categoria = ObtenerCategoriaPorId(idCategoria);
            if (categoria != null)
            {
                if (!categoria.Productos.Contains(producto))
                {
                    categoria.Productos.Add(producto);
                }
            }
        }
    }
}
