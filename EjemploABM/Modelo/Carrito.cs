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
        public int Id;
        public string nombre_producto;
        public int cantidad;
        public double precio_total;
        public int Usuario_id;
        public int Oferta_id;
        public Carrito(int id,string Nombre_producto,int Cantidad,double Precio_total,int usuario_ID,int oferta_ID) 
        {
            this.Id = id;
            this.nombre_producto = Nombre_producto; 
            this.cantidad = Cantidad;
            this.precio_total = Precio_total;
            this.Usuario_id = usuario_ID;
            this.Oferta_id = oferta_ID;
        }
        public Carrito() { }
    }
}
