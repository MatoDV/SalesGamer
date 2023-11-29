using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Modelo
{
    public class Pedido_Producto
    {
        public int id_pedido { get; set; }
        public int id_producto { get; set; }
        public Pedido_Producto(int ID_pedido,int ID_producto)
        {
            this.id_pedido = ID_pedido;
            this.id_producto = ID_producto;
        }
        public Pedido_Producto()
        {

        }
    }
}
