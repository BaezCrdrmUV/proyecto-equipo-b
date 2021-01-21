using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaUsuarioDB
{
    class Program
    {
        static void Main(string[] args)
        {
            CuentasDeUsuario c= new CuentasDeUsuario();

            List<genero> g = new List<genero>();
            g = c.genero.ToList();

            foreach (genero gen in g)
            {
                Console.WriteLine(gen.genero1);
            }

            Console.ReadLine();
        }
    }
}
