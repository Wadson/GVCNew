using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisControl.DALL
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

        public void salvaCliente(ClienteMODEL cliente)
        {
            var conn = Conexao.Conex();

            SqlCeCommand sql = new SqlCeCommand("INSERT INTO Cliente (ClienteID, NomeCliente, Cpf, Endereco, Telefone, Email, CidadeID) VALUES (@ClienteID, @NomeCliente, @Cpf, @Endereco, @Telefone, @Email, @CidadeID)", conn);


            sql.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
            sql.Parameters.AddWithValue("@NomeCliente", cliente.NomeCliente);
            sql.Parameters.AddWithValue("@Cpf", cliente.Cpf);
            sql.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            sql.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            sql.Parameters.AddWithValue("@Email", cliente.Email);
            sql.Parameters.AddWithValue("@CidadeID", cliente.CidadeID);

            conn.Open();
            sql.ExecuteNonQuery();

            //try
            //{

            //}
            //catch (SqlCeException ex)
            //{
            //    throw new ApplicationException(ex.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}

        }
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
