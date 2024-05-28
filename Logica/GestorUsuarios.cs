using System;
using System.Data;
using System.Data.SqlClient;
using Veterinaria.Datos;
using Veterinaria.Model;

namespace Veterinaria.BusinessLogic
{
    public class GestorUsuarios
    {
        // Método para verificar las credenciales de inicio de sesión y devolver los datos del usuario
        public static Usuario IniciarSesion(string nombreUsuario, string contraseña)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                SqlCommand sqlCommand = new SqlCommand("SP_Login", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Usuario", nombreUsuario);
                sqlCommand.Parameters.AddWithValue("@Contrasena", contraseña);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0];
                        Usuario usuario = new Usuario(
                            Convert.ToInt32(row["id"]),
                            row["nombre"].ToString(),
                            row["especialidad"].ToString(),
                            row["Usuario"].ToString(),
                            row["contrasena"].ToString(),
                            row["Rol"].ToString()

                        );
                        return usuario;
                    }
                    else
                    {
                        return null; // Usuario no encontrado
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción apropiadamente (registrándola, notificando al usuario, etc.)
                    throw new Exception("Error al intentar iniciar sesión.", ex);
                }
            }
        }
    }
}
