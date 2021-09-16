
namespace WindowsFormsApp.HOSPITAIS
{
    partial class List
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contato1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contato2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contato3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contato4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuEditar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuEditar.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nome,
            this.Unidade,
            this.CNPJ,
            this.Endereco,
            this.Cidade,
            this.UF,
            this.CEP,
            this.Contato1,
            this.Telefone1,
            this.Email1,
            this.Contato2,
            this.Telefone2,
            this.Email2,
            this.Contato3,
            this.Telefone3,
            this.Email3,
            this.Contato4,
            this.Telefone4,
            this.Email4,
            this.CreatedAt,
            this.UpdatedAt});
            this.dataGridView.ContextMenuStrip = this.menuEditar;
            this.dataGridView.Location = new System.Drawing.Point(0, 64);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(1226, 514);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 43;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 60;
            // 
            // Unidade
            // 
            this.Unidade.HeaderText = "Unidade";
            this.Unidade.Name = "Unidade";
            this.Unidade.ReadOnly = true;
            this.Unidade.Width = 72;
            // 
            // CNPJ
            // 
            this.CNPJ.HeaderText = "CNPJ";
            this.CNPJ.Name = "CNPJ";
            this.CNPJ.ReadOnly = true;
            this.CNPJ.Width = 59;
            // 
            // Endereco
            // 
            this.Endereco.HeaderText = "Endereço";
            this.Endereco.Name = "Endereco";
            this.Endereco.ReadOnly = true;
            this.Endereco.Width = 78;
            // 
            // Cidade
            // 
            this.Cidade.HeaderText = "Cidade";
            this.Cidade.Name = "Cidade";
            this.Cidade.ReadOnly = true;
            this.Cidade.Width = 65;
            // 
            // UF
            // 
            this.UF.HeaderText = "UF";
            this.UF.Name = "UF";
            this.UF.ReadOnly = true;
            this.UF.Width = 46;
            // 
            // CEP
            // 
            this.CEP.HeaderText = "CEP";
            this.CEP.Name = "CEP";
            this.CEP.ReadOnly = true;
            this.CEP.Width = 53;
            // 
            // Contato1
            // 
            this.Contato1.HeaderText = "Relacionamento Médico";
            this.Contato1.Name = "Contato1";
            this.Contato1.ReadOnly = true;
            this.Contato1.Width = 134;
            // 
            // Telefone1
            // 
            this.Telefone1.HeaderText = "Telefone";
            this.Telefone1.Name = "Telefone1";
            this.Telefone1.ReadOnly = true;
            this.Telefone1.Width = 74;
            // 
            // Email1
            // 
            this.Email1.HeaderText = "Email";
            this.Email1.Name = "Email1";
            this.Email1.ReadOnly = true;
            this.Email1.Width = 57;
            // 
            // Contato2
            // 
            this.Contato2.HeaderText = "Central de Reservas";
            this.Contato2.Name = "Contato2";
            this.Contato2.ReadOnly = true;
            this.Contato2.Width = 117;
            // 
            // Telefone2
            // 
            this.Telefone2.HeaderText = "Telefone";
            this.Telefone2.Name = "Telefone2";
            this.Telefone2.ReadOnly = true;
            this.Telefone2.Width = 74;
            // 
            // Email2
            // 
            this.Email2.HeaderText = "Email";
            this.Email2.Name = "Email2";
            this.Email2.ReadOnly = true;
            this.Email2.Width = 57;
            // 
            // Contato3
            // 
            this.Contato3.HeaderText = "Agendamento";
            this.Contato3.Name = "Contato3";
            this.Contato3.ReadOnly = true;
            this.Contato3.Width = 98;
            // 
            // Telefone3
            // 
            this.Telefone3.HeaderText = "Telefone";
            this.Telefone3.Name = "Telefone3";
            this.Telefone3.ReadOnly = true;
            this.Telefone3.Width = 74;
            // 
            // Email3
            // 
            this.Email3.HeaderText = "Email";
            this.Email3.Name = "Email3";
            this.Email3.ReadOnly = true;
            this.Email3.Width = 57;
            // 
            // Contato4
            // 
            this.Contato4.HeaderText = "Autorização";
            this.Contato4.Name = "Contato4";
            this.Contato4.ReadOnly = true;
            this.Contato4.Width = 88;
            // 
            // Telefone4
            // 
            this.Telefone4.HeaderText = "Telefone";
            this.Telefone4.Name = "Telefone4";
            this.Telefone4.ReadOnly = true;
            this.Telefone4.Width = 74;
            // 
            // Email4
            // 
            this.Email4.HeaderText = "Email";
            this.Email4.Name = "Email4";
            this.Email4.ReadOnly = true;
            this.Email4.Width = 57;
            // 
            // CreatedAt
            // 
            this.CreatedAt.HeaderText = "Data de Criação";
            this.CreatedAt.Name = "CreatedAt";
            this.CreatedAt.ReadOnly = true;
            // 
            // UpdatedAt
            // 
            this.UpdatedAt.HeaderText = "Data de Edição";
            this.UpdatedAt.Name = "UpdatedAt";
            this.UpdatedAt.ReadOnly = true;
            this.UpdatedAt.Width = 97;
            // 
            // menuEditar
            // 
            this.menuEditar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem});
            this.menuEditar.Name = "menuEditar";
            this.menuEditar.Size = new System.Drawing.Size(105, 26);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(94, 16);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(266, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox.Controls.Add(this.txtCNPJ);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtUnidade);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtNome);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Location = new System.Drawing.Point(12, 6);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(1201, 45);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Location = new System.Drawing.Point(900, 16);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(266, 20);
            this.txtCNPJ.TabIndex = 7;
            this.txtCNPJ.TextChanged += new System.EventHandler(this.txtCNPJ_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(860, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "CNPJ";
            // 
            // txtUnidade
            // 
            this.txtUnidade.Location = new System.Drawing.Point(485, 16);
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.Size = new System.Drawing.Size(283, 20);
            this.txtUnidade.TabIndex = 3;
            this.txtUnidade.TextChanged += new System.EventHandler(this.txtUnidade_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1227, 584);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox);
            this.KeyPreview = true;
            this.Name = "List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Hospitais";
            this.Load += new System.EventHandler(this.List_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.List_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuEditar.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ContextMenuStrip menuEditar;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox txtCNPJ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn UF;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contato1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contato2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contato3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contato4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdatedAt;
    }
}