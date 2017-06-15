using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZooApp.Models;
using ZooApp.DB;

namespace ZooApi.Controllers
{
    public class EspecieController : ApiController
    {
        // GET: api/Especie
        public RespuestaApi Get()
        {
            RespuestaApi resultado = new RespuestaApi();
            List<Especie> listaEspecie = new List<Especie>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaEspecie = Db.GetEspecies();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = listaEspecie.Count;
            resultado.dataEspecie = listaEspecie;
            return resultado;
        }

        // GET: api/Especie/5
        public RespuestaApi Get(long id)
        {
            RespuestaApi resultado = new RespuestaApi();
            List<Especie> listaEspecie = new List<Especie>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaEspecie = Db.GetEspeciesPorId(id);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = listaEspecie.Count;
            resultado.dataEspecie = listaEspecie;
            return resultado;
        }

        // POST: api/Especie
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Especie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Especie/5
        public void Delete(int id)
        {
        }
    }
}
