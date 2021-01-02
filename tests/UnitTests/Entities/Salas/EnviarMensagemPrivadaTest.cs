using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using Xunit;


namespace UnitTests.Entities.Salas
{
    public class EnviarMensagemPrivadaTest
    {
        private readonly Sala _sala;
        public EnviarMensagemPrivadaTest()
        {
            _sala = new Sala("Sala1");
        }

        [Fact]
        public void Deve_enviar_mensagem_privada()
        {
            _sala.AdicionarParticipante("Maria");
            _sala.AdicionarParticipante("Joao");

            var mensagem = "Bom dia Joao!";

            _sala.EnviarMensagemPrivada(mensagem, "Maria", "Joao");
            Assert.Contains(_sala.ObterMensagensParaOParticipante("Maria"), x => x == "Você disse para Joao [PRIVADO]-> Bom dia Joao!");
        }

        [Fact]
        public void Deve_informar_que_o_participante_que_enviou_nao_foi_encontrado_quando_enviado_uma_mensagem_privada()
        {
            var mensagem = "Bom dia Maria!";
            _sala.AdicionarParticipante("Joao");

            var exception = Assert.Throws<ChatException>(() => _sala.EnviarMensagemPrivada(mensagem, "Maria", "Joao"));

            Assert.Equal("Desculpe, não foi possivel encontrar a Maria.", exception.Message);
        }

        [Fact]
        public void Deve_informar_que_o_participante_que_recebeira_nao_foi_encontrado_quando_enviado_uma_mensagem_privada()
        {
            var mensagem = "Bom dia Maria!";
            _sala.AdicionarParticipante("Maria");

            var exception = Assert.Throws<ChatException>(() => _sala.EnviarMensagemPrivada(mensagem, "Maria", "Joao"));

            Assert.Equal("Desculpe, não foi possivel encontrar a Joao.", exception.Message);
        }
    }
}
