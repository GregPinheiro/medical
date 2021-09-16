using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.FORNECEDORES
{
    public partial class List : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static bool addFornecedor, searchFornecedor;
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

            var datas = from a in db.Fornecedores
                        orderby a.Nome ascending
                        select a;

            if (datas.Any())
            {
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
                                        , data.Email
                                        , data.CreatedAt
                                        , data.UpdatedAt);
                }
            }
        }

        private void txtPlano_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtAcomodacao_TextChanged(object sender, EventArgs e)
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

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)dataGridView.CurrentRow.Cells[0].Value;

            if (addFornecedor)
            {
                CIRURGIAS.Template.fornecedorId = i;
                addFornecedor = false;
                this.Close();
            }

            if (searchFornecedor)
            {
                CONSULTAS.Template.fornecedorId = i;
                searchFornecedor = false;
                this.Close();
            }
        }
    }
}
