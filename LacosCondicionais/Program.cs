using System;

namespace LacosCondicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            // Laços condicionais se referem a estruturas (blocos de codigo) mediante uma determinada situação/condição satisfeita
            int hora = 17;

            // Laço if (se), else if, e else

            if(hora >= 15) // se a hora for igual ou maior a 15, será impressa a mensagem do console 
            Console.WriteLine("Já são 15 horas ou mais!");

             if (hora == 14) //  se colocar o 'else' na frente do 'if' esse laço so sera executado SE o primeiro nao foir validado 
                Console.WriteLine("Já são 14 horas "); // se for 14 horas ele vai executar a mensagem do sonsole 
            // os dois 'if' sao executados pois os dois laços estao separados/ sao independentes 

            /* if (hora >= 15 || hora == 14) ;
            Console.WriteLine("A hora é maior ou igual a 15 OU é igual a 14");*/
            // acima foi parte da aula q mudou depois 
            else // garante a execução do bloco de codigo seguinte a ele ou seja não é feito um teste 
            {
                if (hora == 17)
                    Console.WriteLine("ja sao 17h");
                else
                    Console.WriteLine("ja passou das 17h");
              // esse foi um ex de teste dentro de um 'else' aonde tem se o 'if' nao se validar o 'else' garantira a execução do bloco de codigo

            }
            
             // Laço switch .. case
             // geralmente a expressão 'switch.. case' é uma constante 
             // em nenhuma hipotese serao executados dois casos simultaniamente 
            switch (hora)
            {
                case 17: // o teste aqui é exato. nao pode ser maior, menor somente EXATO
                    Console.WriteLine("sao 17h");
                    break;

            }

            PrimeiroSemestre mes = PrimeiroSemestre.Janeiro;
          /*  if (mes == PrimeiroSemestre.Janeiro)
            {
                Console.WriteLine("estamos em jainero com o 'if'");
            }
            else if(mes == PrimeiroSemestre.Fevereiro) ;
            {
                Console.WriteLine("estamos em fevereiro com if");
            }
          */
            // isso tudo poderia ate ser feito com o 'if' 'else if' mas o codigo fica mais limpo dessa forma e mais facil de se entender 

            switch (mes)
            {
                case PrimeiroSemestre.Janeiro:
                    Console.WriteLine("estamos em janeiro");
                    break;
                case PrimeiroSemestre.Fevereiro:
                    Console.WriteLine("estamos em fevereiro");
                    break;
                case PrimeiroSemestre.Marco:
                    Console.WriteLine("estamos em março");
                    break;
                case PrimeiroSemestre.Abril:
                    Console.WriteLine("estamos em abril");
                    break;
                case PrimeiroSemestre.Maio:
                    Console.WriteLine("estamos em maio");
                    break;
                /*case PrimeiroSemestre.Junho:
                    Console.WriteLine("estamos em junho");
                    break;
                */
                // isso tudo poderia ate ser feito com o 'if' 'else if' mas o codigo fica mais limpo dessa forma e mais facil de se entender 
                default: // será executado se nenhum dos outros for satisfeito
                    Console.WriteLine("Estamos em " + mes);
                    break;
            }
        }
     
        public enum PrimeiroSemestre
        {
            Janeiro, Fevereiro, Marco, Abril, Maio, Junho   
        }
    }
}
