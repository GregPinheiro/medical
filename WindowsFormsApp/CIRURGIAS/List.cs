using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.CIRURGIAS
{
    public partial class List : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static bool searchCirurgia;
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

            var datas = from a in db.Cirurgias
                        where a.Nome.Contains(txtNome.Text) && a.CID.Contains(txtCID.Text) && a.TUS.Contains(txtTUSS.Text)
                        orderby a.Nome ascending
                        select a;

            foreach (var data in datas)
            {
                dataGridView.Rows.Add(data.id
                                    , data.Nome
                                    , data.CID
                                    , data.TUS
                                    , data.Justificativa
                                    , data.CreatedAt
                                    , data.UpdatedAt);
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

            LoadDataGridView();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)dataGridView.CurrentRow.Cells[0].Value;

            if (searchCirurgia)
            {
                CONSULTAS.Template.cirurgiaId = i;
                searchCirurgia = false;
                this.Close();
            }
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
    }
}
