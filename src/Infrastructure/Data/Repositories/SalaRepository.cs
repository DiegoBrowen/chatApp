using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        private readonly List<Sala> _salas;
        public SalaRepository(List<Sala> salas)
        {
            _salas = salas;
        }

        public List<Sala> Obter()
        {
            return _salas;
        }

        public Sala ObterPorNome(string nome)
        {
            return _salas.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
