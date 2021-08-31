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

        private void login_Click(object sender, EventArgs e)
        {
            data.db = dab;
            
            nome = txtNome.Text;
            senha = txtSenha.Text;

            bool conn = data.buscaPeloBancoDeDados("SELECT * FROM usuario;", nome, senha);

            if (conn)
            {
                MessageBox.Show("Conexão realizada com sucesso!", "Parabéns!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(nome != "" & senha != "")
            {
                MessageBox.Show("Usuário não existe ou o nome ou a senha estão errados", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Digite alguma coisa!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
