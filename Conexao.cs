using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Configuration;
using System.IO; // Adicione este namespace

namespace GVC
{
    internal class Conexao
    {
        // Método para obter a string de conexão dinamicamente

        private static string GetConnectionString()
        {
            // Define o caminho do banco de dados SQL Compact (.sdf)
            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bdsiscontrol.sdf");

            // Monta a string de conexão para SQL Compact 4.0
            string connString = $@"Data Source={dbFilePath};Persist Security Info=False;";

            // Verifica se a string de conexão no App.config precisa ser atualizada
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.ConnectionStrings.ConnectionStrings["ConexaoDB"];

            if (settings == null)
            {
                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("ConexaoDB", connString, "System.Data.SqlServerCe.4.0"));
            }
            else if (settings.ConnectionString != connString)
            {
                settings.ConnectionString = connString;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");

            return connString;
        }



        public static SqlCeConnection Conex()
        {
            try
            {
                string conn = GetConnectionString(); // Obtém a string de conexão
                SqlCeConnection myConn = new SqlCeConnection(conn);
                return myConn;
            }
            catch (SqlCeException ex)
            {
                throw new Exception("Erro ao conectar ao banco de dados: " + ex.Message);
            }
        }

        public static SqlCeDataReader Sql_DataReader(string queryString)
        {
            var conexao = Conex();
            conexao.Open();

            SqlCeCommand comando = new SqlCeCommand(queryString, conexao);
            SqlCeDataReader reader = comando.ExecuteReader();

            return reader;
        }

        public static DataTable SQL_data_adapter(string query_String)
        {
            DataTable DataTableC = new DataTable();
            var conexao = Conex();

            try
            {
                conexao.Open();
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(query_String, conexao);
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
                    using (SqlCeCommand comando = new SqlCeCommand(query_String, conexao))
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
