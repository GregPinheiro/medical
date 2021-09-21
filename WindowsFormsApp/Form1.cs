using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public static bool login;
        public Form1()
        {
            InitializeComponent();

            db.Connection.ConnectionString = GlobalVariable.connectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Logon())
            {
                this.Close();
            }
        }

        private bool Logon()
        {
            using (Login form = new Login())
            {
                form.ShowDialog();
            }

            return login;
        }

        private void mudarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logon();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PACIENTES.Template form = new PACIENTES.Template())
            {
                PACIENTES.Template.operation = 1;
                form.ShowDialog();
            }
        }

        private void editarDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PACIENTES.List form = new PACIENTES.List())
            {
                form.ShowDialog();
            }
        }

        private void cadastrarNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MEDICOS.Template form = new MEDICOS.Template())
            {
                MEDICOS.Template.operation = 1;
                form.ShowDialog();
            }
        }

        private void gerenciarMédicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MEDICOS.List form = new MEDICOS.List())
            {
                form.ShowDialog();
            }
        }

        private void cadastrarNovoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (HOSPITAIS.Template form = new HOSPITAIS.Template())
            {
                HOSPITAIS.Template.operation = 1;
                form.ShowDialog();
            }
        }

        private void gerenciarHospitaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (HOSPITAIS.List form = new HOSPITAIS.List())
            {
                form.ShowDialog();
            }
        }

        private void cadastrarNovoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (CONVENIOS.Template form = new CONVENIOS.Template())
            {
                CONVENIOS.Template.operation = 1;
                form.ShowDialog();
            }
        }

        private void gerênciasConvêniosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CONVENIOS.List form = new CONVENIOS.List())
            {
                form.ShowDialog();
            }
        }

        private void cadastrarNovoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            using (FORNECEDORES.Template form = new FORNECEDORES.Template())
            {
                FORNECEDORES.Template.operation = 1;
                form.ShowDialog();
            }
        }

        private void gerenciarFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FORNECEDORES.List form = new FORNECEDORES.List())
            {
                form.ShowDialog();
            }
        }

        private void cadastrarNovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CONSULTAS.Template form = new CONSULTAS.Template())
            {
                CONSULTAS.Template.operation = 1;
                form.ShowDialog();
            }
        }

        private void cadastrarNovaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (CIRURGIAS.Template form = new CIRURGIAS.Template())
            {
                CIRURGIAS.Template.operation = 1;
                form.ShowDialog();
            }
        }

        private void gerenciarCirurgiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CIRURGIAS.List form = new CIRURGIAS.List())
            {
                form.ShowDialog();
            }
        }

        private void gerenciarConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CONSULTAS.List form = new CONSULTAS.List())
            {
                form.ShowDialog();
            }
        }
    }
}
