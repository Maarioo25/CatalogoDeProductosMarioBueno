using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatálogoDeProductos.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T clase);
        void Delete(T clase);
        void Update(T clase);
    }
}
