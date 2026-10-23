using MundialDESKTOP.V1.Models;
using MundialDESKTOP.V1.Service;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MundialDESKTOP.V1.Views
{
    public partial class PrincipalForm : Form
    {
        private StateResponse _estadoAtual;
        private Incident _incident;

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
                AtualizarTabelaIncidentes();
                AutalizarRodape();
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
            AtualizarTabelaIncidentes();
        }





        private void AutalizarRodape()
        {
            if (_estadoAtual?.incidents == null) return;
            var incs = _estadoAtual.incidents;
            int total = incs.Count();
            var naoRec = incs.Count(i => i.status.Equals("unacknowledged", StringComparison.OrdinalIgnoreCase));
            var rec = incs.Count(i => i.status.Equals("acknowledged", StringComparison.OrdinalIgnoreCase));
            var atrib = incs.Count(i => i.status.Equals("assigned", StringComparison.OrdinalIgnoreCase));
            var res = incs.Count(i => i.status.Equals("resolved", StringComparison.OrdinalIgnoreCase));

            lblRodaPe.Text = $"{total} entradas -- {naoRec} não reconhecidas -- {rec} reconhecidas -- {atrib} no local -- {res} resolvidas";
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

        private async void AbrirDetalhes(Incident inc)
        {
            try
            {
                _incident = await ApiService.GetAsync<Incident>($"api/incidents/{inc.id}");
                MessageBox.Show($"Boa, abriu detalhe certinho {inc.id}, o tipo dele é {inc.type}, o status é {inc.status}, e a descrição é {inc.description}", "Sucesso", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }


        private void AtualizarTabelaIncidentes()
        {
            if (_estadoAtual == null || _estadoAtual.incidents == null) return;
            if (!pnlTabela.Visible) return;

            string q = txtPesquisa.Text.Trim(); // Pega o texto digitado sem espaços nas pontas
            var lista = _estadoAtual.incidents.AsEnumerable(); // Pega a lista original de Incidentes


            if (!chkIncidentesIncendio.Checked) lista = lista.Where(i => !i.type.Equals("fire", StringComparison.OrdinalIgnoreCase));
            if (!chkIncidentesCrime.Checked) lista = lista.Where(i => !i.type.Equals("crime", StringComparison.OrdinalIgnoreCase));
            if (!chkIncidentesMedico.Checked) lista = lista.Where(i => !i.type.Equals("medical", StringComparison.OrdinalIgnoreCase));

            if (!chkStatusNaoReconhecido.Checked) lista = lista.Where(i => !i.status.Equals("unacknowledged", StringComparison.OrdinalIgnoreCase));
            if (!chkStatusReconhecido.Checked) lista = lista.Where(i => !i.status.Equals("acknowledged", StringComparison.OrdinalIgnoreCase));
            if (!chkStatusAtribuido.Checked) lista = lista.Where(i => !i.status.Equals("assigned", StringComparison.OrdinalIgnoreCase));
            if (!chkStatusDefault.Checked) lista = lista.Where(i => !i.status.Equals("resolved", StringComparison.OrdinalIgnoreCase));



            if (!string.IsNullOrWhiteSpace(q))
            {
                if (q.StartsWith("--id="))
                    lista = lista.Where(inc => inc.id == q.Substring(5));
                else if (q.StartsWith("--type=", StringComparison.OrdinalIgnoreCase))
                    lista = lista.Where(inc => inc.type.Equals(q.Substring(7), StringComparison.OrdinalIgnoreCase));
                else if (q.StartsWith("--status=", StringComparison.OrdinalIgnoreCase))
                    lista = lista.Where(inc => inc.status.Equals(q.Substring(9), StringComparison.OrdinalIgnoreCase));
                else if (q.StartsWith("--description=", StringComparison.OrdinalIgnoreCase))
                    lista = lista.Where(inc => inc.description != null && inc.description.IndexOf(q.Substring(14), StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var listaExibicao = lista.Select(inc => new
            {
                ID = inc.id,
                Tipo = inc.type,
                Subtipo = inc.subtype,
                Gravidade = inc.severity,
                Horario_Relatado = inc.reportedAt.ToString("dd/MM/yyyy HH:mm:ss"),
                Unidades_Atribuidas = string.Join(", ", inc.assignedUnitIds ?? new string[0]),
                Description = inc.description,
                Status = inc.status,
            }).ToList();

            dgvIncidentes.DataSource = null;
            dgvIncidentes.DataSource = listaExibicao;
        }

        private void dgvIncidentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string coluna = dgvIncidentes.Columns[e.ColumnIndex].Name;
            string valor = e.Value.ToString().ToLower();

            if (coluna == "Tipo")
            {
                if (valor == "fire") e.CellStyle.BackColor = Color.Red;
                else if (valor == "crime") e.CellStyle.BackColor = Color.Blue;
                else if (valor == "medical") e.CellStyle.BackColor = Color.Orange;

                e.CellStyle.ForeColor = Color.White;
            }

            else if (coluna == "Status")
            {
                if (valor == "unacknowledged") e.CellStyle.BackColor = Color.MistyRose;
                if (valor == "acknowledged") e.CellStyle.BackColor = Color.LightGoldenrodYellow;
                if (valor == "assigned") e.CellStyle.BackColor = Color.LightBlue;
                if (valor == "resolved") e.CellStyle.BackColor = Color.LightGreen;

                e.CellStyle.ForeColor = Color.Black;
            }
        }

        private void timerBusca_Tick(object sender, EventArgs e)
        {
            timerBusca.Stop();
            AtualizarTabelaIncidentes();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            timerBusca.Stop();
            timerBusca.Start();
        }

        private void dgvIncidentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvIncidentes.Rows[e.RowIndex].Cells["ID"]?.Value is string id)
            {
                var inc = _estadoAtual.incidents.FirstOrDefault(i => i.id == id);

                if (inc != null) AbrirDetalhes(inc);
            }
        }
    }
}
