using Gestión_de_Citas_Médicas.Interfaces;
using Gestión_de_Citas_Médicas.Models;
using Gestión_de_Citas_Médicas.Validations;

namespace Gestión_de_Citas_Médicas.Services
{
    public class ServicioPacientes
    {
        private readonly IRepositorio<Paciente> _repositorio;

        public ServicioPacientes(IRepositorio<Paciente> repositorio)
        {
            _repositorio = repositorio;
        }

        public Paciente Registrar(int id, string nombre, string apellido, string correo, string numero)
        {
            var paciente = new Paciente(id,
                Validador.TextoObligatorio(nombre, "nombre"),
                Validador.TextoObligatorio(apellido, "apellido"),
                correo,
                numero);

            _repositorio.Agregar(paciente);
            return paciente;
        }

        public List<Paciente> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }
    }
}