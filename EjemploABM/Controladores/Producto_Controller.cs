using EjemploABM.Controladores;
using EjemploABM.Modelo;
using SalesGamer.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.tool.xml.html.HTML;

namespace SalesGamer.Controladores
{
    public class Producto_Controller
    {
        //OBTENER EL PRODUCTO
        public static List<Producto> obtenerProductos(int paginaActual, int elementosPorPagina)
        {
            List<Producto> list = new List<Producto>();
            int offset = (paginaActual - 1) * elementosPorPagina;
            string query = $"SELECT * FROM dbo.Producto ORDER BY Id OFFSET {offset} ROWS FETCH NEXT {elementosPorPagina} ROWS ONLY;";


            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);

            try
            {
                DB_Controller.connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Producto(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7), reader.GetInt32(8)));
                    Trace.WriteLine("Producto encontrado, nombre: " + reader.GetString(1));
                }

                reader.Close();
                DB_Controller.connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }
            finally
            {
                if (DB_Controller.connection.State != ConnectionState.Closed)
                {
                    DB_Controller.connection.Close();
                }
            }

            return list;
        }

        //SACAR EL MAXID
        public static int obtenerMaxId()
        {
            int MaxId = 0;
            string query = "select max(id) from dbo.Producto;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);

            try
            {
                DB_Controller.connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MaxId = reader.GetInt32(0);
                }

                reader.Close();
                DB_Controller.connection.Close();
                return MaxId;
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }
        }

        //OBTENER PRODUCTO POR ID
        public static Producto ObtenerProductoID(int id)
        {
            Producto producto = new Producto();
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
                            Precio = reader.GetInt32(3),
                            Cantidad = reader.GetInt32(4),
                            Distribuidor_id = reader.GetInt32(5),
                            Oferta_id = reader.GetInt32(6),
                            img = reader.GetString(7),
                            Categoria_id = reader.GetInt32(8),
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

        //CREAR PRODUCTO
        public static bool CrearProducto(Producto producto)
        {
            string query = "INSERT INTO dbo.Producto (id,nombre_producto, descripcion, precio, cantidad, Distribuidor_id, Oferta_id, imagen,Categoria_id) " +
                           "VALUES (@id,@nombre, @descripcion, @precio, @cantidad, @distribuidorId, @ofertaId, @imagen,@categoriaId);";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", obtenerMaxId() + 1);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre_producto);
                cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                cmd.Parameters.AddWithValue("@distribuidorId", producto.Distribuidor_id);
                cmd.Parameters.AddWithValue("@ofertaId", producto.Oferta_id);
                cmd.Parameters.AddWithValue("@imagen", producto.img);
                cmd.Parameters.AddWithValue("@categoriaId", producto.Categoria_id);
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

        // EDITAR / CREAR PRODUCTO

        public static bool editarProducto(Producto prod)
        {
            //Darlo de alta en la BBDD

            string query = "update dbo.Producto set nombre_producto = @nombre_producto , " +
                "descripcion = @descripcion , " +
                "precio = @precio , " +
                "cantidad = @cantidad ," +      
                "Distribuidor_id = @Distribuidor_id ," +
                "Oferta_id = @Oferta_id, " +
                "imagen = @imagen," +
                "Categoria_id = @Categoria_id " +
                "where id = @id ;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@id", prod.Id);
            cmd.Parameters.AddWithValue("@nombre_producto", prod.Nombre_producto);
            cmd.Parameters.AddWithValue("@descripcion", prod.Descripcion);
            cmd.Parameters.AddWithValue("@precio", prod.Precio);
            cmd.Parameters.AddWithValue("@cantidad", prod.Cantidad);
            cmd.Parameters.AddWithValue("@Distribuidor_id", prod.Distribuidor_id);
            cmd.Parameters.AddWithValue("@Oferta_id", prod.Oferta_id);
            cmd.Parameters.AddWithValue("@imagen", prod.img);
            cmd.Parameters.AddWithValue("@Categoria_id", prod.Categoria_id);

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

        public static bool eliminarProducto(Producto prodEliminar)
        {
            string query = "DELETE FROM dbo.Producto WHERE id = @id;";

            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", prodEliminar.Id);

                try
                {
                    DB_Controller.connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    DB_Controller.connection.Close();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al intentar eliminar el producto: " + ex.Message);
                }
            }
        }
    }
}
