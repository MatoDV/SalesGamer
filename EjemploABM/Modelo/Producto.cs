using SalesGamer.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploABM.Modelo
{
    public class Producto
    {

        public int Id { get; set; }
        public String Nombre_producto { get; set; }
        public String Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public Categoria Categoria_id {  get; set; }
        public Distribuidor Distribuidor_id { get; set; }
        public Oferta Oferta_id { get; set; }
        public string img { get; set; }




        public Producto(int id, string nombre, string desc, int precio,int cantidad,Categoria categoria_id,Distribuidor distribuidor_id, Oferta oferta_id,string Imagen)
        {
            this.Id = id;
            this.Nombre_producto = nombre;
            this.Descripcion = desc;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Categoria_id = categoria_id;
            this.Distribuidor_id = distribuidor_id;
            this.Oferta_id = oferta_id;
            this.img = Imagen;
        }

        public Producto()
        {
        }


    }
}
