using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Repositories.Salas
{
    public class ObterPorNomeTest
    {
        private readonly ISalaRepository _salaRepository;
        public ObterPorNomeTest()
        {
            var salas = new List<Sala> { new Sala("Sala1"), new Sala("Sala2") };
            _salaRepository = new SalaRepository(salas);
        }

        [Fact]
        public void Deve_obter_a_sala_por_nome()
        {
            var sala = _salaRepository.ObterPorNome("Sala1");
            Assert.NotNull(sala);
            Assert.Equal("Sala1", sala.Nome);
        }

        [Fact]
        public void Deve_retornar_nulo_quando_nao_encontrar_a_sala_por_nome()
        {
            var sala = _salaRepository.ObterPorNome("Sala3");
            Assert.Null(sala);
        }
    }
}
