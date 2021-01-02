using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Infrastructure.Data.Repositories;
using System.Collections.Generic;
using Xunit;
namespace UnitTests.Services.Salas
{
    public class ObterMensagensDoParticipanteTest
    {
        private readonly ISalaService _salaService;
        public ObterMensagensDoParticipanteTest()
        {
            var sala = new Sala("Sala1");
            sala.AdicionarParticipante("Maria");
            sala.EnviarMensagemPublica("Bom dia pessoal", "Maria");

            var salas = new List<Sala> { sala };
            var salaReposioty = new SalaRepository(salas);
            _salaService = new SalaService(salaReposioty);
        }

        [Fact]
        public void Deve_retornar_as_mensagens_do_participante()
        {
            var mensagens = _salaService.ObterMensagemDoParticipante("Sala1", "Maria");

            Assert.Contains(mensagens, x => x == "Entrei!!");
            Assert.Contains(mensagens, x => x == "Bom dia pessoal");
        }

        [Fact]
        public void Deve_informar_que_a_sala_nao_existe()
        {
            var exception = Assert.Throws<ChatException>(() => _salaService.ObterMensagemDoParticipante("Sala5", "Maria"));
            Assert.Equal("Desculpe, a sala informada não existe.", exception.Message);
        }
    }
}
