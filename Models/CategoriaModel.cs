using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatálogoDeProductos.Models
{
    public class CategoriaModel
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private List<ProductoModel> _productos;

        public int Id
        {
            get => _id;
            set
            {
                if (int.IsNegative(value))
                {
                    throw new Exception("El ID de la categoría no puede ser negativo");
                }
                else if (_id != value)
                {
                    _id = value;
                }
            }
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El nombre de la categoría no puede estar vacío");
                }
                else if (_nombre != value)
                {
                    _nombre = value;
                }
            }
        }

        public string Descripcion
        {
            get => _descripcion;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("La descripción de la categoría no puede estar vacía");
                }
                else if (_descripcion != value)
                {
                    _descripcion = value;
                }
            }
        }

        public List<ProductoModel> Productos
        {
            get => _productos;
            set
            {
                if (value == null)
                {
                    throw new Exception("La lista de productos no puede ser nula");
                }
                else if (_productos != value)
                {
                    _productos = value;
                }
            }
        }
    }
}
