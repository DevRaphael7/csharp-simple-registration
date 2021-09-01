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
        string confirmarSenha, dab = "server=localhost;user=raphael;database=c_lan;port=3306;password=159357456852DB$;";
        Usuario user = new Usuario();
        ConexaoDB database = new ConexaoDB();

        private void cadastroClick(object sender, EventArgs e)
        {
            database.db = dab;
            user.setNome(txtNome.Text);
            user.setSenha(txtSenha.Text);
            confirmarSenha = txtConfSenha.Text;
            user.setCpf(txtCPF.Text);

            if (user.getSenha() != confirmarSenha) MessageBox.Show("Senhas diferentes!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (user.getNome() == "" || user.getSenha() == "" || user.getCpf() == "") MessageBox.Show("Os campos estão vazios", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(user.validarCadastro())
            {
                database.query = "INSERT INTO usuario (nome, senha, cpf) VALUES (@NOME, @SENHA, @CPF);";
                database.inserirNovosRegistros(user.getNome(), user.getSenha(), user.getCpf());
            }
        }
        public Form2() => InitializeComponent();
        
        private void hidePassword(object sender, EventArgs e)
        {
            buttonHideShow.Text = buttonHideShow.Text == "SHOW" ? "HIDE" : "SHOW";
            txtSenha.PasswordChar = user.senhaAsterisco(buttonHideShow.Text);
            txtConfSenha.PasswordChar = user.senhaAsterisco(buttonHideShow.Text);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = user.senhaAsterisco(buttonHideShow.Text);
            txtConfSenha.PasswordChar = user.senhaAsterisco(buttonHideShow.Text);
        }
    }
}
