using GVC.Relatorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using OfficeOpenXml; 
using ComponentFactory.Krypton.Toolkit;

namespace GVC.View
{
    public partial class FrmRelatorios : GVC.FrmModeloForm
    {
        public FrmRelatorios()
        {
            InitializeComponent();

            // Definindo o contexto de licença do EPPlus
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Para uso não comercial
                                                                        // ExcelPackage.LicenseContext = LicenseContext.Commercial; // Para uso comercial
        }
        public string clienteSelecionado { get; set; }//não serve para nada, só para preencher o parametro do construtor
        private void CalcularTotalDataGrid()
        {
            try
            {
                // Calcular o total dos valores Não pagos na coluna "SaldoRestante"
                decimal totalEmAberto = Utilitario.SomarValoresDataGrid(dgvContasReceber, "SaldoRestante");

                // Atualizar a label com o total calculado
                lblTotal.Text = $"R$ {totalEmAberto:F2}";


                // Calcular o total dos valores na coluna "ValorParcela"
                decimal totalPago = Utilitario.SomarValoresDataGrid(dgvContasReceber, "ValorRecebido");

                // Atualizar a label com o total calculado
                lblTotalRecebido.Text = $"R$ {totalPago:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular o total: " + ex.Message);
            }
        }
        // Chamando a função após carregar os dados no DataGridView

