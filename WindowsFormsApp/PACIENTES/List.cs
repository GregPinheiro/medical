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
    public partial class List : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static bool searchPaciente;
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
            dataGridView.Rows.Clear();

            var datas = from a in db.Pacientes
                        where a.CPF.Contains(txtCPF.Text) && 
                            a.Nome.Contains(txtNome.Text) && 
                            a.Telefone.Contains(txtTelefone.Text) &&
                            a.Celular.Contains(txtCelular.Text) &&
                            a.Email.Contains(txtEmail.Text)
                        join b in db.Medicos on a.MedicoId equals b.id
                        join c in db.Convenios on a.ConvenioId equals c.id
                        orderby a.Nome ascending
                        select new { a.id
                                    , a.CPF
                                    , a.Nome
                                    , a.DataNasc
                                    , a.Endereco
                                    , a.Cidade
                                    , a.UF
                                    , a.Telefone
                                    , a.Celular
                                    , a.Email
                                    , ConvenioId = c.Nome
                                    , a.NoCarteirinha
                                    , a.Validade
                                    , a.Login
                                    , a.Senha
                                    , MedicoId = b.Nome
                                    , a.createdAt
                                    , a.updatedAt
                                    , a.obs};

            if (datas.Any())
            {
                foreach (var data in datas)
                {
                    dataGridView.Rows.Add(data.id
                                    , data.CPF
                                    , data.Nome
                                    , data.DataNasc
                                    , data.Endereco
                                    , data.Cidade
                                    , data.UF
                                    , data.Telefone
                                    , data.Celular
                                    , data.Email
                                    , data.ConvenioId
                                    , data.NoCarteirinha
                                    , data.Validade
                                    , data.Login
                                    , data.Senha
                                    , data.MedicoId
                                    , data.createdAt
                                    , data.updatedAt
                                    , data.obs);
                }                
            }
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView.CurrentRow.Cells[0].Value;

            using (Template form = new Template())
            {
                Template.operation = 2;
                Template.id = id;
                form.ShowDialog();
            }

            LoadDataGridView();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (searchPaciente)
            {
                CONSULTAS.Template.pacienteId = (int)dataGridView.CurrentRow.Cells[0].Value;
                searchPaciente = false;
                this.Close();
            }
        }
    }
}
