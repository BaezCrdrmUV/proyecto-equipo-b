using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Estado{
    public class TipoEstado{
        [Key]
        public int idTipoEstado {get; set;}
        public string tipo {get; set;}
        public int Estado_idEstado {get; set;}
    }
}