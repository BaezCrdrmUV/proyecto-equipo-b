using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_equipo_b.Entidad.Multimedia;
using ServicioMultimedia;

namespace proyecto_equipo_b.Controllers
{
    [ApiController]
    [Route("multimedia/")]

    public class ServicioMultimediaController : Controller{

        FotoCuentaUsuarioClient servicioCuentaUsuario;
        MensajeImagenClient servicioMensaje;
        AudioDeMensajeClient servicioAudio;


        [HttpPost("registrarFotoCuentaUsuario")]
        public Task<int> RegistrarFotoCuentaUsuario([FromBody] FotoCuentaUsuario fotoStringBase64)
        {
            servicioCuentaUsuario = new FotoCuentaUsuarioClient();
            return servicioCuentaUsuario.RegistrarFotoCuentaUsuarioAsync(fotoStringBase64.foto);
        }

        [HttpGet("obtenerFotoDeCuenta")]
        public Task<string> ObtenerFotoCuentaUsuario(int idFotoCuentaUsuario)
        {
            servicioCuentaUsuario = new FotoCuentaUsuarioClient();
            return servicioCuentaUsuario.ObtenerFotoCuentaUsuarioAsync(idFotoCuentaUsuario);
        }


        [HttpPost("registrarFotoMensaje")]
        public Task<int> RegistrarFotoMensaje(string fotoStringBase64)
        {
            servicioMensaje = new MensajeImagenClient();
            return servicioMensaje.RegistrarFotoDeMensajeAsync(fotoStringBase64);
        }

        [HttpGet("obtenerFotoDeMensaje")]
        public Task<string> ObtenerFotoDeMensaje(int idMensajeImagen)
        {
            servicioMensaje = new MensajeImagenClient();
            return servicioMensaje.ObtenerFotoDeMensajeAsync(idMensajeImagen);
        }

        [HttpPost("registrarAudioMensaje")]
        public Task<int> RegistrarAudioMensaje(string audioStringBase64)
        {
            servicioAudio = new AudioDeMensajeClient();
            return servicioAudio.RegistrarAudioDeMensajeAsync(audioStringBase64);
        }

        [HttpGet("obtenerAudioDeMensaje")]
        public Task<string> ObtenerAudioDeMensaje(int idMensajeAudio)
        {
            servicioAudio = new AudioDeMensajeClient();
            return servicioAudio.ObtenerAudioDeMensajeAsync(idMensajeAudio);
        }

    }

}