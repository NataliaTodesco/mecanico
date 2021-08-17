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
    public class ZonaController : ControllerBase
    {

        private readonly ILogger<ZonaController> _logger;
        private readonly mecanicoApiContext db = new mecanicoApiContext();

        public ZonaController(ILogger<ZonaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Zona/ObtenerZonas")]
        public ActionResult<ResultadoApi> Get(){
            ResultadoApi resultado = new ResultadoApi();
            try
            {
                resultado.Return = db.Zonas.ToList();
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