        private void PersonalizarDataGridView(DataTable dataTable)
        {
            // Define o DataTable como a fonte de dados do DataGridView
            dgvContasReceber.DataSource = dataTable;

            // Renomeia as colunas
            dgvContasReceber.Columns["NomeCliente"].HeaderText = "Cliente";
            dgvContasReceber.Columns["NumeroParcela"].HeaderText = "Parcela";
            dgvContasReceber.Columns["ValorParcela"].HeaderText = "Valor Parcela";
            dgvContasReceber.Columns["DataVencimento"].HeaderText = "Data Vencimento";
            dgvContasReceber.Columns["SaldoRestante"].HeaderText = "Saldo Restante";
            dgvContasReceber.Columns["ValorRecebido"].HeaderText = "Valor Recebido";            
            dgvContasReceber.Columns["Pago"].HeaderText = "Pago";
            dgvContasReceber.Columns["VendaID"].HeaderText = "Venda ID";

            // Oculta as colunas de CódigoID (se necessário)
            dgvContasReceber.Columns["VendaID"].Visible = false;
            dgvContasReceber.Columns["ParcelaID"].Visible = false;
            dgvContasReceber.Columns["ClienteID"].Visible = false;
            // Formata as colunas de valores no formato de moeda ("N2")            
            dgvContasReceber.Columns["ValorParcela"].DefaultCellStyle.Format = "N2";
            dgvContasReceber.Columns["SaldoRestante"].DefaultCellStyle.Format = "N2";
            dgvContasReceber.Columns["ValorRecebido"].DefaultCellStyle.Format = "N2";

            // Redimensiona automaticamente as colunas para ajustar ao conteúdo
            dgvContasReceber.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Alinhamento das colunas de valores
            dgvContasReceber.Columns["ValorParcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContasReceber.Columns["SaldoRestante"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContasReceber.Columns["ValorRecebido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContasReceber.Columns["NumeroParcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configura o DataGridView para exibir a coluna "Pago" como um checkbox
            dgvContasReceber.Columns["Pago"].ValueType = typeof(bool);

            // Habilita a seleção de linha inteira (FullRowSelect)
            dgvContasReceber.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Centralização dos cabeçalhos de todas as colunas
            foreach (DataGridViewColumn column in dgvContasReceber.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Colore as colunas de valores
            dgvContasReceber.Columns["ValorParcela"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvContasReceber.Columns["SaldoRestante"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            dgvContasReceber.Columns["ValorRecebido"].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
        }


        //1. Pesquisar por StatusGeral (Pago = @Pago)
        public DataTable PesquisarPorStatusGeral(bool pago)
        {
            string query = @"
                 SELECT
                    Parcela.ParcelaID,   
                    Parcela.ValorParcela, 
                    Parcela.NumeroParcela,   
                    Parcela.SaldoRestante,     
                    Parcela.DataVencimento, 
                    Parcela.VendaID,           
                    Parcela.Pago,              
                    Parcela.ValorRecebido,         
                    Cliente.ClienteID,              
                    Cliente.NomeCliente            
                FROM Parcela                          
                INNER JOIN Venda ON Parcela.VendaID = Venda.VendaID
                INNER JOIN Cliente ON Venda.ClienteID = Cliente.ClienteID
                WHERE Parcela.Pago = @Pago";

            using (var connection = Conexao.Conex())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Pago", pago);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        // Personaliza o DataGridView com o DataTable resultante
                        PersonalizarDataGridView(dataTable);
                        return dataTable;

                        CalcularTotalDataGrid();
                    }
                }
            }
        }
        // 2. Pesquisar por NomeCliente e StatusGeral (NomeCliente = @NomeCliente AND Pago = @Pago)

        public DataTable PesquisarPorNomeClienteEStatus(string nomeCliente, bool pago)
        {
            string query = @"
                 SELECT
                    Parcela.ParcelaID,   
                    Parcela.ValorParcela, 
                    Parcela.NumeroParcela,   
                    Parcela.SaldoRestante,     
                    Parcela.DataVencimento, 
                    Parcela.VendaID,           
                    Parcela.Pago,              
                    Parcela.ValorRecebido,         
                    Cliente.ClienteID,              
                    Cliente.NomeCliente            
                FROM Parcela                          
                INNER JOIN Venda ON Parcela.VendaID = Venda.VendaID
                INNER JOIN Cliente ON Venda.ClienteID = Cliente.ClienteID
                                WHERE Cliente.NomeCliente = @NomeCliente AND Parcela.Pago = @Pago";

            using (var connection = Conexao.Conex())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomeCliente", nomeCliente);
                    command.Parameters.AddWithValue("@Pago", pago);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        // Personaliza o DataGridView com o DataTable resultante
                        PersonalizarDataGridView(dataTable);
                        CalcularTotalDataGrid();
                        return dataTable;                       
                    }
                }
            }
        }

        public DataTable PesquisarPorPeriodoEStatus(DateTime dataInicial, DateTime dataFinal, bool pago)
        {
            string query = @"
                SELECT
                    Parcela.ParcelaID,   
                    Parcela.ValorParcela, 
                    Parcela.NumeroParcela,   
                    Parcela.SaldoRestante,     
                    Parcela.DataVencimento, 
                    Parcela.VendaID,           
                    Parcela.Pago,              
                    Parcela.ValorRecebido,         
                    Cliente.ClienteID,              
                    Cliente.NomeCliente            
                FROM Parcela                          
                INNER JOIN Venda ON Parcela.VendaID = Venda.VendaID
                INNER JOIN Cliente ON Venda.ClienteID = Cliente.ClienteID
                                WHERE Parcela.DataVencimento BETWEEN @DataInicial AND @DataFinal AND Parcela.Pago = @Pago";

            using (var connection = Conexao.Conex())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DataInicial", dataInicial);
                    command.Parameters.AddWithValue("@DataFinal", dataFinal);
                    command.Parameters.AddWithValue("@Pago", pago);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        // Personaliza o DataGridView com o DataTable resultante
                        PersonalizarDataGridView(dataTable);
                        CalcularTotalDataGrid();
                        return dataTable;                       
                    }
                }
            }
        }

        // 4. Pesquisar por Contas Vencidas (DataVencimento <= @DataVencimento)
        public DataTable PesquisarContasVencidas(DateTime dataVencimento)
        {
            string query = @"
                SELECT                    
                    Parcela.ParcelaID,   
                    Parcela.ValorParcela, 
                    Parcela.NumeroParcela,   
                    Parcela.SaldoRestante,     
                    Parcela.DataVencimento, 
                    Parcela.VendaID,           
                    Parcela.Pago,              
                    Parcela.ValorRecebido,         
                    Cliente.ClienteID,              
                    Cliente.NomeCliente            
                FROM Parcela                          
                INNER JOIN Venda ON Parcela.VendaID = Venda.VendaID
                INNER JOIN Cliente ON Venda.ClienteID = Cliente.ClienteID
                                    WHERE Parcela.DataVencimento <= @DataVencimento";

            using (var connection = Conexao.Conex())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DataVencimento", dataVencimento);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        // Personaliza o DataGridView com o DataTable resultante
                        PersonalizarDataGridView(dataTable);
                        CalcularTotalDataGrid();
                        return dataTable;                       
                    }
                }
            }
        }

        // 5. Pesquisar por Contas Não Vencidas (DataVencimento >= @DataVencimento)

        public DataTable PesquisarContasNaoVencidas(DateTime dataVencimento)
        {
            string query = @"
                SELECT
                    Parcela.ParcelaID,   
                    Parcela.ValorParcela, 
                    Parcela.NumeroParcela,   
                    Parcela.SaldoRestante,     
                    Parcela.DataVencimento, 
                    Parcela.VendaID,           
                    Parcela.Pago,              
                    Parcela.ValorRecebido,         
                    Cliente.ClienteID,              
                    Cliente.NomeCliente            
                FROM Parcela                          
                INNER JOIN Venda ON Parcela.VendaID = Venda.VendaID
                INNER JOIN Cliente ON Venda.ClienteID = Cliente.ClienteID
                                            WHERE Parcela.DataVencimento >= @DataVencimento";

            using (var connection = Conexao.Conex())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DataVencimento", dataVencimento);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        // Personaliza o DataGridView com o DataTable resultante
                        PersonalizarDataGridView(dataTable);
                        CalcularTotalDataGrid();
                        return dataTable;                       
                    }
                }
            }
        }

        private void ExportarExcel()
        {
            SaveFileDialog salvar = new SaveFileDialog();
            salvar.Filter = "Arquivo Excel (*.xlsx)|*.xlsx";
            salvar.Title = "Salvar como Excel";

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(salvar.FileName);

                // Cria o pacote Excel
                using (var pacote = new ExcelPackage(fileInfo))
                {
                    // Cria uma nova planilha
                    var planilha = pacote.Workbook.Worksheets.Add("Dados");

                    // Preenche o cabeçalho (primeira linha)
                    for (int col = 0; col < dgvContasReceber.Columns.Count; col++)
                    {
                        planilha.Cells[1, col + 1].Value = dgvContasReceber.Columns[col].HeaderText;
                    }

                    // Preenche os dados
                    for (int row = 0; row < dgvContasReceber.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvContasReceber.Columns.Count; col++)
                        {
                            // Verifica se a célula não é nula
                            if (dgvContasReceber.Rows[row].Cells[col].Value != null)
                            {
                                planilha.Cells[row + 2, col + 1].Value = dgvContasReceber.Rows[row].Cells[col].Value.ToString();
                            }
                        }
                    }

                    // Salva o arquivo Excel
                    pacote.Save();
                }

                MessageBox.Show("Arquivo Excel salvo com sucesso!");
            }
        }
        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Oculta todos os GroupBox inicialmente
            gbStatus.Visible = false;
            gbPeriodo.Visible = false;
            gbNomeCliente.Visible = false;

            // Obtém o método selecionado no ComboBox
            string metodoSelecionado = cmbFiltro.SelectedItem?.ToString();

            // Habilita os GroupBox necessários conforme o método selecionado
            switch (metodoSelecionado)
            {
                case "PesquisarPorStatusGeral":
                    gbStatus.Visible = true; // Apenas o GroupBox de Status é necessário
                    btnFiltro.Visible = true;                    
                    break;

                case "PesquisarPorNomeClienteEStatus":
                    gbStatus.Visible = true; // Status e Nome do Cliente são necessários
                    gbNomeCliente.Visible = true;
                    btnFiltro.Visible = true;
                    break;

                case "PesquisarPorPeriodoEStatus":
                    gbStatus.Visible = true; // Status e Período são necessários
                    gbPeriodo.Visible = true;
                    btnFiltro.Visible = true;
                    break;

                case "PesquisarContasVencidas":
                case "PesquisarContasNaoVencidas":
                    // Nenhum GroupBox é necessário, pois o filtro é baseado apenas na data atual
                    break;

                default:                    
                    break;
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            // Limpa o DataGridView antes de aplicar um novo filtro
            dgvContasReceber.DataSource = null;
            dgvItensVenda.DataSource = null;

            // Obtém o método selecionado no ComboBox
            string metodoSelecionado = cmbFiltro.SelectedItem?.ToString();

            // Variável para armazenar o resultado da pesquisa
            DataTable resultado = null;

            // Executa o método de pesquisa correspondente ao item selecionado no ComboBox
            switch (metodoSelecionado)
            {
                case "PesquisarPorStatusGeral":
                    if (gbStatus.Visible) // Verifica se o GroupBox está visível
                    {
                        bool status = rbPago.Checked; // true para "Pago", false para "Não Pago"
                        resultado = PesquisarPorStatusGeral(status);
                    }
                    break;

                case "PesquisarPorNomeClienteEStatus":
                    if (gbStatus.Visible && gbNomeCliente.Visible) // Verifica se os GroupBox estão visíveis
                    {
                        string nomeCliente = txtNomeCliente.Text;
                        bool statusCliente = rbPago.Checked; // true para "Pago", false para "Não Pago"
                        resultado = PesquisarPorNomeClienteEStatus(nomeCliente, statusCliente);
                    }
                    break;

                case "PesquisarPorPeriodoEStatus":
                    if (gbStatus.Visible && gbPeriodo.Visible) // Verifica se os GroupBox estão visíveis
                    {
                        DateTime dataInicio = dtpDataVencimentoInicio.Value;
                        DateTime dataFim = dtpDataVencimentoFim.Value;
                        bool statusPeriodo = rbPago.Checked; // true para "Pago", false para "Não Pago"
                        resultado = PesquisarPorPeriodoEStatus(dataInicio, dataFim, statusPeriodo);
                    }
                    break;

                case "PesquisarContasVencidas":
                    resultado = PesquisarContasVencidas(DateTime.Now);
                    break;

                case "PesquisarContasNaoVencidas":
                    resultado = PesquisarContasNaoVencidas(DateTime.Now);
                    break;

                default:
                    MessageBox.Show("Selecione um método válido.");
                    break;
            }

            // Exibe o resultado no DataGridView
            if (resultado != null)
            {
                dgvContasReceber.DataSource = resultado;
                dgvItensVenda.DataSource = null; // Limpa o DataGridView de Itens de Venda
            }
            else
            {
                MessageBox.Show("Nenhum resultado encontrado ou parâmetros inválidos.");
            }
        }

        private void FrmRelatorios_Load(object sender, EventArgs e)
        {
            // Define o primeiro item como selecionado por padrão (opcional)
            if (cmbFiltro.Items.Count > 0)
            {
                cmbFiltro.SelectedIndex = 0;
            }
        }


        private void AbrirFrmLocalizarCliente()
        {
                 // Cria uma instância do frmLocalizarCliente e define o Owner como o FrmPedidoVendaNovo
            FrmLocalizarCliente frmLocalizarCliente = new FrmLocalizarCliente(this, clienteSelecionado)
            {
                Owner = this
            };
            frmLocalizarCliente.ShowDialog();
            frmLocalizarCliente.Text = "Localizar Clientes";
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {            
        }
        public void ExportarParaPDF(KryptonDataGridView dgv, string caminhoArquivo)
        {
            try
            {
                // Criando o documento PDF
                Document documento = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter.GetInstance(documento, new FileStream(caminhoArquivo, FileMode.Create));
                documento.Open();

                // Criando a tabela com base no número de colunas do DataGridView
                PdfPTable tabela = new PdfPTable(dgv.ColumnCount);
                tabela.WidthPercentage = 100;

                // Adicionando cabeçalhos
                foreach (DataGridViewColumn coluna in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(coluna.HeaderText));
                    cell.BackgroundColor = new BaseColor(240, 240, 240); // Cinza claro
                    tabela.AddCell(cell);
                }

                // Adicionando as linhas da tabela
                foreach (DataGridViewRow linha in dgv.Rows)
                {
                    if (!linha.IsNewRow) // Ignorar linha vazia
                    {
                        foreach (DataGridViewCell celula in linha.Cells)
                        {
                            tabela.AddCell(celula.Value?.ToString() ?? ""); // Adiciona os valores, evitando valores nulos
                        }
                    }
                }

                // Adicionando a tabela ao documento e fechando o PDF
                documento.Add(tabela);
                documento.Close();

                MessageBox.Show("PDF gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            SaveFileDialog salvar = new SaveFileDialog();
            salvar.Filter = "Arquivo PDF|*.pdf";
            salvar.Title = "Salvar como PDF";

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                ExportarParaPDF(dgvContasReceber, salvar.FileName);                
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void dgvPesquisar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvContasReceber.SelectedRows.Count > 0)
            {
                int vendaID = Convert.ToInt32(dgvContasReceber.SelectedRows[0].Cells["VendaID"].Value);
                CarregarItensVenda(vendaID);
            }
        }
        private void PersonalizarDataGridView()
        {
            //// Auto redimensionamento das colunas
            //dgvItensVenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Redimensiona automaticamente as colunas para ajustar ao conteúdo
            dgvItensVenda.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Centralização dos campos "Referencia" e "Quantidade"
            dgvItensVenda.Columns["Referencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItensVenda.Columns["Quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Formatação em moeda para "PrecoUnitario" e "Subtotal"
            dgvItensVenda.Columns["PrecoUnitario"].DefaultCellStyle.Format = "C2"; // Formato moeda
            dgvItensVenda.Columns["Subtotal"].DefaultCellStyle.Format = "C2"; // Formato moeda

            // Centralização dos cabeçalhos de todas as colunas
            foreach (DataGridViewColumn column in dgvItensVenda.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // Chame o método PersonalizarDataGridView após definir a fonte de dados do dgvItensVenda
        private void CarregarItensVenda(int vendaID)
        {
            string query = @"SELECT Produtos.Referencia, Produtos.NomeProduto, ItemVenda.Quantidade, 
                        ItemVenda.PrecoUnitario, 
                        (ItemVenda.Quantidade * ItemVenda.PrecoUnitario) AS Subtotal
                 FROM ItemVenda 
                 INNER JOIN Produtos ON ItemVenda.ProdutoID = Produtos.ProdutoID 
                 WHERE VendaID = @VendaID";


            using (var connection = Conexao.Conex())
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@VendaID", vendaID);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvItensVenda.DataSource = dataTable;

                // Personalize o DataGridView após definir a fonte de dados
                PersonalizarDataGridView();
            }
        }


        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            AbrirFrmLocalizarCliente();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
