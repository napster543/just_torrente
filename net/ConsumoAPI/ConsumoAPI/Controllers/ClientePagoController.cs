using ConsumoAPI.Datos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientePagoController : Controller
    {
        DatosClientePago _ClienteDatos = new DatosClientePago();
        [HttpGet("{cedula}")]
        public JsonResult ListarAjax(string cedula = "")
        {
            var oLista = _ClienteDatos.Listar(cedula);
            return Json(new { data = oLista });
        }
        [HttpGet]
        public JsonResult ListarAjax()
        {
            var oLista = _ClienteDatos.Listar("");
            return Json(new { data = oLista });
        }

    }
}
