using GVC.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace GVC.DALL
{
    public class VendaDAL
    {
        // Método para adicionar uma venda
        public void AddVenda(VendaModel venda)
        {
            using (var conn = Conexao.Conex())
            {
                string query = @"INSERT INTO Venda (VendaID, DataVenda, ClienteID, ValorTotal, FormaPgto) 
                             VALUES (@VendaID, @DataVenda, @ClienteID, @ValorTotal, @FormaPgto)";
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@VendaID", venda.VendaID);
                command.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                command.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                command.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                command.Parameters.AddWithValue("@FormaPgto", venda.FormaPgto);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para atualizar uma venda
        public void UpdateVenda(VendaModel venda)
        {
            using (var connection = Conexao.Conex())
            {
                string query = @"UPDATE Venda SET DataVenda = @DataVenda, ClienteID = @ClienteID, 
                             ValorTotal = @ValorTotal, FormaPgto = @FormaPgto 
                             WHERE VendaID = @VendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                command.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                command.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                command.Parameters.AddWithValue("@FormaPgto", venda.FormaPgto);
                command.Parameters.AddWithValue("@VendaID", venda.VendaID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para excluir uma venda
        public void DeleteVenda(int vendaId)
        {
            using (var connection = Conexao.Conex())
            {
                string query = "DELETE FROM Venda WHERE VendaID = @VendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", vendaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para obter uma venda pelo ID
        public VendaModel GetVenda(int vendaId)
        {
            using (var connection = Conexao.Conex())
            {
                string query = "SELECT * FROM Venda WHERE VendaID = @VendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", vendaId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new VendaModel
                        {
                            VendaID = int.Parse(reader["VendaID"].ToString()),
                            DataVenda = (DateTime)reader["DataVenda"],
                            ClienteID = (int)reader["ClienteID"],
                            ValorTotal = (decimal)reader["ValorTotal"],
                            FormaPgto = reader["FormaPgto"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        // Método para listar todas as vendas
        public DataTable ListarVenda()
        {
            using (var conn = Conexao.Conex())
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Venda", conn);
                SqlDataAdapter daUsuario = new SqlDataAdapter(comando);
                DataTable dtUsuario = new DataTable();
                daUsuario.Fill(dtUsuario);
                return dtUsuario;
            }
        }

        // Método para inserir itens da venda
        public void InserirVenda(ItemVendaModel itemVenda)
        {
            using (var connection = Conexao.Conex())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO ItemVenda (ItemVendaID, VendaID, ProdutoID, Quantidade, PrecoUnitario, Subtotal) 
                         VALUES (@ItemVendaID, @VendaID, @ProdutoID, @Quantidade, @PrecoUnitario, @Subtotal)";

                        using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ItemVendaID", itemVenda.ItemVendaID);
                            cmd.Parameters.AddWithValue("@VendaID", itemVenda.VendaID);
                            cmd.Parameters.AddWithValue("@ProdutoID", itemVenda.ProdutoID);
                            cmd.Parameters.AddWithValue("@Quantidade", itemVenda.Quantidade);
                            cmd.Parameters.AddWithValue("@PrecoUnitario", itemVenda.PrecoUnitario);
                            cmd.Parameters.AddWithValue("@Subtotal", itemVenda.Subtotal); // Adicionei o campo Subtotal

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Erro ao salvar as parcelas: {ex.Message}");
                    }
                }
            }
        }


        // Método para inserir parcelas
        public void InserirParcelas(ParcelaModel parcela)
        {
            using (var connection = Conexao.Conex())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO Parcela (ParcelaID, VendaID, NumeroParcela, DataVencimento, ValorParcela, ValorRecebido, SaldoRestante, Pago) 
                                 VALUES (@ParcelaID, @VendaID, @NumeroParcela, @DataVencimento, @ValorParcela, @ValorRecebido, @SaldoRestante, @Pago)";

                        using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ParcelaID", parcela.ParcelaID);
                            cmd.Parameters.AddWithValue("@VendaID", parcela.VendaID);
                            cmd.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
                            cmd.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
                            cmd.Parameters.AddWithValue("@ValorParcela", parcela.ValorParcela);
                            cmd.Parameters.AddWithValue("@ValorRecebido", parcela.ValorRecebido);
                            cmd.Parameters.AddWithValue("@SaldoRestante", parcela.SaldoRestante);
                            cmd.Parameters.AddWithValue("@Pago", parcela.Pago);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Erro ao salvar as parcelas: {ex.Message}");
                    }
                }
            }
        }



        //Criação de Relatórios
        PagamentoMODEL pagamento = new PagamentoMODEL();
        public DataTable RelatorioPagamento(int CodigoCliente)
        {
            using (var conn = Conexao.Conex())
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Pagamento WHERE ClienteID=" + CodigoCliente.ToString(), conn);
                SqlDataAdapter daUsuario = new SqlDataAdapter(comando);
                DataTable dtUsuario = new DataTable();
                daUsuario.Fill(dtUsuario);
                return dtUsuario;
            }
        }
        public DataTable VendaLocalizarPorCliente(int CodigoCliente)
        {
            using (var conn = Conexao.Conex())
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Venda WHERE ClienteID=" + CodigoCliente.ToString(), conn);
                SqlDataAdapter daUsuario = new SqlDataAdapter(comando);
                DataTable dtUsuario = new DataTable();
                daUsuario.Fill(dtUsuario);
                return dtUsuario;
            }
        }
    }
}