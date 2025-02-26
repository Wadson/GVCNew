using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO; // Adicione este namespace

namespace GVC
{
    internal class Conexao
    {
        // Método para obter a string de conexão dinamicamente

        private static string GetConnectionString()
        {
            // String de conexão para SQL Server Express
            string connString = @"Server=.\SQLEXPRESS;Database=bdsiscontrol;Trusted_Connection=True;TrustServerCertificate=True;";

            // Carrega a configuração do App.config
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.ConnectionStrings.ConnectionStrings["ConexaoDB"];

            if (settings == null)
            {
                // Adiciona a string de conexão correta para SQL Server Express
                config.ConnectionStrings.ConnectionStrings.Add(
                    new ConnectionStringSettings("ConexaoDB", connString, "System.Data.SqlClient")
                );
            }
            else if (settings.ConnectionString != connString)
            {
                // Atualiza a string de conexão caso esteja errada
                settings.ConnectionString = connString;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");

            return connString;
        }



        public static SqlConnection Conex()
        {
            try
            {
                string conn = GetConnectionString(); // Obtém a string de conexão
                SqlConnection myConn = new SqlConnection(conn);
                return myConn;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao conectar ao banco de dados: " + ex.Message);
            }
        }

        public static SqlDataReader Sql_DataReader(string queryString)
        {
            var conexao = Conex();
            conexao.Open();

            SqlCommand comando = new SqlCommand(queryString, conexao);
            SqlDataReader reader = comando.ExecuteReader();

            return reader;
        }

        public static DataTable SQL_data_adapter(string query_String)
        {
            DataTable DataTableC = new DataTable();
            var conexao = Conex();

            try
            {
                conexao.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query_String, conexao);
                adapter.Fill(DataTableC);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            return DataTableC;
        }

        public static bool execute_NON_query(string query_String, string ParametroBase, string parametroReal)
        {
            try
            {
                using (var conexao = Conex())
                {
                    conexao.Open();
                    using (SqlCommand comando = new SqlCommand(query_String, conexao))
                    {
                        comando.Parameters.AddWithValue(ParametroBase, parametroReal);
                        comando.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar comando SQL: " + ex.Message);
            }
        }
    }
}
