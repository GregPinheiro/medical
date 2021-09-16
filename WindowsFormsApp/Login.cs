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
    public partial class Login : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        public Login()
        {
            InitializeComponent();

            db.Connection.ConnectionString = GlobalVariable.connectionString;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Form1.login = false;
        }

        private void btLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                var datas = from a in db.users where a.userName.Equals(txtUser.Text) select a;

                if (datas.Any())
                {
                    if (datas.FirstOrDefault().password.Equals(txtSenha.Text))
                    {
                        Form1.login = true;
                        GlobalVariable.userName = datas.FirstOrDefault().name;
                        this.Close();
                    }
                    else
                    {
                        Form1.login = false;
                        MessageBox.Show("Senha incorreta, informe a senha correta",
                                        "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSenha.Focus();
                    }
                }
                else
                {
                    Form1.login = false;
                    MessageBox.Show("Usuário informado não existe, informe um usuário válido",
                                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUser.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
