using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaDB
{
    class Program
    {
        static void Main(string[] args)
        {
            multimediaEntities m = new multimediaEntities();
            List<direccion> d = new List<direccion>();

            d = m.direccion.ToList();

            foreach (direccion dir in d)
            {
                Console.WriteLine(dir.direccion1);
            }

            Console.ReadLine();
        }
    }
}
