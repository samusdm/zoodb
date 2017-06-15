using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ZooApp.Models;


namespace ZooApp.DB
{
    public class Db
    {
        private static SqlConnection conexion = null;

        public static void Conectar()
        {
            try
            {

                string cadenaConexion = @"Server=.\sqlexpress;
                                          Database=zoodb;
                                          User Id=zoouser;
                                          Password=zoouser;";

                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                conexion.Open();

            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
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
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }

        public static List<TiposAnimal> GetTiposAnimales()
        {
            List<TiposAnimal> resultado = new List<TiposAnimal>();

            string procedimiento = "dbo.GetTiposAnimales";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);

            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                TiposAnimal ClaseDeAnimal = new TiposAnimal();
                ClaseDeAnimal.id = (long)reader["idTipoAnimal"];
                ClaseDeAnimal.denominacion = reader["denominacion"].ToString();

                resultado.Add(ClaseDeAnimal);
            }
            return resultado;
        }

        public static List<TiposAnimal> GetTiposAnimalesPorId(long id)
        {
            List<TiposAnimal> resultado = new List<TiposAnimal>();

            string procedimiento = "dbo.GetTiposAnimalesPorId";


            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                TiposAnimal ClaseDeAnimal = new TiposAnimal();
                ClaseDeAnimal.id = (long)reader["idTipoAnimal"];
                ClaseDeAnimal.denominacion = reader["denominacion"].ToString();

                resultado.Add(ClaseDeAnimal);
            }
            return resultado;
        }

        public static int AgregarTiposAnimales(TiposAnimal claseDeAnimal)
        {
            string procedimiento = "dbo.AgregarTipoAnimal";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO (LA BD)
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "denominacion";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = claseDeAnimal.denominacion;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int ActualizarTiposAnimales(long id, TiposAnimal claseDeAnimal)
        {
            string procedimiento = "dbo.ActualizarTiposAnimales";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);

            SqlParameter parametroDenominacion = new SqlParameter();
            parametroDenominacion.ParameterName = "denominacion";
            parametroDenominacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacion.SqlValue = claseDeAnimal.denominacion;
            comando.Parameters.Add(parametroDenominacion);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarTipoAnimal(long id)
        {
            string procedimiento = "dbo.EliminarTipoAnimal";

            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idTipoAnimal";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = id;
            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static List<Clasificacion> GetClasificacion()
        {
            List<Clasificacion> resultado = new List<Clasificacion>();

            string procedimiento = "dbo.GetClasificacion";


            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Clasificacion clasific = new Clasificacion();
                clasific.id = (int)reader["idClasificacion"];
                clasific.denominacion = reader["denominacion"].ToString();
                resultado.Add(clasific);
            }
            return resultado;
        }

        public static List<Clasificacion> GetClasificacionPorId(long id)
        {
            List<Clasificacion> resultado = new List<Clasificacion>();

            string procedimiento = "dbo.GetClasificacionPorId";

  
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
           
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idClasificacion";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Clasificacion clasific = new Clasificacion();
                clasific.id = (int)reader["idClasificacion"];
                clasific.denominacion = reader["denominacion"].ToString();
                // añadir a la lista que voy a devolver
                resultado.Add(clasific);
            }
            return resultado;
        }

        public static int AgregarClasificacion(Clasificacion clasif)
        {
            string procedimiento = "dbo.AgregarClasificacion";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO (LA BD)
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "denominacion";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = clasif.denominacion;

            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int ActualizarClasificacion(long id, Clasificacion clasif)
        {
            string procedimiento = "dbo.ActualizarClasificacion";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO (LA BD)
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idTipoAnimal";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = id;
            comando.Parameters.Add(parametro);

            SqlParameter parametroDenominacion = new SqlParameter();
            parametroDenominacion.ParameterName = "denominacion";
            parametroDenominacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacion.SqlValue = clasif.denominacion;
            comando.Parameters.Add(parametroDenominacion);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarClasificacion(long id)
        {
            string procedimiento = "dbo.EliminarClasificacion";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO (LA BD)
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idClasificacion";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = id;
            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        // <<<<<<<<<FUNCIONES PARA ESPECIE>>>>>>>>>>>

        public static List<Especie> GetEspecies()
        {
            // CREO EL OBJETO EN EL QUE SE DEVOLVERÁN LOS RESULTADOS
            List<Especie> resultado = new List<Especie>();

            // PREPARO LA LLAMADA AL PROCEDIMIENTO ALMACENADO
            string procedimiento = "dbo.GetEspecies";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // RECORRO EL RESULTADO Y LO PASO A LA VARIABLE A DEVOLVER
            while (reader.Read())
            {
                // CREO LA ESPECIE
                Especie especie = new Especie();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.nombre = reader["NombreEspecie"].ToString();
                especie.Clasificacion = new Clasificacion();
                especie.Clasificacion.id = (int)reader["idClasificacion"];
                especie.Clasificacion.denominacion = reader["Clasificacion"].ToString();
                especie.TipoAnimal = new TiposAnimal();
                especie.TipoAnimal.id = (int)reader["idClasificacion"];
                especie.TipoAnimal.denominacion = reader["Clasificacion"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];
                // AÑADO LA ESPECIE A LA LISTA DE RESULTADOS
                resultado.Add(especie);
            }
            return resultado;
        }

        public static List<Especie> GetEspeciesPorId(long id)
        {
            // CREO EL OBJETO EN EL QUE SE DEVOLVERÁN LOS RESULTADOS
            List<Especie> resultado = new List<Especie>();

            // PREPARO LA LLAMADA AL PROCEDIMIENTO ALMACENADO
            string procedimiento = "dbo.GetEspeciesPorId";

            // PREPARAMOS EL COMANDO PARA EJECUTAR EL PROCEDIMIENTO ALMACENADO
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idEspecie";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);

            SqlDataReader reader = comando.ExecuteReader();
            // RECORRO EL RESULTADO Y LO PASO A LA VARIABLE A DEVOLVER
            while (reader.Read())
            {
                // CREO LA ESPECIE
                Especie especie = new Especie();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.nombre = reader["NombreEspecie"].ToString();
                especie.Clasificacion = new Clasificacion();
                especie.Clasificacion.id = (int)reader["idClasificacion"];
                especie.Clasificacion.denominacion = reader["Clasificacion"].ToString();
                especie.TipoAnimal = new TiposAnimal();
                especie.TipoAnimal.id = (int)reader["idClasificacion"];
                especie.TipoAnimal.denominacion = reader["Clasificacion"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];
                // AÑADO LA ESPECIE A LA LISTA DE RESULTADOS
                resultado.Add(especie);
            }
            return resultado;
        }




    }
}