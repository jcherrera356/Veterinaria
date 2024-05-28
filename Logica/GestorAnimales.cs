using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Veterinaria.Datos;
using Veterinaria.Model;
using static Veterinaria.Pages.IndexUsuario;

namespace Veterinaria.Logica
{
    public class GestorAnimales
    {
        private string Id_Usuario;

        public GestorAnimales(string Id_Usuario)
        {
            this.Id_Usuario = Id_Usuario;
        }

        public bool RegistrarAnimal(Animal animal)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("sp_InsertarAnimal", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Codigo", animal.Codigo);
                    command.Parameters.AddWithValue("@Alias", animal.Alias);
                    command.Parameters.AddWithValue("@Especie", animal.Especie);
                    command.Parameters.AddWithValue("@Raza", animal.Raza ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ColorPelo", animal.ColorPelo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FechaNacimiento", animal.FechaNacimiento ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PesoActual", animal.PesoActual ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PropietarioId", Id_Usuario ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Imagen", animal.Ruta_imagen ?? (object)DBNull.Value);


                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        // Si se insertaron filas, la operación fue exitosa
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }



                    }
                    catch (Exception ex)
                    {
                        return false;

                    }
                }
            }
        }
        public List<Animal> GetAnimalsFromDatabase()
        {
            List<Animal> animals = new List<Animal>();
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                SqlCommand sqlCommand = new SqlCommand("SP_Get_Animales", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@IDUsuario", Id_Usuario);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            Animal animal = new Animal();
                            animal.Id = Convert.ToInt32(row["Id"]);
                            animal.Codigo = row["Codigo"].ToString();
                            animal.Alias = row["Alias"].ToString();
                            animal.Especie = row["Especie"].ToString();
                            animal.Raza = row["Raza"].ToString();
                            animal.ColorPelo = row["ColorPelo"].ToString();
                            animal.FechaNacimiento = row.Field<DateTime?>("FechaNacimiento");
                            animal.PesoActual = row.Field<decimal?>("PesoActual");
                            animal.PropietarioId = row.Field<int?>("propietario_id");
                            animal.Ruta_imagen=row.Field<string>("RutaImagen");
                            animals.Add(animal);
                        }
                    }
                    else
                    {
                        return null; // Usuario no encontrado
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción apropiadamente (registrándola, notificando al usuario, etc.)
                    throw new Exception("Error comuniquese con el admin", ex);
                }
            }
            return animals;
        }
    }
}