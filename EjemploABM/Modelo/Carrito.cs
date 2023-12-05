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
        public float precio_total;
        public int Usuario_id;
        public Carrito(int id,string Nombre_producto,int Cantidad,float Precio_total,int usuario_ID) 
        {
            this.Id = id;
            this.nombre_producto = Nombre_producto; 
            this.cantidad = Cantidad;
            this.precio_total = Precio_total;
            this.Usuario_id = usuario_ID;
        }
        public Carrito() { }
    }
}
