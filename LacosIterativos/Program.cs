using System;

namespace LacosIterativos
{
    class Program
    {
        static void Main(string[] args)
        {
            // laços iterativos são estruturas que repetem um bloco de códico, determinado numero de vezes (pq se ele executar
            // sem saber até aonde vai vamos ficar num loop infinito)
            // cada estrutura tem peculiaridades e diferenças e normalmente sao basicas entre as linguaguens de programação 

            // laço 'for'
            for(int i=0; i<5; i++) // i++ significa que i será incrementado de 1 em 1 
            {
                Console.WriteLine("valor de i é " + i);
            }

            // estrutura while 
            int contador = 3;
            while (contador < 10)
            {
                Console.WriteLine(contador);
                contador++; // sem essa linha o 'while' vai fazer com que o 'contador' fique em loop infinito 
            }

            // Do .. while 
            // Execução garantida pelo menos uma vêz (executa o bloco primeiro e depois faz o teste de condição)
            double j = 10;
            do
            {
                Console.WriteLine(j);
                j = j * 1.5;
            } while (j < 100);

            // Foreach
            // Percorre todos os elementos de um conjunto // ex 
            int[] conjunto = { 1, 2, 3, 4 };
            foreach (int numero in conjunto) 
            {
                Console.WriteLine("Esse elemneto do conjunto tem valor de" + numero + "!");
                // nao se trata de variavel de referencia ou valor 'foreach' realmente pega cada elemento do conjunto e o repete 
                // dando a possibilidade desse numero ser trabalhado como abaixo 
                Console.WriteLine("Esse elemneto do conjunto tem valor de" + numero + "! somando esse valor a 10 temos " + (numero+10));
                // essa é uma forma de trabalhar numeros de um conjunto para fazer operações como divisao suritação etc 
            }
        }

    }
}
