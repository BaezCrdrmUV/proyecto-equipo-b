using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;

namespace ServicoEstados
{
   
    [ServiceContract]
    public interface IServicioEstado
    {
        [OperationContract]
        bool RegistrarEstado(int idUsuario, int idEstadoImagen);

        [OperationContract]
        bool ReaccionarAEstado(int idEstado, int idReaccion);

        [OperationContract]
        bool ObtenerEstados(List<int> idUsuario);
    }

    [DataContract]
    public class Estados
    {
        [DataMember]
        int idUsuario;
        [DataMember]
        List<int> idEstadoImagen;
    }
}

