namespace Gestión_de_Citas_Médicas.Models
{
    public class Medico: Persona
    {
        public Especialidad? Especialidad { get; private set; }
        public Medico(int id, string nombre, string apellido, string correo, string numero)
            :base(id, nombre, apellido, correo, numero)
        {
        }

        public void AsignarEspecialidad(Especialidad especialidadMedica)
        {
            Especialidad = especialidadMedica;
        }

        public override string MostrarDetalles()
        {
            string resultado;

            if (Especialidad != null)
            {
                resultado = Especialidad.Nombre;
            }
            else
            {
                resultado = "No asignada";
            }

            return $"Médico - ID: {ID}, Nombre: {NombreCompleto}, Correo: {Correo}, Especialidad: {resultado}";
        }
    }
}
