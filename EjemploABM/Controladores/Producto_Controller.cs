using EjemploABM.Controladores;
using EjemploABM.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Controladores
{
    internal class Producto_Controller
    {
        public Producto ObtenerProducto(int id)
        {
            Producto producto = null;
            string query = "SELECT * FROM dbo.Producto WHERE id = @id;";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    DB_Controller.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        producto = new Producto
                        {
                            Id = reader.GetInt32(0),
                            Nombre_producto = reader.GetString(1),
                            Descripcion = reader.GetString(2), 
                            Precio = reader.GetInt32(4),
                            Cantidad = reader.GetInt32(5),
                            Categoria_id = reader.GetInt32(6),
                            Distribuidor_id = reader.GetInt32(7),
                            Oferta_id = reader.GetInt32(8)
                        };
                    }
                    reader.Close();
                }
                finally
                {
                    DB_Controller.connection.Close();
                }
            }
            return producto;
        }

        public bool CrearProducto(Producto producto)
        {
            string query = "INSERT INTO dbo.Producto (nombre_producto, descripcion, precio, cantidad, Categoria_id, Distribuidor_id, Oferta_id) " +
                           "VALUES (@nombre, @descripcion, @precio, @cantidad, @distribuidorId, @ofertaId);";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre_producto);
                cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                cmd.Parameters.AddWithValue("@Categoria_id", producto.Categoria_id);
                cmd.Parameters.AddWithValue("@distribuidorId", producto.Distribuidor_id);
                cmd.Parameters.AddWithValue("@ofertaId", producto.Oferta_id);
                try
                {
                    DB_Controller.connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                finally
                {
                    DB_Controller.connection.Close();
                }
            }
        }
    }
}
