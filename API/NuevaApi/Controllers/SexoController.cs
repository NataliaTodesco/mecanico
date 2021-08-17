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
    public class SexoController : ControllerBase
    {

        private readonly ILogger<SexoController> _logger;
        private readonly mecanicoApiContext db = new mecanicoApiContext();

        public SexoController(ILogger<SexoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/ObtenerSexo")]
        public ActionResult<ResultadoApi> Get(){
            ResultadoApi resultado = new ResultadoApi();
            try
            {
                resultado.Return = db.Sexos.ToList();
                resultado.Ok = true;
                return Ok(resultado);
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