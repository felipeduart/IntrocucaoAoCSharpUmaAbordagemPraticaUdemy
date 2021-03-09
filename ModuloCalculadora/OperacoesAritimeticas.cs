using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloCalculadora
{
    public static class OperacoesAritimeticas // uma classe estatica: não pode ser instanciada, não pode herdar e nem ser herdada, aó pode conter menbros estaticos
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parcela1"></param>
        /// <param name="parcela2"></param>
        /// <returns></returns>
        public static double Adicao(double parcela1, double parcela2)
        {
            return parcela1 + parcela2;
        }

        public static double Subtracao(double minuando, double subtraendo)
        {
            return minuando - subtraendo;
        }

        public static double Multiplicacao(double multiplicando, double multiplicador)
        {
            return multiplicando * multiplicador;
        }

        public static double Divisao (double dividendo, double divisor)
        {
            return dividendo / divisor;
        }

    }
}
