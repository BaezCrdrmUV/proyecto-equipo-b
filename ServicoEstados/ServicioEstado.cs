using ServicoEstados.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicoEstados
{
    public class ServicioEstado : IServicioEstado
    {
        UsuarioEstadoDAO usuarioEstadoDAO;
        EstadoDAO estadoDAO;
        ReaccionDAO reaccionDAO;
        Estado_has_reaccionDAO estado_Has_ReaccionDAO;

        public bool RegistrarEstado(int idUsuario, int idEstadoImagen)
        {
            usuarioEstadoDAO = new UsuarioEstadoDAO();
            estadoDAO = new EstadoDAO();

            try
            {
                int usuarioEstado = usuarioEstadoDAO.RegistrarUsuarioEstado(idUsuario);

                estadoDAO.RegistrarEstado(usuarioEstado, idEstadoImagen);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public bool ReaccionarAEstado(int idEstado, int idReaccion)
        {
            estado_Has_ReaccionDAO = new Estado_has_reaccionDAO();

            try
            {
                estado_Has_ReaccionDAO.RegistrarReaccion(idEstado, idReaccion);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }

        }

        public bool ObtenerEstados(List<int> idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
