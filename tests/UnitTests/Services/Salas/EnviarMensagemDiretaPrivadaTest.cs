﻿using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Infrastructure.Data.Repositories;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Services.Salas
{
    public class EnviarMensagemDiretaPrivadaTest
    {
        private readonly ISalaService _salaService;
        public EnviarMensagemDiretaPrivadaTest()
        {
            var sala = new Sala("Sala1");
            var salas = new List<Sala> { sala };
            var salaReposioty = new SalaRepository(salas);
            _salaService = new SalaService(salaReposioty);
            _salaService.AdicionarParticipante("Sala1", "Ana");
            _salaService.AdicionarParticipante("Sala1", "Pedro");
        }

        [Fact]
        public void Deve_enviar_uma_mensagem_privada()
        {
            _salaService.EnviarMensagemPrivada("Sala1", "Pedro", "Ana", "Olá");

            var mensagens = _salaService.ObterMensagemDoParticipante("Sala1", "Pedro");

            Assert.Contains(mensagens, x => x == "Você disse para Ana [PRIVADO]-> Olá");
        }

        [Fact]
        public void Deve_informar_que_a_sala_nao_existe()
        {
            var exception = Assert.Throws<ChatException>(() => _salaService.EnviarMensagemPrivada("Sala5", "Pedro", "Ana", "Olá"));
            Assert.Equal("Desculpe, a sala informada não existe.", exception.Message);
        }
    }
}
