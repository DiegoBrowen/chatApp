using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Repositories.Salas
{
    public class ObterTest
    {
        private readonly ISalaRepository _salaRepository;
        public ObterTest()
        {
            var salas = new List<Sala> { new Sala("Sala1"), new Sala("Sala2") };
            _salaRepository = new SalaRepository(salas);
        }

        [Fact]
        public void Deve_obter_as_salas_disponiveis()
        {
            var salas = _salaRepository.Obter();
            Assert.Equal(2, salas.Count);
            Assert.Contains(salas, x => x.Nome == "Sala1");
            Assert.Contains(salas, x => x.Nome == "Sala2");
        }
    }
}
