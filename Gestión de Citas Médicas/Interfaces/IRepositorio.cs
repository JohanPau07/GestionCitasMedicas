using System.Collections.Generic;

namespace Gestión_de_Citas_Médicas.Interfaces
{
    public interface IRepositorio<T>
    {
        void Agregar(T entidad);
        T? ObtenerPorId(int id);
        List<T> ObtenerTodos();
    }
}