using ApplicationCore.Entities;
using Xunit;

namespace chatserver.test.Entities.Salas
{
    public class ObterMensagensParaOParticipanteTest
    {
        private readonly Sala _sala;
        public ObterMensagensParaOParticipanteTest()
        {
            _sala = new Sala("Sala1");
        }

        [Fact]
        public void Deve_obter_as_mensagens_publicas_dos_participante()
        {
            _sala.AdicionarParticipante("Maria");
            _sala.AdicionarParticipante("Joao");

            _sala.EnviarMensagemPublica("Bom dia pessoal", "Maria");
            _sala.EnviarMensagemPublica("Bom dia", "Joao");

            var mensagens = _sala.ObterMensagensParaOParticipante("Maria");

            Assert.Contains(mensagens, x => x == "Entrei!!");
            Assert.Contains(mensagens, x => x == "Joao disse -> Entrei!!");

            Assert.Contains(mensagens, x => x == "Bom dia pessoal");
            Assert.Contains(mensagens, x => x == "Joao disse -> Bom dia");
        }

        [Fact]
        public void Deve_obter_as_mensagens_do_participante_quando_alguem_mencionou_ele()
        {
            _sala.AdicionarParticipante("Maria");
            _sala.AdicionarParticipante("Joao");

            _sala.EnviarMensagemPublica("Bom dia pessoal", "Maria");
            _sala.EnviarMensagemPublicaParaUmParticipante("Bom dia Maria", "Joao", "Maria");

            var mensagens = _sala.ObterMensagensParaOParticipante("Maria");

            Assert.Contains(mensagens, x => x == "Entrei!!");
            Assert.Contains(mensagens, x => x == "Joao disse -> Entrei!!");

            Assert.Contains(mensagens, x => x == "Bom dia pessoal");
            Assert.Contains(mensagens, x => x == "Joao mencionou você -> Bom dia Maria");
        }

        [Fact]
        public void Deve_obter_as_mensagens_do_participante_quando_ele_mencionou_alguem()
        {
            _sala.AdicionarParticipante("Maria");
            _sala.AdicionarParticipante("Joao");

            _sala.EnviarMensagemPublica("Bom dia pessoal", "Maria");
            _sala.EnviarMensagemPublicaParaUmParticipante("Bom dia Maria", "Joao", "Maria");

            var mensagens = _sala.ObterMensagensParaOParticipante("Joao");

            Assert.Contains(mensagens, x => x == "Entrei!!");
            Assert.Contains(mensagens, x => x == "Maria disse -> Entrei!!");

            Assert.Contains(mensagens, x => x == "Maria disse -> Bom dia pessoal");
            Assert.Contains(mensagens, x => x == "Você mencionou Maria -> Bom dia Maria");
        }

        [Fact]
        public void Deve_obter_as_mensagens_do_participante_quando_outro_participante_mencionou_outro_que_nao_seja_o_participante_que_esta_buscando_as_mensagens()
        {
            _sala.AdicionarParticipante("Maria");
            _sala.AdicionarParticipante("Joao");
            _sala.AdicionarParticipante("Ana");

            _sala.EnviarMensagemPublica("Bom dia pessoal", "Maria");
            _sala.EnviarMensagemPublicaParaUmParticipante("Bom dia Ana", "Joao", "Ana");

            var mensagens = _sala.ObterMensagensParaOParticipante("Maria");

            Assert.Contains(mensagens, x => x == "Entrei!!");
            Assert.Contains(mensagens, x => x == "Joao disse -> Entrei!!");

            Assert.Contains(mensagens, x => x == "Bom dia pessoal");
            Assert.Contains(mensagens, x => x == "Joao mencionou Ana -> Bom dia Ana");
        }

        [Fact]
        public void Deve_obter_as_mensagens_privadas_do_participante()
        {
            _sala.AdicionarParticipante("Maria");
            _sala.AdicionarParticipante("Joao");

            _sala.EnviarMensagemPublica("Bom dia pessoal", "Maria");
            _sala.EnviarMensagemPrivada("Aqui só entre nós", "Maria", "Joao");

            var mensagens = _sala.ObterMensagensParaOParticipante("Maria");

            Assert.Contains(mensagens, x => x == "Entrei!!");
            Assert.Contains(mensagens, x => x == "Joao disse -> Entrei!!");

            Assert.Contains(mensagens, x => x == "Bom dia pessoal");
            Assert.Contains(mensagens, x => x == "Você disse para Joao [PRIVADO]-> Aqui só entre nós");
        }

        [Fact]
        public void Deve_obter_as_mensagens_privadas_do_participante_quando_alguem_enviar_uma_mensagem_privada()
        {
            _sala.AdicionarParticipante("Maria");
            _sala.AdicionarParticipante("Joao");

            _sala.EnviarMensagemPublica("Bom dia pessoal", "Maria");
            _sala.EnviarMensagemPrivada("Aqui só entre nós", "Joao", "Maria");

            var mensagens = _sala.ObterMensagensParaOParticipante("Maria");

            Assert.Contains(mensagens, x => x == "Entrei!!");
            Assert.Contains(mensagens, x => x == "Joao disse -> Entrei!!");

            Assert.Contains(mensagens, x => x == "Bom dia pessoal");
            Assert.Contains(mensagens, x => x == "Joao disse para você [PRIVADO]-> Aqui só entre nós");
        }
    }
}
