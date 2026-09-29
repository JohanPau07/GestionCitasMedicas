using System;

namespace Gestión_de_Citas_Médicas.Validations
{
    public static class Validador
    {
        public static string TextoObligatorio(string valor, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"El campo '{nombreCampo}' es obligatorio.");

            return valor.Trim();
        }

        public static DateTime FechaFutura(DateTime fecha)
        {
            if (fecha <= DateTime.Now)
                throw new ArgumentException("La fecha debe ser futura.");

            return fecha;
        }
    }
}
