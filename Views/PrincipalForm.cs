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

            if (_estadoAtual == null) return;


            // ESTAÇÕES DE EMERGÊNCIA
            // FILTRO DE CAMADA: SÓ DESENHA SE CAMADAESTACOES ESTIVER MARCADO

            if (_estadoAtual.stations != null && chkCamadaEstacao.Checked)
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
            // FILTRO DE INCIDENTES: SÓ DESENHA SE CAMADAINCIDENTES ESTIVER MARCADO
            if (_estadoAtual.incidents != null && chkCamadaIncidente.Checked)
            {
                // LEITURA DE CADA INCIDENTE RETORNADO PELA API, PARA DESENHAR NO MAPA
                foreach (var inc in _estadoAtual.incidents)
                {
                    // FILTROS POR TIPO: SE O TIPO ESTIVER DESMARCADO NO PAINEL, PULA ELE
                    if (inc.type.Equals("fire", StringComparison.OrdinalIgnoreCase) && !chkIncidentesIncendio.Checked) continue;
                    if (inc.type.Equals("crime", StringComparison.OrdinalIgnoreCase) && !chkIncidentesCrime.Checked) continue;
                    if (inc.type.Equals("medical", StringComparison.OrdinalIgnoreCase) && !chkIncidentesMedico.Checked) continue;
                    if (inc.status.Equals("unacknowledged", StringComparison.OrdinalIgnoreCase) && !chkStatusNaoReconhecido.Checked) continue;
                    if (inc.status.Equals("acknowledged", StringComparison.OrdinalIgnoreCase) && !chkStatusReconhecido.Checked) continue;
                    if (inc.status.Equals("assigned", StringComparison.OrdinalIgnoreCase) && !chkStatusAtribuido.Checked) continue;
                    if (inc.status.Equals("resolved", StringComparison.OrdinalIgnoreCase) && !chkStatusDefault.Checked) continue;

                    // DESENHO DO INCIDENTE (SÓ CHEGA AQUI SE PASSOU POR TODOS OS FILTROS)
                    Brush corTipo = Brushes.Red;
                    if (inc.type.Equals("crime", StringComparison.OrdinalIgnoreCase)) corTipo = Brushes.Blue;
                    else if (inc.type.Equals("medical", StringComparison.OrdinalIgnoreCase)) corTipo = Brushes.Orange;

                    Brush corFinal = corTipo;
                    bool naoReconhecido = inc.status.Equals("unacknowledged", StringComparison.OrdinalIgnoreCase);

                    if (naoReconhecido)
                    {
                        corFinal = _estadoPiscada ? Brushes.White : corTipo; // alterna entre branco e a cor do tipo
                    }

                    float x = (float)inc.location.x;
                    float y = (float)inc.location.y;
                    int raio = 20;

                    e.Graphics.FillEllipse(corFinal, x - raio, y - raio, raio * 2, raio * 2);
                    e.Graphics.DrawEllipse(Pens.Black, x - raio, y - raio, raio * 2, raio * 2);

                    using (Font font = new Font("Arial", 12, FontStyle.Bold))
                    {
                        SizeF tamanhoTexto = e.Graphics.MeasureString(inc.id, font);
                        float textX = x - (tamanhoTexto.Width / 2);
                        float textY = y - (tamanhoTexto.Height / 2);

                        Brush corTexto = (naoReconhecido && _estadoPiscada) ? Brushes.Black : Brushes.White;
                        e.Graphics.DrawString(inc.id, font, corTexto, textX, textY);
                    }
                }
            }
        }




        // CHAMA SEMPRE QUE QUALQUER UM DOS 9 CHECKBOX FOR CLICADO
        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            picMapa.Invalidate();
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

        private void picMapa_MouseClick(object sender, MouseEventArgs e)
        {

            if (_estadoAtual == null || _estadoAtual.incidents == null || !chkCamadaIncidente.Checked) return;

            int raio = 20;

            foreach (var inc in _estadoAtual.incidents)
            {
                // FILTROS POR TIPO: SE O TIPO ESTIVER DESMARCADO NO PAINEL, PULA ELE
                if (inc.type.Equals("fire", StringComparison.OrdinalIgnoreCase) && !chkIncidentesIncendio.Checked) continue;
                if (inc.type.Equals("crime", StringComparison.OrdinalIgnoreCase) && !chkIncidentesCrime.Checked) continue;
                if (inc.type.Equals("medical", StringComparison.OrdinalIgnoreCase) && !chkIncidentesMedico.Checked) continue;
                if (inc.status.Equals("unacknowledged", StringComparison.OrdinalIgnoreCase) && !chkStatusNaoReconhecido.Checked) continue;
                if (inc.status.Equals("acknowledged", StringComparison.OrdinalIgnoreCase) && !chkStatusReconhecido.Checked) continue;
                if (inc.status.Equals("assigned", StringComparison.OrdinalIgnoreCase) && !chkStatusAtribuido.Checked) continue;
                if (inc.status.Equals("resolved", StringComparison.OrdinalIgnoreCase) && !chkStatusDefault.Checked) continue;

                double dx = e.X - inc.location.x;
                double dy = e.Y - inc.location.y;
                double distancia = Math.Sqrt(dx * dx + dy * dy);

                if (distancia <= raio)
                {
                    AbrirDetalhes(inc);
                    break;
                }
            }
        }

        private void AbrirDetalhes(Incident inc)
        {
            MessageBox.Show($"Boa, abriu detalhe certinho {inc.id}", "Sucesso", MessageBoxButtons.OK);
        }

    }
}
