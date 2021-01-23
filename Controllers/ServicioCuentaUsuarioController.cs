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
        public CuentaCompleta obtenerNombreUSuario(string correo,string contrasena){
            InstanceContext instanceContext = new InstanceContext(this);
                ServicioCuentaUsuarioClient client = new ServicioCuentaUsuarioClient();
                CuentaCompleta cuenta = new CuentaCompleta();
                Console.WriteLine("===============================");
                Console.WriteLine(correo);
                Console.WriteLine(contrasena);
                cuenta = client.IniciarSesion("wcf@gmail.com", "contrasenaWCF");
                Console.WriteLine(cuenta.nombreUsuario);
                Console.WriteLine("Aquí entró");
            return cuenta;
        }


      [HttpPost("registrarUsuario")]
       public int PostLigarLiastaConCancion()
        {
           int respuesta;
            ServicioCuentaUsuarioClient client = new ServicioCuentaUsuarioClient();
            respuesta = client.RegistrarUsuario("UsuarioPostman","usuarioPostmane@gmail.com","123456","2281852805",6,1);
            Console.WriteLine("===============================");
            Console.WriteLine("Aquí entró");
        return respuesta;
        }

      [HttpPut("modificarUsuario")]
      public int PutModificarUsuario(){
          int respuesta;
            ServicioCuentaUsuarioClient client = new ServicioCuentaUsuarioClient();
            respuesta = client.ModificarUsuario(9,"UsuarioPostman1","usuarioPostmane@gmail.com","123456","2281852805",6,1);
            Console.WriteLine("===============================");
            Console.WriteLine("Aquí entró");
        return respuesta;
      }  

    }

}