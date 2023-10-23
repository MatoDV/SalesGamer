using EjemploABM.Modelo;
using SalesGamer.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Controladores
{
    public class Carrito_Controller
    {
        private  Carrito carrito;

        public Carrito_Controller()
        {
            carrito = new Carrito();
        }

        public  void AgregarProductoAlCarrito(int id)
        {
            Producto producto = Producto_Controller.ObtenerProductoID(id);
            carrito.AgregarProducto(producto);
        }

        public void EliminarProductoDelCarrito(int id)
        {
            carrito.EliminarProducto(id);
        }

        public List<Producto> ObtenerProductosEnCarrito()
        {
            return carrito.ObtenerProductosEnCarrito();
        }

    }
}
