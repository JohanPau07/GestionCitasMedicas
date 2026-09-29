using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestión_de_Citas_Médicas.Models
{
    public class Paciente: Persona
    {
        public Paciente(int id, string nombre, string apellido, string correo, string numero)
           : base(id, nombre, apellido, correo, numero)
        {

        }
        public override string MostrarDetalles()
        {
            return $"ID: {ID}, Nombre: {NombreCompleto}, Correo: {Correo}, Número: {Numero}";
        }
    }
}
