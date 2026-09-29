using Gestión_de_Citas_Médicas.Interfaces;
using Gestión_de_Citas_Médicas.Models;
using Gestión_de_Citas_Médicas.Validations;
using System.Collections.Generic;

namespace Gestión_de_Citas_Médicas.Services
{
    public class ServicioMedicos
    {
        private readonly IRepositorio<Medico> _repositorio;

        public ServicioMedicos(IRepositorio<Medico> repositorio)
        {
            _repositorio = repositorio;
        }

        public Medico Registrar(int id, string nombre, string apellido, string correo, string numero)
        {
            var medico = new Medico(id,
                Validador.TextoObligatorio(nombre, "nombre"),
                Validador.TextoObligatorio(apellido, "apellido"),
                correo,
                numero);

            _repositorio.Agregar(medico);
            return medico;
        }

        public void AsignarEspecialidad(Medico medico, Especialidad especialidad)
        {
            medico.AsignarEspecialidad(especialidad);
        }

        public List<Medico> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }
    }
}