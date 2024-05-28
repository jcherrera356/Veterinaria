using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Veterinaria.Datos;
using Veterinaria.Model;

namespace Veterinaria.Logica
{
    public class GestorCitas
    {
        public List<Cita> GetCitas()
        {
            List<Cita> citas = new List<Cita>();
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                SqlCommand sqlCommand = new SqlCommand("SP_Get_Citas", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Cita cita = new Cita
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Hora = TimeSpan.Parse(reader["Hora"].ToString()),
                            AnimalId = reader["Animal_Id"] != DBNull.Value ? Convert.ToInt32(reader["Animal_Id"]) : (int?)null,
                            MedicoId = Convert.ToInt32(reader["Medico_Id"]),
                            Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : null,
                            Estado = reader["Estado"] != DBNull.Value ? Convert.ToBoolean(reader["Estado"]) : (bool?)null,
                            Nombre_medico = reader["Nombre_medico"] != DBNull.Value ? reader["Nombre_medico"].ToString() : null,

                        };
                        citas.Add(cita);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las citas.", ex);
                }
            }
            return citas;
        }

        public bool AsignarCita(Cita cita)
        {
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("sp_Asignar_cita", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_animal", cita.AnimalId);
                    command.Parameters.AddWithValue("@descripcion", cita.Descripcion);
                    command.Parameters.AddWithValue("@idCita", cita.Id);



                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        // Si se insertaron filas, la operación fue exitosa
                        if (rowsAffected < 0)
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

    }
}
