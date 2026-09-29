namespace Gestión_de_Citas_Médicas.Models
{
    public abstract class Persona
    {
        public int ID { get; }
        public string Nombre { get; }
        public string Apellido { get; }    
        public string Correo { get;  }
        public string Numero { get; }

        protected Persona(int id, string nombre, string apellido, string correo, string numero)
        {
            ID = id;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Numero = numero;
        }
        public string NombreCompleto { 
            get { return $"{Nombre} {Apellido}"; }
        }

        public abstract string MostrarDetalles();
    }
}
