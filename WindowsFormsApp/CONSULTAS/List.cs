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
    public partial class List : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public List()
        {
            InitializeComponent();

            db.Connection.ConnectionString = GlobalVariable.connectionString;
        }

        private void List_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {            
            var datas = from a in db.ConsultasMedicas
                        join b in db.Pacientes on a.PacienteId equals b.id
                        join c in db.Medicos on a.MedicoId equals c.id
                        join d in db.Hospitais on a.HospitalId equals d.id
                        where b.Nome.Contains(txtPaciente.Text) && b.CPF.Contains(txtCPF.Text) && c.Nome.Contains(txtMedico.Text) && d.Nome.Contains(txtHospital.Text)
                        orderby a.Status ascending 
                        orderby b.Nome ascending
                        select new { a.id
                                    ,a.Status
                                    ,NomePaciente = b.Nome
                                    ,b.CPF
                                    ,b.DataNasc
                                    ,Medico = c.Nome
                                    ,c.Especialidade
                                    ,c.CRO_CRM
                                    ,Hospital = d.Nome
                                    ,d.Unidade
                                    ,a.DataConsulta
                                    ,a.IndicacaoCirurgia};

            dataGridView.Rows.Clear();

            foreach (var data in datas)
            {
                dataGridView.Rows.Add(data.id                                    
                                    , data.NomePaciente
                                    , data.CPF
                                    , data.DataNasc
                                    , data.Medico
                                    , data.Especialidade
                                    , data.CRO_CRM
                                    , data.Hospital
                                    , data.Unidade
                                    , data.DataConsulta
                                    , data.IndicacaoCirurgia
                                    , StatusConsulta((int)data.Status + 1));
            }
        }

        private string StatusConsulta(int status)
        {
            var datas = (from a in db.StatusCirurgias where a.id.Equals(status) select a).FirstOrDefault();

            return datas.options;
        }

        private void txtPaciente_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtMedico_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtHospital_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = (int)dataGridView.CurrentRow.Cells[0].Value;

            using (Template form = new Template())
            {
                Template.operation = 2;
                Template.id = i;
                form.ShowDialog();

                LoadDataGridView();
            }
        }
    }
}
