using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalRestaurante.Models
{
    public class PedidoDto
    {
        public int IdPedido { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public double Importe { get; set; }

        public PedidoDto(int idPedido, string descripcion, string nombre, double importe)
        {
            IdPedido = idPedido;
            Descripcion = descripcion;
            Nombre = nombre;
            Importe = importe;
        }

        public PedidoDto() { }
    }
}