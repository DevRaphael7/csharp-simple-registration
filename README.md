# Aplicativo simples de cadastro e login com c# 🎓 
<img src="csharp-simple-registration\images\300ppi\c-sharp.png" alt="C#">

## Scripts SQL:

``` sql
    CREATE DATABASE c_lan;
```
``` sql
    create table usuario(
        id int NOT NULL AUTO_INCREMENT,
        nome varchar(30) NOT NULL,
        senha varchar(20) NOT NULL,
        cpf varchar(11) NOT NULL UNIQUE,
        PRIMARY KEY(id)
    );
```

## CODES C SHARP

- Usuario 
- ConexaoDB (Conexao com o banco de dados)


``` c#

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
        private bool val;

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
        
        public bool camposVazios()
        {
            bool empty = senha != " " && nome != " " && cpf != " " ? true : false;
            return empty;
        }
        public char senhaAsterisco(string textButton)
        {
            char visibility = ' ';
            visibility = textButton == "SHOW" ? '*' : '\0';
            textButton = visibility == '*' ? "HIDE" : "SHOW";
            return visibility;
        }

        public Usuario()
        {
            this.senha = " ";
            this.nome = " ";
            this.cpf = " ";
            this.val = false;
        }
    }
}
```

A classe `Usuario` é onde faço as validações do dados do usuário e armazeno o nome, senha e cpf nos sues métodos `sets`. Com o método setSenha por exemplo, eu obrigo o usuário a passar por uma regra, onde a senha deve ter pelo menos 10 ou mais caracteres, e através do atributo `val` eu valido se o usuário cumpriu ou não a regra, caso o usuário tenha digitado uma senha menor que 10, o val é igual a *`true`*, e portanto executará a caixa de diálogo no *Form2.cs* avisando que o usuário deve digitar mais ou pelo menos 10 caracteres para fazer o cadastro.

``` c#
class ConexaoDB
    {
        private MySqlCommand comando;
        private MySqlConnection conexao;
        private MySqlDataReader reader;
        public string query;
        public string db;

        private void conexaoComDB() => conexao = new MySqlConnection(this.db);
        
        public void buscaPeloBancoDeDados(string nome, string senha)
        {
            try
            {
                conexao = new MySqlConnection(this.db);
                bool temporario = false;

                Console.WriteLine("Conectando com o banco de dados...");
                conexao.Open();

                comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@senha", senha);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    if (nome == reader[1].ToString() && senha == reader[2].ToString())
                    {
                        MessageBox.Show("Conexão realizada com sucesso!", "Parabéns!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        temporario = true;
                    }
                }

                if(temporario == false) MessageBox.Show("E-mail ou senha errados", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                Console.WriteLine("Finalizado.");
            } 
        }

        public void inserirNovosRegistros(string nome, string senha, string cpf)
        {
            try
            {
                conexao = new MySqlConnection(this.db);
              
                Console.WriteLine("Conectando com o banco de dados...");
                conexao.Open();

                comando = new MySqlCommand(this.query, conexao);
                
                comando.Parameters.AddWithValue("@NOME", nome);
                comando.Parameters.AddWithValue("@SENHA", senha);
                comando.Parameters.AddWithValue("@CPF", cpf);
                comando.ExecuteNonQuery();

                MessageBox.Show("Usuário cadastrado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                Console.WriteLine("Finalizado.");
            }
        }
    }
```

A classe ConexaoDB é onde realizo a conexão com o banco de dados.



> ### A documentação para usar MySQL com C# está neste link 👉 [ Connector/NET Tutorials ](https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials.html).

## INTERFACE GRÁFICA

<img src="csharp-simple-registration\images\300ppi\GUI.png" alt="Interface gráfica">


