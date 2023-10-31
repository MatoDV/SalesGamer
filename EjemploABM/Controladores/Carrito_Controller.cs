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
        public Carrito carrito;

        public Carrito_Controller()
        {
            carrito = new Carrito();
        }

        public void AgregarProductoAlCarrito(Producto producto)
        {
            carrito.AgregarProductoAlCarrito(producto);
        }

        public void EliminarProductoDelCarrito(int productId)
        {
            carrito.EliminarProductoDelCarrito(productId);
        }

        public List<Producto> ObtenerProductosEnCarrito()
        {
            return carrito.ObtenerProductosEnCarrito();
        }

    }
}
