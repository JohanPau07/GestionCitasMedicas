using System;
using System.Collections.Generic;
using System.Linq;
using Gestión_de_Citas_Médicas.Models;

namespace Gestión_de_Citas_Médicas.Validations
{
    public class ValidadorDisponibilidad
    {
        public void AsegurarLibre(Medico medico, DateTime fechaHora, List<Cita> citasExistentes, int? citaAIgnorarId = null)
        {
            bool hayConflicto = citasExistentes.Any(c =>
                c.Id != citaAIgnorarId &&
                c.MedicoAsignado.ID == medico.ID &&
                c.FechaHora == fechaHora &&
                c.EstaProgramada());

            if (hayConflicto)
                throw new InvalidOperationException("El médico ya tiene una cita en ese horario.");
        }
    }
}