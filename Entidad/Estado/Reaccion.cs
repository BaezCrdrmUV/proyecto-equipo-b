using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Estado{
    public class Reaccion{
        [Key]
        public int idReaccion {get; set;}
        public string nombreReaccion {get; set;}
    }
}