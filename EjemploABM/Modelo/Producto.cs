﻿using System;
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
        public int Categoria_id { get; set; }
        public int Distribuidor_id { get; set; }
        public int Oferta_id { get; set; }



        public Producto(int id, string nombre, string desc, int cat, int precio,int cantidad, int distribuidor_id, int oferta_id)
        {
            Id = id;
            Nombre_producto = nombre;
            Descripcion = desc;
            Categoria_id = cat;
            Precio = precio;
            Cantidad = cantidad;
            Distribuidor_id = distribuidor_id;
            Oferta_id = oferta_id;
        }

        public Producto()
        {
        }


    }
}
