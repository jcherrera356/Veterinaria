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
    public partial class GetCitasMedicas : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int animalId;
            if (int.TryParse(Request.QueryString["id"], out animalId))
            {
                // Lógica para obtener las citas médicas del animal por su id
                string citasMedicasHtml = ObtenerCitasMedicasHtml(animalId);
                Response.Write(citasMedicasHtml);
                Response.End();
            }
            else
            {
                Response.Write("<p>ID de animal no válido.</p>");
                Response.End();
            }
        }

        private string ObtenerCitasMedicasHtml(int animalId)
        {
            GestorCitas gestorCitas = new GestorCitas();
            List<Cita> citas = gestorCitas.GetCitas(); // Obtener las citas médicas

            if (citas != null && citas.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<H1>Citas Disponibles</h1>");
                sb.Append("<table class='table table-striped'>");
                sb.Append("<thead>");
                sb.Append("<tr>");
                sb.Append("<th>Fecha</th>");
                sb.Append("<th>Hora</th>");
                sb.Append("<th>Veterinario</th>");
                sb.Append("<th>Acciones</th>"); // Columna para el botón
                sb.Append("</tr>");
                sb.Append("</thead>");
                sb.Append("<tbody>");

                foreach (var cita in citas)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", cita.Fecha.ToShortDateString());
                    sb.AppendFormat("<td>{0:hh\\:mm}</td>", cita.Hora);
                    sb.AppendFormat("<td>{0}</td>", cita.Nombre_medico);
                    string confirmarCitaUrl = ResolveUrl("~/Pages/ConfirmarCita.aspx?idAnimal=" + animalId + "&idCita=" + cita.Id);
                    sb.AppendFormat("<td><a href='{0}' class='btn btn-success'>Agendar</a></td>", confirmarCitaUrl);
                    sb.Append("</tr>");
                }

                sb.Append("</tbody>");
                sb.Append("</table>");
                return sb.ToString();
            }
            else
            {
                return "<p>No hay citas médicas registradas.</p>";
            }
        }
    }
}
