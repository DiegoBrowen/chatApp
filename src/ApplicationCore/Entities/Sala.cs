using ApplicationCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Sala
    {
        public string Nome { get; private set; }
        private readonly List<Participante> _participantes;
        private readonly List<IMensagem> _mensagens;
        public Sala(string nome)
        {
            _participantes = new List<Participante>();
            _mensagens = new List<IMensagem>();
            Nome = nome;
        }

        public void AdicionarParticipante(string apelido)
        {
            ValidarSeParticipanteNaoExiste(apelido);

            var participante = new Participante(apelido);
            _participantes.Add(participante);

            var mensagemInformadoQueEntrou = $"Entrei!!";
            EnviarMensagemPublica(mensagemInformadoQueEntrou, apelido);
        }

        public void RemoverParticipante(string apelido)
        {
            ValidarSeParticipanteExiste(apelido);

            var mensagemInformandoQueSaiu = $"Vou nessa até mais!";
            EnviarMensagemPublica(mensagemInformandoQueSaiu, apelido);

            _participantes.RemoveAll(x => x.Apelido == apelido);
        }

        public void EnviarMensagemPublica(string conteudo, string apelido)
        {
            ValidarSeParticipanteExiste(apelido);

            var participante = _participantes.FirstOrDefault(x => x.Apelido == apelido);
            var mensagem = new MensagemPublica(conteudo, participante);
            _mensagens.Add(mensagem);
        }

        public void EnviarMensagemPrivada(string conteudo, string apelidoDoParticipanteQueEnviou, string apelidoDoParticipanteQueRecebeu)
        {
            ValidarSeParticipantesDasMensagensDiretasSaoValidos(apelidoDoParticipanteQueEnviou, apelidoDoParticipanteQueRecebeu);

            var participanteQueEnviou = _participantes.FirstOrDefault(x => x.Apelido == apelidoDoParticipanteQueEnviou);
            var participanteQueRecebeu = _participantes.FirstOrDefault(x => x.Apelido == apelidoDoParticipanteQueRecebeu);

            var mensagem = new MensagemPrivada(conteudo, participanteQueEnviou, participanteQueRecebeu);

            _mensagens.Add(mensagem);
        }

        public void EnviarMensagemPublicaParaUmParticipante(string conteudo, string apelidoDoParticipanteQueEnviou, string apelidoDoParticipanteQueRecebeu)
        {
            ValidarSeParticipantesDasMensagensDiretasSaoValidos(apelidoDoParticipanteQueEnviou, apelidoDoParticipanteQueRecebeu);

            var participanteQueEnviou = _participantes.FirstOrDefault(x => x.Apelido == apelidoDoParticipanteQueEnviou);
            var participanteQueRecebeu = _participantes.FirstOrDefault(x => x.Apelido == apelidoDoParticipanteQueRecebeu);

            var mensagem = new MensagemPublicaDireta(conteudo, participanteQueEnviou, participanteQueRecebeu);
            _mensagens.Add(mensagem);
        }

        public List<string> ObterMensagensParaOParticipante(string apelido)
        {
            var mensagens = new List<string>();
            foreach (var mensagem in _mensagens)
            {
                var conteudo = mensagem.ObterMensagemParaOParticipante(apelido);
                mensagens.Add(conteudo);
            }
            return mensagens;
        }

        private void ValidarSeParticipanteNaoExiste(string apelido)
        {
            var participanteExistente = _participantes.Any(x => x.Apelido == apelido);
            if (participanteExistente)
                throw new ChatException($"Desculpe, o apelido {apelido} já existe na sala, Por favor escolher um diferente.");
        }

        private void ValidarSeParticipanteExiste(string apelido)
        {
            var participanteExistente = _participantes.Any(x => x.Apelido == apelido);
            if (!participanteExistente)
                throw new ChatException($"Desculpe, não foi possivel encontrar a {apelido}.");
        }

        private void ValidarSeParticipantesDasMensagensDiretasSaoValidos(string apelidoDoParticipanteQueEnviou, string apelidoDoParticipanteQueRecebeu)
        {
            var participanteQueEnviouExiste = _participantes.Any(x => x.Apelido == apelidoDoParticipanteQueEnviou);
            if (!participanteQueEnviouExiste)
                throw new ChatException($"Desculpe, não foi possivel encontrar a { apelidoDoParticipanteQueEnviou }.");

            var participanteQueRecebeuExiste = _participantes.Any(x => x.Apelido == apelidoDoParticipanteQueRecebeu);
            if (!participanteQueRecebeuExiste)
                throw new ChatException($"Desculpe, não foi possivel encontrar a { apelidoDoParticipanteQueRecebeu }.");
        }
    }
}
