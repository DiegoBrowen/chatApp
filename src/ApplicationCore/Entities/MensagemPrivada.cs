using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MensagemPrivada : IMensagem
    {
        private readonly string _conteudo;
        private readonly Participante _participanteQueEnviou;
        protected Participante _participanteQueRecebeu;

        public MensagemPrivada(string conteudo, Participante participanteQueEnviou, Participante participanteQueRecebeu)
        {
            _participanteQueEnviou = participanteQueEnviou;
            _participanteQueRecebeu = participanteQueRecebeu;
            _conteudo = conteudo;
        }

        public string ObterMensagemParaOParticipante(string apelido)
        {
            if (apelido == _participanteQueRecebeu.Apelido)
                return $"{ _participanteQueEnviou.Apelido } disse para você [PRIVADO]-> {_conteudo}";

            if (apelido == _participanteQueEnviou.Apelido)
                return $"Você disse para { _participanteQueRecebeu.Apelido } [PRIVADO]-> {_conteudo}";
            return string.Empty;
        }
    }
}
