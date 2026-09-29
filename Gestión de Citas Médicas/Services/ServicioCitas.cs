using Gestión_de_Citas_Médicas.Interfaces;
using Gestión_de_Citas_Médicas.Models;
using Gestión_de_Citas_Médicas.Validations;


namespace Gestión_de_Citas_Médicas.Services
{
    public class ServicioCitas
    {
        private readonly IRepositorio<Cita> _repositorio;
        private readonly ValidadorDisponibilidad _validadorDisponibilidad;

        public ServicioCitas(IRepositorio<Cita> repositorio, ValidadorDisponibilidad validadorDisponibilidad)
        {
            _repositorio = repositorio;
            _validadorDisponibilidad = validadorDisponibilidad;
        }

        public Cita Agendar(int id, Paciente paciente, Medico medico, DateTime fechaHora)
        {
            Validador.FechaFutura(fechaHora);
            _validadorDisponibilidad.AsegurarLibre(medico, fechaHora, _repositorio.ObtenerTodos());

            var cita = new Cita(id, paciente, medico, fechaHora);
            _repositorio.Agregar(cita);
            return cita;
        }

        public void Cancelar(int citaId)
        {
            var cita = _repositorio.ObtenerTodos().First(c => c.Id == citaId);
            cita.Cancelar();
        }

        public void Reprogramar(int citaId, DateTime nuevaFecha)
        {
            var cita = _repositorio.ObtenerTodos().First(c => c.Id == citaId);

            Validador.FechaFutura(nuevaFecha);
            _validadorDisponibilidad.AsegurarLibre(cita.MedicoAsignado, nuevaFecha, _repositorio.ObtenerTodos(), cita.Id);

            cita.Reprogramar(nuevaFecha);
        }

        public List<Cita> PorPaciente(int pacienteId)
        {
            return _repositorio.ObtenerTodos().Where(c => c.PacienteAsignado.ID == pacienteId).ToList();
        }

        public List<Cita> PorMedico(int medicoId)
        {
            return _repositorio.ObtenerTodos().Where(c => c.MedicoAsignado.ID == medicoId).ToList();
        }
    }
}