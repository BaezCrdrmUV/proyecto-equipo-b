using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace proyecto_equipo_b.Controllers
{
    [ApiController]
    [Route("cuenta/")]

    public class ServicioCuentaUsuarioController : Controller{
    
    [HttpGet]
    public string obtenerString(){

        return "Hola";
    }

    [HttpGet("hola")]
    public String obtenerHola(){
        return "Hola 2";
    }

    }

}