using System.Data;

namespace Veterinaria.Model
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Especialidad {  get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }


        public Usuario(int id,string nombre,string especialidad,string nombreUsuario, string contraseña,string rol)
        {
            Id = id;
            Nombre = nombre;
            Especialidad = especialidad;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Rol = rol;
            
        }
    }
}
