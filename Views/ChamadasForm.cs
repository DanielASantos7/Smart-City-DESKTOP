using MundialDESKTOP.V1.Models;
using MundialDESKTOP.V1.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MundialDESKTOP.V1.Views
{
    public partial class ChamadasForm : Form
    {
        // (Armazenam os dados vindos do servidor)
        private List<Call> _chamadas = new List<Call>(); // Lista completa vinda do Get /api/calls 
        private Call _selecionada; // Chamada clicada no momento pelo operador

        public ChamadasForm()
        {
            InitializeComponent();
        }

        // Carga inicial e Polling continuo da API (2000ms)
        private async void ChamadasForm_Load(object sender, System.EventArgs e)
        {
            await CarregarDadosAsync();

            timerChamada.Interval = 2000;
            timerChamada.Start();
        }

        private async void timerChamada_Tick(object sender, EventArgs e)
        {
            await CarregarDadosAsync();
        }


        // Método para carregar os dados da API e atualizar a interface
        private async Task CarregarDadosAsync()
        {
            try
            {
                // Busca a lista envelope de chamadas da API
                var dados = await ApiService.GetAsync<CallsResponse>("api/calls");
                if (dados?.calls == null) return;

                _chamadas = dados.calls.ToList();

                // Redesenha a lista da esquerda com o estado atual da API
                DesenharListas();

                // Auto-Seleciona a primeira chamada se nenhuma estiver aberta
                if (_selecionada == null && _chamadas.Count > 0)
                {
                    _selecionada = _chamadas.FirstOrDefault(c => c.status == "ringing" || c.status == "active")
                        ?? _chamadas.First();
                }

                // Sincroniza a chamada selecionada com a nova versão atualizada do servidor
                if (_selecionada != null)
                {
                    _selecionada = _chamadas.FirstOrDefault(c => c.id == _selecionada.id) ?? _selecionada;

                    // Atualiza o painel de detalhes direita
                    MostrarDetalhes(_selecionada);
                }
            }
            catch
            {

            }
        }
        private void DesenharListas()
        {
            flpRecebida.Controls.Clear();
            flpRecente.Controls.Clear();

            foreach (var c in _chamadas)
            {
                Label card = new Label
                {
                    Text = $"{c.callerName ?? "Anônimo"}\n{c.status.ToUpper()}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),

                    ForeColor = c.status == "ringing" ? Color.Red : Color.Black,
                    BackColor = Color.White,

                    BorderStyle = BorderStyle.FixedSingle,

                    Width = flpRecebida.ClientSize.Width - 25,
                    Height = 45,
                    Padding = new Padding(4)
                };

                card.Click += (s, e) =>
                {
                    _selecionada = c;
                    MostrarDetalhes(c);
                };

                if (c.status == "ringing" || c.status == "active")
                    flpRecebida.Controls.Add(card);
                else
                    flpRecente.Controls.Add(card);
            }
        }

        // Exibição de Detalhes, Cronômetro e botões
        private void MostrarDetalhes(Call c)
        {
            if (c == null) return;

            lblNumeroTelefone.Text = string.IsNullOrWhiteSpace(c.callerNumber) ? "Número desconhecido" : c.callerNumber;
            lblStatusChamada.Text = c.status.ToUpper();
            lblNomeChamada.Text = $"Nome: {c.callerName ?? "Não informado"}";
            lblTipoChamada.Text = $"Tipo: {c.reportedType ?? "Geral"}";
            txtDescricao.Text = c.description ?? "Sem descrição";

            AtualizarCronometro(c);

            bool isRinging = (c.status == "ringing");
            bool isActive = (c.status == "active");

            bool existeChamadaAtiva = _chamadas.Any(call => call.status == "active");

            btnAceitar.Enabled = isRinging && !existeChamadaAtiva;
            btnRecusar.Enabled = isRinging;
            btnEncerrar.Enabled = isActive;
            btnVincular.Enabled = isActive;


            DesenharPontoNoMiniMapa(c.location?.x ?? 0, c.location?.y ?? 0);
        }

        private void AtualizarCronometro(Call c)
        {
            if (c.startedAt == default)
            {
                lblTimer.Text = "00:00";
                return;
            }

            TimeSpan duracao = DateTime.UtcNow - c.startedAt;
            if (duracao.TotalSeconds < 0) duracao = TimeSpan.Zero;

            lblTimer.Text = duracao.ToString(@"mm\:ss");
        }

        private void DesenharPontoNoMiniMapa(double x, double y)
        {
            if (picMiniMapa.Image == null) return;

            Bitmap bmp = new Bitmap(picMiniMapa.Image);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                float px = (float)(x * picMiniMapa.Width / 1408.0);
                float py = (float)(y * picMiniMapa.Width / 768.0);

                g.FillEllipse(Brushes.Red, px - 5, py - 5, 10, 10);
                g.DrawEllipse(Pens.White, px - 5, py - 5, 10, 10);
            }

            picMiniMapa.Image?.Dispose();
            picMiniMapa.Image = bmp;
        }

        private async void btnAceitar_Click(object sender, EventArgs e)
        {
            if (_selecionada == null) return;
            await ExecutarAcaoApiAsync($"api/calls/{_selecionada.id}/accept");
        }

        private async void btnRecusar_Click(object sender, EventArgs e)
        {
            if (_selecionada == null) return;
            await ExecutarAcaoApiAsync($"api/calls/{_selecionada.id}/decline");
        }

        private async void btnEncerrar_Click(object sender, EventArgs e)
        {
            if (_selecionada == null) return;
            await ExecutarAcaoApiAsync($"api/calls/{_selecionada.id}/end");
        }

        private async void btnVincular_Click(object sender, EventArgs e)
        {
            if (_selecionada == null) return;
            string incidenteID = PrincipalForm.IncidenteSelecionadoID;

            if (string.IsNullOrWhiteSpace(incidenteID))
            {
                MessageBox.Show("Selecione primeiro um incidente no Mapa ou na Tabela!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show($"Deseja vincular esta ao Incidente #{incidenteID}",
                "Confirmar Vinculação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                await ExecutarAcaoApiAsync($"api/calls/{_selecionada.id}/link", new { incidenteId = incidenteID });
            }
        }

        private async Task ExecutarAcaoApiAsync(string rota, object payload = null)
        {
            try
            {
                await ApiService.PostAsync<object>(rota, payload);

                await CarregarDadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem do Servidor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
