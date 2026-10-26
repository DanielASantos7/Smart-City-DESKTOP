using MundialDESKTOP.V1.Helpers;
using MundialDESKTOP.V1.Models;
using MundialDESKTOP.V1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MundialDESKTOP.V1.Views
{
    public partial class DetalhesForm : Form
    {
        private readonly string _incidenteId;
        private Incident _incidenteAtual;
        private List<Unit> _todasUnidades = new List<Unit>();
        private List<string> _unidadesSelecionadas = new List<string>();

        // Construtor 1: Recebe o ID do Incidente como string (ex: "16")
        public DetalhesForm(string incidenteId)
        {
            InitializeComponent();
            _incidenteId = incidenteId;
        }

        // Construtor 2 (Sobrecarga): Recebe a model Incident e extrai o ID automaticamente
        public DetalhesForm(Incident incidente) : this(incidente?.id)
        {
            _incidenteAtual = incidente;
        }

        private async void DetalhesForm_Load(object sender, EventArgs e)
        {
            await CarregarDadosAsync();

            // Polling continuo de 2000ms conforme regra da prova (Seção 5)
            timerPolling.Interval = 2000;
            timerPolling.Start();
        }

        private async void timerPolling_Tick(object sender, EventArgs e)
        {
            await CarregarDadosAsync();
        }

        private async Task CarregarDadosAsync()
        {
            try
            {
                // 1. Busca os dados atualizados do incidente na API
                _incidenteAtual = await ApiService.GetAsync<Incident>($"api/incidents/{_incidenteId}");
                if (_incidenteAtual == null) return;

                // 2. Busca o estado global para obter a lista de unidades atualizada
                StateResponse state = await ApiService.GetAsync<StateResponse>("api/state");
                if (state != null && state.units != null)
                {
                    _todasUnidades = state.units.ToList();
                }

                // 3. Atualiza os componentes gráficos
                AtualizarCamposFormulario();
                AplicarRegrasEstadoUI();
                RenderizarUnidades();
            }
            catch
            {
                // Proteção contra oscilações de rede durante o polling
            }
        }

        private void AtualizarCamposFormulario()
        {
            txtIdEM.Text = $"EM-{_incidenteAtual.id}";
            cmbStatusEM.Text = _incidenteAtual.status?.ToUpper() ?? "";

            // Tradução de (X, Y) para Endereço via GeocodingHelper (C# 7.3)
            if (_incidenteAtual.location != null)
            {
                EnderecoInfo endereco = GeocodingHelper.ObterEndereco(_incidenteAtual.location.x, _incidenteAtual.location.y);
                txtRuaEM.Text = endereco.Rua;
                txtNumeroEM.Text = endereco.Numero;
                txtCEPEM.Text = endereco.CEP;
                txtCidadeEM.Text = endereco.Cidade;
            }

            // Sincroniza unidades atribuídas salvas
            if (_incidenteAtual.assignedUnitIds != null)
            {
                _unidadesSelecionadas = _incidenteAtual.assignedUnitIds.ToList();
            }
        }

        /// <summary>
        /// REGRA DE MARCAÇÃO DA PROVA (Seção 5):
        /// - unacknowledged: Todos os campos travados exceto o botão Reconhecer.
        /// - acknowledged: Permite selecionar unidades, aplicar recomendação e Salvar/Atribuir.
        /// - resolved: Somente leitura.
        /// </summary>
        private void AplicarRegrasEstadoUI()
        {
            string status = (_incidenteAtual.status ?? "").ToLower();

            bool isUnacknowledged = (status == "unacknowledged");
            bool isAcknowledged = (status == "acknowledged");

            // Botões de Ação
            btnReconhecer.Enabled = isUnacknowledged;
            btnRecomendacoes.Enabled = isAcknowledged;
            btnAtribuir.Enabled = isAcknowledged;
            btnSalvar.Enabled = isAcknowledged;
            chkListaUnidades.Enabled = isAcknowledged;

            // Bloqueio de campos de texto
            txtRuaEM.ReadOnly = true;
            txtNumeroEM.ReadOnly = true;
            txtCEPEM.ReadOnly = true;
            txtCidadeEM.ReadOnly = true;
            txtIdEM.ReadOnly = true;
        }

        private void RenderizarUnidades()
        {
            chkListaUnidades.Items.Clear();

            for (int i = 0; i < _todasUnidades.Count; i++)
            {
                Unit u = _todasUnidades[i];
                bool isAlreadyAssigned = _unidadesSelecionadas.Contains(u.id);

                string rotulo = $"[{u.type.ToUpper()}] {u.callSign} - ({u.status})";
                chkListaUnidades.Items.Add(rotulo, isAlreadyAssigned);
            }
        }

        // Evento ItemCheck do CheckedListBox para impedir a seleção de unidades indisponíveis (Regra da Prova)
        private void chkListaUnidades_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index < 0 || e.Index >= _todasUnidades.Count) return;

            Unit u = _todasUnidades[e.Index];
            bool isAvailable = ((u.status ?? "").ToLower() == "available");
            bool isAlreadyAssigned = _unidadesSelecionadas.Contains(u.id);

            // Se a unidade não estiver disponível e não for deste incidente, cancela a alteração
            if (!isAvailable && !isAlreadyAssigned && e.NewValue == CheckState.Checked)
            {
                e.NewValue = e.CurrentValue; // Cancela a alteração
                MessageBox.Show($"A unidade {u.callSign} está indisponível ({u.status}).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Atualiza a lista de IDs selecionados
                if (e.NewValue == CheckState.Checked && !_unidadesSelecionadas.Contains(u.id))
                {
                    _unidadesSelecionadas.Add(u.id);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    _unidadesSelecionadas.Remove(u.id);
                }
            }
        }

        // =========================================================================================
        // EVENTOS DOS BOTÕES
        // =========================================================================================

        // 1. Botão RECONHECER (POST /api/incidents/{id}/acknowledge)
        private async void btnReconhecer_Click(object sender, EventArgs e)
        {
            await ApiService.PostAsync<object>($"api/incidents/{_incidenteId}/acknowledge");
            await CarregarDadosAsync();
        }

        // 2. Botão APLICAR RECOMENDAÇÃO (GET /api/incidents/{id}/recommendation)
        private async void btnRecomendacoes_Click(object sender, EventArgs e)
        {
            RecommendationResponse rec = await ApiService.GetAsync<RecommendationResponse>($"api/incidents/{_incidenteId}/recommendation");
            if (rec != null && rec.suggestedUnitIds != null)
            {
                _unidadesSelecionadas = rec.suggestedUnitIds.ToList();
                RenderizarUnidades();
            }
        }

        // 3. Botões ATRIBUIR / SALVAR (PATCH /api/incidents/{id})
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            await ExecutarSalvamentoAsync();
        }

        private async void btnAtribuir_Click(object sender, EventArgs e)
        {
            await ExecutarSalvamentoAsync();
        }

        private async Task ExecutarSalvamentoAsync()
        {
            var payload = new
            {
                assignedUnitIds = _unidadesSelecionadas.ToArray()
            };

            var resposta = await ApiService.PatchAsync<object>($"api/incidents/{_incidenteId}", payload);
            if (resposta != null)
            {
                MessageBox.Show("Atribuição de unidades salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CarregarDadosAsync();
            }
        }

        // 4. Botão CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Modelo auxiliar local para desserializar a rota de recomendação da API
    public class RecommendationResponse
    {
        public string subtype { get; set; }
        public string[] suggestedUnitIds { get; set; }
    }
}