using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ZooApp.Models;

namespace ZooApp.DB
{
    public static class Db
    {
        private static SqlConnection conexion = null;

        public static void Conectar()
        {
            try
            {
                string cadenaConexion = @"Server=.\sqlexpress;
                                        database=zoodb;
                                        usser Id= zoouser;
                                        Password=zoouser;";


                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                conexion.Open();


            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != System.Data.ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
            finally
            {

            }
        }

             public static bool EstaLaConexionAbierta()
        {
            return conexion.State == System.Data.ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != System.Data.ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }


        public static List<TiposAnimal> GetTiposAnimales()
        {
            List<TiposAnimal> resultado = new List<TiposAnimal>();

            // PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GetTiposAnimales";
            // PREPARO EL COMANDO PARA LA BD
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
            comando.CommandType = CommandType.StoredProcedure;
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
            while (reader.Read())
            {
                TiposAnimal marca = new TiposAnimal();
                TiposAnimal.id = (long)reader["id"];
                TiposAnimal.denominacion = reader["denominacion"].ToString();
                resultado.Add(TiposAnimal);
            }

            return resultado;
        }



    }
    }
