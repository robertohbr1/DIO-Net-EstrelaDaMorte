
namespace ControleAcesso.Forms
{
    partial class frmControleNaves
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
            this.txtNomeNave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomePiloto = new System.Windows.Forms.TextBox();
            this.dgvNaves = new System.Windows.Forms.DataGridView();
            this.dgvPilotos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbSaindo = new System.Windows.Forms.RadioButton();
            this.rdbChegando = new System.Windows.Forms.RadioButton();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.btnBuscarNave = new System.Windows.Forms.Button();
            this.btnBuscarPiloto = new System.Windows.Forms.Button();
            this.btnBuscarOrigem = new System.Windows.Forms.Button();
            this.dgvPlanetaOrigem = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlanetaOrigem = new System.Windows.Forms.TextBox();
            this.btnBuscarDestino = new System.Windows.Forms.Button();
            this.dgvPlanetaDestino = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlanetaDestino = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPilotos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanetaOrigem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanetaDestino)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomeNave
            // 
            this.txtNomeNave.Location = new System.Drawing.Point(56, 12);
            this.txtNomeNave.Name = "txtNomeNave";
            this.txtNomeNave.Size = new System.Drawing.Size(620, 23);
            this.txtNomeNave.TabIndex = 0;
            this.txtNomeNave.Leave += new System.EventHandler(this.txtNomeNave_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nave:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Piloto:";
            // 
            // txtNomePiloto
            // 
            this.txtNomePiloto.Location = new System.Drawing.Point(56, 157);
            this.txtNomePiloto.Name = "txtNomePiloto";
            this.txtNomePiloto.Size = new System.Drawing.Size(620, 23);
            this.txtNomePiloto.TabIndex = 2;
            this.txtNomePiloto.Leave += new System.EventHandler(this.txtNomePiloto_Leave);
            // 
            // dgvNaves
            // 
            this.dgvNaves.AllowUserToAddRows = false;
            this.dgvNaves.AllowUserToDeleteRows = false;
            this.dgvNaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNaves.Location = new System.Drawing.Point(56, 41);
            this.dgvNaves.Name = "dgvNaves";
            this.dgvNaves.RowTemplate.Height = 25;
            this.dgvNaves.Size = new System.Drawing.Size(693, 109);
            this.dgvNaves.TabIndex = 4;
            // 
            // dgvPilotos
            // 
            this.dgvPilotos.AllowUserToAddRows = false;
            this.dgvPilotos.AllowUserToDeleteRows = false;
            this.dgvPilotos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPilotos.Location = new System.Drawing.Point(56, 186);
            this.dgvPilotos.Name = "dgvPilotos";
            this.dgvPilotos.RowTemplate.Height = 25;
            this.dgvPilotos.Size = new System.Drawing.Size(693, 109);
            this.dgvPilotos.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbSaindo);
            this.groupBox1.Controls.Add(this.rdbChegando);
            this.groupBox1.Location = new System.Drawing.Point(51, 587);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 37);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rdbSaindo
            // 
            this.rdbSaindo.AutoSize = true;
            this.rdbSaindo.Location = new System.Drawing.Point(171, 12);
            this.rdbSaindo.Name = "rdbSaindo";
            this.rdbSaindo.Size = new System.Drawing.Size(61, 19);
            this.rdbSaindo.TabIndex = 1;
            this.rdbSaindo.TabStop = true;
            this.rdbSaindo.Text = "Saindo";
            this.rdbSaindo.UseVisualStyleBackColor = true;
            // 
            // rdbChegando
            // 
            this.rdbChegando.AutoSize = true;
            this.rdbChegando.Location = new System.Drawing.Point(21, 12);
            this.rdbChegando.Name = "rdbChegando";
            this.rdbChegando.Size = new System.Drawing.Size(80, 19);
            this.rdbChegando.TabIndex = 0;
            this.rdbChegando.TabStop = true;
            this.rdbChegando.Text = "Chegando";
            this.rdbChegando.UseVisualStyleBackColor = true;
            // 
            // btnAvancar
            // 
            this.btnAvancar.Location = new System.Drawing.Point(646, 597);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(75, 23);
            this.btnAvancar.TabIndex = 7;
            this.btnAvancar.Text = "Avançar";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // btnBuscarNave
            // 
            this.btnBuscarNave.Location = new System.Drawing.Point(682, 11);
            this.btnBuscarNave.Name = "btnBuscarNave";
            this.btnBuscarNave.Size = new System.Drawing.Size(67, 23);
            this.btnBuscarNave.TabIndex = 8;
            this.btnBuscarNave.Text = "Buscar";
            this.btnBuscarNave.UseVisualStyleBackColor = true;
            this.btnBuscarNave.Click += new System.EventHandler(this.btnBuscarNave_Click);
            // 
            // btnBuscarPiloto
            // 
            this.btnBuscarPiloto.Location = new System.Drawing.Point(682, 156);
            this.btnBuscarPiloto.Name = "btnBuscarPiloto";
            this.btnBuscarPiloto.Size = new System.Drawing.Size(67, 23);
            this.btnBuscarPiloto.TabIndex = 9;
            this.btnBuscarPiloto.Text = "Buscar";
            this.btnBuscarPiloto.UseVisualStyleBackColor = true;
            this.btnBuscarPiloto.Click += new System.EventHandler(this.btnBuscarPiloto_Click);
            // 
            // btnBuscarOrigem
            // 
            this.btnBuscarOrigem.Location = new System.Drawing.Point(682, 300);
            this.btnBuscarOrigem.Name = "btnBuscarOrigem";
            this.btnBuscarOrigem.Size = new System.Drawing.Size(67, 23);
            this.btnBuscarOrigem.TabIndex = 13;
            this.btnBuscarOrigem.Text = "Buscar";
            this.btnBuscarOrigem.UseVisualStyleBackColor = true;
            this.btnBuscarOrigem.Click += new System.EventHandler(this.btnBuscarOrigem_Click);
            // 
            // dgvPlanetaOrigem
            // 
            this.dgvPlanetaOrigem.AllowUserToAddRows = false;
            this.dgvPlanetaOrigem.AllowUserToDeleteRows = false;
            this.dgvPlanetaOrigem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanetaOrigem.Location = new System.Drawing.Point(56, 330);
            this.dgvPlanetaOrigem.Name = "dgvPlanetaOrigem";
            this.dgvPlanetaOrigem.RowTemplate.Height = 25;
            this.dgvPlanetaOrigem.Size = new System.Drawing.Size(693, 109);
            this.dgvPlanetaOrigem.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Origem:";
            // 
            // txtPlanetaOrigem
            // 
            this.txtPlanetaOrigem.Location = new System.Drawing.Point(56, 301);
            this.txtPlanetaOrigem.Name = "txtPlanetaOrigem";
            this.txtPlanetaOrigem.Size = new System.Drawing.Size(620, 23);
            this.txtPlanetaOrigem.TabIndex = 10;
            this.txtPlanetaOrigem.Leave += new System.EventHandler(this.txtPlanetaOrigem_Leave);
            // 
            // btnBuscarDestino
            // 
            this.btnBuscarDestino.Location = new System.Drawing.Point(682, 442);
            this.btnBuscarDestino.Name = "btnBuscarDestino";
            this.btnBuscarDestino.Size = new System.Drawing.Size(67, 23);
            this.btnBuscarDestino.TabIndex = 17;
            this.btnBuscarDestino.Text = "Buscar";
            this.btnBuscarDestino.UseVisualStyleBackColor = true;
            this.btnBuscarDestino.Click += new System.EventHandler(this.btnBuscarDestino_Click);
            // 
            // dgvPlanetaDestino
            // 
            this.dgvPlanetaDestino.AllowUserToAddRows = false;
            this.dgvPlanetaDestino.AllowUserToDeleteRows = false;
            this.dgvPlanetaDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanetaDestino.Location = new System.Drawing.Point(56, 472);
            this.dgvPlanetaDestino.Name = "dgvPlanetaDestino";
            this.dgvPlanetaDestino.RowTemplate.Height = 25;
            this.dgvPlanetaDestino.Size = new System.Drawing.Size(693, 109);
            this.dgvPlanetaDestino.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 446);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Destino:";
            // 
            // txtPlanetaDestino
            // 
            this.txtPlanetaDestino.Location = new System.Drawing.Point(56, 443);
            this.txtPlanetaDestino.Name = "txtPlanetaDestino";
            this.txtPlanetaDestino.Size = new System.Drawing.Size(620, 23);
            this.txtPlanetaDestino.TabIndex = 14;
            this.txtPlanetaDestino.Leave += new System.EventHandler(this.txtPlanetaDestino_Leave);
            // 
            // frmControleNaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 631);
            this.Controls.Add(this.btnBuscarDestino);
            this.Controls.Add(this.dgvPlanetaDestino);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPlanetaDestino);
            this.Controls.Add(this.btnBuscarOrigem);
            this.Controls.Add(this.dgvPlanetaOrigem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPlanetaOrigem);
            this.Controls.Add(this.btnBuscarPiloto);
            this.Controls.Add(this.btnBuscarNave);
            this.Controls.Add(this.btnAvancar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPilotos);
            this.Controls.Add(this.dgvNaves);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomePiloto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeNave);
            this.Name = "frmControleNaves";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmControleNaves_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPilotos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanetaOrigem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanetaDestino)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeNave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomePiloto;
        private System.Windows.Forms.DataGridView dgvNaves;
        private System.Windows.Forms.DataGridView dgvPilotos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbSaindo;
        private System.Windows.Forms.RadioButton rdbChegando;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Button btnBuscarNave;
        private System.Windows.Forms.Button btnBuscarPiloto;
        private System.Windows.Forms.Button btnBuscarOrigem;
        private System.Windows.Forms.DataGridView dgvPlanetaOrigem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlanetaOrigem;
        private System.Windows.Forms.Button btnBuscarDestino;
        private System.Windows.Forms.DataGridView dgvPlanetaDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlanetaDestino;
    }
}