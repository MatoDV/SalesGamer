using EjemploABM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Modelo
{
    internal class Carrito
    {
        private List<Producto> productosEnCarrito = new List<Producto>();
        public void  AgregarProducto(Producto producto)
        {
            productosEnCarrito.Add(producto);
        }

        public void EliminarProducto(int id)
        {
            Producto productoAEliminar = productosEnCarrito.FirstOrDefault(p => p.Id == id);
            if (productoAEliminar != null)
            {
                productosEnCarrito.Remove(productoAEliminar);
            }
        }

        public List<Producto> ObtenerProductosEnCarrito()
        {
            return productosEnCarrito;
        }
    }
}
