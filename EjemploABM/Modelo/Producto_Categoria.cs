using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Modelo
{
    public class Producto_Categoria
    {
        public int id_producto { get; set; }
        public int id_pedido { get; set; }
        public Producto_Categoria(int ID_producto,int ID_pedido)
        {
            this.id_producto = ID_producto;
            this.id_pedido = ID_pedido;
        }
        public Producto_Categoria()
        {

        }
    }
}
