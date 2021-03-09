using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMundoDasClassesParte1
{
    class Program // sem modificador de acesso explícito = internal por padrao  
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro(Cor.Branco, 4, "Gol G6 "); // criando carro 

            // exibindo atributos do carro
            Console.WriteLine("o carro é um " + carro.Modelo + "de cor " + carro.Cor + " e tem " + carro.Portas + " portas.");

            Console.WriteLine(carro.Ligar());// ligar carro 
            Console.WriteLine(" Ligado? " + carro.Ligado);
            Console.WriteLine(carro.Andar());// andar com carro
            Console.WriteLine(carro.Desligar()); // desligar carro
            Console.WriteLine("ligado? " + carro.Ligado);

            carro.Cor = Cor.Azul;
            Console.WriteLine("a nova cor do carro é " + carro.Cor);
        }
    }
}
