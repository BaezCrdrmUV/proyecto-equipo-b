using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicioCuentaUsuario;

namespace proyecto_equipo_b.Controllers
{
    [ApiController]
    [Route("cuenta/")]

    [CallbackBehavior(UseSynchronizationContext = false)]
    public class ServicioCuentaUsuarioController : Controller{

    [HttpPost("login")]
    public Cuenta obtenerNombreUSuario(string correo,string contrasena){
        InstanceContext instanceContext = new InstanceContext(this);
            ServicioCuentaUsuarioClient client = new ServicioCuentaUsuarioClient();
            Cuenta cuenta = new Cuenta();
            Console.WriteLine("===============================");
            Console.WriteLine(correo);
            Console.WriteLine(contrasena);
            cuenta = client.IniciarSesion("javierjuarez385@gmail.com", "123456");
            Console.WriteLine(cuenta.nombreUsuario);
            Console.WriteLine("Aquí entró");
        return cuenta;
    }


      [HttpPost("obtenerUsuario")]
       public Cuenta PostLigarLiastaConCancion()
       {
           
            ServicioCuentaUsuarioClient client = new ServicioCuentaUsuarioClient();
            Cuenta cuenta = new Cuenta();
            Console.WriteLine("===============================");
            
            Console.WriteLine(cuenta.nombreUsuario);
            Console.WriteLine("Aquí entró");
        return cuenta;
        }



    [HttpGet("hola")]
    public String obtenerHola(){
        return "Hola 2";
    }

    }

}