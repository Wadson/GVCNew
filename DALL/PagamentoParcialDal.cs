using GVC.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GVC.DALL
{
    internal class PagamentoParcialDal
    {
        public void InserirPagamentoParcial(PagamentoParcialModel pagamentoParcial)
        {
            using (var conn = Conexao.Conex())
            {
                conn.Open();
                string query = "INSERT INTO PagamentosParciais (ParcelaID, ValorPago, DataPagamento) VALUES (@ParcelaID, @ValorPago, @DataPagamento)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ParcelaID", pagamentoParcial.ParcelaID);
                    cmd.Parameters.AddWithValue("@ValorPago", pagamentoParcial.ValorPago);
                    cmd.Parameters.AddWithValue("@DataPagamento", pagamentoParcial.DataPagamento);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ExcluirPagamentoParcial(int pagamentoParcialID)
        {
            using (var connection = Conexao.Conex())
            {
                string query = "DELETE FROM PagamentosParciais WHERE ParcelaID = @ParcelaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ParcelaID", pagamentoParcialID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<PagamentoParcialModel> ObterPagamentosParciaisPorParcela(int parcelaID)
        {
            List<PagamentoParcialModel> pagamentosParciais = new List<PagamentoParcialModel>();

            using (var conn = Conexao.Conex())
            {
                conn.Open();
                string query = "SELECT PagamentoParcialID, ParcelaID, ValorPago, DataPagamento FROM PagamentosParciais WHERE ParcelaID = @ParcelaID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ParcelaID", parcelaID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PagamentoParcialModel pagamentoParcial = new PagamentoParcialModel
                            {
                                PagamentoParcialID = reader.GetInt32(0),
                                ParcelaID = reader.GetInt32(1),
                                ValorPago = reader.GetDecimal(2),
                                DataPagamento = reader.GetDateTime(3)
                            };
                            pagamentosParciais.Add(pagamentoParcial);
                        }
                    }
                }
            }

            return pagamentosParciais;
        }
        public void ExcluirPagamentosParciaisPorParcelaID(int parcelaID)
        {
            string query = "DELETE FROM PagamentosParciais WHERE ParcelaID = @ParcelaID";
            using (var conn = Conexao.Conex())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ParcelaID", parcelaID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ListarPagamentosParciais()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM PagamentosParciais", conn);

                SqlDataAdapter daUsuario = new SqlDataAdapter();
                daUsuario.SelectCommand = comando;

                DataTable dtUsuario = new DataTable();
                daUsuario.Fill(dtUsuario);
                return dtUsuario;
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

    }
}
