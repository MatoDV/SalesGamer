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
    internal class Oferta_Controller
    {
        //OBTENER LA OFERTA

        public static List<Oferta> obtenerOferta()
        {
            List<Oferta> list = new List<Oferta>();
            string query = "select * from dbo.Oferta;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);

            try
            {
                DB_Controller.connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Oferta(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetString(5), reader.GetInt32(6)));
                    Trace.WriteLine("Oferta encontrada, nombre: " + reader.GetString(1));
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

        //SACAR EL MAXID
        public static int obtenerMaxId()
        {
            int MaxId = 0;
            string query = "select max(id) from dbo.Oferta;";

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

        //OBTENER OFERTA POR ID
        public static Oferta ObtenerOfertaID(int id)
        {
            Oferta ofer = new Oferta();
            string query = "SELECT * FROM dbo.Oferta WHERE id = @id;";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    DB_Controller.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ofer = new Oferta
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Tipo_oferta = reader.GetString(2),
                            Fecha_inicio = reader.GetDateTime(3),
                            Fecha_final = reader.GetDateTime(4),
                            Condiciones = reader.GetString(5),
                            Is_active = reader.GetInt32(6),
                        };
                    }
                    reader.Close();
                }
                finally
                {
                    DB_Controller.connection.Close();
                }
            }
            return ofer;
        }

        //CREAR OFERTA
        public static bool CrearOferta(Oferta ofert)
        {
            string query = "INSERT INTO dbo.Oferta (id,nombre,tipo_oferta,fecha_inicio,fecha_final,condiciones,is_active) " +
                           "VALUES (@id,@nombre,@tipo_oferta,@fecha_inicio,@fecha_final,@condiciones,@activo);";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", obtenerMaxId() + 1);
                cmd.Parameters.AddWithValue("@nombre", ofert.Nombre);
                cmd.Parameters.AddWithValue("@tipo_oferta", ofert.Tipo_oferta);
                cmd.Parameters.AddWithValue("@fecha_inicio", ofert.Fecha_inicio);
                cmd.Parameters.AddWithValue("@fecha_final", ofert.Fecha_final);
                cmd.Parameters.AddWithValue("@condiciones", ofert.Condiciones);
                cmd.Parameters.AddWithValue("@activo", ofert.Is_active);

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

        // EDITAR / CREAR OFERTA

        public static bool editarOferta(Oferta ofer)
        {
            //Darlo de alta en la BBDD

            string query = "update dbo.Oferta set nombre = @nombre , " + 
                "tipo_oferta = @tipo_oferta, "+
                "fecha_inicio = @fecha_inicio, " +
                "fecha_final = @fecha_final, " +
                "condiciones = @condiciones, " +
                "is_active = @activo, " +
                "where id = @id ;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@id", ofer.Id);
            cmd.Parameters.AddWithValue("@nombre", ofer.Nombre);
            cmd.Parameters.AddWithValue("@tipo_oferta", ofer.Tipo_oferta);
            cmd.Parameters.AddWithValue("@fecha_inicio", ofer.Fecha_inicio);
            cmd.Parameters.AddWithValue("@fecha_final", ofer.Fecha_final);
            cmd.Parameters.AddWithValue("@condiciones", ofer.Condiciones);
            cmd.Parameters.AddWithValue("@activo", ofer.Is_active);


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

        //Eliminar Oferta
        public static bool eliminarOferta(Oferta oferEliminar)
        {
            string query = "UPDATE dbo.Oferta set is_active = 2 WHERE id = @id;";

            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", oferEliminar.Id);

                try
                {
                    DB_Controller.connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    DB_Controller.connection.Close();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al intentar eliminar la categoria: " + ex.Message);
                }
            }
        }
    }
}
