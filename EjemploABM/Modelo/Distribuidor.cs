using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Modelo
{
    public class Distribuidor
    {
        public int Id { get; set; }
        public string nombre_empresa { get; set; }
        public int stock { get; set; }

        public Distribuidor(int id,string Nombre_empresa,int Stock) 
        {
            this.Id = id;
            this.nombre_empresa = Nombre_empresa;
            this.stock = Stock;
        }
        public Distribuidor()
        {
        }
    }
}
