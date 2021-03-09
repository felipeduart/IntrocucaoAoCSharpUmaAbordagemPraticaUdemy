using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMundoDasClassesParte1 // é como se fosse uma pasta virtual
{
    public class Carro
    {
        // atributos do carro
        public Cor Cor { get; set; } // a cor pode ser trocada pq sem a entrada set e a saida get 
        public int Portas { get; }// get faz com que o seja atribuido 'portas' somente uma vez e assim com os outro tb 
        public string Modelo { get; }
        private bool ligado = false; // private = so a classe tem acesso 

        public bool Ligado // Propriedade = define uma maneira de acessar atributos 
        {
            get // retorna valor 
            {
                return ligado;
            }
        }

        // metodo construtor da classe
        public Carro(Cor cor, int portas, string modelo)
        {
            Cor = cor;
            Portas = portas;
            Modelo = modelo;
        }

        //comportamentos do carro
        public string Ligar()
        {
            ligado = true;
            return "O carro foi ligado.";
        }

        public string Desligar()
        {
            ligado = false;
            return "o carro foi desligado.";
        }

        public string Andar()
        {
            return "o carro esta andando";
        }
    }
}
