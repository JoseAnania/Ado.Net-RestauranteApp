using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalRestaurante.Models
{
    public class Restaurante
    {
        public Pedido pedido { get; set; }
        public List<Mozo> nombreMozo { get; set; }
    }
}