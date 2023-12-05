using EjemploABM.Controladores;
using EjemploABM.Modelo;
using SalesGamer.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Controladores
{
    public class Carrito_Controller
    {
        public static List<Carrito> obtenerCarrito()
        {
            List<Carrito> list = new List<Carrito>();
            
            string query = "SELECT * FROM dbo.Carrito";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);

            try
            {
                DB_Controller.connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Carrito(reader.GetInt32(0), reader.GetString(1),reader.GetInt32(2),reader.GetDouble(3),reader.GetInt32(4),reader.GetInt32(5)));
                    Trace.WriteLine("Carrito encontrado, nombre: " + reader.GetString(1));
                }

                reader.Close();
                DB_Controller.connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }

            return list;
        }

        public static int obtenerMaxId()
        {
            int MaxId = -1; // Valor predeterminado para un carrito vacío
            string query = "select max(id) from dbo.Carrito;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);

            try
            {
                DB_Controller.connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    MaxId = Convert.ToInt32(result);
                }

                DB_Controller.connection.Close();
                return MaxId;
            }
            catch (Exception ex)
            {
                // Manejar la excepción y retornar el valor predeterminado
                throw new Exception("Hay un error en la query: " + ex.Message);
            }
        }

        public static Carrito ObtenerCarritoID(int id)
        {
            Carrito carrito = new Carrito();
            string query = "SELECT * FROM dbo.Carrito WHERE id = @id;";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    DB_Controller.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        carrito = new Carrito
                        {
                            Id = reader.GetInt32(0),
                            nombre_producto = reader.GetString(1),
                            cantidad = reader.GetInt32(2),
                            precio_total = reader.GetDouble(3),
                            Usuario_id = reader.GetInt32(4),
                            Oferta_id = reader.GetInt32(5),
                        };
                    }
                    reader.Close();
                }
                finally
                {
                    DB_Controller.connection.Close();
                }
            }
            return carrito;
        }

        public static bool CrearCarrito(Carrito carrito)
        {
            string query = "INSERT INTO dbo.Carrito (id,nombre_producto,cantidad,precio_total,Usuario_id,Oferta_id) " +
                           "VALUES (@id,@nombre,@cantidad,@precio_total,@Usuario_id,@Oferta_id);";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", obtenerMaxId() + 1);
                cmd.Parameters.AddWithValue("@nombre", carrito.nombre_producto);
                cmd.Parameters.AddWithValue("@cantidad", carrito.cantidad);
                cmd.Parameters.AddWithValue("@precio_total", carrito.precio_total);
                cmd.Parameters.AddWithValue("@Usuario_id", carrito.Usuario_id);
                cmd.Parameters.AddWithValue("@Oferta_id", carrito.Oferta_id);


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

        // EDITAR / CREAR CATEGORIA

        public static bool editarCarrito(Carrito carr)
        {
            //Darlo de alta en la BBDD

            string query = "update dbo.Carrito set nombre_producto = @nombre_producto, " +
                "cantidad = @cantidad, " +
                "precio_total = @precio_total, " +
                "Usuario_id = @Usuario_id, " +
                "Oferta_id = @Oferta_id " +
                "where id = @id ;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@id", carr.Id);
            cmd.Parameters.AddWithValue("@nombre_producto", carr.nombre_producto);
            cmd.Parameters.AddWithValue("@cantidad", carr.cantidad);
            cmd.Parameters.AddWithValue("@precio_total", carr.precio_total);
            cmd.Parameters.AddWithValue("@Usuario_id", carr.Usuario_id);
            cmd.Parameters.AddWithValue("@Oferta_id", carr.Oferta_id);


            try
            {
                DB_Controller.connection.Open();
                cmd.ExecuteNonQuery();
                DB_Controller.connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }

        }

        //Eliminar Categoria
        public static bool eliminarCarrito(Carrito carrEliminar)
        {
            string query = "DELETE FROM dbo.Carrito WHERE id = @id;";

            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", carrEliminar.Id);

                try
                {
                    DB_Controller.connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    DB_Controller.connection.Close();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al intentar eliminar la Carrito: " + ex.Message);
                }
            }
        }
    }
}
