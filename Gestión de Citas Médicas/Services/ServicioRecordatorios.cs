using Gestión_de_Citas_Médicas.Interfaces;
using Gestión_de_Citas_Médicas.Models;

namespace Gestión_de_Citas_Médicas.Services
{
    public class ServicioRecordatorios
    {
        private readonly INotificador _notificador;

        public ServicioRecordatorios(INotificador notificador)
        {
            _notificador = notificador;
        }

        public void EnviarRecordatorio(Cita cita)
        {
            var mensaje = $"Recordatorio: cita con {cita.MedicoAsignado.NombreCompleto} el {cita.FechaHora:g}";
            _notificador.Enviar(cita.PacienteAsignado.Correo, mensaje);
        }
    }
}