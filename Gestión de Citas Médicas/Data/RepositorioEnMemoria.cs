using System.Collections.Generic;
using System.Linq;
using Gestión_de_Citas_Médicas.Interfaces;

namespace Gestión_de_Citas_Médicas.Data
{
    public class RepositorioEnMemoria<T> : IRepositorio<T>
    {
        private readonly List<T> _elementos = new List<T>();

        public void Agregar(T entidad)
        {
            _elementos.Add(entidad);
        }

        public T? ObtenerPorId(int id)
        {
            dynamic? encontrado = _elementos.FirstOrDefault(e => ((dynamic)e!).ID == id);
            return encontrado;
        }

        public List<T> ObtenerTodos()
        {
            return _elementos;
        }
    }
}