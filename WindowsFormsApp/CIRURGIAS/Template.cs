using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.CIRURGIAS
{
    public partial class Template : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static int operation, id, fornecedorId;
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
                    this.Text = @"Cadastrar Nova Cirurgia";
                    gbDadosFornecedores.Enabled = false;
                    break;

                case 2:
                    this.Text = @"Editar Dados da Cirurgia";
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
                    if (VerifyInfo() && Duplicate())
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
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informar o nome da cirurgia", "Nome", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCID.Text))
            {
                MessageBox.Show("Informar o CID da cirurgia", "CID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCID.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTUSS.Text))
            {
                MessageBox.Show("Informar o TUSS da cirurgia", "TUSS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTUSS.Focus();
                return false;
            }

            return true;
        }

        private bool Duplicate()
        {
            var datas = from a in db.Cirurgias
                        where a.CID.Equals(txtCID.Text) && a.TUS.Equals(txtTUSS.Text)
                        select a;

            if (datas.Any())
            {
                MessageBox.Show("Já existem uma cirurgia cadastrada com este CID e TUSS", "Duplicação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void Create()
        {
            try
            {
                Cirurgia cirurgias = new Cirurgia();
                cirurgias.Nome = txtNome.Text;
                cirurgias.CID = txtCID.Text;
                cirurgias.TUS = txtTUSS.Text;
                cirurgias.Justificativa = txtJustificativa.Text;
                cirurgias.Materiais = txtMateriais.Text;
                cirurgias.CreatedAt = DateTime.Now;
                cirurgias.UpdatedAt = DateTime.Now;

                db.Cirurgias.InsertOnSubmit(cirurgias);
                db.SubmitChanges();

                MessageBox.Show("Cirurgia cadastrada com sucesso!!!", "Cadastro Cirurgia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInfo()
        {
            var datas = (from a in db.Cirurgias where a.id.Equals(id) select a).FirstOrDefault();

            txtNome.Text = datas.Nome;
            txtCID.Text = datas.CID;
            txtTUSS.Text = datas.TUS;
            txtJustificativa.Text = datas.Justificativa;
            txtMateriais.Text = datas.Materiais;

            LoadDataGridView();
        }

        private void Update(int idCirurgia)
        {
            try
            {
                Cirurgia cirurgias = (from a in db.Cirurgias where a.id.Equals(idCirurgia) select a).FirstOrDefault();
                cirurgias.Nome = txtNome.Text;
                cirurgias.CID = txtCID.Text;
                cirurgias.TUS = txtTUSS.Text;
                cirurgias.Justificativa = txtJustificativa.Text;
                cirurgias.Materiais = txtMateriais.Text;
                cirurgias.UpdatedAt = DateTime.Now;

                db.SubmitChanges();

                MessageBox.Show("Dados atualizado com sucesso!!!", "Atualização Cirurgia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deletarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dataGridView.CurrentRow.Cells[0].Value;
            string NOME = dataGridView.CurrentRow.Cells[1].Value.ToString();

            DialogResult result = MessageBox.Show("Você relamente deseja deletar o fornecedor abaixo \n\n" +
                                                    "Nome: " + NOME, "Deletar Fornecedor",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result.Equals(DialogResult.Yes))
            {
                CirurgiaFornecedor item = (from a in db.CirurgiaFornecedors where a.id.Equals(ID) select a).FirstOrDefault();

                db.CirurgiaFornecedors.DeleteOnSubmit(item);

                db.SubmitChanges();

                MessageBox.Show("Fornecedor deletado com suceosso!", "Deletar Forncedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView();
            }
        }

        private void btAddHospital_Click(object sender, EventArgs e)
        {
            using (FORNECEDORES.List form = new FORNECEDORES.List())
            {
                fornecedorId = 0;
                FORNECEDORES.List.addFornecedor = true;
                form.ShowDialog();
            }

            if (fornecedorId > 0)
            {
                var datas = from a in db.CirurgiaFornecedors
                            where a.CirurgiaId.Equals(id) && a.FornecedorId.Equals(fornecedorId)
                            select a;

                if (!datas.Any())
                {
                    try
                    {
                        CirurgiaFornecedor item = new CirurgiaFornecedor();
                        item.CirurgiaId = id;
                        item.FornecedorId = fornecedorId;
                        item.CreatedAt = DateTime.Now;
                        item.UpdatedAt = DateTime.Now;

                        db.CirurgiaFornecedors.InsertOnSubmit(item);
                        db.SubmitChanges();

                        LoadDataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadDataGridView()
        {
            dataGridView.Rows.Clear();

            var datas = from a in db.CirurgiaFornecedors
                        where a.CirurgiaId.Equals(id)
                        join b in db.Fornecedores on a.FornecedorId equals b.id
                        select new { a.id
                                    ,b.Nome
                                    ,b.CNPJ
                                    ,b.Endereco
                                    ,b.Cidade
                                    ,b.UF
                                    ,b.CEP
                                    ,b.Contato
                                    ,b.Telefone
                                    ,b.Email};

            foreach (var data in datas)
            {
                dataGridView.Rows.Add(data.id
                                    , data.Nome
                                    , data.CNPJ
                                    , data.Endereco
                                    , data.Cidade
                                    , data.UF
                                    , data.CEP
                                    , data.Contato
                                    , data.Telefone
                                    , data.Email);
            }
        }
    }
}
