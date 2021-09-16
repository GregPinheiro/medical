using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.PACIENTES
{
    public partial class Template : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static int operation, id;
        public static int convenioId, medicoId;
        public static string conenioName, planoName, medicoName;
        public Template()
        {
            InitializeComponent();

            db.Connection.ConnectionString = GlobalVariable.connectionString;
        }

        private void Template_Load(object sender, EventArgs e)
        {
            switch (operation)
            {
                case 1:
                    this.Text = @"Cadastro de Usuário";
                    medicoId = convenioId = 0;
                    break;

                case 2:
                    this.Text = @"Editar Dados do Usuário";
                    loadInfo(id);
                    break;

                default:
                    this.Close();
                    break;
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case 1:
                    if (verifyInfo() && duplicateCPF(txtCPF.Text))
                    {
                        Create();
                    }
                    break;

                case 2:
                    if (verifyInfo())
                    {
                        Update(id);
                    }
                    break;

                default:
                    MessageBox.Show("Erro no processamento dos dados!!! Está operação será finalizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }

        private void btMedico_Click(object sender, EventArgs e)
        {
            using (MEDICOS.List form = new MEDICOS.List())
            {
                MEDICOS.List.search = true;
                form.ShowDialog();
            }

            LoadMedicoInfo(medicoId);
        }

        private bool verifyInfo()
        {
            if (string.IsNullOrEmpty(txtCPF.Text) || txtCPF.Text.Length < 11)
            {
                MessageBox.Show("Informe o CPF do paciente", "CPF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCPF.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do paciente", "Nome do Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return false;
            }

            if (convenioId.Equals(0))
            {
                MessageBox.Show("Selecione o convênio do paciente", "Convênio do Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btConvenio.Focus();
                return false;
            }

            if (medicoId.Equals(0))
            {
                MessageBox.Show("Selecione o médico do paciente", "Médico do Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btMedico.Focus();
                return false;
            }

            return true;
        }

        private bool duplicateCPF(string cpf)
        {
            var datas = from a in db.Pacientes where a.CPF.Equals(cpf) select a;

            if (datas.Any())
            {
                MessageBox.Show("Já existem um paciente cadastrado com este número de CPF!!! \n\n" +
                                "CPF: " + datas.FirstOrDefault().CPF + "\n\n" +
                                "Nome: " + datas.FirstOrDefault().Nome, "Cadastro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCPF.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btConvenio_Click(object sender, EventArgs e)
        {
            using (CONVENIOS.List form = new CONVENIOS.List())
            {
                CONVENIOS.List.searchConvenio = true;
                form.ShowDialog();                
            }

            loadConvenioInfo(convenioId);
        }

        private void Create()
        {    
            try
            {
                Paciente paciente = new Paciente();
                paciente.CPF = txtCPF.Text;
                paciente.Nome = txtNome.Text;
                paciente.DataNasc = dtNascimento.Value;
                paciente.Endereco = txtEndereco.Text;
                paciente.Cidade = txtCidade.Text;
                paciente.UF = txtUF.Text;
                paciente.Telefone = txtTelefone.Text;
                paciente.Celular = txtCelular.Text;
                paciente.Email = txtEmail.Text;
                paciente.ConvenioId = (int)convenioId;
                paciente.NoCarteirinha = txtCarteirinha.Text;
                paciente.Validade = dtValidade.Value;
                paciente.Login = txtLogin.Text;
                paciente.Senha = txtSenha.Text;
                paciente.MedicoId = (int)medicoId;
                paciente.obs = txtObs.Text;
                paciente.createdAt = DateTime.Now;
                paciente.updatedAt = DateTime.Now;

                db.Pacientes.InsertOnSubmit(paciente);
                db.SubmitChanges();

                MessageBox.Show("Paciente cadastrado com sucesso!!!", "Cadastro de Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void loadInfo(int idPaciente)
        {
            var datas = (from a in db.Pacientes 
                         where a.id.Equals(idPaciente) 
                         select a).FirstOrDefault();

            txtCPF.Text = datas.CPF;
            txtNome.Text = datas.Nome;
            DateTime dt = new DateTime(datas.DataNasc.Value.Year, datas.DataNasc.Value.Month, datas.DataNasc.Value.Day, 0, 0, 0);
            dtNascimento.Value = dt;
            txtEndereco.Text = datas.Endereco;
            txtCidade.Text = datas.Cidade;
            txtUF.Text = datas.UF;
            txtTelefone.Text = datas.Telefone;
            txtCelular.Text = datas.Celular;
            txtEmail.Text = datas.Email;
            convenioId = datas.ConvenioId;
            txtCarteirinha.Text = datas.NoCarteirinha;
            txtLogin.Text = datas.Login;
            txtSenha.Text = datas.Senha;
            dt = new DateTime(datas.Inclusao.Value.Year, datas.Inclusao.Value.Month, datas.Inclusao.Value.Day, 0, 0, 0);
            dtInclusao.Value = dt;
            dt = new DateTime(datas.Validade.Value.Year, datas.Validade.Value.Month, datas.Validade.Value.Day, 0, 0, 0);
            dtValidade.Value = dt;
            medicoId = datas.MedicoId;
            txtObs.Text = datas.obs;

            LoadMedicoInfo(medicoId);

            loadConvenioInfo(convenioId);
        }

        private void loadConvenioInfo(int convenioId)
        {
            var datas = from a in db.Convenios where a.id.Equals(convenioId) select a;

            foreach (var data in datas)
            {
                txtConvenio.Text = data.Nome;
                txtPlano.Text = data.Plano;
            }
        }

        private void LoadMedicoInfo(int idMedico)
        {
            if (idMedico > 0)
            {
                var datas = (from a in db.Medicos where a.id.Equals(idMedico) select a).FirstOrDefault();

                txtMedico.Text = datas.Nome;
                txtEspecialidade.Text = datas.Especialidade;
                txtCRO_CRM.Text = datas.CRO_CRM;
            }
        }

        private void Update(int idPaciente)
        {
            try
            {
                Paciente paciente = (from a in db.Pacientes where a.id.Equals(idPaciente) select a).FirstOrDefault();
                paciente.CPF = txtCPF.Text;
                paciente.Nome = txtNome.Text;
                paciente.DataNasc = dtNascimento.Value;
                paciente.Endereco = txtEndereco.Text;
                paciente.Cidade = txtCidade.Text;
                paciente.UF = txtUF.Text;
                paciente.Telefone = txtTelefone.Text;
                paciente.Celular = txtCelular.Text;
                paciente.Email = txtEmail.Text;
                paciente.ConvenioId = (int)convenioId;
                paciente.NoCarteirinha = txtCarteirinha.Text;
                paciente.Validade = dtValidade.Value;
                paciente.Login = txtLogin.Text;
                paciente.Senha = txtSenha.Text;
                paciente.MedicoId = (int)medicoId;
                paciente.obs = txtObs.Text;
                paciente.updatedAt = DateTime.Now;

                db.SubmitChanges();

                MessageBox.Show("Paciente atualizado com sucesso!!!", "Editar Paciente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
