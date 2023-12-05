﻿using EjemploABM.Controladores;
using EjemploABM.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGamer.Controladores
{
    internal class Categoria_Controller
    {
        //OBTENER LA CATEGORIA
        public static List<Categoria> obtenerCategoria(int paginaActual, int elementosPorPagina)
        {
            List<Categoria> list = new List<Categoria>();
            int offset = (paginaActual - 1) * elementosPorPagina;
            string query = $"SELECT * FROM dbo.Categoria ORDER BY Id OFFSET {offset} ROWS FETCH NEXT {elementosPorPagina} ROWS ONLY;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);

            try
            {
                DB_Controller.connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Categoria(reader.GetInt32(0), reader.GetString(1)));
                    Trace.WriteLine("Categoria encontrado, nombre: " + reader.GetString(1));
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
        public static bool VerificarCategoriaExistente(string nombreCategoria)
        {
            // Realizar la consulta a la base de datos para verificar si ya existe un producto con este nombre
            string query = "SELECT COUNT(*) FROM dbo.Categoria WHERE nombre_categoria = @nombreCategoria";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@nombreCategoria", nombreCategoria);

            try
            {
                DB_Controller.connection.Open();
                int count = (int)cmd.ExecuteScalar();
                DB_Controller.connection.Close();

                // Si count es mayor que cero, significa que ya existe un producto con ese nombre
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar el producto: " + ex.Message);
            }
        }

        //SACAR EL MAXID
        public static int obtenerMaxId()
        {
            int MaxId = 0;
            string query = "select max(id) from dbo.Categoria;";

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

        //OBTENER CATEGORIA POR ID
        public static Categoria ObtenerCategoriaID(int id)
        {
            Categoria categoria= new Categoria();
            string query = "SELECT * FROM dbo.Categoria WHERE id = @id;";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    DB_Controller.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        categoria = new Categoria
                        {
                            Id = reader.GetInt32(0),
                            Nombre_categoria = reader.GetString(1),
                            
                        };
                    }
                    reader.Close();
                }
                finally
                {
                    DB_Controller.connection.Close();
                }
            }
            return categoria;
        }

        //CREAR CATEGORIA
        public static bool CrearCategoria(Categoria categoria)
        {
            string query = "INSERT INTO dbo.Categoria (id,nombre_categoria) " +
                           "VALUES (@id,@nombre);";
            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", obtenerMaxId() + 1);
                cmd.Parameters.AddWithValue("@nombre", categoria.Nombre_categoria);

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

        public static bool editarCategoria(Categoria cat)
        {
            //Darlo de alta en la BBDD

            string query = "update dbo.Categoria set nombre_categoria = @nombre_categoria " +
                "where id = @id ;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@id", cat.Id);
            cmd.Parameters.AddWithValue("@nombre_categoria", cat.Nombre_categoria);


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
        public static bool eliminarCategoria(Categoria catEliminar)
        {
            string query = "DELETE FROM dbo.Categoria WHERE id = @id;";

            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", catEliminar.Id);

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
