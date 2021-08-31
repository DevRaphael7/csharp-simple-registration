using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_simple_registration
{
    public partial class Form1 : Form
    {
        String nome, senha;
        String dab = "server=localhost;user=raphael;database=c_lan;port=3306;password=159357456852DB$;";
        ConexaoDB data = new ConexaoDB();
        public Form1()
        {
            InitializeComponent();
        }

        private void tela_Cadastro(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void login_Click(object sender, EventArgs e)
        {
            data.db = dab;
            data.query = "SELECT * FROM usuario WHERE Nome = @nome and Senha = @senha;";


            nome = txtNome.Text;
            senha = txtSenha.Text;

            data.buscaPeloBancoDeDados(nome, senha);
        }
    }
}
