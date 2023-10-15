using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploABM.Modelo
{
    public class Categoria
    {

        public int Id { get; set; }
        public String nombre_categoria { get; set; }

        public Categoria(int id, string nombre_cat)
        {
            Id = id;
            nombre_categoria = nombre_cat;
        }

        public Categoria()
        {
        }
    }
}
