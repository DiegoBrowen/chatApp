using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using Xunit;


namespace UnitTests.Entities.Salas
{
    public class EnviarMensagemPublicaParaUmParticipanteTest
    {
        private readonly Sala _sala;
        public EnviarMensagemPublicaParaUmParticipanteTest()
        {
            _sala = new Sala("Sala1");
        }

        [Fact]
        public void Deve_enviar_mensagem_publica_para_outro_participante()
        {
            _sala.AdicionarParticipante("Maria");
            _sala.AdicionarParticipante("Joao");
            var mensagem = "Eu te conheço de algum lugar!!";

            _sala.EnviarMensagemPublicaParaUmParticipante(mensagem, "Maria", "Joao");

            Assert.Contains(_sala.ObterMensagensParaOParticipante("Maria"), x => x == "Você mencionou Joao -> Eu te conheço de algum lugar!!");
        }

        [Fact]
        public void Deve_informar_que_o_participante_que_enviou_nao_foi_encontrado_quando_enviado_uma_mensagem_publica_direta()
        {
            var mensagem = "Bom dia Maria!";
            _sala.AdicionarParticipante("Joao");

            var exception = Assert.Throws<ChatException>(() => _sala.EnviarMensagemPublicaParaUmParticipante(mensagem, "Maria", "Joao"));

            Assert.Equal("Desculpe, não foi possivel encontrar a Maria.", exception.Message);
        }

        [Fact]
        public void Deve_informar_que_o_participante_que_recebeira_nao_foi_encontrado_quando_enviado_uma_mensagem_publica_direta()
        {
            var mensagem = "Bom dia Maria!";
            _sala.AdicionarParticipante("Maria");

            var exception = Assert.Throws<ChatException>(() => _sala.EnviarMensagemPublicaParaUmParticipante(mensagem, "Maria", "Joao"));

            Assert.Equal("Desculpe, não foi possivel encontrar a Joao.", exception.Message);
        }
    }
}
