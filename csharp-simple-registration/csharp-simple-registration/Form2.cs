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
    public partial class Form2 : Form
    {
        string nome, senha, confirmarSenha, cpf;
        String dab = "server=localhost;user=raphael;database=c_lan;port=3306;password=159357456852DB$;";
        ConexaoDB database = new ConexaoDB();

        private void cadastroClick(object sender, EventArgs e)
        {
            database.db = dab;
            nome = txtNome.Text;
            senha = txtSenha.Text;
            confirmarSenha = txtConfSenha.Text;
            cpf = txtCPF.Text;

            if (senha != confirmarSenha)
            {
                MessageBox.Show("Senhas diferentes!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (nome == "" || senha == "" || confirmarSenha == "")
            {
                MessageBox.Show("Os campos estão vazios", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                database.query = "INSERT INTO usuario (nome, senha, cpf) VALUES (@NOME, @SENHA, @CPF);";
                database.inserirNovosRegistros(nome, senha, cpf);
            }
        }

        Usuario user = new Usuario();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
