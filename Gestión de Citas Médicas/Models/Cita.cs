using System;
namespace Gestión_de_Citas_Médicas.Models
{
    public class Cita
    {
        public int Id { get; }
        public Paciente PacienteAsignado { get; }
        public Medico MedicoAsignado { get; }
        public DateTime FechaHora { get; private set;}
        public StatusCita Estado { get; private set;}
        public Cita(int id, Paciente pacienteAsignado, Medico medicoAsignado, DateTime fechaHora)

        {

            Id = id;
            PacienteAsignado = pacienteAsignado;
            MedicoAsignado = medicoAsignado;
            FechaHora = fechaHora;
            Estado = StatusCita.Programada;

        }
        public bool EstaCancelada()
        {
            return Estado == StatusCita.Cancelada;
        }

        public bool EstaProgramada()
        {
            return Estado == StatusCita.Programada;
        }
        public void Cancelar()
        {
            if (EstaCancelada())
                throw new InvalidOperationException("La cita ya está cancelada.");

            Estado = StatusCita.Cancelada;
        }

        public void Reprogramar(DateTime nuevaFecha)
        {
            if (EstaCancelada())
                throw new InvalidOperationException("No se puede reprogramar una cita cancelada.");

            FechaHora = nuevaFecha;
        }

    }
}
