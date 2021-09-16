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
            FillComboBox();

            switch (operation)
            {
                case 1:
                    this.Text = @"Cadastrar Nova Consulta";
                    pacienteId = medicoId = hospitalId = 0;
                    break;

                default:
                    this.Close();
                    break;
            }            
        }

        private void FillComboBox()
        {
            var datas = from a in db.StatusCirurgias orderby a.id ascending select a;

            cbStatusCirurgia.Items.Clear();
            foreach (var item in datas)
            {
                cbStatusCirurgia.Items.Add(item.options);
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
            else
            {
                txtPacNome.Text = "";
                txtPacCPF.Text = "";
                txtPacTelefone.Text = "";
                txtPacCelular.Text = "";
                txtPacEmail.Text = "";
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
            }
            else
            {
                txtMedNome.Text = "";
                txtMedEspecialidade.Text = "";
                txtMedCRO_CRM.Text = "";
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
            else
            {
                txtFornecNome.Text = "";
                txtFornecCNPJ.Text = "";
            }
        }

        private void gbCirurgia_Enter(object sender, EventArgs e)
        {

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case 1:
                    if (VerifyInfo())
                    {
                        Create();
                    }
                    break;

                default:
                    this.Close();
                    break;
            }
        }

        private bool VerifyInfo()
        {
            if (pacienteId.Equals(0))
            {
                MessageBox.Show("Selecione o paciente da consulta", "Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btSearchPaciente.Focus();
                return false;
            }

            if (medicoId.Equals(0))
            {
                MessageBox.Show("Selecione o médico da consulta", "Médico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btSearchMedico.Focus();
                return false;
            }

            if (hospitalId.Equals(0))
            {
                MessageBox.Show("Selecione o hospital da consulta", "Hospital", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btSearchHospital.Focus();
                return false;
            }

            return true;
        }

        private void Create()
        {
            try
            {
                ConsultasMedica item = new ConsultasMedica();
                item.PacienteId = pacienteId;
                item.MedicoId = medicoId;
                item.HospitalId = hospitalId;
                item.CirurgiaId = cirurgiaId;
                item.FornecedorId = fornecedorId;
                item.Historico = txtDescricao.Text;
                item.DataConsulta = dtConsulta.Value;
                item.Queixa = txtQueixa.Text;
                item.HistoriaDoenca = txtHistDoenca.Text;
                item.ExameFisico = txtExameFisico.Text;
                item.Diagnostico = txtDiagnostico.Text;
                item.IndicacaoCirurgia = cbCirurgia.Checked;
                item.DataPrevista = dtDataPrevista.Value;
                item.DataCirurgia = dtCirurgia.Value;
                item.ResultadoEsperado = txtResultEsperado.Text;
                item.Justificativa = txtJustificativa.Text;
                item.PlanejamentoCirurgico = txtPlanejamentoMedico.Text;
                item.CreatedAt = DateTime.Now;
                item.UpdatedAt = DateTime.Now;

                db.ConsultasMedicas.InsertOnSubmit(item);
                db.SubmitChanges();

                MessageBox.Show("Consulta médica criada com sucesso!!!", "Cadastrar Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                txtCID.Text = "";
                txtNomeCirurgia.Text = "";
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
            }
            else
            {
                txtHospNome.Text = "";
                txtHospUnidade.Text = "";
                txtHospCNPJ.Text = "";
            }
        }
    }
}
