using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using Xunit;

namespace chatserver.test.Entities.Salas
{
    public class RemoverParticipanteTest
    {
        private readonly Sala _sala;
        public RemoverParticipanteTest()
        {
            _sala = new Sala("Sala1");
        }

        [Fact]
        public void Deve_retirar_um_participante_da_sala_quando_o_participante_sair()
        {
            _sala.AdicionarParticipante("Maria");
            _sala.RemoverParticipante("Maria");


            var mensagens = _sala.ObterMensagensParaOParticipante("Maria");
            Assert.Contains(mensagens, x => x == "Vou nessa até mais!");
        }

        [Fact]
        public void Deve_informar_que_participante_nao_existe_quando_tentar_sair_da_sala()
        {
            var exception = Assert.Throws<ChatException>(() => _sala.RemoverParticipante("Maria"));

            Assert.Equal("Desculpe, não foi possivel encontrar a Maria.", exception.Message);
        }
    }
}
