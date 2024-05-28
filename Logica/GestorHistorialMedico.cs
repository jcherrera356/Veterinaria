using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Veterinaria.Datos;
using Veterinaria.Model;

namespace Veterinaria.Logica
{
    public class GestorHistorialMedico
    {
        private string Id_animal;

        public GestorHistorialMedico(string Id_animal)
        {
            this.Id_animal = Id_animal;
        }
        public List<HistorialMedico> GetHistorialMedicoFromDatabase()
        {
            List<HistorialMedico>  historialMedicos = new List<HistorialMedico>();
            ConexionBD conexionBD = new ConexionBD();
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                SqlCommand sqlCommand = new SqlCommand("SP_Get_Historial_clinico", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id_animal", Id_animal);

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
                            HistorialMedico historialMedico = new HistorialMedico();
                            historialMedico.id = Convert.ToInt32(row["Id"]);
                            historialMedico.animal_id = Convert.ToInt32(row["animal_id"]);
                            historialMedico.enfermedad = row["enfermedad"].ToString();
                            historialMedico.fechaEnfermedad = row.Field<DateTime?>("fechaEnfermedad");
                            historialMedico.MotivoConsulta = row["MotivoConsulta"].ToString();


                            historialMedicos.Add(historialMedico);
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
            return historialMedicos;
        }
    }
}