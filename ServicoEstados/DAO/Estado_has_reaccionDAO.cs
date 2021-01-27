using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoEstados.DAO
{
    class Estado_has_reaccionDAO
    {
        MySqlConnection conexion = null;

        public Estado_has_reaccionDAO()
        {

        }

        public void RegistrarReaccion(int idEstado, int idReaccion)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "INSERT INTO estado_has_reaccion (Estado_idEstado, Reaccion_idReaccion) VALUES (?idEstado, ?idReaccion)";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idEstado", idEstado);
            comando.Parameters.AddWithValue("?idReaccion", idReaccion);
            comando.ExecuteNonQuery();
            ConexionDAO.CerrarConexion();
        }
    }
}
