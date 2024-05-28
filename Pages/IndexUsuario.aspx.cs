using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veterinaria.Logica;
using Veterinaria.Metodos;
using Veterinaria.Model;

namespace Veterinaria.Pages
{

    public partial class IndexUsuario : System.Web.UI.Page
    {
        public string IdUser;
        List<Animal> animals = new List<Animal>();

        protected void Page_Load(object sender, EventArgs e)
        {


            lblWelcome.Text = ($"Bienvenid@ {Session["Nombre"].ToString()}");
            IdUser = Session["id_usuario"].ToString();


            GestorAnimales animalRepository = new GestorAnimales(IdUser);
            try
            {
                List<Animal> animals = animalRepository.GetAnimalsFromDatabase();
                rptAnimals.DataSource = animals;
                rptAnimals.DataBind();

            }
            catch (Exception ex)
            {
                string script = $"alert('{ex}{ex.InnerException}');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LoginSuccessScript", script, true);
                Response.Redirect("login.aspx");
            }

        }

        protected void btnAgregarMascota_Click(object sender, EventArgs e)
        {
            string fileName = null;  // Definir la variable que será pasada por referencia

            // Crear una instancia de la clase MoverImagen
            MoverImagen moverImagen = new MoverImagen();

            // Llamar al método MoverImagen para mover el archivo y pasar fileName por referencia
            string resultado = moverImagen.MoverArchivoImagen(fileImagen, ref fileName);

            // Verificar si hubo un error
            if (resultado.StartsWith("Error") || resultado == "Falta Imagen")
            {
                // Manejar el error
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ImageMoveErrorScript", $"alert('{resultado}');", true);
                return;
            }

            // La imagen se movió exitosamente, usar el nuevo nombre de archivo para construir la ruta
            string rutaImagen = $"Imagenes/{fileName}";

            Animal animal = new Animal
            {
                Codigo = txtCodigo.Text,
                Alias = txtAlias.Text,
                Especie = txtEspecie.Text,
                ColorPelo = txtColorPelo.Text,
                Raza = txtRaza.Text,
                FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                PesoActual = decimal.Parse(txtPesoActual.Text),
                Ruta_imagen = rutaImagen  // Guardar la ruta de la imagen en la base de datos
            };

            animals.Add(animal);
            bool Respuesta = animal.RegistrarAnimal(IdUser);

            if (Respuesta)
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                // Mostrar mensaje de error
                string script = $"alert('Error');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LoginSuccessScript", script, true);
            }
        }
    }


}