﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioChat
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Mensaje", Namespace="http://schemas.datacontract.org/2004/07/ServicioChat")]
    public partial class Mensaje : object
    {
        
        private string Chat_nombreChatField;
        
        private string UsuarioChat_nombreUsuarioField;
        
        private string dateField;
        
        private int favoritoField;
        
        private int idMensajeField;
        
        private int idMensajeAudioField;
        
        private int idMensajeImagenField;
        
        private string mensajeField;
        
        private string tipoMensajeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Chat_nombreChat
        {
            get
            {
                return this.Chat_nombreChatField;
            }
            set
            {
                this.Chat_nombreChatField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuarioChat_nombreUsuario
        {
            get
            {
                return this.UsuarioChat_nombreUsuarioField;
            }
            set
            {
                this.UsuarioChat_nombreUsuarioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int favorito
        {
            get
            {
                return this.favoritoField;
            }
            set
            {
                this.favoritoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idMensaje
        {
            get
            {
                return this.idMensajeField;
            }
            set
            {
                this.idMensajeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idMensajeAudio
        {
            get
            {
                return this.idMensajeAudioField;
            }
            set
            {
                this.idMensajeAudioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idMensajeImagen
        {
            get
            {
                return this.idMensajeImagenField;
            }
            set
            {
                this.idMensajeImagenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string mensaje
        {
            get
            {
                return this.mensajeField;
            }
            set
            {
                this.mensajeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tipoMensaje
        {
            get
            {
                return this.tipoMensajeField;
            }
            set
            {
                this.tipoMensajeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Reacion_has_Mensaje", Namespace="http://schemas.datacontract.org/2004/07/ServicioChat")]
    public partial class Reacion_has_Mensaje : object
    {
        
        private int Mensaje_idMensajeField;
        
        private int Reaccion_idReaccionField;
        
        private string UsuarioChat_nombreUsuarioField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Mensaje_idMensaje
        {
            get
            {
                return this.Mensaje_idMensajeField;
            }
            set
            {
                this.Mensaje_idMensajeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Reaccion_idReaccion
        {
            get
            {
                return this.Reaccion_idReaccionField;
            }
            set
            {
                this.Reaccion_idReaccionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuarioChat_nombreUsuario
        {
            get
            {
                return this.UsuarioChat_nombreUsuarioField;
            }
            set
            {
                this.UsuarioChat_nombreUsuarioField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Amigo", Namespace="http://schemas.datacontract.org/2004/07/ServicioChat")]
    public partial class Amigo : object
    {
        
        private string amigoNombreUsuarioField;
        
        private int idAmigoField;
        
        private string nombreUsuarioField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string amigoNombreUsuario
        {
            get
            {
                return this.amigoNombreUsuarioField;
            }
            set
            {
                this.amigoNombreUsuarioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idAmigo
        {
            get
            {
                return this.idAmigoField;
            }
            set
            {
                this.idAmigoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombreUsuario
        {
            get
            {
                return this.nombreUsuarioField;
            }
            set
            {
                this.nombreUsuarioField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioChat.IServicioChat")]
    public interface IServicioChat
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/registrarChat", ReplyAction="http://tempuri.org/IServicioChat/registrarChatResponse")]
        System.Threading.Tasks.Task<int> registrarChatAsync(string nombreChat, string tipoChat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/eliminarChat", ReplyAction="http://tempuri.org/IServicioChat/eliminarChatResponse")]
        System.Threading.Tasks.Task<int> eliminarChatAsync(string nombreChat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/agregarUsuarioChat", ReplyAction="http://tempuri.org/IServicioChat/agregarUsuarioChatResponse")]
        System.Threading.Tasks.Task<int> agregarUsuarioChatAsync(string nombreChat, string nombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/enviarMensaje", ReplyAction="http://tempuri.org/IServicioChat/enviarMensajeResponse")]
        System.Threading.Tasks.Task<int> enviarMensajeAsync(string fecha, int favorito, string mensaje, string tipoMensaje, int idMensajeImagen, int mensajeAudio, string UsuarioChat_nombreUsuario, string Chat_nombreChat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/editarMensaje", ReplyAction="http://tempuri.org/IServicioChat/editarMensajeResponse")]
        System.Threading.Tasks.Task<int> editarMensajeAsync(int idMensaje, int favorito, string mensaje);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/eliminarMensaje", ReplyAction="http://tempuri.org/IServicioChat/eliminarMensajeResponse")]
        System.Threading.Tasks.Task<int> eliminarMensajeAsync(int idMensaje);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/modificarChat", ReplyAction="http://tempuri.org/IServicioChat/modificarChatResponse")]
        System.Threading.Tasks.Task<int> modificarChatAsync(string nombreChat, string tipoChat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/salirDeChatGrupal", ReplyAction="http://tempuri.org/IServicioChat/salirDeChatGrupalResponse")]
        System.Threading.Tasks.Task<int> salirDeChatGrupalAsync(string nombreUsuario, string Chat_nombreChat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/obtenerContenidoChat", ReplyAction="http://tempuri.org/IServicioChat/obtenerContenidoChatResponse")]
        System.Threading.Tasks.Task<ServicioChat.Mensaje[]> obtenerContenidoChatAsync(string Chat_nombreChat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/reaccionaMensaje", ReplyAction="http://tempuri.org/IServicioChat/reaccionaMensajeResponse")]
        System.Threading.Tasks.Task<int> reaccionaMensajeAsync(string UsuarioChat_nombreUsuario, int Mensaje_idMensaje, int Reaccion_idReaccion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/obtenerReaccionesMensaje", ReplyAction="http://tempuri.org/IServicioChat/obtenerReaccionesMensajeResponse")]
        System.Threading.Tasks.Task<ServicioChat.Reacion_has_Mensaje[]> obtenerReaccionesMensajeAsync(int Mensaje_idMensaje);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/agregarAmigo", ReplyAction="http://tempuri.org/IServicioChat/agregarAmigoResponse")]
        System.Threading.Tasks.Task<int> agregarAmigoAsync(string nombreUsuario, string amigoNombreUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioChat/obtenerAmigos", ReplyAction="http://tempuri.org/IServicioChat/obtenerAmigosResponse")]
        System.Threading.Tasks.Task<ServicioChat.Amigo[]> obtenerAmigosAsync(string nombreUsuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface IServicioChatChannel : ServicioChat.IServicioChat, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class ServicioChatClient : System.ServiceModel.ClientBase<ServicioChat.IServicioChat>, ServicioChat.IServicioChat
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServicioChatClient() : 
                base(ServicioChatClient.GetDefaultBinding(), ServicioChatClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IServicioChat.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicioChatClient(EndpointConfiguration endpointConfiguration) : 
                base(ServicioChatClient.GetBindingForEndpoint(endpointConfiguration), ServicioChatClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicioChatClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServicioChatClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicioChatClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServicioChatClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServicioChatClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<int> registrarChatAsync(string nombreChat, string tipoChat)
        {
            return base.Channel.registrarChatAsync(nombreChat, tipoChat);
        }
        
        public System.Threading.Tasks.Task<int> eliminarChatAsync(string nombreChat)
        {
            return base.Channel.eliminarChatAsync(nombreChat);
        }
        
        public System.Threading.Tasks.Task<int> agregarUsuarioChatAsync(string nombreChat, string nombreUsuario)
        {
            return base.Channel.agregarUsuarioChatAsync(nombreChat, nombreUsuario);
        }
        
        public System.Threading.Tasks.Task<int> enviarMensajeAsync(string fecha, int favorito, string mensaje, string tipoMensaje, int idMensajeImagen, int mensajeAudio, string UsuarioChat_nombreUsuario, string Chat_nombreChat)
        {
            return base.Channel.enviarMensajeAsync(fecha, favorito, mensaje, tipoMensaje, idMensajeImagen, mensajeAudio, UsuarioChat_nombreUsuario, Chat_nombreChat);
        }
        
        public System.Threading.Tasks.Task<int> editarMensajeAsync(int idMensaje, int favorito, string mensaje)
        {
            return base.Channel.editarMensajeAsync(idMensaje, favorito, mensaje);
        }
        
        public System.Threading.Tasks.Task<int> eliminarMensajeAsync(int idMensaje)
        {
            return base.Channel.eliminarMensajeAsync(idMensaje);
        }
        
        public System.Threading.Tasks.Task<int> modificarChatAsync(string nombreChat, string tipoChat)
        {
            return base.Channel.modificarChatAsync(nombreChat, tipoChat);
        }
        
        public System.Threading.Tasks.Task<int> salirDeChatGrupalAsync(string nombreUsuario, string Chat_nombreChat)
        {
            return base.Channel.salirDeChatGrupalAsync(nombreUsuario, Chat_nombreChat);
        }
        
        public System.Threading.Tasks.Task<ServicioChat.Mensaje[]> obtenerContenidoChatAsync(string Chat_nombreChat)
        {
            return base.Channel.obtenerContenidoChatAsync(Chat_nombreChat);
        }
        
        public System.Threading.Tasks.Task<int> reaccionaMensajeAsync(string UsuarioChat_nombreUsuario, int Mensaje_idMensaje, int Reaccion_idReaccion)
        {
            return base.Channel.reaccionaMensajeAsync(UsuarioChat_nombreUsuario, Mensaje_idMensaje, Reaccion_idReaccion);
        }
        
        public System.Threading.Tasks.Task<ServicioChat.Reacion_has_Mensaje[]> obtenerReaccionesMensajeAsync(int Mensaje_idMensaje)
        {
            return base.Channel.obtenerReaccionesMensajeAsync(Mensaje_idMensaje);
        }
        
        public System.Threading.Tasks.Task<int> agregarAmigoAsync(string nombreUsuario, string amigoNombreUsuario)
        {
            return base.Channel.agregarAmigoAsync(nombreUsuario, amigoNombreUsuario);
        }
        
        public System.Threading.Tasks.Task<ServicioChat.Amigo[]> obtenerAmigosAsync(string nombreUsuario)
        {
            return base.Channel.obtenerAmigosAsync(nombreUsuario);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServicioChat))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServicioChat))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/ServicioChat/Service1/");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ServicioChatClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IServicioChat);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ServicioChatClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IServicioChat);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IServicioChat,
        }
    }
}
