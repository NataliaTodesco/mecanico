using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comandos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NuevaApi.Models;
using Resultado;

namespace NuevaApi.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    public class MecanicoController : ControllerBase
    {
        private readonly ILogger<MecanicoController> _logger;
        private readonly mecanicoApiContext db = new mecanicoApiContext();

        public MecanicoController(ILogger<MecanicoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Mecanico/ObtenerMecanicos")]
        public ActionResult<ResultadoApi> Get(){
            var Resultado = new ResultadoApi();

            try{
                Resultado.Ok = true;
                Resultado.Return = db.Mecanicos.ToList();
                return Resultado;
            }
            catch(Exception ex){
                Resultado.Ok = false;
                Resultado.Error = "Error " + ex.Message;
                return Resultado;
            }
        }
        
        [HttpPost]
        [Route("Mecanico/CargarMecanico")]
        public ActionResult<ResultadoApi> Post(ComandoMecanico comando){
            ResultadoApi resultado = new ResultadoApi();
            try
            {
                if (comando.Nombre == ""){
                    resultado.Error = "Ingrese Nombre";
                    resultado.Ok = false;
                    return resultado;
                }
                Mecanico mec = new Mecanico();
                mec.Nombre = comando.Nombre;
                mec.Apellido = comando.Apellido;
                mec.EspecialidadId = comando.EspecialidadId;
                mec.FechaNacimiento = comando.FechaNacimiento;
                mec.SexoId = comando.SexoId;
                mec.Soltero = comando.Soltero;
                mec.ZonaId = comando.ZonaId;

                db.Mecanicos.Add(mec);
                db.SaveChanges();

                resultado.Return = db.Mecanicos.ToList();
                resultado.Ok = true;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error "+ex.Message;
                return resultado;
            } 
        }

         [HttpPost]
        [Route("[controller]/CargarMecanicos")]
        public ActionResult<ResultadoApi> Post2(int id){
            ResultadoApi resultado = new ResultadoApi();
            try
            {
                resultado.Return = db.Mecanicos.ToList();
                resultado.Ok = true;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error "+ex.Message;
                return resultado;
            } 
        }


            [HttpPut]
            [Route("Mecanico/ActualizarMecanico")]
            public ActionResult<ResultadoApi> Put([FromBody] ComandoMecanico comando){
                ResultadoApi resultado = new ResultadoApi();
                try
                {
                    var mec = db.Mecanicos.Where(c => c.MecanicoId == comando.MecanicoId).FirstOrDefault();
                    if (mec != null){
                        mec.Nombre = comando.Nombre;
                        mec.Apellido = comando.Apellido;
                        mec.EspecialidadId = comando.EspecialidadId;
                        mec.FechaNacimiento = comando.FechaNacimiento;
                        mec.SexoId = comando.SexoId;
                        mec.Soltero = comando.Soltero;
                        mec.ZonaId = comando.ZonaId;

                        db.Mecanicos.Update(mec);
                        db.SaveChanges();
                    }

                    resultado.Ok = true;
                    resultado.Return = db.Mecanicos.ToList();
                    return resultado;
                }
                catch (System.Exception ex)
                {
                    resultado.Ok = false;
                    resultado.Error = "Error "+ex.Message;
                    return resultado;
                }


            }
    }
}
