using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Modelo
{
    public class Metodo_de_pago
    {
        public int Id { get; set; }
        public string tipo_tarjeta { get; set; }
        public int numero_tarjeta { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public string nombre_titular { get; set; }
        public int id_Producto { get; set; }

        public Metodo_de_pago(int id,string Tipo_tarjeta,int Numero_tarjeta,DateTime Fecha_vencimiento,string Nombre_titular,int ID_producto)
        {
            this.Id = id;
            this.tipo_tarjeta = Tipo_tarjeta;
            this.numero_tarjeta = Numero_tarjeta;
            this.fecha_vencimiento = Fecha_vencimiento;
            this.nombre_titular = Nombre_titular;
            this.id_Producto = ID_producto;
        }
        public Metodo_de_pago()
        {

        }
    }
}
