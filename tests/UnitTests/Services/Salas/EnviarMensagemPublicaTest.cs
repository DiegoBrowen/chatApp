using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Infrastructure.Data.Repositories;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Services.Salas
{
    public class EnviarMensagemPublicaTest
    {
        private readonly ISalaService _salaService;
        public EnviarMensagemPublicaTest()
        {
            var sala = new Sala("Sala1");
            var salas = new List<Sala> { sala };
            var salaReposioty = new SalaRepository(salas);
            _salaService = new SalaService(salaReposioty);
            _salaService.AdicionarParticipante("Sala1", "Pedro");
        }

        [Fact]
        public void Deve_enviar_uma_mensagem_publica()
        {
            _salaService.EnviarMensagemPublica("Sala1", "Pedro", "Olá");

            var mensagens = _salaService.ObterMensagemDoParticipante("Sala1", "Pedro");

            Assert.Contains(mensagens, x => x == "Olá");
        }

        [Fact]
        public void Deve_informar_que_a_sala_nao_existe()
        {
            var exception = Assert.Throws<ChatException>(() => _salaService.EnviarMensagemPublica("Sala5", "Maria", "Olá"));
            Assert.Equal("Desculpe, a sala informada não existe.", exception.Message);
        }
    }
}
