using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.CuentaUsuario{
    public class LoginCuenta{
        [Key]
        public string correo1 {get;set;}
        public string contrasena2 {get; set;}
    }
}