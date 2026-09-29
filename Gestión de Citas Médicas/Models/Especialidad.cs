namespace Gestión_de_Citas_Médicas.Models
{
    public class Especialidad
    {
        public int ID { get; }
        public string Nombre { get; }

        public Especialidad(int id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }

    }
}
