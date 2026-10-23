namespace MundialDESKTOP.V1.Views
{
    partial class PrincipalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMapa = new System.Windows.Forms.Panel();
            this.pnlCamadas = new System.Windows.Forms.Panel();
            this.chkStatusDefault = new System.Windows.Forms.CheckBox();
            this.chkStatusAtribuido = new System.Windows.Forms.CheckBox();
            this.chkStatusReconhecido = new System.Windows.Forms.CheckBox();
            this.chkStatusNaoReconhecido = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIncidentesMedico = new System.Windows.Forms.CheckBox();
            this.chkIncidentesCrime = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkIncidentesIncendio = new System.Windows.Forms.CheckBox();
            this.chkCamadaEstacao = new System.Windows.Forms.CheckBox();
            this.chkCamadaIncidente = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picMapa = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuMapa = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.object_89736b10_0ca1_4338_a0cb_29df0ea92f76 = new System.Windows.Forms.PictureBox();
            this.pnlTabela = new System.Windows.Forms.Panel();
            this.dgvIncidentes = new System.Windows.Forms.DataGridView();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerPiscada = new System.Windows.Forms.Timer(this.components);
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            this.lblRodaPe = new System.Windows.Forms.Label();
            this.lblIndicadorConnection = new System.Windows.Forms.Label();
            this.pnlMapa.SuspendLayout();
            this.pnlCamadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapa)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.object_89736b10_0ca1_4338_a0cb_29df0ea92f76)).BeginInit();
            this.pnlTabela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidentes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMapa
            // 
            this.pnlMapa.Controls.Add(this.pnlCamadas);
            this.pnlMapa.Controls.Add(this.picMapa);
            this.pnlMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMapa.Location = new System.Drawing.Point(0, 50);
            this.pnlMapa.Name = "pnlMapa";
            this.pnlMapa.Size = new System.Drawing.Size(1737, 792);
            this.pnlMapa.TabIndex = 1;
            // 
            // pnlCamadas
            // 
            this.pnlCamadas.Controls.Add(this.chkStatusDefault);
            this.pnlCamadas.Controls.Add(this.chkStatusAtribuido);
            this.pnlCamadas.Controls.Add(this.chkStatusReconhecido);
            this.pnlCamadas.Controls.Add(this.chkStatusNaoReconhecido);
            this.pnlCamadas.Controls.Add(this.label3);
            this.pnlCamadas.Controls.Add(this.chkIncidentesMedico);
            this.pnlCamadas.Controls.Add(this.chkIncidentesCrime);
            this.pnlCamadas.Controls.Add(this.label2);
            this.pnlCamadas.Controls.Add(this.chkIncidentesIncendio);
            this.pnlCamadas.Controls.Add(this.chkCamadaEstacao);
            this.pnlCamadas.Controls.Add(this.chkCamadaIncidente);
            this.pnlCamadas.Controls.Add(this.label1);
            this.pnlCamadas.Location = new System.Drawing.Point(1417, 3);
            this.pnlCamadas.Name = "pnlCamadas";
            this.pnlCamadas.Size = new System.Drawing.Size(317, 714);
            this.pnlCamadas.TabIndex = 1;
            // 
            // chkStatusDefault
            // 
            this.chkStatusDefault.AutoSize = true;
            this.chkStatusDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatusDefault.Location = new System.Drawing.Point(9, 566);
            this.chkStatusDefault.Name = "chkStatusDefault";
            this.chkStatusDefault.Size = new System.Drawing.Size(57, 35);
            this.chkStatusDefault.TabIndex = 12;
            this.chkStatusDefault.Text = "...";
            this.chkStatusDefault.UseVisualStyleBackColor = true;
            this.chkStatusDefault.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // chkStatusAtribuido
            // 
            this.chkStatusAtribuido.AutoSize = true;
            this.chkStatusAtribuido.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatusAtribuido.Location = new System.Drawing.Point(9, 525);
            this.chkStatusAtribuido.Name = "chkStatusAtribuido";
            this.chkStatusAtribuido.Size = new System.Drawing.Size(140, 35);
            this.chkStatusAtribuido.TabIndex = 11;
            this.chkStatusAtribuido.Text = "Atribuído";
            this.chkStatusAtribuido.UseVisualStyleBackColor = true;
            this.chkStatusAtribuido.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // chkStatusReconhecido
            // 
            this.chkStatusReconhecido.AutoSize = true;
            this.chkStatusReconhecido.Checked = true;
            this.chkStatusReconhecido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatusReconhecido.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatusReconhecido.Location = new System.Drawing.Point(9, 484);
            this.chkStatusReconhecido.Name = "chkStatusReconhecido";
            this.chkStatusReconhecido.Size = new System.Drawing.Size(192, 35);
            this.chkStatusReconhecido.TabIndex = 10;
            this.chkStatusReconhecido.Text = "Reconhecido";
            this.chkStatusReconhecido.UseVisualStyleBackColor = true;
            this.chkStatusReconhecido.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // chkStatusNaoReconhecido
            // 
            this.chkStatusNaoReconhecido.AutoSize = true;
            this.chkStatusNaoReconhecido.Checked = true;
            this.chkStatusNaoReconhecido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatusNaoReconhecido.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatusNaoReconhecido.Location = new System.Drawing.Point(9, 443);
            this.chkStatusNaoReconhecido.Name = "chkStatusNaoReconhecido";
            this.chkStatusNaoReconhecido.Size = new System.Drawing.Size(238, 35);
            this.chkStatusNaoReconhecido.TabIndex = 9;
            this.chkStatusNaoReconhecido.Text = "Não reconhecido";
            this.chkStatusNaoReconhecido.UseVisualStyleBackColor = true;
            this.chkStatusNaoReconhecido.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status";
            // 
            // chkIncidentesMedico
            // 
            this.chkIncidentesMedico.AutoSize = true;
            this.chkIncidentesMedico.Checked = true;
            this.chkIncidentesMedico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncidentesMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncidentesMedico.Location = new System.Drawing.Point(9, 297);
            this.chkIncidentesMedico.Name = "chkIncidentesMedico";
            this.chkIncidentesMedico.Size = new System.Drawing.Size(120, 35);
            this.chkIncidentesMedico.TabIndex = 7;
            this.chkIncidentesMedico.Text = "Médico";
            this.chkIncidentesMedico.UseVisualStyleBackColor = true;
            this.chkIncidentesMedico.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // chkIncidentesCrime
            // 
            this.chkIncidentesCrime.AutoSize = true;
            this.chkIncidentesCrime.Checked = true;
            this.chkIncidentesCrime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncidentesCrime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncidentesCrime.Location = new System.Drawing.Point(9, 256);
            this.chkIncidentesCrime.Name = "chkIncidentesCrime";
            this.chkIncidentesCrime.Size = new System.Drawing.Size(105, 35);
            this.chkIncidentesCrime.TabIndex = 6;
            this.chkIncidentesCrime.Text = "Crime";
            this.chkIncidentesCrime.UseVisualStyleBackColor = true;
            this.chkIncidentesCrime.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Incidentes";
            // 
            // chkIncidentesIncendio
            // 
            this.chkIncidentesIncendio.AutoSize = true;
            this.chkIncidentesIncendio.Checked = true;
            this.chkIncidentesIncendio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncidentesIncendio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncidentesIncendio.Location = new System.Drawing.Point(9, 215);
            this.chkIncidentesIncendio.Name = "chkIncidentesIncendio";
            this.chkIncidentesIncendio.Size = new System.Drawing.Size(136, 35);
            this.chkIncidentesIncendio.TabIndex = 4;
            this.chkIncidentesIncendio.Text = "Incêndio";
            this.chkIncidentesIncendio.UseVisualStyleBackColor = true;
            this.chkIncidentesIncendio.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // chkCamadaEstacao
            // 
            this.chkCamadaEstacao.AutoSize = true;
            this.chkCamadaEstacao.Checked = true;
            this.chkCamadaEstacao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCamadaEstacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCamadaEstacao.Location = new System.Drawing.Point(9, 84);
            this.chkCamadaEstacao.Name = "chkCamadaEstacao";
            this.chkCamadaEstacao.Size = new System.Drawing.Size(146, 35);
            this.chkCamadaEstacao.TabIndex = 2;
            this.chkCamadaEstacao.Text = "Estações";
            this.chkCamadaEstacao.UseVisualStyleBackColor = true;
            this.chkCamadaEstacao.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // chkCamadaIncidente
            // 
            this.chkCamadaIncidente.AutoSize = true;
            this.chkCamadaIncidente.Checked = true;
            this.chkCamadaIncidente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCamadaIncidente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCamadaIncidente.Location = new System.Drawing.Point(9, 43);
            this.chkCamadaIncidente.Name = "chkCamadaIncidente";
            this.chkCamadaIncidente.Size = new System.Drawing.Size(158, 35);
            this.chkCamadaIncidente.TabIndex = 1;
            this.chkCamadaIncidente.Text = "Incidentes";
            this.chkCamadaIncidente.UseVisualStyleBackColor = true;
            this.chkCamadaIncidente.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camadas";
            // 
            // picMapa
            // 
            this.picMapa.Image = global::MundialDESKTOP.V1.Properties.Resources.mapa;
            this.picMapa.Location = new System.Drawing.Point(3, 0);
            this.picMapa.Name = "picMapa";
            this.picMapa.Size = new System.Drawing.Size(1408, 770);
            this.picMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMapa.TabIndex = 0;
            this.picMapa.TabStop = false;
            this.picMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.picMapa_Paint);
            this.picMapa.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picMapa_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1737, 50);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(1607, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "📞";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMapa,
            this.tabelaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1737, 38);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuMapa
            // 
            this.menuMapa.Name = "menuMapa";
            this.menuMapa.Size = new System.Drawing.Size(78, 34);
            this.menuMapa.Text = "Mapa";
            this.menuMapa.Click += new System.EventHandler(this.menuMapa_Click_1);
            // 
            // tabelaToolStripMenuItem
            // 
            this.tabelaToolStripMenuItem.Name = "tabelaToolStripMenuItem";
            this.tabelaToolStripMenuItem.Size = new System.Drawing.Size(84, 34);
            this.tabelaToolStripMenuItem.Text = "Tabela";
            this.tabelaToolStripMenuItem.Click += new System.EventHandler(this.tabelaToolStripMenuItem_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblIndicadorConnection);
            this.panel2.Controls.Add(this.lblRodaPe);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 842);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1737, 101);
            this.panel2.TabIndex = 2;
            // 
            // object_89736b10_0ca1_4338_a0cb_29df0ea92f76
            // 
            this.object_89736b10_0ca1_4338_a0cb_29df0ea92f76.Location = new System.Drawing.Point(0, 0);
            this.object_89736b10_0ca1_4338_a0cb_29df0ea92f76.Name = "object_89736b10_0ca1_4338_a0cb_29df0ea92f76";
            this.object_89736b10_0ca1_4338_a0cb_29df0ea92f76.Size = new System.Drawing.Size(919, 497);
            this.object_89736b10_0ca1_4338_a0cb_29df0ea92f76.TabIndex = 0;
            this.object_89736b10_0ca1_4338_a0cb_29df0ea92f76.TabStop = false;
            // 
            // pnlTabela
            // 
            this.pnlTabela.Controls.Add(this.dgvIncidentes);
            this.pnlTabela.Controls.Add(this.txtPesquisa);
            this.pnlTabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabela.Location = new System.Drawing.Point(0, 0);
            this.pnlTabela.Name = "pnlTabela";
            this.pnlTabela.Size = new System.Drawing.Size(1737, 842);
            this.pnlTabela.TabIndex = 2;
            // 
            // dgvIncidentes
            // 
            this.dgvIncidentes.AllowUserToDeleteRows = false;
            this.dgvIncidentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIncidentes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvIncidentes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIncidentes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIncidentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIncidentes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIncidentes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvIncidentes.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvIncidentes.Location = new System.Drawing.Point(0, 191);
            this.dgvIncidentes.MultiSelect = false;
            this.dgvIncidentes.Name = "dgvIncidentes";
            this.dgvIncidentes.ReadOnly = true;
            this.dgvIncidentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncidentes.Size = new System.Drawing.Size(1737, 651);
            this.dgvIncidentes.TabIndex = 3;
            this.dgvIncidentes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidentes_CellClick);
            this.dgvIncidentes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvIncidentes_CellFormatting);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtPesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.Location = new System.Drawing.Point(0, 0);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(1737, 38);
            this.txtPesquisa.TabIndex = 3;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerPiscada
            // 
            this.timerPiscada.Enabled = true;
            this.timerPiscada.Interval = 500;
            this.timerPiscada.Tick += new System.EventHandler(this.timerPiscada_Tick);
            // 
            // timerBusca
            // 
            this.timerBusca.Enabled = true;
            this.timerBusca.Interval = 300;
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // lblRodaPe
            // 
            this.lblRodaPe.AutoSize = true;
            this.lblRodaPe.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRodaPe.Location = new System.Drawing.Point(12, 39);
            this.lblRodaPe.Name = "lblRodaPe";
            this.lblRodaPe.Size = new System.Drawing.Size(93, 33);
            this.lblRodaPe.TabIndex = 0;
            this.lblRodaPe.Text = "label4";
            // 
            // lblIndicadorConnection
            // 
            this.lblIndicadorConnection.AutoSize = true;
            this.lblIndicadorConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndicadorConnection.Location = new System.Drawing.Point(1411, 39);
            this.lblIndicadorConnection.Name = "lblIndicadorConnection";
            this.lblIndicadorConnection.Size = new System.Drawing.Size(93, 33);
            this.lblIndicadorConnection.TabIndex = 1;
            this.lblIndicadorConnection.Text = "label4";
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1737, 943);
            this.Controls.Add(this.pnlMapa);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTabela);
            this.Controls.Add(this.panel2);
            this.Name = "PrincipalForm";
            this.Text = "Mapa";
            this.Load += new System.EventHandler(this.PrincipalForm_Load);
            this.pnlMapa.ResumeLayout(false);
            this.pnlCamadas.ResumeLayout(false);
            this.pnlCamadas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.object_89736b10_0ca1_4338_a0cb_29df0ea92f76)).EndInit();
            this.pnlTabela.ResumeLayout(false);
            this.pnlTabela.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidentes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMapa;
        private System.Windows.Forms.PictureBox picMapa;
        private System.Windows.Forms.Panel pnlCamadas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuMapa;
        private System.Windows.Forms.ToolStripMenuItem tabelaToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox object_89736b10_0ca1_4338_a0cb_29df0ea92f76;
        private System.Windows.Forms.CheckBox chkCamadaIncidente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkStatusDefault;
        private System.Windows.Forms.CheckBox chkStatusAtribuido;
        private System.Windows.Forms.CheckBox chkStatusReconhecido;
        private System.Windows.Forms.CheckBox chkStatusNaoReconhecido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIncidentesMedico;
        private System.Windows.Forms.CheckBox chkIncidentesCrime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIncidentesIncendio;
        private System.Windows.Forms.CheckBox chkCamadaEstacao;
        private System.Windows.Forms.Panel pnlTabela;
        private System.Windows.Forms.DataGridView dgvIncidentes;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerPiscada;
        private System.Windows.Forms.Timer timerBusca;
        private System.Windows.Forms.Label lblRodaPe;
        private System.Windows.Forms.Label lblIndicadorConnection;
    }
}