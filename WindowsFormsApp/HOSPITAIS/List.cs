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
    public partial class List : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static bool addHospital, searchHospital;
        public static int id;
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

            var datas = from a in db.Hospitais
                        where a.Nome.Contains(txtNome.Text) &&
                                a.Unidade.Contains(txtUnidade.Text) &&
                                a.CNPJ.Contains(txtCNPJ.Text)
                        orderby a.Nome ascending
                        select a;

            foreach (var data in datas)
            {
                dataGridView.Rows.Add(data.id
                                    , data.Nome
                                    , data.Unidade
                                    , data.CNPJ
                                    , data.Endereco
                                    , data.Cidade
                                    , data.UF
                                    , data.CEP
                                    , data.Contato1, data.Telefone1, data.Email1
                                    , data.Contato2, data.Telefone2, data.Email2
                                    , data.Contato3, data.Telefone3, data.Email3
                                    , data.Contato4, data.Telefone4, data.Email4
                                    , data.CreatedAt, data.UpdatedAt);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView.CurrentRow.Cells[0].Value;

            using (Template form = new Template())
            {
                Template.id = id;
                Template.operation = 2;
                form.ShowDialog();
            }

            LoadDataGridView();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtUnidade_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void txtCNPJ_TextChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)dataGridView.CurrentRow.Cells[0].Value;

            if (addHospital)
            {                
                MEDICOS.Template.idHospital = i;
                CONVENIOS.Template.hospitalId = i;
                addHospital = false;
                this.Close();
            }

            if (searchHospital)
            {
                CONSULTAS.Template.hospitalId = i;
                searchHospital = false;
                this.Close();

            }
        }
    }
}
