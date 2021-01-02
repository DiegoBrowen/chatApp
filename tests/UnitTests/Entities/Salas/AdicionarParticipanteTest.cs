using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using Xunit;

namespace UnitTests.Entities.Salas
{
    public class AdicionarParticipanteTest
    {
        private readonly Sala _sala;
        public AdicionarParticipanteTest()
        {
            _sala = new Sala("Sala1");
        }

        [Fact]
        public void Deve_registar_um_participante()
        {
            var apelido = "Paulo";
            _sala.AdicionarParticipante(apelido);


            var mensagens = _sala.ObterMensagensParaOParticipante("Paulo");
            Assert.Contains(mensagens, x => x == "Entrei!!");
        }

        [Fact]
        public void Deve_informar_que_existe_um_participante_com_o_mesmo_apelido()
        {
            _sala.AdicionarParticipante("Joao");

            var apelido = "Joao";
            var exception = Assert.Throws<ChatException>(() => _sala.AdicionarParticipante(apelido));
            Assert.Equal("Desculpe, o apelido Joao já existe na sala, Por favor escolher um diferente.", exception.Message);
        }
    }
}
