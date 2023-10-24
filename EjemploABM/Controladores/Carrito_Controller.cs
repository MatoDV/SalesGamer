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
        private static Carrito_Controller instancia;
        private  Carrito carrito;

        public Carrito_Controller()
        {
            carrito = new Carrito();
        }
        public static Carrito_Controller ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Carrito_Controller();
            }
            return instancia;
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
