using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;

namespace SisControl.DALL
{
    internal class ProdutosDal
    {

        //public List<ProdutosModel> Listar()
        //{
        //    var connection = Conexao.Conex();

        //    var produtos = new List<ProdutosModel>();
        //    using (connection)
        //    {
        //        var query = "SELECT * FROM Produtos";
        //        using (var command = new SqlCeCommand(query, connection))
        //        {
        //            connection.Open();
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var produto = new ProdutosModel
        //                    {
        //                        ProdutoID = reader.GetInt32(reader.GetOrdinal("ProdutoID")),
        //                        NomeProduto = reader.GetString(reader.GetOrdinal("NomeProduto")),                               
        //                        PrecoCusto = reader.GetDecimal(reader.GetOrdinal("PrecoCusto")),
        //                        Lucro = reader.GetDecimal(reader.GetOrdinal("Lucro")),
        //                        PrecoDeVenda = reader.GetDecimal(reader.GetOrdinal("PrecoDeVenda")),
        //                        Estoque = reader.GetInt32(reader.GetOrdinal("Estoque")),
        //                        DataDeEntrada = reader.GetDateTime(reader.GetOrdinal("DataDeEntrada")),                              
        //                        Status = reader.GetString(reader.GetOrdinal("Status")),                                                               
        //                        Referencia = reader.GetString(reader.GetOrdinal("Referencia")), 
                                
        //                    };
        //                    produtos.Add(produto);
        //                }
        //            }
        //        }

              
        //    }
        //    return produtos;
        //}
        public DataTable listarProdutos()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCeCommand comando = new SqlCeCommand("SELECT TOP (30) ProdutoID, Referencia, NomeProduto, PrecoCusto, Lucro, PrecoDeVenda, Estoque, DataDeEntrada, Status FROM Produtos", conn);              

                SqlCeDataAdapter daProduto = new SqlCeDataAdapter();
                daProduto.SelectCommand = comando;

                DataTable dtProduto= new DataTable();
                daProduto.Fill(dtProduto);
                return dtProduto;
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

