using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.HOSPITAIS
{
    public partial class Template : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static int operation, id, convenioId;
        public Template()
        {
            InitializeComponent();

            db.Connection.ConnectionString = GlobalVariable.connectionString;
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case 1:
                    if (VerifyInfo() && DuplicateUnidade(txtNome.Text, txtUnidade.Text))
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

        private void Update(int id)
        {
            try
            {
                Hospitai hospital = (from a in db.Hospitais where a.id.Equals(id) select a).FirstOrDefault();
                hospital.Nome = txtNome.Text;
                hospital.Unidade = txtUnidade.Text;
                hospital.CNPJ = txtCNPJ.Text;
                hospital.Endereco = txtEndereo.Text;
                hospital.Cidade = txtCidade.Text;
                hospital.UF = txtUF.Text;
                hospital.CEP = txtCEP.Text;
                hospital.Contato1 = txtContato1.Text;
                hospital.Telefone1 = txtTelefone1.Text;
                hospital.Email1 = txtEmail1.Text;
                hospital.Contato2 = txtContato2.Text;
                hospital.Telefone2 = txtTelefone2.Text;
                hospital.Email2 = txtEmail2.Text;
                hospital.Contato3 = txtContato3.Text;
                hospital.Telefone3 = txtTelefone3.Text;
                hospital.Email3 = txtEmail3.Text;
                hospital.Contato4 = txtContato4.Text;
                hospital.Telefone4 = txtTelefone4.Text;
                hospital.Email4 = txtEmail4.Text;
                hospital.UpdatedAt = DateTime.Now;

                db.SubmitChanges();

                MessageBox.Show("Dados atualizados com sucesso!!!", "Editar Dados do Hospital", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Create()
        {
            try
            {
                Hospitai hospital = new Hospitai();
                hospital.Nome = txtNome.Text;
                hospital.Unidade = txtUnidade.Text;
                hospital.CNPJ = txtCNPJ.Text;
                hospital.Endereco = txtEndereo.Text;
                hospital.Cidade = txtCidade.Text;
                hospital.UF = txtUF.Text;
                hospital.CEP = txtCEP.Text;
                hospital.Contato1 = txtContato1.Text;
                hospital.Telefone1 = txtTelefone1.Text;
                hospital.Email1 = txtEmail1.Text;
                hospital.Contato2 = txtContato2.Text;
                hospital.Telefone2 = txtTelefone2.Text;
                hospital.Email2 = txtEmail2.Text;
                hospital.Contato3 = txtContato3.Text;
                hospital.Telefone3 = txtTelefone3.Text;
                hospital.Email3 = txtEmail3.Text;
                hospital.Contato4 = txtContato4.Text;
                hospital.Telefone4 = txtTelefone4.Text;
                hospital.Email4 = txtEmail4.Text;
                hospital.CreatedAt = DateTime.Now;
                hospital.UpdatedAt = DateTime.Now;

                db.Hospitais.InsertOnSubmit(hospital);
                db.SubmitChanges();

                MessageBox.Show("Hospital cadastrado com sucesso!!!", "Cadastro de Hospital", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Template_Load(object sender, EventArgs e)
        {
            switch (operation)
            {
                case 1:
                    this.Text = @"Cadastro de Hospital";
                    gbDadosConvenio.Enabled = false;
                    break;

                case 2:
                    this.Text = @"Editar Dados do Hospital";
                    gbDadosConvenio.Enabled = true;
                    LoadInfo();
                    break;

                default:
                    this.Close();
                    break;
            }
        }

        private void LoadInfo()
        {
            var datas = (from a in db.Hospitais where a.id.Equals(id) select a).FirstOrDefault();

            txtNome.Text = datas.Nome;
            txtUnidade.Text = datas.Unidade;
            txtCNPJ.Text = datas.CNPJ;
            txtEndereo.Text = datas.Endereco;
            txtCidade.Text = datas.Cidade;
            txtUF.Text = datas.UF;
            txtCEP.Text = datas.CEP;
            txtContato1.Text = datas.Contato1;
            txtTelefone1.Text = datas.Telefone1;
            txtEmail1.Text = datas.Email1;
            txtContato2.Text = datas.Contato2;
            txtTelefone2.Text = datas.Telefone2;
            txtEmail2.Text = datas.Email2;
            txtContato3.Text = datas.Contato3;
            txtTelefone3.Text = datas.Telefone3;
            txtEmail3.Text = datas.Email3;
            txtContato4.Text = datas.Contato4;
            txtTelefone4.Text = datas.Telefone4;
            txtEmail4.Text = datas.Email4;

            LoadConvenios(id);
        }

        private bool VerifyInfo()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do hospital", "Nome", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtUnidade.Text))
            {
                MessageBox.Show("Informe a unidade do hospital", "Unidade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUnidade.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCNPJ.Text))
            {
                MessageBox.Show("Informe o CNPJ do hospital", "CNPJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return false;
            }

            return true;
        }

        private void btAddHospital_Click(object sender, EventArgs e)
        {
            using (CONVENIOS.List form = new CONVENIOS.List())
            {
                convenioId = 0;
                CONVENIOS.List.addConvenio = true;
                form.ShowDialog();
            }

            if (convenioId > 0)
            {
                var datas = from a in db.HospitalConvenios
                            where a.HospitalId.Equals(id) && a.ConvenioId.Equals(convenioId)
                            select a;

                if (!datas.Any())
                {
                    try
                    {
                        HospitalConvenio item = new HospitalConvenio();
                        item.HospitalId = id;
                        item.ConvenioId = convenioId;
                        item.CreatedAt = DateTime.Now;
                        item.UpdatedAt = DateTime.Now;

                        db.HospitalConvenios.InsertOnSubmit(item);
                        db.SubmitChanges();

                        LoadConvenios(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void deletarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dataGridView.CurrentRow.Cells[0].Value;
            string NOME = dataGridView.CurrentRow.Cells[1].Value.ToString();

            DialogResult result = MessageBox.Show("Você relamente deseja deletar o convênio abaixo \n\n" +
                                                    "Nome: " + NOME, "Deletar Convênio",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result.Equals(DialogResult.Yes))
            {
                HospitalConvenio item = (from a in db.HospitalConvenios where a.id.Equals(ID) select a).FirstOrDefault();

                db.HospitalConvenios.DeleteOnSubmit(item);
                db.SubmitChanges();

                MessageBox.Show("Convênio deletado com sucesso!!!", "Deletar Convênio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadConvenios(id);
            }    
        }

        private void LoadConvenios(int id)
        {
            dataGridView.Rows.Clear();

            var datas = from a in db.HospitalConvenios
                        where a.HospitalId.Equals(id)
                        join b in db.Convenios on a.ConvenioId equals b.id
                        select new { a.id
                                    ,b.Nome
                                    ,b.Plano
                                    ,b.Acomodacao
                                    ,b.Cidade
                                    ,b.UF};

            foreach (var data in datas)
            {
                dataGridView.Rows.Add(data.id
                                    , data.Nome
                                    , data.Plano
                                    , data.Acomodacao
                                    , data.Cidade
                                    , data.UF);
            }
        }

        private bool DuplicateUnidade(string hospital, string idUnidade)
        {
            var datas = from a in db.Hospitais where a.Unidade.Equals(idUnidade) && a.Nome.Equals(hospital) select a;

            if (datas.Any())
            {
                MessageBox.Show("Já existem uma unidade cadastrada com este nome \n\n" +
                                "Unidade: " + datas.FirstOrDefault().Unidade, 
                                "Cadastro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUnidade.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
