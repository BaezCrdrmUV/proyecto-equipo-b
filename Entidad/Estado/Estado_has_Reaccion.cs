using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace proyecto_equipo_b.Entidad.Estado{
    public class Estado_has_Reaccion{
        public int Estado_idEstado {get; set;}
        public int Reaccion_idReaccion {get; set;}
    }
}