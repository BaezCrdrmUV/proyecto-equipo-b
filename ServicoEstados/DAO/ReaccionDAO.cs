using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoEstados.DAO
{
    class ReaccionDAO
    {
        MySqlConnection conexion = null;

        public ReaccionDAO()
        {

        }

        /*public int ObtenerIdReaccion(string nombreReaccion)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT idReaccion FROM reaccion WHERE nombreReaccion = ?nombreReaccion";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?nombreReaccion", nombreReaccion);
            int idReaccion = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idReaccion;
        }*/

    }
}
