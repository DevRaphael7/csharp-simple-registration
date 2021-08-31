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

        public void setNome(String nome)
        {
            if (nome.Length <= 1)
            {
                MessageBox.Show("Nome inválido", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.nome = nome;
            }
        }

        public void setSenha(String senha)
        {
            if (senha.Length < 10)
            {
                MessageBox.Show("Senha deve ter pelo menos 10 caracteres", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.senha = senha;
            }
        }

        public void setCpf(String cpf)
        {
            if (cpf.Length < 11 || cpf.Length > 11)
            {
                MessageBox.Show("O CPF deve possuir 11 caracteres", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.cpf = cpf;
            }
        }

        public String getNome() => this.nome;
        public String getSenha() => this.senha;
        public String getCpf() => this.cpf;

    }
}
