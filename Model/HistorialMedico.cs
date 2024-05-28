using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinaria.Logica;

namespace Veterinaria.Model
{
    public class HistorialMedico
    {
        public int id { get; set; }
        public int animal_id { get; set; }
        public string enfermedad { get; set; }
        public DateTime? fechaEnfermedad { get; set; }
        public string MotivoConsulta { get; set; }


        private List<HistorialMedico> GetHistorialMedicoFromDatabase(string Id_Animal)
        {
            GestorHistorialMedico repository = new GestorHistorialMedico(Id_Animal);
            return repository.GetHistorialMedicoFromDatabase();

        }

    }


}