using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinaria.Logica;


namespace Veterinaria.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Alias { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public string ColorPelo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public decimal? PesoActual { get; set; }
        public int? PropietarioId { get; set; }
        public byte[] Imagen { get; set; }
        public string Ruta_imagen { get; set; }

        private List<Animal> GetAnimalsFromDatabase(string Id_Usuario)
        {
            GestorAnimales repository = new GestorAnimales(Id_Usuario);
            return repository.GetAnimalsFromDatabase();

        }

        public bool RegistrarAnimal(string Id_Usuario)
        {
            GestorAnimales repository = new GestorAnimales(Id_Usuario);
            return repository.RegistrarAnimal(this);
        }
    }


}