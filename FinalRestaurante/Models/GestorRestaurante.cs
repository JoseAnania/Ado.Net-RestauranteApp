using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalRestaurante.Models
{
    public class GestorRestaurante
    {
        public void Agregar(Pedido nuevoPedido)
        {
            SqlConnection conn = new SqlConnection("data source=DESKTOP-E8FRIUV\\SQLEXPRESS;initial catalog=Restaurante;user id=sa;password=giandjoe");
            conn.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Pedido(descripcion, idMozo, importe) VALUES (@descripcion, @idMozo, @importe)", conn);

            comm.Parameters.Add(new SqlParameter("@descripcion", nuevoPedido.Descripcion));
            comm.Parameters.Add(new SqlParameter("@idMozo", nuevoPedido.IdMozo));
            comm.Parameters.Add(new SqlParameter("@importe", nuevoPedido.Importe));

            comm.ExecuteNonQuery();
            conn.Close();

        }

        public List<Mozo>ObtenerNombre()
        {
            List<Mozo> lista = new List<Mozo>();

            SqlConnection conn = new SqlConnection("data source=DESKTOP-E8FRIUV\\SQLEXPRESS;initial catalog=Restaurante;user id=sa;password=giandjoe");
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT * FROM Mozo", conn);
            SqlDataReader dr = comm.ExecuteReader();

            while(dr.Read())
            {
                int idMozo = dr.GetInt32(0);
                string nombre = dr.GetString(1);

                Mozo M = new Mozo(idMozo, nombre);
                lista.Add(M);
            }

            conn.Close();
            return lista;
        }

        public void Eliminar(Pedido borrarPedido)
        {
            SqlConnection conn = new SqlConnection("data source=DESKTOP-E8FRIUV\\SQLEXPRESS;initial catalog=Restaurante;user id=sa;password=giandjoe");
            conn.Open();
            SqlCommand comm = new SqlCommand("DELETE FROM Pedido WHERE idPedido=@idPedido", conn);

            comm.Parameters.Add(new SqlParameter("@idPedido", borrarPedido.IdPedido));

            comm.ExecuteNonQuery();
            conn.Close();

        }

        public void Modificar(Pedido cambiarPedido)
        {
            SqlConnection conn = new SqlConnection("data source=DESKTOP-E8FRIUV\\SQLEXPRESS;initial catalog=Restaurante;user id=sa;password=giandjoe");
            conn.Open();
            SqlCommand comm = new SqlCommand("UPDATE Pedido SET descripcion=@descripcion, idMozo=@idMozo, importe=@importe WHERE idPedido=@idPedido", conn);

            comm.Parameters.Add(new SqlParameter("@descripcion", cambiarPedido.Descripcion));
            comm.Parameters.Add(new SqlParameter("@idMozo", cambiarPedido.IdMozo));
            comm.Parameters.Add(new SqlParameter("@importe", cambiarPedido.Importe));
            comm.Parameters.Add(new SqlParameter("@idPedido", cambiarPedido.IdPedido));

            comm.ExecuteNonQuery();
            conn.Close();

        }

        public List<PedidoDto> Listar()
        {
            List<PedidoDto> lista = new List<PedidoDto>();

            SqlConnection conn = new SqlConnection("data source=DESKTOP-E8FRIUV\\SQLEXPRESS;initial catalog=Restaurante;user id=sa;password=giandjoe");
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT p.idPedido, p.descripcion, m.nombre, p.importe FROM pedido p INNER JOIN mozo m ON p.idMozo=m.idMozo", conn);
            SqlDataReader dr = comm.ExecuteReader();

            while (dr.Read())
            {
                int idPedido = dr.GetInt32(0);
                string descripcion = dr.GetString(1);
                string nombre = dr.GetString(2);
                double importe = dr.GetDouble(3);

                PedidoDto P = new PedidoDto(idPedido, descripcion, nombre, importe);
                lista.Add(P);
            }

            conn.Close();
            return lista;
        }

        public double Reporte()
        {
            double total = 0;

            SqlConnection conn = new SqlConnection("data source=DESKTOP-E8FRIUV\\SQLEXPRESS;initial catalog=Restaurante;user id=sa;password=giandjoe");
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT SUM(importe) FROM Pedido", conn);
            SqlDataReader dr = comm.ExecuteReader();

            dr.Read();

            total = dr.GetDouble(0);

            conn.Close();
            return total;
        }
    }
}