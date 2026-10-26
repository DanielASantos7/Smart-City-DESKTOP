namespace MundialDESKTOP.V1.Views
{
    partial class DetalhesForm
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
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkListaUnidades = new System.Windows.Forms.CheckedListBox();
            this.btnAtribuir = new System.Windows.Forms.Button();
            this.btnRecomendacoes = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReconhecer = new System.Windows.Forms.Button();
            this.txtCidadeEM = new System.Windows.Forms.TextBox();
            this.txtCEPEM = new System.Windows.Forms.TextBox();
            this.txtNumeroEM = new System.Windows.Forms.TextBox();
            this.txtRuaEM = new System.Windows.Forms.TextBox();
            this.cmbStatusEM = new System.Windows.Forms.ComboBox();
            this.txtIdEM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmergencia = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlPrincipal.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.panel2);
            this.pnlPrincipal.Controls.Add(this.panel1);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1737, 850);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkListaUnidades);
            this.panel2.Controls.Add(this.btnAtribuir);
            this.panel2.Controls.Add(this.btnRecomendacoes);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1227, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(507, 847);
            this.panel2.TabIndex = 14;
            // 
            // chkListaUnidades
            // 
            this.chkListaUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListaUnidades.FormattingEnabled = true;
            this.chkListaUnidades.Location = new System.Drawing.Point(15, 143);
            this.chkListaUnidades.Name = "chkListaUnidades";
            this.chkListaUnidades.Size = new System.Drawing.Size(482, 631);
            this.chkListaUnidades.TabIndex = 18;
            // 
            // btnAtribuir
            // 
            this.btnAtribuir.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtribuir.Location = new System.Drawing.Point(15, 800);
            this.btnAtribuir.Name = "btnAtribuir";
            this.btnAtribuir.Size = new System.Drawing.Size(238, 42);
            this.btnAtribuir.TabIndex = 17;
            this.btnAtribuir.Text = "Atribuir";
            this.btnAtribuir.UseVisualStyleBackColor = true;
            // 
            // btnRecomendacoes
            // 
            this.btnRecomendacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecomendacoes.Location = new System.Drawing.Point(42, 71);
            this.btnRecomendacoes.Name = "btnRecomendacoes";
            this.btnRecomendacoes.Size = new System.Drawing.Size(436, 42);
            this.btnRecomendacoes.TabIndex = 14;
            this.btnRecomendacoes.Text = "✨ Aplicar recomendação";
            this.btnRecomendacoes.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 33);
            this.label6.TabIndex = 13;
            this.label6.Text = "Unidades";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnReconhecer);
            this.panel1.Controls.Add(this.txtCidadeEM);
            this.panel1.Controls.Add(this.txtCEPEM);
            this.panel1.Controls.Add(this.txtNumeroEM);
            this.panel1.Controls.Add(this.txtRuaEM);
            this.panel1.Controls.Add(this.cmbStatusEM);
            this.panel1.Controls.Add(this.txtIdEM);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblEmergencia);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 847);
            this.panel1.TabIndex = 13;
            // 
            // btnReconhecer
            // 
            this.btnReconhecer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReconhecer.Location = new System.Drawing.Point(756, 99);
            this.btnReconhecer.Name = "btnReconhecer";
            this.btnReconhecer.Size = new System.Drawing.Size(238, 42);
            this.btnReconhecer.TabIndex = 17;
            this.btnReconhecer.Text = "Reconhecer";
            this.btnReconhecer.UseVisualStyleBackColor = true;
            // 
            // txtCidadeEM
            // 
            this.txtCidadeEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCidadeEM.Location = new System.Drawing.Point(210, 289);
            this.txtCidadeEM.Name = "txtCidadeEM";
            this.txtCidadeEM.Size = new System.Drawing.Size(540, 31);
            this.txtCidadeEM.TabIndex = 12;
            // 
            // txtCEPEM
            // 
            this.txtCEPEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCEPEM.Location = new System.Drawing.Point(210, 243);
            this.txtCEPEM.Name = "txtCEPEM";
            this.txtCEPEM.Size = new System.Drawing.Size(540, 31);
            this.txtCEPEM.TabIndex = 11;
            // 
            // txtNumeroEM
            // 
            this.txtNumeroEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroEM.Location = new System.Drawing.Point(568, 200);
            this.txtNumeroEM.Name = "txtNumeroEM";
            this.txtNumeroEM.Size = new System.Drawing.Size(182, 31);
            this.txtNumeroEM.TabIndex = 10;
            // 
            // txtRuaEM
            // 
            this.txtRuaEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuaEM.Location = new System.Drawing.Point(210, 200);
            this.txtRuaEM.Name = "txtRuaEM";
            this.txtRuaEM.Size = new System.Drawing.Size(342, 31);
            this.txtRuaEM.TabIndex = 9;
            // 
            // cmbStatusEM
            // 
            this.cmbStatusEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusEM.FormattingEnabled = true;
            this.cmbStatusEM.Location = new System.Drawing.Point(206, 108);
            this.cmbStatusEM.Name = "cmbStatusEM";
            this.cmbStatusEM.Size = new System.Drawing.Size(544, 33);
            this.cmbStatusEM.TabIndex = 8;
            // 
            // txtIdEM
            // 
            this.txtIdEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdEM.Location = new System.Drawing.Point(206, 71);
            this.txtIdEM.Name = "txtIdEM";
            this.txtIdEM.Size = new System.Drawing.Size(544, 31);
            this.txtIdEM.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(100, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 31);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(130, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "CEP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rua + nº";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status da EM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID da EM";
            // 
            // lblEmergencia
            // 
            this.lblEmergencia.AutoSize = true;
            this.lblEmergencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmergencia.Location = new System.Drawing.Point(23, 20);
            this.lblEmergencia.Name = "lblEmergencia";
            this.lblEmergencia.Size = new System.Drawing.Size(181, 33);
            this.lblEmergencia.TabIndex = 1;
            this.lblEmergencia.Text = "Emergência";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(1487, 889);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(238, 42);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(1243, 889);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(238, 42);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // DetalhesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1737, 943);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.pnlPrincipal);
            this.Name = "DetalhesForm";
            this.Text = "DetalhesForm";
            this.pnlPrincipal.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Label lblEmergencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdEM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCidadeEM;
        private System.Windows.Forms.TextBox txtCEPEM;
        private System.Windows.Forms.TextBox txtNumeroEM;
        private System.Windows.Forms.TextBox txtRuaEM;
        private System.Windows.Forms.ComboBox cmbStatusEM;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRecomendacoes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnReconhecer;
        private System.Windows.Forms.Button btnAtribuir;
        private System.Windows.Forms.CheckedListBox chkListaUnidades;
    }
}