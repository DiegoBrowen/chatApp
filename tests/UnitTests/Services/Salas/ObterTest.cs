using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Services;
using Infrastructure.Data.Repositories;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Services.Salas
{
    public class ObterTest
    {
        [Fact]
        public void Deve_obter_as_salas_disponiveis()
        {
            var salas = new List<Sala> { new Sala("Sala1"), new Sala("Sala2") };
            var salaRepository = new SalaRepository(salas);
            var salaService = new SalaService(salaRepository);

            var salasEncontradas = salaService.Obter();
            Assert.Equal(2, salasEncontradas.Count);
            Assert.Contains(salasEncontradas, x => x.Nome == "Sala1");
            Assert.Contains(salasEncontradas, x => x.Nome == "Sala2");
        }

        [Fact]
        public void Deve_informar_que_nao_existem_salas_disponiveis()
        {
            var salas = new List<Sala>();
            var salaRepository = new SalaRepository(salas);
            var salaService = new SalaService(salaRepository);

            var exception = Assert.Throws<ChatException>(() => salaService.Obter());
            Assert.Equal("Desculpe, não existem salas disponiveis.", exception.Message);
        }
    }
}
