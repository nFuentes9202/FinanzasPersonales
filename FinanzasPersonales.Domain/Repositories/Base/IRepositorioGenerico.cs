using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzasPersonales.Domain.Repositories.Base
{
    public interface IRepositorioGenerico<T> where T : class
    {
        T ObtenerPorId(int id);
        void Guardar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
        IEnumerable<T> ListarTodos();
    }
}
