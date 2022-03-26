using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalRestaurante.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public string Descripcion { get; set; }
        public int IdMozo { get; set; }
        public double Importe { get; set; }

        public Pedido(int idPedido, string descripcion, int idMozo, double importe)
        {
            IdPedido = idPedido;
            Descripcion = descripcion;
            IdMozo = idMozo;
            Importe = importe;
        }

        public Pedido() { }
    }
}