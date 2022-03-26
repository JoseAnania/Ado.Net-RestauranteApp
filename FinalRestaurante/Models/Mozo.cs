using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalRestaurante.Models
{
    public class Mozo
    {
        public int IdMozo { get; set; }
        public string Nombre { get; set; }
        public Mozo (int idMozo, string nombre)
        {
            IdMozo = idMozo;
            Nombre = nombre;
        }
        public Mozo() { }
    }
}