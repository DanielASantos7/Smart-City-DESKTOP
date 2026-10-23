//using MundialDESKTOP.V1.Models;
//using MundialDESKTOP.V1.Service;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace MundialDESKTOP.V1.Views
//{
//    public partial class DetalhesForm : Form
//    {
//        // Variaveis para guardar o ID recebido e as respostas da API
//        private readonly string _incidentId;
//        private Incident _incidenteAtual;
//        private StateResponse _estadoGlobal;

//        // O construtor recebe o ID do incidente clicado no mapa ou na tabela
//        public DetalhesForm(string incidentId)
//        {
//            InitializeComponent();
//            _incidentId = incidentId;
//        }

//        // Executado assim que a janela de detalhes e aberta na tela
//        private async void DetalhesForm_Load(object sender, EventArgs e)
//        {
//            await CarregarDadosAsync();
//        }

//        // Metodo assincrono que consulta a API e atualiza a interface
//        private async Task CarregarDadosAsync()
//        {
//            try
//            {
//                // Busca as informacoes deste incidente e o estado das estacoes na cidade
//                _incidenteAtual = await ApiService.GetAsync<Incident>($"api/incidents/{_incidentId}");
//                _estadoGlobal = await ApiService.GetAsync<StateResponse>("api/state");

//                if (_incidenteAtual == null) return;

//                // Preenche os campos de texto do formulario
//                txtIdEM.Text = _incidenteAtual.id;
//                .Text = _incidenteAtual.status;
//                txtRuaEM.Text = _incidenteAtual.location?.street ?? "";
//                txtNumeroEM.Text = _incidenteAtual.location?.number ?? "";
//                txtCEPEM.Text = _incidenteAtual.location?.zipcode ?? "";
//                txtCidadeEM.Text = _incidenteAtual.location?.city ?? "";

//                // Aplica os bloqueios de tela dependendo do status retornado
//                //AplicarRegrasPorStatus(_incidenteAtual.status);

//                // Popula o CheckedListBox com as viaturas disponíveis
//                CarregarUnidades();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // Controla a regra de bloqueio dos campos de acordo com o manual
//        private void AplicarRegrasPorStatus(string status)
//        {
//            bool isUnack = status.Equals("unacknowledged", StringComparison.OrdinalIgnoreCase);
//            bool isAck = status.Equals("acknowledged", StringComparison.OrdinalIgnoreCase);

//            // Quando NAO reconhecido: Apenas o botao Reconhecer fica ativo
//            btnReconhecer.Enabled = isUnack;

//            // Quando reconhecido: Libera a edicao dos campos e a selecao de viaturas
//            txtRuaEM.ReadOnly = !isAck;
//            txtNumeroEM.ReadOnly = !isAck;
//            txtCEPEM.ReadOnly = !isAck;
//            txtCidadeEM.ReadOnly = !isAck;

//            btnSalvar.Enabled = isAck;
//            btnRecomendacoes.Enabled = isAck;
//            chkListaUnidades.Enabled = isAck;
//        }

//        // Preenche o CheckedListBox com as unidades vindas das estacoes da API
//        private void CarregarUnidades()
//        {
//            if (_estadoGlobal?.stations == null) return;

//            chkListaUnidades.Items.Clear();

//            foreach (var estacao in _estadoGlobal.stations)
//            {
//                if (estacao.units == null) continue;

//                foreach (var unidade in estacao.units)
//                {
//                    // Exemplo de exibicao na lista: "FD-1 [FIRE] - (FD-ST1)"
//                    string textoExibicao = $"{unidade.id} [{unidade.type.ToUpper()}] - ({estacao.id})";

//                    // Verifica se a unidade ja esta atribuida a este incidente
//                    bool jaAtribuida = _incidenteAtual.assignedUnitIds != null &&
//                                        _incidenteAtual.assignedUnitIds.Contains(unidade.id);

//                    chkListaUnidades.Items.Add(textoExibicao, jaAtribuida);
//                }
//            }
//        }

//        // Clique do botao Reconhecer: Envia POST api/incidents/{id}/acknowledge
//        private async void btnReconhecer_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                await ApiService.PostAsync<object>($"api/incidents/{_incidentId}/acknowledge", null);
//                MessageBox.Show("Incidente reconhecido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                await CarregarDadosAsync();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Erro ao reconhecer: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // Clique do botao Salvar: Envia PUT api/incidents/{id} com as unidades marcadas
//        private async void btnSalvar_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                // Extrai o ID de cada unidade marcada no CheckedListBox
//                List<string> unidadesSelecionadas = new List<string>();

//                foreach (var item in chkListaUnidades.CheckedItems)
//                {
//                    string textoItem = item.ToString();
//                    string idUnidade = textoItem.Split(' ')[0]; // Pega a primeira palavra (ex: "FD-1")
//                    unidadesSelecionadas.Add(idUnidade);
//                }

//                // Objeto no formato exigido pela API
//                var payload = new
//                {
//                    assignedUnitIds = unidadesSelecionadas.ToArray(),
//                    location = new
//                    {
//                        street = txtRuaEM.Text.Trim(),
//                        number = txtNumeroEM.Text.Trim(),
//                        zipcode = txtCEPEM.Text.Trim(),
//                        city = txtCidadeEM.Text.Trim()
//                    }
//                };

//                await ApiService.PatchAsync<Incident>($"api/incidents/{_incidentId}", payload);

//                MessageBox.Show("Atribuição salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                await CarregarDadosAsync();
//            }
//            catch (Exception ex)
//            {
//                // Requisito do manual: Exibe a mensagem enviada pelo servidor sem alteracao em caso de erro 400
//                MessageBox.Show(ex.Message, "Validação da API", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }

//        private void btnCancelar_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//    }
//}