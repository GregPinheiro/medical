
namespace WindowsFormsApp
{
    partial class Form1
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mudarUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trocarSenhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreF1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairAltF4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarDadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.médicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarNovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarMédicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hospitaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarNovoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarHospitaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convêniosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarNovoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.gerênciasConvêniosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarNovoToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarFornecedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarNovaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cirurgiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarNovaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarCirurgiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pacientesToolStripMenuItem,
            this.médicosToolStripMenuItem,
            this.hospitaisToolStripMenuItem,
            this.convêniosToolStripMenuItem,
            this.fornecedoresToolStripMenuItem,
            this.cirurgiasToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mudarUsuárioToolStripMenuItem,
            this.trocarSenhaToolStripMenuItem,
            this.sobreF1ToolStripMenuItem,
            this.sairAltF4ToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mudarUsuárioToolStripMenuItem
            // 
            this.mudarUsuárioToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mudarUsuárioToolStripMenuItem.Name = "mudarUsuárioToolStripMenuItem";
            this.mudarUsuárioToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.mudarUsuárioToolStripMenuItem.Text = "Mudar Usuário";
            this.mudarUsuárioToolStripMenuItem.Click += new System.EventHandler(this.mudarUsuárioToolStripMenuItem_Click);
            // 
            // trocarSenhaToolStripMenuItem
            // 
            this.trocarSenhaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trocarSenhaToolStripMenuItem.Name = "trocarSenhaToolStripMenuItem";
            this.trocarSenhaToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.trocarSenhaToolStripMenuItem.Text = "Trocar Senha";
            // 
            // sobreF1ToolStripMenuItem
            // 
            this.sobreF1ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sobreF1ToolStripMenuItem.Name = "sobreF1ToolStripMenuItem";
            this.sobreF1ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.sobreF1ToolStripMenuItem.Text = "Sobre (F1)";
            // 
            // sairAltF4ToolStripMenuItem
            // 
            this.sairAltF4ToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sairAltF4ToolStripMenuItem.Name = "sairAltF4ToolStripMenuItem";
            this.sairAltF4ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.sairAltF4ToolStripMenuItem.Text = "Sair (Alt + F4)";
            // 
            // pacientesToolStripMenuItem
            // 
            this.pacientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.editarDadosToolStripMenuItem});
            this.pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            this.pacientesToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.pacientesToolStripMenuItem.Text = "Pacientes";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.cadastrarToolStripMenuItem.Text = "Cadastrar Novo";
            this.cadastrarToolStripMenuItem.Click += new System.EventHandler(this.cadastrarToolStripMenuItem_Click);
            // 
            // editarDadosToolStripMenuItem
            // 
            this.editarDadosToolStripMenuItem.Name = "editarDadosToolStripMenuItem";
            this.editarDadosToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.editarDadosToolStripMenuItem.Text = "Gerenciar Pacientes";
            this.editarDadosToolStripMenuItem.Click += new System.EventHandler(this.editarDadosToolStripMenuItem_Click);
            // 
            // médicosToolStripMenuItem
            // 
            this.médicosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarNovoToolStripMenuItem,
            this.gerenciarMédicosToolStripMenuItem});
            this.médicosToolStripMenuItem.Name = "médicosToolStripMenuItem";
            this.médicosToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.médicosToolStripMenuItem.Text = "Médicos";
            // 
            // cadastrarNovoToolStripMenuItem
            // 
            this.cadastrarNovoToolStripMenuItem.Name = "cadastrarNovoToolStripMenuItem";
            this.cadastrarNovoToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.cadastrarNovoToolStripMenuItem.Text = "Cadastrar Novo";
            this.cadastrarNovoToolStripMenuItem.Click += new System.EventHandler(this.cadastrarNovoToolStripMenuItem_Click);
            // 
            // gerenciarMédicosToolStripMenuItem
            // 
            this.gerenciarMédicosToolStripMenuItem.Name = "gerenciarMédicosToolStripMenuItem";
            this.gerenciarMédicosToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.gerenciarMédicosToolStripMenuItem.Text = "Gerenciar Médicos";
            this.gerenciarMédicosToolStripMenuItem.Click += new System.EventHandler(this.gerenciarMédicosToolStripMenuItem_Click);
            // 
            // hospitaisToolStripMenuItem
            // 
            this.hospitaisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarNovoToolStripMenuItem1,
            this.gerenciarHospitaisToolStripMenuItem});
            this.hospitaisToolStripMenuItem.Name = "hospitaisToolStripMenuItem";
            this.hospitaisToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.hospitaisToolStripMenuItem.Text = "Hospitais";
            // 
            // cadastrarNovoToolStripMenuItem1
            // 
            this.cadastrarNovoToolStripMenuItem1.Name = "cadastrarNovoToolStripMenuItem1";
            this.cadastrarNovoToolStripMenuItem1.Size = new System.Drawing.Size(207, 24);
            this.cadastrarNovoToolStripMenuItem1.Text = "Cadastrar Novo";
            this.cadastrarNovoToolStripMenuItem1.Click += new System.EventHandler(this.cadastrarNovoToolStripMenuItem1_Click);
            // 
            // gerenciarHospitaisToolStripMenuItem
            // 
            this.gerenciarHospitaisToolStripMenuItem.Name = "gerenciarHospitaisToolStripMenuItem";
            this.gerenciarHospitaisToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.gerenciarHospitaisToolStripMenuItem.Text = "Gerenciar Hospitais";
            this.gerenciarHospitaisToolStripMenuItem.Click += new System.EventHandler(this.gerenciarHospitaisToolStripMenuItem_Click);
            // 
            // convêniosToolStripMenuItem
            // 
            this.convêniosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarNovoToolStripMenuItem2,
            this.gerênciasConvêniosToolStripMenuItem});
            this.convêniosToolStripMenuItem.Name = "convêniosToolStripMenuItem";
            this.convêniosToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.convêniosToolStripMenuItem.Text = "Convênios";
            // 
            // cadastrarNovoToolStripMenuItem2
            // 
            this.cadastrarNovoToolStripMenuItem2.Name = "cadastrarNovoToolStripMenuItem2";
            this.cadastrarNovoToolStripMenuItem2.Size = new System.Drawing.Size(214, 24);
            this.cadastrarNovoToolStripMenuItem2.Text = "Cadastrar Novo";
            this.cadastrarNovoToolStripMenuItem2.Click += new System.EventHandler(this.cadastrarNovoToolStripMenuItem2_Click);
            // 
            // gerênciasConvêniosToolStripMenuItem
            // 
            this.gerênciasConvêniosToolStripMenuItem.Name = "gerênciasConvêniosToolStripMenuItem";
            this.gerênciasConvêniosToolStripMenuItem.Size = new System.Drawing.Size(214, 24);
            this.gerênciasConvêniosToolStripMenuItem.Text = "Gerências Convênios";
            this.gerênciasConvêniosToolStripMenuItem.Click += new System.EventHandler(this.gerênciasConvêniosToolStripMenuItem_Click);
            // 
            // fornecedoresToolStripMenuItem
            // 
            this.fornecedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarNovoToolStripMenuItem3,
            this.gerenciarFornecedoresToolStripMenuItem});
            this.fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            this.fornecedoresToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.fornecedoresToolStripMenuItem.Text = "Fornecedores";
            // 
            // cadastrarNovoToolStripMenuItem3
            // 
            this.cadastrarNovoToolStripMenuItem3.Name = "cadastrarNovoToolStripMenuItem3";
            this.cadastrarNovoToolStripMenuItem3.Size = new System.Drawing.Size(234, 24);
            this.cadastrarNovoToolStripMenuItem3.Text = "Cadastrar Novo";
            this.cadastrarNovoToolStripMenuItem3.Click += new System.EventHandler(this.cadastrarNovoToolStripMenuItem3_Click);
            // 
            // gerenciarFornecedoresToolStripMenuItem
            // 
            this.gerenciarFornecedoresToolStripMenuItem.Name = "gerenciarFornecedoresToolStripMenuItem";
            this.gerenciarFornecedoresToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.gerenciarFornecedoresToolStripMenuItem.Text = "Gerenciar Fornecedores";
            this.gerenciarFornecedoresToolStripMenuItem.Click += new System.EventHandler(this.gerenciarFornecedoresToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarNovaToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // cadastrarNovaToolStripMenuItem
            // 
            this.cadastrarNovaToolStripMenuItem.Name = "cadastrarNovaToolStripMenuItem";
            this.cadastrarNovaToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.cadastrarNovaToolStripMenuItem.Text = "Cadastrar Nova";
            this.cadastrarNovaToolStripMenuItem.Click += new System.EventHandler(this.cadastrarNovaToolStripMenuItem_Click);
            // 
            // cirurgiasToolStripMenuItem
            // 
            this.cirurgiasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarNovaToolStripMenuItem1,
            this.gerenciarCirurgiasToolStripMenuItem});
            this.cirurgiasToolStripMenuItem.Name = "cirurgiasToolStripMenuItem";
            this.cirurgiasToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.cirurgiasToolStripMenuItem.Text = "Cirurgias";
            // 
            // cadastrarNovaToolStripMenuItem1
            // 
            this.cadastrarNovaToolStripMenuItem1.Name = "cadastrarNovaToolStripMenuItem1";
            this.cadastrarNovaToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.cadastrarNovaToolStripMenuItem1.Text = "Cadastrar Nova";
            this.cadastrarNovaToolStripMenuItem1.Click += new System.EventHandler(this.cadastrarNovaToolStripMenuItem1_Click);
            // 
            // gerenciarCirurgiasToolStripMenuItem
            // 
            this.gerenciarCirurgiasToolStripMenuItem.Name = "gerenciarCirurgiasToolStripMenuItem";
            this.gerenciarCirurgiasToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.gerenciarCirurgiasToolStripMenuItem.Text = "Gerenciar Cirurgias";
            this.gerenciarCirurgiasToolStripMenuItem.Click += new System.EventHandler(this.gerenciarCirurgiasToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mudarUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trocarSenhaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreF1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairAltF4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarDadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem médicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarNovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciarMédicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hospitaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarNovoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gerenciarHospitaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convêniosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarNovoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem gerênciasConvêniosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarNovoToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem gerenciarFornecedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarNovaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cirurgiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarNovaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gerenciarCirurgiasToolStripMenuItem;
    }
}

