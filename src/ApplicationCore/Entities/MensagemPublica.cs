using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MensagemPublica : IMensagem
    {
        private readonly string _conteudo;
        private readonly Participante _participante;
        public MensagemPublica(string conteudo, Participante participante)
        {
            _participante = participante;
            _conteudo = conteudo;
        }

        public string ObterMensagemParaOParticipante(string apelido)
        {
            if (apelido == _participante.Apelido)
                return _conteudo;

            return $"{ _participante.Apelido } disse -> {_conteudo}";
        }
    }
}
