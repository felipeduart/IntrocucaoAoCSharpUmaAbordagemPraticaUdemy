using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class FormPrincipal : Form
    {

        private bool flagPintar = false; // essa variavel controla quando se deve pintar 
        private Graphics graphicsPainelPintura;
        private float espessuraCaneta;
        private Color corBorracha;
        private bool flagApagar = false; // controla quando se deve apagar 
        private Image imagemASalvar;
        private Graphics graphicsImagemASalvar;



        public FormPrincipal()
        {
            InitializeComponent();

            //essas pripiedades só fazem efeito quando o button está com a propiedade 'FlatStyle' setada em 'Flat'
            buttonBorracha.FlatAppearance.MouseOverBackColor = Color.Gray; // altera a cor de fundo do botão quando o cursor do mouse esta sobre ele
            buttonLimpar.FlatAppearance.MouseOverBackColor = Color.Red;
            buttonSalvar.FlatAppearance.MouseOverBackColor = Color.Blue;

            for (int i = 2; i <= 50; i += 2)// ira preencher a comboBox de 2 ate 100 contando de 2 em 2 
            {
                comboBoxEspessuraDaCaneta.Items.Add(i); // adiciona o valor da espessura na combobox
            }
            
            comboBoxEspessuraDaCaneta.Text = "20"; // define o padrao de iniciação 
            
            comboBoxEspessuraDaCaneta.MaxDropDownItems = 4; // aqui eu limito o numero de opcoes que vao aparecer dentro da janela( janela leia-se combobox)
            comboBoxEspessuraDaCaneta.IntegralHeight = false; // e aqui eu desativo a função q nao iria me permitir limitar as opçoes por janela(combobox)

            graphicsPainelPintura = panelPintura.CreateGraphics(); // o 'graphics' permite o desenho sobre o controle 
            espessuraCaneta = float.Parse(comboBoxEspessuraDaCaneta.Text); // converte o texto da combobox espessura para o tipo float (numero)
            corBorracha = panelPintura.BackColor; // especifica a cor padrao da borracha como cor de fundo do painel 

            imagemASalvar = new Bitmap(panelPintura.Width, panelPintura.Height); // imagem para salvar do tamnho do painel de pinturA
            graphicsImagemASalvar = Graphics.FromImage(imagemASalvar); // extraindo graphics da imagem p/ salvar de forma que permite desenhar nela 
            graphicsImagemASalvar.Clear(panelPintura.BackColor); // preenche a imagem com a cor do painel 
        }
        // Handler do evento de click do botao
        // É disparado quando o botão é clicado 
        // Serve para maniplar oque acontece quando o clique ocorre 
        private void buttonCorCaneta_Click(object sender, EventArgs e)
        {
            var ColorDialog = new ColorDialog(); // criando uma caixa de dialogo para seleção de cores 
            var CorEscolhida = ColorDialog.ShowDialog(); // exibe na forma modal - a aplicação fica travada enquanto o dialogo não é resolvido 
            if (CorEscolhida == DialogResult.OK) // verifica se o usuario clicou mesmo em OK
            {
                buttonCorCaneta.BackColor = ColorDialog.Color; // altera a cor do botao pela cor escolhida pelo usuario 
            }
        }

        private void panelPintura_MouseDown(object sender, MouseEventArgs e)
        {
            flagPintar = true; // quando o botao do mouse é precionado sob o painel ele entende que deve pintar 
        }

        private void panelPintura_MouseUp(object sender, MouseEventArgs e)
        {
            flagPintar = false; // quando o botao do mouse é solto o painel entende que nao deve pintar 
        }

        private void panelPintura_MouseMove(object sender, MouseEventArgs e)
        {
            if(flagPintar)
            {
                if (!flagApagar)
                {
                    // desenhando uma elipse de cor e espessura definida pelo usuario, com as coordenadas do mouse 
                    graphicsPainelPintura
                    .DrawEllipse(new Pen(buttonCorCaneta.BackColor, espessuraCaneta), new RectangleF(e.X, e.Y, espessuraCaneta, espessuraCaneta));
                    // desenhando na imagem
                    graphicsImagemASalvar
                    .DrawEllipse(new Pen(buttonCorCaneta.BackColor, espessuraCaneta), new RectangleF(e.X, e.Y, espessuraCaneta, espessuraCaneta));
                }
                else
                {
                    graphicsPainelPintura
                    .DrawRectangle(new Pen(corBorracha, espessuraCaneta), new Rectangle(e.X, e.Y, (int)espessuraCaneta, (int)espessuraCaneta));
                    
                    graphicsImagemASalvar
                    .DrawRectangle(new Pen(corBorracha, espessuraCaneta), new Rectangle(e.X, e.Y, (int)espessuraCaneta, (int)espessuraCaneta));
                }

                //graphicsPainelPintura
                  //  .DrawEllipse(new Pen(buttonCorCaneta.BackColor, espessuraCaneta), new RectangleF(e.X, e.Y, espessuraCaneta, espessuraCaneta));
            }
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja limpar tudo?", "Apagar desenho", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== DialogResult.OK)
            {
                graphicsPainelPintura.Clear(Color.White);// limpa o painel preenxendo de branco 
                imagemASalvar = new Bitmap(panelPintura.Width, panelPintura.Height); // imagem para salvar do tamnho do painel de pinturA
                graphicsImagemASalvar = Graphics.FromImage(imagemASalvar); // extraindo graphics da imagem p/ salvar de forma que permite desenhar nela 
                graphicsImagemASalvar.Clear(panelPintura.BackColor); // preenche a imagem com a cor do painel 
            }
        }

        //SelectedIndexChanged ocorre qnd o indice do item selecionado muda ou seja quando o usuario escolhe uma opcao na combo box 
        private void comboBoxEspessuraDaCaneta_SelectedIndexChanged(object sender, EventArgs e)
        {
            espessuraCaneta = float.Parse(comboBoxEspessuraDaCaneta.SelectedItem.ToString());
        }

        private void buttonBorracha_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // seleciona a cor da borracha se clicar com o botao direito sob o button
            {
                var colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    corBorracha = colorDialog.Color; // seleciona qual a cor da borracha
                }
            }
            else
            {
                if (!flagApagar) // o operador '!' antes da flag ira virar o seu valor ao contrario, se é false fica true e se é true vira false
                {
                    flagApagar = true;
                    buttonBorracha.BackColor = corBorracha; // cor do botao sera o mesmo que o da borracha 
                }
                else
                {
                    flagApagar = false; // a borracha nao estara mais selecionada 
                    buttonBorracha.BackColor = Color.Black; // cor do botao volta ao padrao
                }
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog(); // janela para salvar a imagem 
            saveFileDialog.Filter = "Portable Network Grafics|.png|Arquivo JPEG|.JPEG|Arquivo GIF|.GIF"; // atribuindo os formatos de imagem disponiveis para salvar  
            if (saveFileDialog.ShowDialog() == DialogResult.OK) 
            {
                // define a extensao da imagme que ira salvar 
                switch(saveFileDialog.FilterIndex)
                {
                    case 1:
                        imagemASalvar.Save(saveFileDialog.FileName, ImageFormat.Png);
                        break;
                    case 2:
                        imagemASalvar.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                        break;
                    case 3:
                        imagemASalvar.Save(saveFileDialog.FileName, ImageFormat.Gif);
                        break;
                }
            }
        }
        
        private void panelPintura_Resize(object sender, EventArgs e) // esse evento é disparado sempre que o painel de pintira é redimencionado 
        {
            graphicsPainelPintura = panelPintura.CreateGraphics(); // atualiza a referencia do objeto  graphics do painel
            var imgTemp = new Bitmap(panelPintura.Width, panelPintura.Height); // cria uma imgem temporia 
            var graphicsImgTemp = Graphics.FromImage(imgTemp);
            graphicsImgTemp.DrawImage(imagemASalvar, 0, 0); // desenha a imagem antiga na imgtemp
            imagemASalvar = imgTemp;// atualiza qual iamgem salvar 
            graphicsImagemASalvar = graphicsImgTemp;// atualiza como salvar a imagem 
        }
    }
}
