using System;
using System.IO;
using System.Web.UI.WebControls;

namespace Veterinaria.Metodos
{
    public class MoverImagen
    {
        public string MoverArchivoImagen(FileUpload fileImagen, ref string fileName)
        {
            string newFileName = null;
            string filePath = null;
            if (fileImagen.HasFile)
            {
                // Obtener el nombre del archivo original
                fileName = Path.GetFileName(fileImagen.FileName);

                // Generar un nuevo nombre de archivo único
                newFileName = "mascota_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fileName);

                // Ruta deseada donde se guardará la imagen
                string directoryPath = @"C:\Users\Usuario\source\repos\Infraestructura de software\Veterinaria\Pages\Imagenes";
                filePath = Path.Combine(directoryPath, newFileName);

                try
                {
                    // Guardar la imagen directamente en la ruta deseada
                    fileImagen.PostedFile.SaveAs(filePath);
                    fileName = newFileName;  // Actualizar fileName con el nuevo nombre
                    return newFileName;
                }
                catch (Exception ex)
                {
                    // Manejar cualquier error al guardar la imagen
                    string errorMessage = "Error al guardar la imagen: " + ex.Message;
                    return errorMessage;
                }
            }
            else
            {
                return "Falta Imagen";
            }
        }
    }
}
