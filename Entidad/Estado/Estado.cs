using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Estado{
    public class Estado{
        [Key]
        public int idEstado {get; set;}
        public String fecha {get; set;}
        public int UsuarioEstado_idUsuarioEstado {get; set;}
        public int idEstadoImagen {get; set;}
    }
}