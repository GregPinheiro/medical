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
    public partial class List : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static bool addHospital, searchConvenio, addConvenio;
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

            var datas = from a in db.Convenios
                        where a.Nome.Contains(txtNome.Text) && 
                                a.Plano.Contains(txtPlano.Text) && 
                                a.Acomodacao.Contains(txtAcomodacao.Text) &&
                                a.Cidade.Contains(txtCidade.Text) 
                        orderby a.Nome ascending
                        select a;

            foreach (var data in datas)
            {
                dataGridView.Rows.Add(data.id
                                    , data.Nome
                                    , data.Plano
                                    , data.Acomodacao
                                    , data.Cidade
                                    , data.UF
                                    , data.Contato
                                    , data.Telefone
                                    , data.Email
                                    , data.CreatedAt, data.UpdatedAt);
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtPlano_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtAcomodacao_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)dataGridView.CurrentRow.Cells[0].Value;

            if (searchConvenio)
            {       
                PACIENTES.Template.convenioId = i;
                searchConvenio = false;
                this.Close();
            }

            if (addConvenio)
            {
                HOSPITAIS.Template.convenioId = i;
                addConvenio = false;
                this.Close();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = (int)dataGridView.CurrentRow.Cells[0].Value;

            using (Template form = new Template())
            {
                Template.operation = 2;
                Template.id = i;
                form.ShowDialog();
            }
        }
    }
}
