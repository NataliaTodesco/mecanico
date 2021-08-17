using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NuevaApi.Models;
using Resultado;

namespace NuevaApi.Controllers
{
    [ApiController]
    [EnableCors("Prog3")]
    public class EspecialidadController : ControllerBase
    {

        private readonly ILogger<EspecialidadController> _logger;
        private readonly mecanicoApiContext db = new mecanicoApiContext();

        public EspecialidadController(ILogger<EspecialidadController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Especialidad/ObtenerEspecialidad")]
        public ActionResult<ResultadoApi> Get(){
            ResultadoApi resultado = new ResultadoApi();
            try
            {
                resultado.Return = db.Especialidades.ToList();
                resultado.Ok = true;
                return resultado;
            }
            catch (System.Exception ex)
            {
                resultado.Error = "Error "+ex.Message;
                resultado.Ok = false;
                return resultado;
            }
        }
    }
}
