using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ISalaRepository
    {
        List<Sala> Obter();
        Sala ObterPorNome(string nome);
    }
}
