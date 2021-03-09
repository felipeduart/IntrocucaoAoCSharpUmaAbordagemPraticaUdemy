using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; // adiciona componentes do VisualBasic (importando)

namespace SimpleTOPark
{
    public partial class FormPrincipal : Form
    {

        private DataTable bancoDeDados; // usado para armazenar dados em linhas e colunas ou seja uma tabela 
        private GerenciadorDeArrecadacao gerenciador; // contem a logica de calculo da estadia 
        public FormPrincipal()
        {
            InitializeComponent();

            bancoDeDados = new DataTable("Estacionamento "); // criando uma tabela 'estacionamento'
            bancoDeDados.Columns.Add("Placa", typeof(string)); // adiciona uma coluna de nome 'placa' tipo texto 'string'
            bancoDeDados.Columns.Add("Entrada", typeof(string)); // adiciona uma coluna de nome 'entrada' tipo texto 'string'

            dataGridViewCarrosEstacionados.DataSource = bancoDeDados; // atrela o dataGridView ao DataTable

            gerenciador = new GerenciadorDeArrecadacao // inicia o gerenciador 
            {
                ValorHora = 10,
                Arrecadado = 0 // é o valor total arrecadado no dia 
            };

            labelValorHora.Text = $"Valor da hora: R$ {gerenciador.ValorHora.ToString("0.00")}";
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            var placa = Interaction.InputBox("Digite a placa do veículo: ", "Entrada de veículo"); // exibe janela para colocar a placa/ se aproveita de componentes do VisualBasuc
            if (!string.IsNullOrEmpty(placa)) // verifica se o campo da placa foi preenchido para saber se o usuario clicou em OK ou em Cancelar
            {
                bancoDeDados.Rows.Add(new string[] { placa, DateTime.Now.ToString() }); // cadastrando veiculo 
            }

        }

        private void buttonConfigurar_Click(object sender, EventArgs e)
        {
            var valorDaHora = Interaction.InputBox("Digite o valor da hora:", "Valor da hora"); //abre janela para conf o valor da hora 
            if (!string.IsNullOrEmpty(valorDaHora))
            {
                gerenciador.ValorHora = float.Parse(valorDaHora);
                labelValorHora.Text = $"Valor da hora: R$ {gerenciador.ValorHora.ToString("0.00")}";
            }
        }

        private void dataGridViewCarrosEstacionados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                // Recupera a hora de entrada e a placa do veículo
                var entrada = DateTime.Parse(bancoDeDados.Rows[e.RowIndex].ItemArray[1].ToString()); // Recupera a data/hora de entrada
                var placa = bancoDeDados.Rows[e.RowIndex].ItemArray[0].ToString(); // Recupera a placa do veículo

                var arrecadado = gerenciador.CalcularEstadiaCliente(entrada); // Calcula o valor que o cliente deverá pagar

                // Exibe mensagem
                if (MessageBox
                    .Show(this, $"Deseja encerrar o ticket de {placa}? Valor: R$ {arrecadado.ToString("0.00")}", "Encerrar Ticket", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // Remove do banco de dados
                    bancoDeDados.Rows.RemoveAt(e.RowIndex);
                    // Arrecada o valor
                    gerenciador.Arrecadado = arrecadado;
                    // Atualiza o valor na tela
                    labelValorArrecadado.Text = $"Total Arrecadado: R$ {gerenciador.Arrecadado.ToString("0.00")}";
                }
            }

        }
    }
}
