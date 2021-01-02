using Api.Attributes;
using Api.ViewModels;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ExceptionFilterAttribute]
    [Route("salas")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly ISalaService _salaService;
        public SalasController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        [HttpGet]
        public IEnumerable<Sala> Get()
        {
            return _salaService.Obter();
        }

        [HttpGet("{nomeSala}/participante/{apelido}/mensagens")]
        public IEnumerable<string> ObterMensagensDoParticipante(string nomeSala, string apelido)
        {
            return _salaService.ObterMensagemDoParticipante(nomeSala, apelido);
        }

        [HttpPost("{nomeSala}/participante")]
        public void Post(string nomeSala, [FromBody] ParticipanteViewModel participanteViewModel)
        {
            _salaService.AdicionarParticipante(nomeSala, participanteViewModel.Apelido);
        }

        [HttpPost("{nomeSala}/participante/{apelido}/mensagem-publica")]
        public void EnviarMensagemPublica(string nomeSala, string apelido, [FromBody] MensagemViewModel mensagemViewModel)
        {
            _salaService.EnviarMensagemPublica(nomeSala, apelido, mensagemViewModel.Mensagem);
        }

        [HttpPost("{nomeSala}/participante/{apelido}/mensagem-publica-direta")]
        public void EnviarMensagemPublicaDireta(string nomeSala, string apelido, [FromBody] MensagemDiretaViewModel mensagemViewModel)
        {
            _salaService.EnviarMensagemPublicaDireta(nomeSala, apelido, mensagemViewModel.ApelidoMencionado, mensagemViewModel.Mensagem);
        }


        [HttpPost("{nomeSala}/participante/{apelido}/mensagem-privada")]
        public void EnviarMensagemPrivada(string nomeSala, string apelido, [FromBody] MensagemPrivadaViewModel mensagemViewModel)
        {
            _salaService.EnviarMensagemPrivada(nomeSala, apelido, mensagemViewModel.ApelidoMencionado, mensagemViewModel.Mensagem);
        }

        [HttpDelete("{nomeSala}/participante/{apelido}")]
        public void Delete(string nomeSala, string apelido)
        {
            _salaService.RemoverPaticipante(nomeSala, apelido);
        }
    }
}
