using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veterinaria.Model;

namespace Veterinaria.Pages
{
    public partial class ConfirmarCita : System.Web.UI.Page
    {
        int idAnimal, idCita;
        List<Cita> Citas = new List<Cita>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //prueba
            idAnimal = Convert.ToInt32(Request.QueryString["idAnimal"]);
            idCita = Convert.ToInt32(Request.QueryString["idCita"]);

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Cita cita = new Cita
            {
                Id = idCita,
                AnimalId = idAnimal,
                Descripcion = txtMotivo.Text
            };

            bool Respuesta = cita.AsignarCita();

            if (Respuesta)
            {
                // Mostrar mensaje de cita guardada
                string script = "alert('Cita guardada correctamente.');";
                ClientScript.RegisterStartupScript(this.GetType(), "CitaGuardadaScript", script, true);
            }
            else
            {
                // Mostrar mensaje de error
                string script = "alert('Error al guardar la cita.');";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorCitaScript", script, true);
            }

            // Redireccionar a la página IndexUsuario.aspx después de un breve retraso
            string redirectScript = "setTimeout(function(){ window.location.href = '" + ResolveUrl("~/Pages/IndexUsuario.aspx") + "'; }, 500);";
            ClientScript.RegisterStartupScript(this.GetType(), "RedirectScript", redirectScript, true);
        }




        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}