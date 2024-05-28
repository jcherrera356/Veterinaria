using System.Data.SqlClient;

namespace Veterinaria.Datos
{
    public class ConexionBD
    {
        private string connectionString = "Data Source=P971E27;Initial Catalog=Veterinaria;User Id=sa;Password=sa123;Integrated Security=False";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        // Agrega métodos para ejecutar consultas SQL, insertar usuarios, etc.
    }
}
