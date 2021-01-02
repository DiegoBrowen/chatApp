using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MensagemPublicaDireta : IMensagem
    {
        private readonly string _conteudo;
        private readonly Participante _participanteQueEnviou;
        private readonly Participante _participanteQueRecebeu;

        public MensagemPublicaDireta(string conteudo, Participante participanteQueEnviou, Participante participanteQueRecebeu)
        {
            _participanteQueEnviou = participanteQueEnviou;
            _participanteQueRecebeu = participanteQueRecebeu;
            _conteudo = conteudo;
        }

        public string ObterMensagemParaOParticipante(string apelido)
        {
            if (apelido == _participanteQueRecebeu.Apelido)
                return $"{ _participanteQueEnviou.Apelido } mencionou você -> {_conteudo}";

            if (apelido == _participanteQueEnviou.Apelido)
                return $"Você mencionou { _participanteQueRecebeu.Apelido } -> {_conteudo}";

            return $"{ _participanteQueEnviou.Apelido } mencionou { _participanteQueRecebeu.Apelido } -> {_conteudo}";
        }
    }
}
