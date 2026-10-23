using MundialDESKTOP.V1.Models;
using MundialDESKTOP.V1.Service;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MundialDESKTOP.V1.Views
{
    public partial class PrincipalForm : Form
    {
        private StateResponse _estadoAtual;

        public PrincipalForm()
        {
            InitializeComponent();
            pnlMapa.BringToFront();
            pnlTabela.Visible = false;
        }

        private async void PrincipalForm_Load(object sender, EventArgs e)
        {
            await CarregarDadosAsync();
        }


        private async Task CarregarDadosAsync()
        {
            _estadoAtual = await ApiService.GetAsync<StateResponse>("api/state");

            if (_estadoAtual != null)
            {
                picMapa.Invalidate();
            }
        }


        private async void timer1_Tick(object sender, EventArgs e)
        {
            await CarregarDadosAsync();
        }

        private bool _estadoPiscada = false;
        private void timerPiscada_Tick(object sender, EventArgs e)
        {
            _estadoPiscada = !_estadoPiscada; // alterna o estado da piscada, ta true vai para false, ta false vai para true
            picMapa.Invalidate(); // Pede par ao mapa redesenhar a piscada
        }

        private void picMapa_Paint(object sender, PaintEventArgs e)
        {
            // SE A API NÃO RESPONDEU NÃO DESENHA NADA, SÓ MOSTRA O MAPA
            if (_estadoAtual == null || _estadoAtual.incidents == null) return;

            // LEITURA DE CADA INCIDENTE RETORNADO PELA API, PARA DESENHAR NO MAPA
            foreach (var inc in _estadoAtual.incidents)
            {
                // Define a cor base pelo tipo de incidente
                Brush corTipo = Brushes.Red;
                if (inc.type == "crime") corTipo = Brushes.Blue;
                else if (inc.type == "medical") corTipo = Brushes.Orange;


                // SE NÃO FOR RECONHECIDO, APLICA A COR PISCANDO COM BRANCO
                Brush corFinal = corTipo;
                if (inc.status == "unacknowledged")
                {
                    corFinal = _estadoPiscada ? Brushes.White : corTipo;
                }

                // PEGA AS COORDENADAS X E Y E APLICA O RAIO PARA CENTRALIZAR
                float x = (float)inc.location.x;
                float y = (float)inc.location.y;
                int raio = 30; // circulo de tamanho 24x24

                // DESENHA O PREECHIMENTO DO CÍRCULO NO MAPA
                e.Graphics.FillEllipse(corFinal, x - raio, y - raio, raio * 2, raio * 2);

                // DESENHA A BORDA PRETA DO CIRCULO
                e.Graphics.DrawEllipse(Pens.Black, x - raio, y - raio, raio * 2, raio * 2);

                //DESENHA O ID DO INCIDENTE NO CENTRO DO MARCADOR
                using (Font fonte = new Font("Arial", 12, FontStyle.Bold))
                {
                    e.Graphics.DrawString(inc.id, fonte, Brushes.Black, x - 6, y - 5);
                }
            }

            if (_estadoAtual.stations != null)
            {
                foreach (var st in _estadoAtual.stations)
                {
                    // PEGA A LOCALIZAÇÃO EM PIXELS
                    float x = (float)st.location.x;
                    float y = (float)st.location.y;

                    string sigla = "FD";
                    if (st.type == "police") sigla = "PD";
                    else if (st.type == "medical") sigla = "EMS";

                    string textoEstacao = $"{sigla} [{st.availableUnitCount}]";

                    // DIMENSÕES DA CAIXINHA DA ESTAÇÃO
                    int larguraBox = 90;
                    int alturaBox = 60;
                    float boxX = x - larguraBox / 2;
                    float boxY = y - alturaBox / 2;

                    // DESENHA O FUNDO BRANCO DA CAIXINHA
                    e.Graphics.FillRectangle(Brushes.White, boxX, boxY, larguraBox, alturaBox);

                    // DESENHA A BORDA PRETA DA CAIXINHA
                    e.Graphics.DrawRectangle(Pens.Black, boxX, boxY, larguraBox, alturaBox);

                    // ESCREVE O TEXTO COM A SIGLA E O NÚMERO DE UNIDADES DISPONÍVEIS
                    using (Font font = new Font("Arial", 12, FontStyle.Bold))
                    {
                        e.Graphics.DrawString(textoEstacao, font, Brushes.Black, x - 25, y - 10);
                    }
                }
            }
        }

















        private void menuMapa_Click_1(object sender, EventArgs e)
        {
            pnlMapa.Visible = true;
            pnlMapa.BringToFront();
            pnlTabela.Visible = false;


        }

        private void tabelaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pnlTabela.Visible = true;
            pnlTabela.BringToFront();
            pnlMapa.Visible = false;

        }
    }
}
