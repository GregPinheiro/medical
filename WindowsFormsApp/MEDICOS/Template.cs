using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.MEDICOS
{
    public partial class Template : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static int operation, id, idHospital;
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
                    this.Text = @"Cadastro de Médico";
                    gbDadosHospital.Enabled = false;
                    break;

                case 2:
                    this.Text = @"Editar Dados do Médico";
                    LoadInfo(id);
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
                    if (VerifyInfo() && DuplicateCRO_CRM(txtCRO_CRM.Text))
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
                    MessageBox.Show("Erro no processamento dos dados!!! Está operação será finalizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }

        private bool VerifyInfo()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do médico", "Nome", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtEspecialidade.Text))
            {
                MessageBox.Show("Informe a especialidade do médico", "Especialidade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEspecialidade.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCRO_CRM.Text))
            {
                MessageBox.Show("Informe o CRO|CRM do médico", "CRO|CRM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCRO_CRM.Focus();
                return false;
            }

            return true;
        }

        private bool DuplicateCRO_CRM(string cro_crm)
        {
            var datas = from a in db.Medicos where a.CRO_CRM.Equals(cro_crm) select a;

            if (datas.Any())
                return false;

            return true;
        }

        private void Create()
        {
            try
            {
                Medico medico = new Medico();
                medico.Nome = txtNome.Text;
                medico.Especialidade = txtEspecialidade.Text;
                medico.CRO_CRM = txtCRO_CRM.Text;
                medico.Endereco = txtEndereo.Text;
                medico.Cidade = txtCidade.Text;
                medico.UF = txtUF.Text;
                medico.CEP = txtCEP.Text;
                medico.Telefone1 = txtTelefone1.Text;
                medico.Telefone2 = txtTelefone2.Text;
                medico.Consultorio = txtConsultorio.Text;
                medico.Celular = txtCelular.Text;
                medico.Email = txtEmail.Text;
                medico.Secretaria = txtSecretaria.Text;
                medico.CreatedAt = DateTime.Now;
                medico.UpdatedAt = DateTime.Now;

                db.Medicos.InsertOnSubmit(medico);
                db.SubmitChanges();

                MessageBox.Show("Médico cadastrado com sucesso!!!", "Cadastro de Médico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInfo(int id)
        {
            var datas = (from a in db.Medicos where a.id.Equals(id) select a).FirstOrDefault();

            txtNome.Text = datas.Nome;
            txtEspecialidade.Text = datas.Especialidade;
            txtCRO_CRM.Text = datas.CRO_CRM;
            txtEndereo.Text = datas.Endereco;
            txtCidade.Text = datas.Cidade;
            txtUF.Text = datas.UF;
            txtCEP.Text = datas.CEP;
            txtTelefone1.Text = datas.Telefone1;
            txtTelefone2.Text = datas.Telefone2;
            txtConsultorio.Text = datas.Consultorio;
            txtCelular.Text = datas.Celular;
            txtEmail.Text = datas.Email;
            txtSecretaria.Text = datas.Secretaria;

            LoadHospitais(id);
        }

        private void LoadHospitais(int idMedico)
        {
            dataGridView.Rows.Clear();
            try
            {
                var datas = from a in db.MedicoHospitals
                            where a.MedicoId.Equals(idMedico)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var datas = (from a in db.MedicoHospitals where a.id.Equals(ID) select a).FirstOrDefault();

                db.MedicoHospitals.DeleteOnSubmit(datas);
                db.SubmitChanges();

                MessageBox.Show("Hospital deletado com sucesso!!!", "Deletar Hospital", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadHospitais(id);
            }
        }

        private void btAddHospital_Click(object sender, EventArgs e)
        {
            using (HOSPITAIS.List form = new HOSPITAIS.List())
            {
                HOSPITAIS.List.addHospital = true;
                form.ShowDialog();
            }

            var datas = from a in db.MedicoHospitals
                        where a.MedicoId.Equals(id) && a.HospitalId.Equals(idHospital)
                        select a;

            if (!datas.Any())
            {
                try
                {
                    MedicoHospital item = new MedicoHospital();
                    item.MedicoId = id;
                    item.HospitalId = idHospital;
                    item.CreatedAt = DateTime.Now;
                    item.UpdatedAt = DateTime.Now;

                    db.MedicoHospitals.InsertOnSubmit(item);
                    db.SubmitChanges();

                    LoadHospitais(id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }

        private void Update(int id)
        {
            try
            {
                Medico medico = (from a in db.Medicos where a.id.Equals(id) select a).FirstOrDefault();
                medico.Nome = txtNome.Text;
                medico.Especialidade = txtEspecialidade.Text;
                medico.CRO_CRM = txtCRO_CRM.Text;
                medico.Endereco = txtEndereo.Text;
                medico.Cidade = txtCidade.Text;
                medico.UF = txtUF.Text;
                medico.CEP = txtCEP.Text;
                medico.Telefone1 = txtTelefone1.Text;
                medico.Telefone2 = txtTelefone2.Text;
                medico.Consultorio = txtConsultorio.Text;
                medico.Celular = txtCelular.Text;
                medico.Email = txtEmail.Text;
                medico.Secretaria = txtSecretaria.Text;
                medico.UpdatedAt = DateTime.Now;

                db.SubmitChanges();

                MessageBox.Show("Médico Atualizado com sucesso!!!", "Editar Médico", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
