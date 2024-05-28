using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Veterinaria
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_usuario"] != null)
            {
                // Usuario ha iniciado sesión, mostrar el botón de cerrar sesión
                btnCerrarSesion.Visible = true;
            }
            else
            {
                btnCerrarSesion.Visible = false;

            }

        

        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("id_usuario");
            Response.Redirect("login.aspx");
        }

    }
}