using System;

namespace TiposEVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero1 = 10; // declara uma variável inteira e armazena o valor 10 nela
            int numero2 = 20;
            var soma = numero1 + numero2; // o var define automaticamente ou dinamicamente o tipo da variável 
            Console.WriteLine("10 + 20 = " + soma);

            int copiadenumero1 = numero1; // copia o valor de 'numero1'
            copiadenumero1 = 11; // sera que o valor de 'numero1' foi alterado?
            Console.WriteLine(numero1);
            Console.WriteLine(copiadenumero1);
            // aqui foi feita um acopia completa e nao referencial 
            // nesse caso é uma variavel que guarda a informação nela mesma portando nao altera o valor de referencia sendo 'numero1'
            // = 10 e 'copiadenumero1' = 11 

            var quadrado1 = new Quadrado(); // cria um quadrado 
            quadrado1.lado = 10; // quadrado1 tera valor = 10 
            var quadrado2 = quadrado1; // será que a cópia do quadrado foi completa? ou copiamos apenas a referencia?
            quadrado2.lado = 11;
            Console.WriteLine(quadrado1.lado); // deveria ter o valor = 10
            Console.WriteLine(quadrado2.lado); // deveria ter o valor = 11 
            // ao alterar o 'quadrado2' eu tambem estou alterando o 'quadrado1' 
            // ou seja é uma varial por tipo de REFERENCIA 
        }

        class Quadrado // define uma classe chamada Quadrado 
        {
           public int lado; // define um atributo inteiro chamado lado, na classe quadrado 
        }
    }
}
