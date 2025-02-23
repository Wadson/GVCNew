using GVC.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GVC.DALL
{
    internal class ClienteDALL
    {
        public DataTable ListarClientes()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCeCommand sql = new SqlCeCommand("SELECT Cliente.ClienteID, Cliente.NomeCliente, Cliente.Cpf, Cliente.Endereco, Cliente.Telefone, Cliente.Email, Cliente.CidadeID, Cidade.NomeCidade AS NomeCidade, Cidade.EstadoID, Estado.NomeEstado AS NomeEstado, Estado.Uf FROM Cliente INNER JOIN Cidade ON Cliente.CidadeID = Cidade.CidadeID INNER JOIN Estado ON Cidade.EstadoID = Estado.EstadoID", conn);

                //                SqlCeCommand sql = new SqlCeCommand("SELECT Cliente.ClienteID, Cliente.NomeCliente, Cliente.Cpf, Cliente.Endereco, Cliente.Telefone, Cliente.Email, Cliente.CidadeID, Cidade.NomeCidade AS Expr1, Cidade.EstadoID, Estado.NomeEstado AS Expr2, Estado.Uf " +
                //"FROM Cliente INNER JOIN Cidade ON Cliente.CidadeID = Cidade.CidadeID INNER JOIN Estado ON Cidade.EstadoID = Estado.EstadoID", conn);

                SqlCeDataAdapter daCliente = new SqlCeDataAdapter();
                daCliente.SelectCommand = sql;
                DataTable dtcliente = new DataTable();
                daCliente.Fill(dtcliente);
                return dtcliente;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }





        public bool ClienteExiste(string nomeCliente, string cpf)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                var query = @"SELECT COUNT(*) FROM Cliente 
                      WHERE (@NomeCliente <> '' AND NomeCliente = @NomeCliente) 
                      OR (@Cpf <> '' AND Cpf = @Cpf)";

                using (var command = new SqlCeCommand(query, connection))
                {
                    command.Parameters.Add("@NomeCliente", SqlDbType.NVarChar, 100).Value = nomeCliente ?? string.Empty;
                    command.Parameters.Add("@Cpf", SqlDbType.NVarChar, 14).Value = cpf ?? string.Empty;

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void SalvarCliente(ClienteMODEL cliente)
        {
            var connection = Conexao.Conex();

            using (connection)
            {
                connection.Open();

                // Verificação de duplicidade
                var verificarQuery = @"SELECT COUNT(*) FROM Cliente 
                              WHERE (@NomeCliente <> '' AND NomeCliente = @NomeCliente) 
                              OR (@Cpf <> '' AND Cpf = @Cpf)";

                using (var verificarCommand = new SqlCeCommand(verificarQuery, connection))
                {
                    verificarCommand.Parameters.Add("@NomeCliente", SqlDbType.NVarChar, 100).Value = cliente.NomeCliente ?? string.Empty;
                    verificarCommand.Parameters.Add("@Cpf", SqlDbType.NVarChar, 14).Value = cliente.Cpf ?? string.Empty;

                    int count = Convert.ToInt32(verificarCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        throw new Exception("Já existe um cliente cadastrado com o mesmo nome ou CPF.");
                    }
                }

                // Inserção do cliente
                var insertQuery = @"INSERT INTO Cliente (ClienteID, NomeCliente, Cpf, Endereco, Telefone, Email, CidadeID) 
                           VALUES (@ClienteID, @NomeCliente, @Cpf, @Endereco, @Telefone, @Email, @CidadeID)";

                using (var insertCommand = new SqlCeCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.Add("@ClienteID", SqlDbType.Int).Value = cliente.ClienteID;
                    insertCommand.Parameters.Add("@NomeCliente", SqlDbType.NVarChar, 100).Value = cliente.NomeCliente ?? string.Empty;
                    insertCommand.Parameters.Add("@Cpf", SqlDbType.NVarChar, 14).Value = cliente.Cpf ?? string.Empty;
                    insertCommand.Parameters.Add("@Endereco", SqlDbType.NVarChar, 200).Value = cliente.Endereco ?? string.Empty;
                    insertCommand.Parameters.Add("@Telefone", SqlDbType.NVarChar, 20).Value = cliente.Telefone ?? string.Empty;
                    insertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = cliente.Email ?? string.Empty;
                    insertCommand.Parameters.Add("@CidadeID", SqlDbType.Int).Value = cliente.CidadeID;

                    insertCommand.ExecuteNonQuery();
                }
            }
        }








        //public void salvaCliente(ClienteMODEL cliente)
        //{
        //    var conn = Conexao.Conex();
        //    try
        //    {
        //        SqlCeCommand sql = new SqlCeCommand("INSERT INTO Cliente (ClienteID, NomeCliente, Cpf, Endereco, Telefone, Email, CidadeID) VALUES (@ClienteID, @NomeCliente, @Cpf, @Endereco, @Telefone, @Email, @CidadeID)", conn);


        //        sql.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
        //        sql.Parameters.AddWithValue("@NomeCliente", cliente.NomeCliente);
        //        sql.Parameters.AddWithValue("@Cpf", cliente.Cpf);
        //        sql.Parameters.AddWithValue("@Endereco", cliente.Endereco);
        //        sql.Parameters.AddWithValue("@Telefone", cliente.Telefone);
        //        sql.Parameters.AddWithValue("@Email", cliente.Email);
        //        sql.Parameters.AddWithValue("@CidadeID", cliente.CidadeID);
        //        conn.Open();
        //        sql.ExecuteNonQuery();
        //    }
        //    catch (SqlCeException ex)
        //    {
        //        throw new ApplicationException(ex.ToString());
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        public void excluiCliente(ClienteMODEL cliente)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCeCommand sql = new SqlCeCommand("DELETE FROM Cliente WHERE ClienteID = @ClienteID ", conn);
                sql.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);


                conn.Open();
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }

        public void atualiza_Cliente(ClienteMODEL cliente)
        {
            var conn = Conexao.Conex();
            
            try
            {
                SqlCeCommand Sql = new SqlCeCommand("UPDATE Cliente SET NomeCliente = @NomeCliente, Cpf = @Cpf, Endereco = @Endereco, Telefone = @Telefone, Email = @Email, CidadeID = @CidadeID WHERE ClienteID = @ClienteID", conn);

                Sql.Parameters.AddWithValue("@NomeCliente", cliente.NomeCliente);
                Sql.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                Sql.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                Sql.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                Sql.Parameters.AddWithValue("@Email", cliente.Email);
                Sql.Parameters.AddWithValue("@CidadeID", cliente.CidadeID);
                Sql.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);

                conn.Open();
                Sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable PesquisarPorNome(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT Cliente.ClienteID, Cliente.NomeCliente, Cliente.Cpf, Cliente.Endereco, Cliente.Telefone, Cliente.Email, Cliente.CidadeID, Cidade.NomeCidade AS NomeCidade, Cidade.EstadoID, Estado.NomeEstado AS NomeEstado, Estado.Uf FROM Cliente INNER JOIN Cidade ON Cliente.CidadeID = Cidade.CidadeID INNER JOIN Estado ON Cidade.EstadoID = Estado.EstadoID WHERE NomeCliente LIKE @NomeCliente";


                //string sqlconn = "SELECT TOP (30) * FROM Cliente WHERE NomeCliente LIKE @NomeCliente";
                SqlCeCommand cmd = new SqlCeCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeCliente", nome);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a pesquisa: " + ex);
                return null;
            }
        }
        public DataTable PesquisarPorCodigo(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT Cliente.ClienteID, Cliente.NomeCliente, Cliente.Cpf, Cliente.Endereco, Cliente.Telefone, Cliente.Email, Cliente.CidadeID, Cidade.NomeCidade AS NomeCidade, Cidade.EstadoID, Estado.NomeEstado AS NomeEstado, Estado.Uf FROM Cliente INNER JOIN Cidade ON Cliente.CidadeID = Cidade.CidadeID INNER JOIN Estado ON Cidade.EstadoID = Estado.EstadoID WHERE ClienteID LIKE @ClienteID";


                //string sqlconn = "SELECT TOP (30) * FROM Cliente WHERE NomeCliente LIKE @NomeCliente";
                SqlCeCommand cmd = new SqlCeCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@ClienteID", nome);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a pesquisa: " + ex);
                return null;
            }
        }
        public DataTable PesquisarGeral()
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();
                string sqlconn = "SELECT TOP (30) Cliente.ClienteID, Cliente.NomeCliente, Cliente.Cpf, Cliente.Email, Cliente.Endereco, Cliente.Telefone, Cliente.CidadeID, Cidade.NomeCidade, Estado.NomeEstado FROM Cliente INNER JOIN Cidade ON Cliente.CidadeID = Cidade.CidadeID INNER JOIN Estado ON Cidade.EstadoID = Estado.EstadoID";
                //WHERE Cidade.NomeCidade = @NomeCidade);

                SqlCeCommand cmd = new SqlCeCommand(sqlconn, conn);
                //cmd.Parameters.AddWithValue("@NomeCidade", nome);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a pesquisa: " + ex);
                return null;
            }
        }
    }
}
