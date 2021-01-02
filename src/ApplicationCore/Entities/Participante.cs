using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Participante
    {
        public int Id { get; protected set; }
        public string Apelido { get; private set; }
        public Participante(string apelido)
        {
            Apelido = apelido;
        }
    }
}
