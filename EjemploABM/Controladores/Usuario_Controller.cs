﻿using EjemploABM.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploABM.Controladores
{
    class Usuario_Controller
    {

        // GET ONE


        public static bool autenticar(string usr, string pass, bool hasheado)
        {
            Usuario user = new Usuario();
            string query = "SELECT * FROM dbo.Usuario WHERE nombre_usuario = @usr AND contrasena_usuario = @pass;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@usr", usr);
            if (hasheado)
            {
                cmd.Parameters.AddWithValue("@pass", pass);
            }

            try
            {
                DB_Controller.connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Trace.WriteLine("Usr encontrado, nombre: " + reader.GetString(1));
                        user = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), "", reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetInt32(8));
                    }

                    reader.Close();
                    DB_Controller.connection.Close();
                    Program.logueado = user;
                    return true;
                }
                else
                {
                    reader.Close();
                    DB_Controller.connection.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }
        }


        // POST

        public static bool crearUsuario(Usuario usr)
        {
            //Darlo de alta en la BBDD

            string query = "insert into dbo.Usuario values" +
               "(@id, " +
               "@nombre_usuario, " +
               "@mail, " +
               "@contrasena_usuario, " +
               "@nombre, " +
               "@apellido, " +
               "@telefono, " +
               "@direccion, " +
               "@rol);";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@id", obtenerMaxId() + 1);
            cmd.Parameters.AddWithValue("@nombre_usuario", usr.usuario);
            cmd.Parameters.AddWithValue("@mail", usr.Mail);
            cmd.Parameters.AddWithValue("@contrasena_usuario", usr.Contraseña);
            cmd.Parameters.AddWithValue("@nombre", usr.Nombre);
            cmd.Parameters.AddWithValue("@apellido", usr.Apellido);
            cmd.Parameters.AddWithValue("@telefono", usr.Telefono);
            cmd.Parameters.AddWithValue("@direccion", usr.Direccion);
            cmd.Parameters.AddWithValue("@rol", usr.ID_rol);
            

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

        public static bool VerificarUsuarioExistente(string nombreUsuario)
        {
            // Realizar la consulta a la base de datos para verificar si ya existe un producto con este nombre
            string query = "SELECT COUNT(*) FROM dbo.Usuario WHERE nombre_usuario = @nombreUsuario";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

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
                throw new Exception("Error al verificar el Usuario: " + ex.Message);
            }
        }

        // OBTENER EL MAX ID

        public static int obtenerMaxId()
        {
            int MaxId = 0;
            string query = "select max(id) from dbo.Usuario;";

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


        // GET ALL

        public static List<Usuario> obtenerTodos(int paginaActual, int elementosPorPagina)
        {
            List<Usuario> list = new List<Usuario>();
            int offset = (paginaActual - 1) * elementosPorPagina;
            string query = $"SELECT * FROM dbo.Usuario ORDER BY Id OFFSET {offset} ROWS FETCH NEXT {elementosPorPagina} ROWS ONLY;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);

            try
            {
                DB_Controller.connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), "", reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetInt32(8)));
                    Trace.WriteLine("Usr encontrado, nombre: " + reader.GetString(1));
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



        // GET ONE BY ID

        public static Usuario obtenerPorId(int id)
        {
            Usuario usr = new Usuario();
            string query = "select * from dbo.Usuario where id = @id;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                DB_Controller.connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usr = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), "", reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetInt32(8));
                    Trace.WriteLine("Usr encontrado, nombre: " + reader.GetString(1));
                }

                reader.Close();
                DB_Controller.connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la query: " + ex.Message);
            }

            return usr;
        }



        // EDIT / PUT

        public static bool editarUsuario(Usuario usr)
        {
            //Darlo de alta en la BBDD

            string query = "update dbo.Usuario set nombre_usuario = @nombre_usuario , " +
                "nombre = @nombre , " +
                "apellido = @apellido , " +
                "rol = @rol " + 
                "where id = @id ;";

            SqlCommand cmd = new SqlCommand(query, DB_Controller.connection);
            cmd.Parameters.AddWithValue("@id", usr.Id);
            cmd.Parameters.AddWithValue("@nombre_usuario", usr.usuario);
            cmd.Parameters.AddWithValue("@mail", usr.Mail);
            cmd.Parameters.AddWithValue("@contrasena_usuario", usr.Contraseña);
            cmd.Parameters.AddWithValue("@nombre", usr.Nombre);
            cmd.Parameters.AddWithValue("@apellido", usr.Apellido);
            cmd.Parameters.AddWithValue("@telefono", usr.Telefono);
            cmd.Parameters.AddWithValue("@direccion", usr.Direccion);
            cmd.Parameters.AddWithValue("@rol", usr.ID_rol);

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

        public static bool eliminarUsuario(Usuario usuarioEliminar)
        {
            string query = "DELETE FROM dbo.Usuario WHERE id = @id;";

            using (SqlCommand cmd = new SqlCommand(query, DB_Controller.connection))
            {
                cmd.Parameters.AddWithValue("@id", usuarioEliminar.Id);

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
