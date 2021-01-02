using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using Xunit;

namespace chatserver.test.Entities.Salas
{
    public class EnviarMensagemPublicaTest
    {
        private readonly Sala _sala;
        public EnviarMensagemPublicaTest()
        {
            _sala = new Sala("Sala1");
        }

        [Fact]
        public void Deve_enviar_mensagem_publica()
        {
            _sala.AdicionarParticipante("Joao");

            var mensagem = "Bom dia a todos!";
            var apelido = "Joao";

            _sala.EnviarMensagemPublica(mensagem, apelido);

            Assert.Contains(_sala.ObterMensagensParaOParticipante("Joao"), x => x == "Bom dia a todos!");
        }

        [Fact]
        public void Deve_informar_que_o_participante_que_enviou_nao_foi_encontrado_quando_enviado_uma_mensagem_publica()
        {
            var mensagem = "Bom dia Maria!";
            _sala.AdicionarParticipante("Joao");

            var exception = Assert.Throws<ChatException>(() => _sala.EnviarMensagemPublica(mensagem, "Maria"));

            Assert.Equal("Desculpe, não foi possivel encontrar a Maria.", exception.Message);
        }
    }
}
