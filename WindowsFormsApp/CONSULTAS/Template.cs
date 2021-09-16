using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.CONSULTAS
{
    public partial class Template : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static int operation;
        public static int pacienteId, medicoId, hospitalId, cirurgiaId, fornecedorId;
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
                    this.Text = @"Cadastrar Nova Consulta";
                    break;

                default:
                    this.Close();
                    break;
            }
        }

        private void btSearchPaciente_Click(object sender, EventArgs e)
        {
            using (PACIENTES.List form = new PACIENTES.List())
            {
                PACIENTES.List.searchPaciente = true;
                pacienteId = 0;
                form.ShowDialog();

                LoadPacienteInfo();
            }
        }

        private void LoadPacienteInfo()
        {
            if (pacienteId > 0)
            {
                var datas = (from a in db.Pacientes where a.id.Equals(pacienteId) select a).FirstOrDefault();

                txtPacNome.Text = datas.Nome;
                txtPacCPF.Text = datas.CPF;
                DateTime dt = new DateTime(datas.DataNasc.Value.Year, datas.DataNasc.Value.Month, datas.DataNasc.Value.Day, 0, 0, 0);
                dtPacNascimento.Value = dt;
                txtPacTelefone.Text = datas.Telefone;
                txtPacCelular.Text = datas.Celular;
                txtPacEmail.Text = datas.Email;
            }
        }

        private void btMedico_Click(object sender, EventArgs e)
        {
            using (MEDICOS.List form = new MEDICOS.List())
            {
                MEDICOS.List.searchMedico = true;
                medicoId = 0;
                form.ShowDialog();

                LoadMedicoInfo();
            }
        }

        private void LoadMedicoInfo()
        {
            if (medicoId > 0)
            {
                var datas = (from a in db.Medicos where a.id.Equals(medicoId) select a).FirstOrDefault();

                txtMedNome.Text = datas.Nome;
                txtMedEspecialidade.Text = datas.Especialidade;
                txtMedCRO_CRM.Text = datas.CRO_CRM;
                txtMedTelefone1.Text = datas.Telefone1;
                txtMedCelular.Text = datas.Celular;
                txtMedEmail.Text = datas.Email;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btSearchFornecedor_Click(object sender, EventArgs e)
        {
            using (FORNECEDORES.List form = new FORNECEDORES.List())
            {
                FORNECEDORES.List.searchFornecedor = true;
                fornecedorId = 0;

                form.ShowDialog();

                LoadFornecedorInfo();
            }
        }

        private void LoadFornecedorInfo()
        {
            if (fornecedorId > 0)
            {
                var datas = (from a in db.Fornecedores where a.id.Equals(fornecedorId) select a).FirstOrDefault();

                txtFornecNome.Text = datas.Nome;
                txtFornecCNPJ.Text = datas.CNPJ;
            }
        }

        private void btSearchCirurgia_Click(object sender, EventArgs e)
        {
            using (CIRURGIAS.List form = new CIRURGIAS.List())
            {
                CIRURGIAS.List.searchCirurgia = true;
                cirurgiaId = 0;
                form.ShowDialog();

                LoadCirurgiaInfo();
            }
        }

        private void LoadCirurgiaInfo()
        {
            if (cirurgiaId > 0)
            {
                var datas = (from a in db.Cirurgias where a.id.Equals(cirurgiaId) select a).FirstOrDefault();

                txtCID.Text = datas.CID;
                txtNomeCirurgia.Text = datas.Nome;
            }
        }

        private void btSearchHospital_Click(object sender, EventArgs e)
        {
            using (HOSPITAIS.List form = new HOSPITAIS.List())
            {
                HOSPITAIS.List.searchHospital = true;
                hospitalId = 0;
                form.ShowDialog();

                LoadHospitalInfo();
            }
        }

        private void LoadHospitalInfo()
        {
            if (hospitalId > 0)
            {
                var datas = (from a in db.Hospitais where a.id.Equals(hospitalId) select a).FirstOrDefault();

                txtHospNome.Text = datas.Nome;
                txtHospUnidade.Text = datas.Unidade;
                txtHospCNPJ.Text = datas.CNPJ;
                txtHospEndereco.Text = datas.Endereco;
                txtHospCidade.Text = datas.Cidade;
                txtHospUF.Text = datas.UF;
                txtHospCEP.Text = datas.CEP;
            }
        }
    }
}
