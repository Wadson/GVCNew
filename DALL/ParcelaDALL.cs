using GVC.MODEL;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlServerCe;


namespace GVC.DALL
{
    public class ParcelaDAL
    {
        // Método para adicionar uma parcela
      
        // Método para atualizar uma parcela
        public void UpdateParcela(ParcelaModel parcela)
        {
            using (var connection = Conexao.Conex())
            {
                string query = @"UPDATE Parcela SET DataVencimento = @DataVencimento, ValorParcela = @ValorParcela, 
                             ValorRecebido = @ValorRecebido, SaldoRestante = @SaldoRestante, Pago = @Pago 
                             WHERE ParcelaID = @ParcelaID";
                SqlCeCommand command = new SqlCeCommand(query, connection);
                command.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
                command.Parameters.AddWithValue("@ValorParcela", parcela.ValorParcela);
                command.Parameters.AddWithValue("@ValorRecebido", parcela.ValorRecebido);
                command.Parameters.AddWithValue("@SaldoRestante", parcela.SaldoRestante);
                command.Parameters.AddWithValue("@Pago", parcela.Pago);
                command.Parameters.AddWithValue("@ParcelaID", parcela.ParcelaID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para excluir uma parcela
        public void DeleteParcela(int parcelaId)
        {
            using (var connection = Conexao.Conex())
            {
                string query = "DELETE FROM Parcela WHERE ParcelaID = @ParcelaID";
                SqlCeCommand command = new SqlCeCommand(query, connection);
                command.Parameters.AddWithValue("@ParcelaID", parcelaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para obter parcelas por VendaID
        public List<ParcelaModel> GetParcelas(int vendaId)
        {
            List<ParcelaModel> parcelas = new List<ParcelaModel>();
            using (var connection = Conexao.Conex())
            {
                string query = "SELECT * FROM Parcela WHERE VendaID = @VendaID";
                SqlCeCommand command = new SqlCeCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", vendaId);

                connection.Open();
                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        parcelas.Add(new ParcelaModel
                        {
                            ParcelaID = Convert.ToInt32(reader["ParcelaID"]),
                            VendaID = Convert.ToInt32(reader["VendaID"]),
                            NumeroParcela = Convert.ToInt32(reader["NumeroParcela"]),
                            DataVencimento = Convert.ToDateTime(reader["DataVencimento"]),
                            ValorParcela = Convert.ToDecimal(reader["ValorParcela"]),
                            ValorRecebido = Convert.ToDecimal(reader["ValorRecebido"]),
                            SaldoRestante = Convert.ToDecimal(reader["SaldoRestante"]),
                            Pago = Convert.ToBoolean(reader["Pago"])
                        });
                    }
                }
            }
            return parcelas;
        }

        // Método para listar todas as parcelas
        public DataTable ListarParcelas()
        {
            using (var conn = Conexao.Conex())
            {
                SqlCeCommand comando = new SqlCeCommand("SELECT * FROM Parcela", conn);
                SqlCeDataAdapter daParcela = new SqlCeDataAdapter(comando);
                DataTable dtParcela = new DataTable();
                daParcela.Fill(dtParcela);
                return dtParcela;
            }
        }

        // Método para salvar múltiplas parcelas

        public void InsertParcela(ParcelaModel parcela)
        {
            try
            {
                using (SqlCeConnection connection = Conexao.Conex()) // Obtém a conexão do SQL Server Express
                {
                    connection.Open();
                    using (SqlCeCommand cmd = new SqlCeCommand(@"
                INSERT INTO Parcela 
                (ParcelaID, VendaID, NumeroParcela, DataVencimento, ValorParcela, ValorRecebido, SaldoRestante, Pago) 
                VALUES 
                (@ParcelaID, @VendaID, @NumeroParcela, @DataVencimento, @ValorParcela, @ValorRecebido, @SaldoRestante, @Pago)", connection))
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
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar parcela: {ex.Message}");
            }
        }




    }
}