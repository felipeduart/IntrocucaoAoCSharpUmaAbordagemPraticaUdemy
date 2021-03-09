using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMundoDasClassesParte2
{
    public class Cachorro : Animal
    {
        public Cachorro(string nome, int idade) : base(nome, idade)//base(nome, idade) invoca o construtor da classe mae 'animal'
        {
        }

        public override Som SomEmitido => Som.Latido;
    }
}
