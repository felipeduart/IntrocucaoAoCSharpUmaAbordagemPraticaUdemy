using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMundoDasClassesParte2
{
    public abstract class Animal // uma classe abstrata nao pode ser instanciada
    {
        public string Nome { get; }
        public int Idade { get; }
        public abstract Som SomEmitido {get;} // essa propriedade devera ser implementada por cada classe filha, ja que é abstratas
        public virtual string Locomocao { get { return "esta andando"; } } // essa propriedade podera ou nao ser sobreesscrevida nas classes filhas


        public Animal(string nome, int idade) // construtor da classe animal 
        {
            Nome = nome;
            Idade = idade;
        }
    }
}
