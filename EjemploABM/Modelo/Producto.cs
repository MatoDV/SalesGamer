using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Categoria Cat { get; set; }
        public int Precio { get; set; }
        public int Distribuidor_id { get; set; }
        public int Oferta_id { get; set; }

        public Producto(int id, string nombre_prod, string desc, Categoria cat, int precio, int distribuidor_ID, int oferta_ID)
        {
            Id = id;
            Nombre_producto = nombre_prod;
            Descripcion = desc;
            Cat = cat;
            Precio = precio;
            Distribuidor_id = distribuidor_ID;
            Oferta_id = oferta_ID;        }

        public Producto()
        {
        }


    }
}
