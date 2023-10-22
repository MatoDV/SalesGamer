using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Modelo
{
    internal class Oferta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo_oferta { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_final { get; set; }
        public string Condiciones { get; set; }

        public Oferta(int id,string nombre,string tipo_oferta,DateTime fecha_inicio, DateTime fecha_Final,string condiciones) 
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Tipo_oferta = tipo_oferta;
            this.Fecha_inicio = fecha_inicio;
            this.Fecha_final = fecha_Final;
            this.Condiciones = condiciones;
        } 
        public Oferta()
        { 
        }
    }
}
