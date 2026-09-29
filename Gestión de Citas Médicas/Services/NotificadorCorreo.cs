using System;
using Gestión_de_Citas_Médicas.Interfaces;

namespace Gestión_de_Citas_Médicas.Services
{
    public class NotificadorCorreo : INotificador
    {
        public void Enviar(string destino, string mensaje)
        {
            Console.WriteLine($"[Correo a {destino}]: {mensaje}");
        }
    }
}