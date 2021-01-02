using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _salaRepository;
        public SalaService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public List<Sala> Obter()
        {
            var salas = _salaRepository.Obter();
            if (!salas.Any())
                throw new ChatException("Desculpe, não existem salas disponiveis.");

            return salas;
        }

        public IEnumerable<string> ObterMensagemDoParticipante(string nomeSala, string apelido)
        {
            var sala = _salaRepository.ObterPorNome(nomeSala);
            ValidarSala(sala);

            return sala.ObterMensagensParaOParticipante(apelido);
        }

        public void AdicionarParticipante(string nomeSala, string apelido)
        {
            var sala = _salaRepository.ObterPorNome(nomeSala);
            ValidarSala(sala);

            sala.AdicionarParticipante(apelido);
        }

        public void EnviarMensagemPublica(string nomeSala, string apelido, string mensagem)
        {
            var sala = _salaRepository.ObterPorNome(nomeSala);
            ValidarSala(sala);

            sala.EnviarMensagemPublica(mensagem, apelido);
        }

        public void EnviarMensagemPublicaDireta(string nomeSala, string apelidoEnviou, string apelidoRecebeu, string mensagem)
        {
            var sala = _salaRepository.ObterPorNome(nomeSala);
            ValidarSala(sala);

            sala.EnviarMensagemPublicaParaUmParticipante(mensagem, apelidoEnviou, apelidoRecebeu);
        }

        public void EnviarMensagemPrivada(string nomeSala, string apelidoEnviou, string apelidoRecebeu, string mensagem)
        {
            var sala = _salaRepository.ObterPorNome(nomeSala);
            ValidarSala(sala);

            sala.EnviarMensagemPrivada(mensagem, apelidoEnviou, apelidoRecebeu);
        }

        public void RemoverPaticipante(string nomeSala, string apelido)
        {
            var sala = _salaRepository.ObterPorNome(nomeSala);
            ValidarSala(sala);

            sala.RemoverParticipante(apelido);
        }

        private void ValidarSala(Sala sala)
        {
            if (sala == null)
                throw new ChatException("Desculpe, a sala informada não existe.");
        }
    }
}
