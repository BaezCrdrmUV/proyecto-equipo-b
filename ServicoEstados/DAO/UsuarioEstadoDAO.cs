using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoEstados.DAO
{
    class UsuarioEstadoDAO
    {
        MySqlConnection conexion = null;

        public UsuarioEstadoDAO()
        {

        }

        public int RegistrarUsuarioEstado(int idUsuario)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "INSERT INTO usuarioestado (idUsuario) VALUES (?idUsuario); SELECT LAST_INSERT_ID()";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idUsuario", idUsuario);
            int idUsuarioEstado = Convert.ToInt32(comando.ExecuteScalar());
            ConexionDAO.CerrarConexion();

            return idUsuarioEstado;
        }

        public int RecuperarIdDeE(List<int> idUsuario)
        {
            conexion = ConexionDAO.ObtenerConexion();
            string consulta = "SELECT idUsuarioEstado FROM usuarioestado WHERE ?idUsuario = idUsuario";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?idUsuario", idUsuario);
            comando.ExecuteReader();
            ConexionDAO.CerrarConexion();

            //return idUsuarioEstado;
        }
    }
}
