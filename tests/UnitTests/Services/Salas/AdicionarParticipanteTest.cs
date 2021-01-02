using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Infrastructure.Data.Repositories;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Services.Salas
{
    public class AdicionarParticipanteTest
    {
        private readonly ISalaService _salaService;
        public AdicionarParticipanteTest()
        {
            var sala = new Sala("Sala1");
            var salas = new List<Sala> { sala };
            var salaReposioty = new SalaRepository(salas);
            _salaService = new SalaService(salaReposioty);
        }

        [Fact]
        public void Deve_adicionar_um_participante()
        {
            _salaService.AdicionarParticipante("Sala1", "Pedro");

            var mensagens = _salaService.ObterMensagemDoParticipante("Sala1", "Pedro");

            Assert.Contains(mensagens, x => x == "Entrei!!");
        }

        [Fact]
        public void Deve_informar_que_a_sala_nao_existe()
        {
            var exception = Assert.Throws<ChatException>(() => _salaService.AdicionarParticipante("Sala5", "Maria"));
            Assert.Equal("Desculpe, a sala informada não existe.", exception.Message);
        }
    }
}
