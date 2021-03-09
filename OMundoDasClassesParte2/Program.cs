using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMundoDasClassesParte2
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Cachorro("rex", 5);
            var g = new Gato("ana", 3);

            Animal a = new Gato("felix", 4);// polimorfismo: o gato teambem é um animal 

            ExibeAnimal(c); // recebe argumento do tipo cachorro
            ExibeAnimal(g);// recebe argumento do tipo gato
            ExibeAnimal(a);// recebe argumento do tipo animal
        }

        public static void ExibeAnimal(Animal animal)
        {
            Console.WriteLine($"Nome:{animal.Nome}");
            Console.WriteLine($"Idade:{animal.Idade}");
            Console.WriteLine($"Som emitido: {animal.SomEmitido}");
            Console.WriteLine($"Locomoção: {animal.Locomocao}");
        }
    }
}
