using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veterinaria.BusinessLogic;
using Veterinaria.Model;

namespace Veterinaria.Pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = username.Text;
            string contraseña = password.Text;


            Usuario usuario = GestorUsuarios.IniciarSesion(nombreUsuario, contraseña);

            if (usuario != null)
            {
                string nombre = usuario.Nombre;

                string script = $"alert('Bienvenido: {nombre}');";

                Session["Nombre"] = nombre;
                Session["id_usuario"] = usuario.Id;


                ScriptManager.RegisterStartupScript(this, this.GetType(), "LoginSuccessScript", script, true);

                if (usuario.Rol == "1")
                {
                    Response.Redirect("IndexVeterinario.aspx");

                }
                else if(usuario.Rol == "2")
                {
                    Response.Redirect("IndexUsuario.aspx");

                }

            }
            else
            {
                string script = $"alert('Usuario o contraseña incorrecta');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LoginSuccessScript", script, true);
            }




        }
    }
}