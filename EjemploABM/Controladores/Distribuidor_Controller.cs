using EjemploABM.Controladores;
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
    internal class Distribuidor_Controller
    {
        public static List<Distribuidor> obtenerDistribuidor()
        {
            List<Distribuidor> list = new List<Distribuidor>();
            string query = "select * from dbo.Distribuidor;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);

            try
            {
                DB_Controller.connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Distribuidor(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    Trace.WriteLine("Distribuidor encontrada, nombre: " + reader.GetString(1));
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
            string query = "select max(id) from dbo.Distribuidor;";

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
        public static Distribuidor ObtenerDistribuidorID(int id)
        {
            Distribuidor distri = new Distribuidor();
            string query = "SELECT * FROM dbo.Distribuidor WHERE id = @id;";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    DB_Controller.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        distri = new Distribuidor
                        {
                            Id = reader.GetInt32(0),
                            nombre_empresa = reader.GetString(1),
                            stock = reader.GetInt32(2),
                        };
                    }
                    reader.Close();
                }
                finally
                {
                    DB_Controller.connection.Close();
                }
            }
            return distri;
        }

        //CREAR OFERTA
        public static bool CrearDistribuidor(Distribuidor distribuidor)
        {
            string query = "INSERT INTO dbo.Distribuidor (id,nombre_empresa,stock) " +
                           "VALUES (@id,@nombre_empresa,@stock);";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", obtenerMaxId() + 1);
                cmd.Parameters.AddWithValue("@nombre_empresa", distribuidor.nombre_empresa);
                cmd.Parameters.AddWithValue("@stock", distribuidor.stock);


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

        public static bool editarDistribuidor(Distribuidor dis)
        {
            //Darlo de alta en la BBDD

            string query = "update dbo.Distribuidor set nombre_empresa = @nombre_empresa , " +
                "stock = @stock " +
                "where id = @id ;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@id", dis.Id);
            cmd.Parameters.AddWithValue("@nombre_empresa", dis.nombre_empresa);
            cmd.Parameters.AddWithValue("@stock", dis.stock);


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
        public static bool eliminarDistribuidor(Distribuidor distEliminar)
        {
            string query = "DELETE FROM dbo.Distribuidor WHERE id = @id;";

            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", distEliminar.Id);

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
