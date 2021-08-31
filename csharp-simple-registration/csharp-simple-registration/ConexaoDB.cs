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


        public bool buscaPeloBancoDeDados(string cmd, string nome, string senha)
        {

            bool consulta = false;

            try
            {
                conexao = new MySqlConnection(this.db);

                Console.WriteLine("Conectando com o banco de dados...");
                conexao.Open();

                query = cmd;

                comando = new MySqlCommand(query, conexao);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3]);

                    if (nome == reader[1].ToString() && senha == reader[2].ToString())
                    {
                        consulta = true;
                    }
                    else
                    {
                        consulta = false;
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar banco de dados", "", MessageBoxButtons.OK);
            }
            finally
            {
                conexao.Close();
                Console.WriteLine("Finalizado.");
            }

            return consulta;
        }
        
    }
}
