using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatálogoDeProductos.Models
{
    public class ProductoModel
    {
        private int _id;
        private string _nombre;
        private string _descripcion;
        private double _precio;
        private CategoriaModel _categoria;


        public int Id {
            get => _id;
            set
            {
                if (int.IsNegative(value))
                {
                    throw new Exception("El ID del producto no puede ser negativo");
                }
                else if (_id != value)
                {
                    _id = value;
                }
            }
        }
        public string Nombre { 
            get => _nombre; 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("El nombre del producto no puede estar vacío");
                }
                else if (_nombre != value)
                {
                    _nombre = value;
                }
            }
        }
        public string Descripcion { 
            get => _descripcion; 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("La descripción del producto no puede estar vacía");
                }
                else if (_descripcion != value)
                {
                    _descripcion = value;
                }
            }
        }
        public double Precio { 
            get => _precio; 
            set
            {
                if (double.IsNegative(value))
                {
                    throw new Exception("El precio del producto no puede ser negativo");
                }
                else if (_precio != value)
                {
                    _precio = value;
                }
            }
        }
        public CategoriaModel Categoria
        {
            get => _categoria;
            set
            {
                if (_categoria != value)
                {
                    _categoria = value;
                }
            }
        }


    }
}
