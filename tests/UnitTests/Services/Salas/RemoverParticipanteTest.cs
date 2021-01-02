using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Infrastructure.Data.Repositories;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Services.Salas
{
    public class RemoverParticipanteTest
    {
        private readonly ISalaService _salaService;
        public RemoverParticipanteTest()
        {
            var sala = new Sala("Sala1");

            var salas = new List<Sala> { sala };
            var salaReposioty = new SalaRepository(salas);
            _salaService = new SalaService(salaReposioty);
            _salaService.AdicionarParticipante("Sala1", "Pedro");
        }

        [Fact]
        public void Deve_remover_um_participante()
        {
            _salaService.RemoverPaticipante("Sala1", "Pedro");

            var mensagens = _salaService.ObterMensagemDoParticipante("Sala1", "Pedro");

            Assert.Contains(mensagens, x => x == "Vou nessa até mais!");
        }

        [Fact]
        public void Deve_informar_que_a_sala_nao_existe()
        {
            var exception = Assert.Throws<ChatException>(() => _salaService.RemoverPaticipante("Sala5", "Maria"));
            Assert.Equal("Desculpe, a sala informada não existe.", exception.Message);
        }
    }
}
