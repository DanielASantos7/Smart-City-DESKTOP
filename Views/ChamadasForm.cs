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
        // Guardamos a lista de chamadas vindas da API e a chamada atualmente selecionada na UI
        private List<Call> _listaChamadas = new List<Call>();
        private Call _chamadaSelecionada;

        public ChamadasForm()
        {
            InitializeComponent();
        }

        // Evento que roda assim que o formulário é carregado na tela
        private async void ChamadasForm_Load(object sender, EventArgs e)
        {
            // 1. Busca inicial das chamadas na API
            await AtualizarChamadasAsync();

            // 2. Configura e inicia o Timer de 2 segundos (2000 ms) para polling contínuo
            timerChamadas.Interval = 2000;
            timerChamadas.Start();
        }

        // Evento Tick disparado automaticamente pelo Timer a cada 2 segundos
        private async void timerChamadas_Tick(object sender, EventArgs e)
        {
            await AtualizarChamadasAsync();
        }

        // MÉTODO PRINCIPAL: Consulta o envelope CallsResponse da API (/api/calls) e atualiza a interface
        public async Task AtualizarChamadasAsync()
        {
            try
            {
                // Requisita o objeto envelope contendo as chamadas
                var respostaServer = await ApiService.GetAsync<CallsResponse>("api/calls");
                if (respostaServer?.calls == null) return;

                _listaChamadas = respostaServer.calls.ToList();

                // Desenha os cartões na fila da esquerda
                RenderizarFilaChamadas();

                // Auto-seleciona a primeira chamada válida caso nenhuma esteja selecionada ainda
                if (_chamadaSelecionada == null && _listaChamadas.Count > 0)
                {
                    _chamadaSelecionada = _listaChamadas.FirstOrDefault(c => c.status == "ringing" || c.status == "active")
                                          ?? _listaChamadas.First();
                }

                // Mantém os detalhes da chamada selecionada atualizados
                if (_chamadaSelecionada != null)
                {
                    _chamadaSelecionada = _listaChamadas.FirstOrDefault(c => c.id == _chamadaSelecionada.id) ?? _chamadaSelecionada;
                    ExibirDetalhesChamada(_chamadaSelecionada);
                }
            }
            catch
            {
                // Ignora falhas temporárias de rede para garantir estabilidade da tela na prova
            }
        }

        // MÉTODO DE RENDERIZAÇÃO: Monta dinamicamente os cartões nos FlowLayoutPanels
        private void RenderizarFilaChamadas()
        {
            // Congela o redesenho dos painéis para evitar piscamento (flicker)
            flpRecebidas.SuspendLayout();
            flpRecentes.SuspendLayout();

            // Limpa os cartões anteriores
            flpRecebidas.Controls.Clear();
            flpRecentes.Controls.Clear();

            foreach (var call in _listaChamadas)
            {
                // Painel container para cada chamada
                Panel card = new Panel
                {
                    Width = flpRecebidas.ClientSize.Width - 25,
                    Height = 45,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(3),
                    BackColor = Color.White
                };

                // Número do telefone (trata chamadas sem número/anônimas)
                Label lblNum = new Label
                {
                    Text = string.IsNullOrEmpty(call.callerNumber) ? "Anônimo" : call.callerNumber,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Location = new Point(5, 5),
                    AutoSize = true
                };

                // Exibição do status (Destaque em Vermelho para "RINGING")
                Label lblStatus = new Label
                {
                    Text = call.status.ToUpper(),
                    Font = new Font("Segoe UI", 8, FontStyle.Italic),
                    ForeColor = call.status.Equals("ringing", StringComparison.OrdinalIgnoreCase) ? Color.Red : Color.Gray,
                    Location = new Point(5, 22),
                    AutoSize = true
                };

                card.Controls.Add(lblNum);
                card.Controls.Add(lblStatus);

                // Eventos de clique no cartão e nos rótulos internos
                card.Click += (s, e) => SelecionarChamada(call);
                lblNum.Click += (s, e) => SelecionarChamada(call);
                lblStatus.Click += (s, e) => SelecionarChamada(call);

                // Separação de filas conforme especificação: Ativas/Tocando vs. Encerradas/Recusadas
                if (call.status.Equals("ringing", StringComparison.OrdinalIgnoreCase) ||
                    call.status.Equals("active", StringComparison.OrdinalIgnoreCase))
                {
                    flpRecebidas.Controls.Add(card);
                }
                else
                {
                    flpRecentes.Controls.Add(card);
                }
            }

            // Descongela e reativa o redesenho dos painéis
            flpRecebidas.ResumeLayout();
            flpRecentes.ResumeLayout();
        }

        // Seleciona a chamada clicada e exibe seus dados no painel da direita
        private void SelecionarChamada(Call call)
        {
            _chamadaSelecionada = call;
            ExibirDetalhesChamada(call);
        }

        // Preenche os campos de detalhes, botões e minimapa na direita
        private void ExibirDetalhesChamada(Call call)
        {
            if (call == null) return;

            lblNumeroTelefone.Text = string.IsNullOrEmpty(call.callerNumber) ? "Privado" : call.callerNumber;
            lblNome.Text = $"Nome: {call.callerName ?? "Não informado"}";
            lblTipo.Text = $"Tipo: {call.reportedType ?? "Geral"}";
            lblDescricao.Text = $"Descrição: {call.description ?? "Sem descrição"}";

            bool isRinging = call.status.Equals("ringing", StringComparison.OrdinalIgnoreCase);
            bool isActive = call.status.Equals("active", StringComparison.OrdinalIgnoreCase);

            // Regras do manual:
            // - Aceitar e Recusar ativos apenas para chamadas no status 'ringing'
            // - Encerrar ativo apenas para chamadas no status 'active'
            btnAceitar.Enabled = isRinging;
            btnRecusar.Enabled = isRinging;
            btnEncerrar.Enabled = isActive;

            // Desenha a marcação no minimapa
            DesenharPontoNoMinimapa(call.location?.x ?? 0, call.location?.y ?? 0);
        }

        // DESENHO GDI+: Projeção da coordenada (1408x768) para as dimensões da PictureBox
        private void DesenharPontoNoMinimapa(double x, double y)
        {
            if (picMinimapa.Image == null) return;

            // Clona a imagem original carregada no PictureBox
            Bitmap bmp = new Bitmap(picMinimapa.Image);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Regra de três simples para converter a coordenada do mapa original
                float posX = (float)(x * picMinimapa.Width / 1408.0);
                float posY = (float)(y * picMinimapa.Height / 768.0);

                // Desenha uma bolinha vermelha com contorno branco no ponto do chamado
                g.FillEllipse(Brushes.Red, posX - 6, posY - 6, 12, 12);
                g.DrawEllipse(Pens.White, posX - 6, posY - 6, 12, 12);
            }

            // Descarta a imagem antiga da memória para evitar vazamento de memória (Memory Leak)
            picMinimapa.Image?.Dispose();
            picMinimapa.Image = bmp;
        }

        // AÇÃO ACEITAR: Dispara POST /api/calls/{id}/accept
        private async void btnAceitar_Click(object sender, EventArgs e)
        {
            if (_chamadaSelecionada == null) return;

            try
            {
                await ApiService.PostAsync<object>($"api/calls/{_chamadaSelecionada.id}/accept", null);
                MessageBox.Show("Chamada aceita! Incidente gerado no sistema.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await AtualizarChamadasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aceitar chamada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // AÇÃO RECUSAR: Dispara POST /api/calls/{id}/reject
        private async void btnRecusar_Click(object sender, EventArgs e)
        {
            if (_chamadaSelecionada == null) return;

            try
            {
                await ApiService.PostAsync<object>($"api/calls/{_chamadaSelecionada.id}/reject", null);
                await AtualizarChamadasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao recusar chamada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // AÇÃO ENCERRAR: Dispara POST /api/calls/{id}/end
        private async void btnEncerrar_Click(object sender, EventArgs e)
        {
            if (_chamadaSelecionada == null) return;

            try
            {
                await ApiService.PostAsync<object>($"api/calls/{_chamadaSelecionada.id}/end", null);
                MessageBox.Show("Chamada encerrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await AtualizarChamadasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao encerrar chamada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}