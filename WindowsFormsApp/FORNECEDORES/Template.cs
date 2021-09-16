using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.FORNECEDORES
{
    public partial class Template : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static int operation, id;

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
                    this.Text = @"Cadastrar Novo Forncedor";
                    break;

                case 2:
                    this.Text = @"Editar Dados do Fornecedor";
                    LoadInfo();
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
                    if (VerifyInfo() && Duplicate(txtCNPJ.Text))
                    {
                        Create();
                    }
                    break;

                case 2:
                    if (VerifyInfo())
                    {
                        Update(id);
                    }
                    break;

                default:
                    this.Close();
                    break;
            }
        }

        private bool VerifyInfo()
        {
            if (string.IsNullOrEmpty(txtCNPJ.Text))
            {
                MessageBox.Show("Informe o CNPJ da empresa para cadastro", "CNPJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCNPJ.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o nome da empresa para cadastro", "NOME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return false;
            }

            return true;
        }

        private bool Duplicate(string cnpj)
        {
            var datas = from a in db.Fornecedores where a.CNPJ.Equals(cnpj) select a;

            if (datas.Any())
            {
                MessageBox.Show("Já existem um fornecedor cadastrado com este CNPJ", "CNPJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCNPJ.Focus();
                return false;
            }

            return true;
        }

        private void Create()
        {
            try
            {
                Fornecedore fornecedores = new Fornecedore();
                fornecedores.Nome = txtNome.Text;
                fornecedores.CNPJ = txtCNPJ.Text;
                fornecedores.Endereco = txtEndereo.Text;
                fornecedores.Cidade = txtCidade.Text;
                fornecedores.UF = txtUF.Text;
                fornecedores.CEP = txtCEP.Text;
                fornecedores.Contato = txtContato1.Text;
                fornecedores.Telefone = txtTelefone1.Text;
                fornecedores.Email = txtEmail1.Text;
                fornecedores.CreatedAt = DateTime.Now;
                fornecedores.UpdatedAt = DateTime.Now;

                db.Fornecedores.InsertOnSubmit(fornecedores);
                db.SubmitChanges();

                MessageBox.Show("Fornecedor cadastrado com sucesso!!!", "Cadastro de Fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInfo()
        {
            var datas = (from a in db.Fornecedores where a.id.Equals(id) select a).FirstOrDefault();

            txtNome.Text = datas.Nome;
            txtCNPJ.Text = datas.CNPJ;
            txtEndereo.Text = datas.Endereco;
            txtCidade.Text = datas.Cidade;
            txtUF.Text = datas.UF;
            txtCEP.Text = datas.CEP;
            txtContato1.Text = datas.Contato;
            txtTelefone1.Text = datas.Telefone;
            txtEmail1.Text = datas.Email;
        }

        private void Update(int idFornecedor)
        {
            try
            {
                Fornecedore fornecedores = (from a in db.Fornecedores where a.id.Equals(idFornecedor) select a).FirstOrDefault();
                fornecedores.Nome = txtNome.Text;
                fornecedores.CNPJ = txtCNPJ.Text;
                fornecedores.Endereco = txtEndereo.Text;
                fornecedores.Cidade = txtCidade.Text;
                fornecedores.UF = txtUF.Text;
                fornecedores.CEP = txtCEP.Text;
                fornecedores.Contato = txtContato1.Text;
                fornecedores.Telefone = txtTelefone1.Text;
                fornecedores.Email = txtEmail1.Text;
                fornecedores.UpdatedAt = DateTime.Now;

                db.SubmitChanges();

                MessageBox.Show("Fornecedor Atualizado com sucesso!!!", "Atualização de Fornecedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
