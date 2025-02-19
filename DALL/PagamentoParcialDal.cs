using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;

namespace SisControl.DALL
{
    internal class PagamentoParcialDal
    {
        public void InserirPagamentoParcial(PagamentoParcialModel pagamentoParcial)
        {
            using (var conn = Conexao.Conex())
            {
                conn.Open();
                string query = "INSERT INTO PagamentosParciais (ParcelaID, ValorPago, DataPagamento) VALUES (@ParcelaID, @ValorPago, @DataPagamento)";

                using (SqlCeCommand cmd = new SqlCeCommand(query, conn))
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
                SqlCeCommand command = new SqlCeCommand(query, connection);
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

                using (SqlCeCommand cmd = new SqlCeCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ParcelaID", parcelaID);
                    using (SqlCeDataReader reader = cmd.ExecuteReader())
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
                SqlCeCommand cmd = new SqlCeCommand(query, conn);
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
                SqlCeCommand comando = new SqlCeCommand("SELECT * FROM PagamentosParciais", conn);

                SqlCeDataAdapter daUsuario = new SqlCeDataAdapter();
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
