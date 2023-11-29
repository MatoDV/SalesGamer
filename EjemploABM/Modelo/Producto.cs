﻿using SalesGamer.Modelo;
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
        public Distribuidor Distribuidor_id { get; set; }
        public Oferta Oferta_id { get; set; }
        public byte[] img { get; set; }




        public Producto(int id, string nombre, string desc, int precio,int cantidad, Distribuidor distribuidor_id, Oferta oferta_id,byte[] Imagen)
        {
            this.Id = id;
            this.Nombre_producto = nombre;
            this.Descripcion = desc;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Distribuidor_id = distribuidor_id;
            this.Oferta_id = oferta_id;
            this.img = Imagen;
        }

        public Producto()
        {
        }


    }
}
