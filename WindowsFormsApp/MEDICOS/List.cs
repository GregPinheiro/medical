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
    public partial class List : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static bool search, searchMedico;
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

            var datas = from a in db.Medicos
                        where a.CRO_CRM.Contains(txtCRO_CRM.Text) && 
                            a.Nome.Contains(txtNome.Text) && 
                            a.Especialidade.Contains(txtEspecialidade.Text)
                        orderby a.Nome ascending
                        select a;

            if (datas.Any())
            {
                foreach (var data in datas)
                {
                    dataGridView.Rows.Add(data.id
                                        , data.Nome
                                        , data.Especialidade
                                        , data.CRO_CRM
                                        , data.Endereco
                                        , data.Cidade
                                        , data.UF
                                        , data.CEP
                                        , data.Telefone1
                                        , data.Telefone2
                                        , data.Consultorio
                                        , data.Celular
                                        , data.Email
                                        , data.Secretaria
                                        , data.CreatedAt
                                        , data.UpdatedAt);
                }
            }
        }

        private void txtCRO_CRM_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtEspecialidade_TextChanged(object sender, EventArgs e)
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

        private void List_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)dataGridView.CurrentRow.Cells[0].Value;

            if (search)
            {
                PACIENTES.Template.medicoId = i;
                search = false;
                this.Close();
            }

            if (searchMedico)
            {
                CONSULTAS.Template.medicoId = i;
                searchMedico = false;
                this.Close();
            }
        }
    }
}
