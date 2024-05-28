using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinaria.Logica;

namespace Veterinaria.Model
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int? AnimalId { get; set; }
        public int MedicoId { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public string Nombre_medico { get; set; }


        public List<Cita> GetCitas()
        {
            GestorCitas repository = new GestorCitas();
            return repository.GetCitas();

        }

        public bool AsignarCita()
        {
            GestorCitas repository = new GestorCitas();
            return repository.AsignarCita(this);
        }
    }
}