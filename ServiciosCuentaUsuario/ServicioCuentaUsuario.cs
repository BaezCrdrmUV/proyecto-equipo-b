using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace ServiciosCuentaUsuario
{
   
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ServicioCuentaUsuario : IServicioCuentaUsuario
    {
        int salida;
        int salida2;
        Cuenta cuenta;
        public Cuenta IniciarSesion(string correo, string contrasena)
        {
            
            MySqlCommand comando = new MySqlCommand(string.Format(
                "Select Cuenta_idCuenta from Contrasena where contrasena='{0}'", contrasena), Conexion.ObtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                salida = reader.GetInt32(0);
            }

            MySqlCommand comando2 = new MySqlCommand(string.Format(
                "Select Cuenta_idCuenta from Correo where correo='{0}'", correo), Conexion.ObtenerConexion());
            MySqlDataReader reader2 = comando2.ExecuteReader();
            while (reader2.Read())
            {
                salida2 = reader2.GetInt32(0);
            }
            
            if(salida == salida2)
            {
                MySqlCommand comando3 = new MySqlCommand(string.Format(
                "Select idCuenta, nombreUsuario, idFotoCuentaUsuario ,Genero_idGenero from Cuenta where idCuenta='{0}'", salida), Conexion.ObtenerConexion());
                MySqlDataReader reader3 = comando3.ExecuteReader();

                while (reader3.Read())
                {
                    cuenta = new Cuenta(reader3.GetInt32(0),reader3.GetString(1),reader3.GetInt32(2),reader3.GetInt32(3));
                }
               
                return cuenta;

            }
            return cuenta;
        }

        public MensajeR RegistrarUsuario(Cuenta cuenta, Contrasena contrasena, Correo correo, Telefono telefono)
        {
            throw new NotImplementedException();
        }
    }
}
