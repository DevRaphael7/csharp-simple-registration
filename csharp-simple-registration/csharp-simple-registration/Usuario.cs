using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace csharp_simple_registration
{
    class Usuario
    {
        private string nome;
        private string senha;
        private string cpf;
        private bool val = false;

        public void setNome(String nome) => this.nome = nome;
        

        public void setSenha(String senha)
        {
            if (senha.Length < 10)
            {
                MessageBox.Show("Senha deve ter pelo menos 10 caracteres", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.senha = senha;
                val = true;
            }
            else this.senha = senha;
        }

        public void setCpf(String cpf)
        {
            if (cpf.Length < 11 || cpf.Length > 11)
            {
                MessageBox.Show("O CPF deve possuir 11 caracteres", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                val = true;
            }
            else this.cpf = cpf;
        }

        public String getNome() => this.nome;
        public String getSenha() => this.senha;
        public String getCpf() => this.cpf;

        public bool validarCadastro() => this.val;
        
        public char senhaAsterisco(string textButton)
        {
            char visibility = ' ';
            if (textButton == "SHOW")
            {
                visibility = '*';
                textButton = "HIDE";
            }
            else
            {
                visibility = '\0';
                textButton = "SHOW";
            }

            return visibility;
        }

    }
}
