using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTOPark
{
    class GerenciadorDeArrecadacao
    {
        public float ValorHora { get; set; } //configura o valor da hora dinâmicamente
        private float _arrecadado; // armazena o total arrecadado

        public float Arrecadado // Esta propriedade serve para manipular os dados armazenados na variável "_arrecadado"
        {
            get => _arrecadado; // retorna o valor da variável "_arrecadado"
            set => _arrecadado += value; // Soma o valor atual da variável "_arrecadado" com o valor recebido e salva este na variável "_arrecadado"
        }

        public float CalcularEstadiaCliente(DateTime entrada) // Método usado para calcular o valor total que o cliente deve pagar
        {
            var permanencia = DateTime.Now - entrada; // Calcula o tempo de permanência da entrada até o presente momento

            if (permanencia.Hours <= 0) // Se a estadia foi menor que 1h, retorna o valor de 1h...
                return ValorHora;
            else // ...senão, calcula o valor de acordo com o tempo de estadia
                return ValorHora * permanencia.Hours; 
        }
    }
}
