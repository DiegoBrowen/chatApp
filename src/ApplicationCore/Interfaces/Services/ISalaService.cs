using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface ISalaService
    {
        List<Sala> Obter();
        IEnumerable<string> ObterMensagemDoParticipante(string nomeSala, string apelido);
        void AdicionarParticipante(string nomeSala, string apelido);
        void RemoverPaticipante(string nomeSala, string apelido);
        void EnviarMensagemPublica(string nomeSala, string apelido, string mensagem);
        void EnviarMensagemPublicaDireta(string nomeSala, string apelidoEnviou, string apelidoRecebeu, string mensagem);
        void EnviarMensagemPrivada(string nomeSala, string apelidoEnviou, string apelidoRecebeu, string mensagem);
    }
}
