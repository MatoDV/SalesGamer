using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Modelo
{
    public class Producto_Carrito
    {
        public int id_producto { get; set; }
        public int id_carrito { get; set; }
        public Producto_Carrito(int ID_producto, int ID_carrito)
        {
            this.id_producto = ID_producto;
            this.id_carrito = ID_carrito;
        }
        public Producto_Carrito()
        {

        }
    }
}
