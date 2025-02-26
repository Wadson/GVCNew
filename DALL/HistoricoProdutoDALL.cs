using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GVC.DALL
{
    internal class HistoricoProdutoDALL
    {


        public void InserirHistorico(BLL.HistoricoPrecoBLL historico)
        {
            using (var conn = Conexao.Conex())
            {
                // A consulta não inclui o HistoricoID, pois ele é auto-incremento
                string sql = "INSERT INTO HistoricoPreco (ProdutoID, DataRegistro, PrecoCusto, Lucro, PrecoVenda) " +
                             "VALUES (@ProdutoID, @DataRegistro, @PrecoCusto, @Lucro, @PrecoVenda)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProdutoID", historico.ProdutoID);
                cmd.Parameters.AddWithValue("@DataRegistro", historico.DataRegistro);
                cmd.Parameters.AddWithValue("@PrecoCusto", historico.PrecoCusto);
                cmd.Parameters.AddWithValue("@Lucro", historico.Lucro);
                cmd.Parameters.AddWithValue("@PrecoVenda", historico.PrecoVenda);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        // Método para obter o histórico de um produto específico
        public List<BLL.HistoricoPrecoBLL> ObterHistoricoPorProduto(int produtoID)
        {
            List<BLL.HistoricoPrecoBLL> listaHistorico = new List<BLL.HistoricoPrecoBLL>();

            using (var conn = Conexao.Conex())
            {
                string sql = "SELECT HistoricoID, ProdutoID, DataRegistro, PrecoCusto, Lucro, PrecoVenda " +
                             "FROM HistoricoPreco WHERE ProdutoID = @ProdutoID ORDER BY DataRegistro DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProdutoID", produtoID);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaHistorico.Add(new BLL.HistoricoPrecoBLL
                        {
                            HistoricoID = Convert.ToInt32(dr["HistoricoID"]),
                            ProdutoID = Convert.ToInt32(dr["ProdutoID"]),
                            DataRegistro = Convert.ToDateTime(dr["DataRegistro"]),
                            PrecoCusto = Convert.ToDecimal(dr["PrecoCusto"]),
                            Lucro = Convert.ToDecimal(dr["Lucro"]),
                            PrecoVenda = Convert.ToDecimal(dr["PrecoVenda"])
                        });
                    }
                }
            }
            return listaHistorico;
        }
    }
}
