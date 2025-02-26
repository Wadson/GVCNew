using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GVC.View
{
    public partial class FrmInsertBancoSqlCompact : FrmModeloForm
    {
        public FrmInsertBancoSqlCompact()
        {
            InitializeComponent();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText(); // Obtém o texto da área de transferência
            string[] items = clipboardText.Split(new[] { Environment.NewLine }, StringSplitOptions.None); // Divide o texto em linhas

            // Adiciona cada item ao ListBox
            foreach (string item in items)
            {
                if (!string.IsNullOrWhiteSpace(item)) // Verifica se não é uma linha vazia
                {
                    listBoxScripts.Items.Add(item);
                }
            }
            // Atualiza a label com a quantidade de itens no ListBox
            lblQuantidade.Text = $"Quantidade: {listBoxScripts.Items.Count}";
        }
        private void InsertBancoSqlCompact()
        {
            using (var connection = Conexao.Conex())
            {
                try
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        var erros = new List<string>(); // Lista para registrar erros
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = listBoxScripts.Items.Count;
                        progressBar1.Value = 0;

                        foreach (var item in listBoxScripts.Items)
                        {
                            string query = item.ToString().Trim();

                            // Corrigir comandos inválidos adicionando "INSERT INTO" se necessário
                            if (!query.StartsWith("INSERT INTO", StringComparison.OrdinalIgnoreCase))
                            {
                                query = "INSERT INTO " + query;
                            }

                            try
                            {
                                // Criar e executar o comando SQL
                                using (SqlCommand cmd = new SqlCommand(query, connection, transaction))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                erros.Add($"Erro ao executar o comando: {query}\n{ex.Message}");
                            }
                            // Atualiza a progressBar após cada inserção
                            progressBar1.Value++;
                            Application.DoEvents(); // Mantém a interface responsiva
                        }

                        // Confirmar a transação se todos os comandos forem executados com sucesso
                        transaction.Commit();

                        // Exibir resumo dos erros, se houver
                        if (erros.Count > 0)
                        {
                            MessageBox.Show($"Scripts executados com {erros.Count} erros:\n\n" + string.Join("\n", erros));
                        }
                        else
                        {
                            MessageBox.Show("Todos os scripts foram executados com sucesso!");
                        }
                        // Reseta a progressBar após a execução
                        progressBar1.Value = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao executar os scripts: " + ex.Message);
                }
            }
        }

        // Método auxiliar para extrair o EstadoID do comando SQL
        private int ExtractEstadoIDFromQuery(string query)
        {
            // Regex ajustado para capturar o valor de EstadoID em diferentes formatos
            var match = System.Text.RegularExpressions.Regex.Match(query, @"EstadoID\s*,?\s*(\d+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return int.Parse(match.Groups[1].Value);
            }

            // Tentativa alternativa: procurar o valor na parte VALUES
            match = System.Text.RegularExpressions.Regex.Match(query, @"VALUES\s*\(\s*\d+\s*,\s*N?['""][^'""]+['""]\s*,\s*(\d+)",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return int.Parse(match.Groups[1].Value);
            }

            // Se ainda não encontrar, lançar uma exceção com mais detalhes
            throw new FormatException($"Não foi possível extrair o EstadoID do comando: {query}");
        }


        private void insertBancoSqlCompact4()
        {
            
            using (var connection = Conexao.Conex())
            {
                connection.Open();
                string[] queries =
                {            
                
                "INSERT INTO Cidade (CidadeID, NomeCidade, EstadoID, ibge) VALUES (3, N'Águia Branca', 8, 3200136);",
                // Adicione mais comandos aqui...
            };

                foreach (var query in queries)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
           InsertBancoSqlCompact();
        }
        private void VerificarDadosInseridos()
        {
            using (var connection = Conexao.Conex())
            {
                connection.Open();
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM SuaTabela", connection))
                {
                    int count = (int)cmd.ExecuteScalar();
                    MessageBox.Show("Total de registros na tabela: " + count);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            listBoxScripts.Items.Clear(); // Limpa todos os itens do ListView
            lblQuantidade.Text = "Quantidade: 0"; // Atualiza a label de quantidade, se aplicável
            progressBar1.Value = 0; // Reseta a progressBar, se estiver sendo usada
        }
    }
}
