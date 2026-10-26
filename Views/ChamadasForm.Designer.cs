namespace MundialDESKTOP.V1.Views
{
    partial class ChamadasForm
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
            this.lblEmergencia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flpRecebida = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flpRecente = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNumeroTelefone = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNomeChamada = new System.Windows.Forms.Label();
            this.lblTipoChamada = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.picMiniMapa = new System.Windows.Forms.PictureBox();
            this.timerChamada = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblStatusChamada = new System.Windows.Forms.Label();
            this.btnAceitar = new System.Windows.Forms.Button();
            this.btnRecusar = new System.Windows.Forms.Button();
            this.btnEncerrar = new System.Windows.Forms.Button();
            this.btnVincular = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMiniMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmergencia
            // 
            this.lblEmergencia.AutoSize = true;
            this.lblEmergencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmergencia.Location = new System.Drawing.Point(24, 25);
            this.lblEmergencia.Name = "lblEmergencia";
            this.lblEmergencia.Size = new System.Drawing.Size(262, 33);
            this.lblEmergencia.TabIndex = 2;
            this.lblEmergencia.Text = "Fila de chamadas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Recebida";
            // 
            // flpRecebida
            // 
            this.flpRecebida.Location = new System.Drawing.Point(30, 124);
            this.flpRecebida.Name = "flpRecebida";
            this.flpRecebida.Size = new System.Drawing.Size(569, 222);
            this.flpRecebida.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recente";
            // 
            // flpRecente
            // 
            this.flpRecente.Location = new System.Drawing.Point(30, 463);
            this.flpRecente.Name = "flpRecente";
            this.flpRecente.Size = new System.Drawing.Size(569, 222);
            this.flpRecente.TabIndex = 5;
            // 
            // lblNumeroTelefone
            // 
            this.lblNumeroTelefone.AutoSize = true;
            this.lblNumeroTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroTelefone.Location = new System.Drawing.Point(650, 25);
            this.lblNumeroTelefone.Name = "lblNumeroTelefone";
            this.lblNumeroTelefone.Size = new System.Drawing.Size(221, 33);
            this.lblNumeroTelefone.TabIndex = 6;
            this.lblNumeroTelefone.Text = "+84 333 33333";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picMiniMapa);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.lblTipoChamada);
            this.panel1.Controls.Add(this.lblNomeChamada);
            this.panel1.Location = new System.Drawing.Point(655, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 324);
            this.panel1.TabIndex = 7;
            // 
            // lblNomeChamada
            // 
            this.lblNomeChamada.AutoSize = true;
            this.lblNomeChamada.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeChamada.Location = new System.Drawing.Point(17, 11);
            this.lblNomeChamada.Name = "lblNomeChamada";
            this.lblNomeChamada.Size = new System.Drawing.Size(97, 33);
            this.lblNomeChamada.TabIndex = 8;
            this.lblNomeChamada.Text = "Nome";
            // 
            // lblTipoChamada
            // 
            this.lblTipoChamada.AutoSize = true;
            this.lblTipoChamada.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoChamada.Location = new System.Drawing.Point(17, 53);
            this.lblTipoChamada.Name = "lblTipoChamada";
            this.lblTipoChamada.Size = new System.Drawing.Size(67, 31);
            this.lblTipoChamada.TabIndex = 8;
            this.lblTipoChamada.Text = "Tipo";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(31, 101);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(476, 204);
            this.txtDescricao.TabIndex = 9;
            this.txtDescricao.TabStop = false;
            // 
            // picMiniMapa
            // 
            this.picMiniMapa.Image = global::MundialDESKTOP.V1.Properties.Resources.mapa;
            this.picMiniMapa.Location = new System.Drawing.Point(529, 25);
            this.picMiniMapa.Name = "picMiniMapa";
            this.picMiniMapa.Size = new System.Drawing.Size(504, 280);
            this.picMiniMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMiniMapa.TabIndex = 10;
            this.picMiniMapa.TabStop = false;
            // 
            // timerChamada
            // 
            this.timerChamada.Enabled = true;
            this.timerChamada.Tick += new System.EventHandler(this.timerChamada_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(1436, 27);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(253, 31);
            this.lblTimer.TabIndex = 8;
            this.lblTimer.Text = "Tempo de chamada";
            // 
            // lblStatusChamada
            // 
            this.lblStatusChamada.AutoSize = true;
            this.lblStatusChamada.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusChamada.Location = new System.Drawing.Point(659, 89);
            this.lblStatusChamada.Name = "lblStatusChamada";
            this.lblStatusChamada.Size = new System.Drawing.Size(571, 33);
            this.lblStatusChamada.TabIndex = 11;
            this.lblStatusChamada.Text = "Recebida/Ativa, Tocando, ENCERRADA";
            // 
            // btnAceitar
            // 
            this.btnAceitar.BackColor = System.Drawing.Color.Lime;
            this.btnAceitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceitar.Location = new System.Drawing.Point(661, 466);
            this.btnAceitar.Name = "btnAceitar";
            this.btnAceitar.Size = new System.Drawing.Size(174, 41);
            this.btnAceitar.TabIndex = 12;
            this.btnAceitar.Text = "ACEITAR";
            this.btnAceitar.UseVisualStyleBackColor = false;
            this.btnAceitar.Click += new System.EventHandler(this.btnAceitar_Click);
            // 
            // btnRecusar
            // 
            this.btnRecusar.BackColor = System.Drawing.Color.Red;
            this.btnRecusar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecusar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecusar.Location = new System.Drawing.Point(841, 466);
            this.btnRecusar.Name = "btnRecusar";
            this.btnRecusar.Size = new System.Drawing.Size(174, 41);
            this.btnRecusar.TabIndex = 13;
            this.btnRecusar.Text = "RECUSAR";
            this.btnRecusar.UseVisualStyleBackColor = false;
            this.btnRecusar.Click += new System.EventHandler(this.btnRecusar_Click);
            // 
            // btnEncerrar
            // 
            this.btnEncerrar.BackColor = System.Drawing.Color.Gray;
            this.btnEncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncerrar.Location = new System.Drawing.Point(1021, 466);
            this.btnEncerrar.Name = "btnEncerrar";
            this.btnEncerrar.Size = new System.Drawing.Size(174, 41);
            this.btnEncerrar.TabIndex = 14;
            this.btnEncerrar.Text = "ENCERRAR";
            this.btnEncerrar.UseVisualStyleBackColor = false;
            this.btnEncerrar.Click += new System.EventHandler(this.btnEncerrar_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVincular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVincular.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVincular.Location = new System.Drawing.Point(1201, 466);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(227, 41);
            this.btnVincular.TabIndex = 15;
            this.btnVincular.Text = "Vincular a incidente";
            this.btnVincular.UseVisualStyleBackColor = false;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // ChamadasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1737, 943);
            this.Controls.Add(this.btnVincular);
            this.Controls.Add(this.btnEncerrar);
            this.Controls.Add(this.btnRecusar);
            this.Controls.Add(this.btnAceitar);
            this.Controls.Add(this.lblStatusChamada);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNumeroTelefone);
            this.Controls.Add(this.flpRecente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flpRecebida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEmergencia);
            this.Name = "ChamadasForm";
            this.Text = "ChamadasForm";
            this.Load += new System.EventHandler(this.ChamadasForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMiniMapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmergencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpRecebida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpRecente;
        private System.Windows.Forms.Label lblNumeroTelefone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNomeChamada;
        private System.Windows.Forms.PictureBox picMiniMapa;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblTipoChamada;
        private System.Windows.Forms.Timer timerChamada;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblStatusChamada;
        private System.Windows.Forms.Button btnAceitar;
        private System.Windows.Forms.Button btnRecusar;
        private System.Windows.Forms.Button btnEncerrar;
        private System.Windows.Forms.Button btnVincular;
    }
}