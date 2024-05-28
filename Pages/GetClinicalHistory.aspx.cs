using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veterinaria.Logica;
using Veterinaria.Model;

namespace Veterinaria.Pages
{
    public partial class GetClinicalHistory : System.Web.UI.Page
    {
        List<HistorialMedico> historialMedicos = new List<HistorialMedico>();
        protected void Page_Load(object sender, EventArgs e)
        {
            int animalId;
            if (int.TryParse(Request.QueryString["id"], out animalId))
            {
                // Lógica para obtener el historial clínico del animal por su id
                string clinicalHistoryHtml = ObtenerHistorialClinicoHtml(animalId);
                Response.Write(clinicalHistoryHtml);
                Response.End();
            }
            else
            {
                Response.Write("<p>ID de animal no válido.</p>");
                Response.End();

            }
        }

        private string ObtenerHistorialClinicoHtml(int animalId)
        {
            GestorHistorialMedico gestorHistorialMedico = new GestorHistorialMedico(animalId.ToString());

            List<HistorialMedico> historialMedicos = gestorHistorialMedico.GetHistorialMedicoFromDatabase();

            if(historialMedicos != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table class='table table-striped'>");
                sb.Append("<thead>");
                sb.Append("<tr>");
                sb.Append("<th>Enfermedad</th>");
                sb.Append("<th>Fecha de Enfermedad</th>");
                sb.Append("<th>Motivo Consulta</th>");
                sb.Append("</tr>");
                sb.Append("</thead>");
                sb.Append("<tbody>");

                foreach (var registro in historialMedicos)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", registro.enfermedad);
                    sb.AppendFormat("<td>{0:dd/MM/yyyy}</td>", registro.fechaEnfermedad);
                    sb.AppendFormat("<td>{0:dd/MM/yyyy}</td>", registro.MotivoConsulta);

                    sb.Append("</tr>");
                }

                sb.Append("</tbody>");
                sb.Append("</table>");
                return sb.ToString(); ;
            }
            else
            {
                return "<p>No hay historal clinico registrado</p>";

            }

        }
    }
}