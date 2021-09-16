using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.CONVENIOS
{
    public partial class Template : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static int operation, id, hospitalId;
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
                    this.Text = @"Cadastrar Convênio";
                    gbDadosHospital.Enabled = false;
                    break;

                case 2:
                    this.Text = @"Editar Dados do Convênio";
                    LoadInfo();
                    gbDadosHospital.Enabled = true;
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
                    if (VerifyInfo() && Duplicate(txtNome.Text, txtPlano.Text))
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

        private void Create()
        {
            try
            {
                Convenio convenio = new Convenio();
                convenio.Nome = txtNome.Text;
                convenio.Plano = txtPlano.Text;
                convenio.Acomodacao = txtAcomodacao.Text;
                convenio.Endereco = txtEndereo.Text;
                convenio.Cidade = txtCidade.Text;
                convenio.UF = txtUF.Text;
                convenio.CEP = txtCEP.Text;
                convenio.Contato = txtContato1.Text;
                convenio.Telefone = txtTelefone1.Text;
                convenio.Email = txtEmail1.Text;
                convenio.CreatedAt = DateTime.Now;
                convenio.UpdatedAt = DateTime.Now;

                db.Convenios.InsertOnSubmit(convenio);
                db.SubmitChanges();

                MessageBox.Show("Convênio cadastrado com sucesso!!!", "Cadastro de Convênio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerifyInfo()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Por favor informe o nome do convênio", "Nome do Convênio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPlano.Text))
            {
                MessageBox.Show("Por favor informe o plano do convênio", "Plano do Convênio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPlano.Focus();
                return false;
            }

            return true;
        }

        private bool Duplicate(string nome, string plano)
        {
            var datas = from a in db.Convenios
                        where a.Nome.Equals(nome) && a.Plano.Equals(plano)
                        select a;

            if (datas.Any())
            {
                return false;
            }

            return true;
        }

        private void LoadInfo()
        {
            var datas = (from a in db.Convenios where a.id.Equals(id) select a).FirstOrDefault();

            txtNome.Text = datas.Nome;
            txtPlano.Text = datas.Plano;
            txtAcomodacao.Text = datas.Acomodacao;
            txtEndereo.Text = datas.Endereco;
            txtCidade.Text = datas.Cidade;
            txtUF.Text = datas.UF;
            txtCEP.Text = datas.CEP;
            txtContato1.Text = datas.Contato;
            txtTelefone1.Text = datas.Telefone;
            txtEmail1.Text = datas.Email;

            LoadHospitais(id);
        }

        private void btAddHospital_Click(object sender, EventArgs e)
        {
            using (HOSPITAIS.List form = new HOSPITAIS.List())
            {
                HOSPITAIS.List.addHospital = true;
                form.ShowDialog();
            }

            var datas = from a in db.ConvenioHosptals
                        where a.ConvenioId.Equals(id) && a.HospitalId.Equals(hospitalId)
                        select a;

            if (!datas.Any())
            {
                try
                {
                    ConvenioHosptal item = new ConvenioHosptal();
                    item.ConvenioId = id;
                    item.HospitalId = hospitalId;
                    item.CreatedAt = DateTime.Now;
                    item.UpdatedAt = DateTime.Now;

                    db.ConvenioHosptals.InsertOnSubmit(item);
                    db.SubmitChanges();

                    LoadHospitais(id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deletarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dataGridView.CurrentRow.Cells[0].Value;
            string NOME = dataGridView.CurrentRow.Cells[1].Value.ToString();

            DialogResult result = MessageBox.Show("Você relamente deseja deletar o hospital abaixo \n\n" +
                                                    "Hospital: " + NOME, "Deletar Hospital",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result.Equals(DialogResult.Yes))
            {
                var datas = (from a in db.ConvenioHosptals where a.id.Equals(ID) select a).FirstOrDefault();

                db.ConvenioHosptals.DeleteOnSubmit(datas);
                db.SubmitChanges();

                MessageBox.Show("Hospital deletado com sucesso!!!", "Deletar Hospital", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadHospitais(id);
            }
        }

        private void LoadHospitais(int id)
        {
            dataGridView.Rows.Clear();

            var datas = from a in db.ConvenioHosptals
                        where a.ConvenioId.Equals(id)
                        join b in db.Hospitais on a.HospitalId equals b.id
                        select new { a.id
                                   , b.Nome
                                   , b.Unidade
                                   , b.CNPJ
                                   , b.Endereco
                                   , b.Cidade
                                   , b.UF
                                   , b.CEP};

            if (datas.Any())
            {
                foreach (var data in datas)
                {
                    dataGridView.Rows.Add(data.id
                                        , data.Nome
                                        , data.Unidade
                                        , data.CNPJ
                                        , data.Endereco
                                        , data.Cidade
                                        , data.UF
                                        , data.CEP);
                }
            }
        }

        private void Update(int idConvenio)
        {
            Convenio convenio = (from a in db.Convenios where a.id.Equals(idConvenio) select a).FirstOrDefault();
            convenio.Nome = txtNome.Text;
            convenio.Plano = txtPlano.Text;
            convenio.Acomodacao = txtAcomodacao.Text;
            convenio.Endereco = txtEndereo.Text;
            convenio.Cidade = txtCidade.Text;
            convenio.UF = txtUF.Text;
            convenio.CEP = txtCEP.Text;
            convenio.Contato = txtContato1.Text;
            convenio.Telefone = txtTelefone1.Text;
            convenio.Email = txtEmail1.Text;
            convenio.UpdatedAt = DateTime.Now;

            db.SubmitChanges();

            MessageBox.Show("Dados atualizados com sucesso!!!", "Edição dos Dados do Convênio", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
