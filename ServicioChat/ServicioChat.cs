using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioChat
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ServicioChat : IServicioChat
    {
        public int agregarUsuarioChat(string nombreChat, string nombreUsuario)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format(
                "Insert into UsuarioChat (nombreUsuario,Chat_nombreChat) values ('{0}','{1}')", nombreUsuario, nombreChat), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public int editarMensaje(int idMensaje, int favorito, string mensaje)
        {
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format(
                "Update Mensaje set favorito='{0}', mensaje='{1}' where idMensaje='{2}'", favorito,mensaje,idMensaje), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public int eliminarChat(string nombreChat)
        {
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format(
               "Delete from Chat where nombreChat='{0}'", nombreChat), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public int eliminarMensaje(int idMensaje)
        {
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format(
               "Delete from Mensaje where idMensaje='{0}'", idMensaje), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public int enviarMensaje(string fecha, int favorito, string mensaje, string tipoMensaje, int idMensajeImagen, int mensajeAudio, string UsuarioChat_nombreUsuario, string Chat_nombreChat)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format(
                "Insert into Mensaje (fecha,favorito,mensaje,tipoMensaje,idMensajeImagen,idMensajeAudio,UsuarioChat_nombreUsuario,Chat_nombreChat) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",fecha, favorito, mensaje, tipoMensaje, idMensajeImagen, mensajeAudio,UsuarioChat_nombreUsuario,Chat_nombreChat), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public int modificarChat(string nombreChat, string tipoChat)
        {
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format(
                "Update Chat set tipoChat='{0}' where nombreChat='{1}'",tipoChat,nombreChat), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public List<Mensaje> obtenerContenidoChat(string Chat_nombreChat)
        {
            List<Mensaje> list = new List<Mensaje>();
            MySqlCommand comando = new MySqlCommand(string.Format(
                "Select * from Mensaje where Chat_nombreChat='{0}' ORDER BY Mensaje.fecha DESC", Chat_nombreChat), Conexion.ObtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Mensaje mensaje = new Mensaje(reader.GetInt32(0),reader.GetString(1),reader.GetInt32(2),reader.GetString(3),reader.GetString(4),reader.GetInt32(5),reader.GetInt32(6),reader.GetString(7),reader.GetString(8));
                list.Add(mensaje);
            }
            return list;
        }

        public int registrarChat(string nombreChat, string tipoChat)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format(
                "Insert into Chat (nombreChat,tipoChat) values ('{0}','{1}')", nombreChat, tipoChat), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public int salirDeChatGrupal(string nombreUsuario, string Chat_nombreChat)
        {
            int retorno;
            MySqlCommand comando = new MySqlCommand(string.Format(
               "Delete from UsuarioChat where nombreUsuario='{0}' and Chat_nombreChat ='{1}'",nombreUsuario,Chat_nombreChat), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