        public void SalvarProduto(ProdutosModel produto)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                var query = "INSERT INTO Produtos (ProdutoID, NomeProduto, PrecoCusto, Lucro, PrecoDeVenda, Estoque, DataDeEntrada, Status, Referencia) VALUES (@ProdutoID, @NomeProduto, @PrecoCusto, @Lucro, @PrecoDeVenda, @Estoque, @DataDeEntrada, @Status, @Referencia)";
                using (var command = new SqlCeCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProdutoID", produto.ProdutoID);
                    command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                    command.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                    command.Parameters.AddWithValue("@Lucro", produto.Lucro);
                    command.Parameters.AddWithValue("@PrecoDeVenda", produto.PrecoDeVenda);
                    command.Parameters.AddWithValue("@Estoque", produto.Estoque);
                    command.Parameters.AddWithValue("@DataDeEntrada", produto.DataDeEntrada);
                    command.Parameters.AddWithValue("@Status", produto.Status);


                    command.Parameters.AddWithValue("@Referencia", produto.Referencia);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarEstoqueVenda(int produtoID, int quantidadeVendida)
        {
            using (var conn = Conexao.Conex())
            {
                string sql = "UPDATE Produtos SET Estoque = Estoque - @QuantidadeEmVendida WHERE ProdutoID = @ProdutoID";
                SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                cmd.Parameters.AddWithValue("@QuantidadeEmVendida", quantidadeVendida);
                cmd.Parameters.AddWithValue("@ProdutoID", produtoID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }




        public void AlterarProduto(ProdutosModel produto)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                var query = "UPDATE Produtos SET NomeProduto = @NomeProduto, PrecoCusto = @PrecoCusto, Lucro = @Lucro, PrecoDeVenda = @PrecoDeVenda, Estoque = @Estoque, DataDeEntrada = @DataDeEntrada, Status = @Status, Referencia = @Referencia WHERE ProdutoID = @ProdutoID";
                using (var command = new SqlCeCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProdutoID", produto.ProdutoID);
                    command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                    command.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                    command.Parameters.AddWithValue("@Lucro", produto.Lucro);
                    command.Parameters.AddWithValue("@PrecoDeVenda", produto.PrecoDeVenda);
                    command.Parameters.AddWithValue("@Estoque", produto.Estoque);
                    command.Parameters.AddWithValue("@DataDeEntrada", produto.DataDeEntrada);
                    command.Parameters.AddWithValue("@Status", produto.Status);

                    command.Parameters.AddWithValue("@Referencia", produto.Referencia);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

       

        public void ExcluirProduto(ProdutosModel produto)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                var query = "DELETE FROM Produtos WHERE ProdutoID = @ProdutoID";
                using (var command = new SqlCeCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProdutoID", produto.ProdutoID);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public ProdutosModel PesquisarPorCodigo(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {

                SqlCeCommand sql = new SqlCeCommand("SELECT * FROM Produtos WHERE Referencia LIKE '" + pesquisa + "%' ", conn);
                conn.Open();
                SqlCeDataReader datareader;
                ProdutosModel obj_Produto = new ProdutosModel();

                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    obj_Produto.ProdutoID = Convert.ToInt32(datareader["ProdutoID"]);
                    obj_Produto.NomeProduto = datareader["NomeProduto"].ToString();
                    obj_Produto.PrecoCusto = Convert.ToDecimal(datareader["PrecoCusto"]);
                    obj_Produto.Lucro = Convert.ToDecimal(datareader["Lucro"]);
                    obj_Produto.PrecoDeVenda = Convert.ToDecimal(datareader["PrecoDeVenda"]);
                    obj_Produto.Estoque = Convert.ToInt32(datareader["Estoque"]);
                    obj_Produto.DataDeEntrada = Convert.ToDateTime(datareader["DataDeEntrada"]);
                    obj_Produto.Status = datareader["Status"].ToString();
                    obj_Produto.Referencia = datareader["Referencia"].ToString();
                }
                return obj_Produto;
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

        public void AtualizarEstoque(int produtoID, int quantidade)
        {
            using (var conn = Conexao.Conex())
            {
                string sql = "UPDATE Produtos SET Estoque = Estoque + @Quantidade WHERE ProdutoID = @ProdutoID";
                SqlCeCommand cmd = new SqlCeCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                cmd.Parameters.AddWithValue("@ProdutoID", produtoID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable PesquisarProdutoPorNome(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT TOP (30) ProdutoID, Referencia, NomeProduto, PrecoCusto, Lucro, PrecoDeVenda, Estoque, DataDeEntrada, Status FROM Produtos WHERE NomeProduto LIKE @NomeProduto";


                //string sqlconn = "SELECT TOP (30) * FROM Cliente WHERE NomeCliente LIKE @NomeCliente";
                SqlCeCommand cmd = new SqlCeCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeProduto", nome);
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
        public DataTable PesquisarProdutoPorCodido(string codigo)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                
                string sqlconn = "SELECT TOP (30) ProdutoID, Referencia, NomeProduto, PrecoCusto, Lucro, PrecoDeVenda, Estoque, DataDeEntrada, Status FROM Produtos WHERE Referencia LIKE @Referencia";

                //string sqlconn = "SELECT TOP (30) * FROM Cliente WHERE NomeCliente LIKE @NomeCliente";
                SqlCeCommand cmd = new SqlCeCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@Referencia", codigo);
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
//Exemplo de como usar o DataTable
//var dataTable = Conexao.SQL_data_adapter(query);
//foreach (DataRow row in dataTable.Rows)
//{
//    var produto = new ProdutosModel
//    {

//        ProdutoID = Convert.ToInt32(row["ProdutoID"]),
//        NomeProduto = row["NomeProduto"].ToString(),
//        Descricao = row["Descricao"].ToString(),
//        PrecoCusto = Convert.ToDecimal(row["PrecoCusto"]),
//        Lucro = Convert.ToDecimal(row["Lucro"]),
//        PrecoDeVenda = Convert.ToDecimal(row["PrecoDeVenda"]),
//        QuantidadeEmEstoque = Convert.ToInt32(row["QuantidadeEmEstoque"]),
//        DataDeEntrada = Convert.ToDateTime(row["DataDeEntrada"]),
//        CategoriaID = Convert.ToInt32(row["CategoriaID"]),
//        FabricanteID = Convert.ToInt32(row["FabricanteID"]),
//        UnidadeDeMedida = row["UnidadeDeMedida"].ToString(),
//        Status = row["Status"].ToString(),
//        DataDeVencimento = Convert.ToDateTime(row["DataDeVencimento"]),
//        Imagem = (byte[])row["Imagem"],
//        FornecedorID = Convert.ToInt32(row["FornecedorID"])
//    };

//    produtos.Add(produto);
//
// 
/*Outro exemplo é:
 * private void PopularDataGridView()
{
    var produtos = produtosDAL.ListarProdutos();
    dataGridViewProdutos.DataSource = produtos;
}

 * */