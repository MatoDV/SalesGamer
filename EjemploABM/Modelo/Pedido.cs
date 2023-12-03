using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Modelo
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public string estado_pedido { get; set; }
        public int cantidad { get; set; }
        public int precio_unitario { get; set; }
        public float subtotal { get; set; }
        public int Usuario_id { get; set; }


        public Pedido(int id, DateTime Fecha, string Estado_pedido, int Cantidad, int Precio_unitario, float Subtotal,int usuario_ID)
        {
            this.Id = id;
            this.fecha = Fecha;
            this.estado_pedido = Estado_pedido;
            this.cantidad = Cantidad;
            this.precio_unitario = Precio_unitario;
            this.subtotal = Subtotal;
            this.Usuario_id = usuario_ID;
        }
    }
}
