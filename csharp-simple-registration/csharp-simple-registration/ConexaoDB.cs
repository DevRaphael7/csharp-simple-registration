using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace csharp_simple_registration
{
    class ConexaoDB
    {
        private MySqlCommand comando;
        private MySqlConnection conexao;
        private MySqlDataReader reader;
        public string query;
        public string db;


        private void conexaoComDB()
        {
           conexao = new MySqlConnection(this.db);
        }


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

                if(temporario == false)
                {
                    MessageBox.Show("E-mail ou senha errados", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
}
