using EjemploABM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Modelo
{
    public class Carrito
    {
        public List<Producto> productosEnCarrito;

        public Carrito()
        {
            productosEnCarrito = new List<Producto>();
        }

        public void AgregarProductoAlCarrito(Producto producto)
        {
            productosEnCarrito.Add(producto);
        }

        public void EliminarProductoDelCarrito(int productId)
        {
            Producto producto = productosEnCarrito.FirstOrDefault(p => p.Id == productId);
            if (producto != null)
            {
                productosEnCarrito.Remove(producto);
            }
        }

        public List<Producto> ObtenerProductosEnCarrito()
        {
            return productosEnCarrito;
        }
    }
}
