using Gestión_de_Citas_Médicas.Interfaces;
using Gestión_de_Citas_Médicas.Models;
using Gestión_de_Citas_Médicas.Validations;
using System.Collections.Generic;

namespace Gestión_de_Citas_Médicas.Services
{
    public class ServicioEspecialidades
    {
        private readonly IRepositorio<Especialidad> _repositorio;

        public ServicioEspecialidades(IRepositorio<Especialidad> repositorio)
        {
            _repositorio = repositorio;
        }

        public Especialidad Registrar(int id, string nombre)
        {
            var especialidad = new Especialidad(id, Validador.TextoObligatorio(nombre, "nombre"));
            _repositorio.Agregar(especialidad);
            return especialidad;
        }

        public List<Especialidad> ObtenerTodas()
        {
            return _repositorio.ObtenerTodos();
        }
    }
}