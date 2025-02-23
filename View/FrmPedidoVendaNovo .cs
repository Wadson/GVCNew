using GVC.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using GVC;
using System.IO;
using ComponentFactory.Krypton.Toolkit;
using System.Transactions;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using GVC.DALL;
using GVC.BLL;
using System.Threading;



namespace GVC.View
{
    public partial class FrmPedidoVendaNovo : GVC.FrmModeloForm
    {
        private string QueryVendas = "SELECT MAX(VendaID) FROM Venda";
        private string QueryItensVenda = "SELECT MAX(ItemVendaID) FROM ItemVenda";
        private string QueryParcela = "SELECT MAX(ParcelaID) FROM Parcela";        
        private string QueryFormaPgto = "SELECT NomeFormaPgto, FormaPgtoID FROM FormaPgto";
        
        private int nextItemVendaID;

        public int ClienteID { get; set; }
        public string formaPgto { get; set; }
        public int VendaID { get; set; }
        public int ItemVendaID { get; set; }
        public int ContaReceberID { get; set; }
        public int ParcelaID { get; set; }
        public int ProdutoID { get; set; }
        public string connectionString { get; set; }   //implementado 10/01/2025 
        public string clienteSelecionado { get; set; }//não serve para nada só para preencher o parametro do construtor
        public decimal valorTotal { get; set; }
        public int numeroParcelas = 1;
        private bool bloqueiaPesquisa = false;


        public FrmPedidoVendaNovo()
        {
            InitializeComponent();

            Utilitario.AdicionarEfeitoFocoEmTodos(this);
            //Centraliza o Label dentro do Panel
            label28.Location = new Point(
                (kryptonPanel2.Width - label28.Width) / 2,
                (kryptonPanel2.Height - label28.Height) / 2);

            nextItemVendaID = Utilitario.GerarNovoCodigoID("ItemVendaID", "ItemVenda");

            // Registrar o evento KeyDown
            
            // Definir os valores iniciais dos TextBox
            txtValorProduto.Text = "0,00";
            txtValorRecebido.Text = "0,00";
            txtSubTotal.Text = "0,00";
            txtQuantidade.Text = "1";

            InicializarDataGridViewItensVenda();

            // Configura o evento de clique no DataGridView
            dgvItensVenda.CellClick += dgvItensVenda_CellClick;
            

            txtQuantidade.Leave += new EventHandler(txtQuantidade_Leave);
            txtValorProduto.Leave += new EventHandler(txtValorProduto_Leave); 
            txtValorRecebido.Leave += new EventHandler(txtValorRecebido_Leave);
        }
        // Método para excluir a linha selecionada


        private void ContarLinhasComDados()
        {
            int numeroDeLinhasComDados = dgvItensVenda.Rows.Cast<DataGridViewRow>().Count(row => !row.IsNewRow);            
            txtQtdItens.Text = numeroDeLinhasComDados.ToString();
        }

        private void ExcluirItemSelecionado()
        {
            if (dgvItensVenda.SelectedRows.Count > 0)
            {
                // Confirmar exclusão
                var confirmResult = MessageBox.Show(
                    "Tem certeza de que deseja excluir o(s) item(ns) selecionado(s)?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Iterar pelas linhas selecionadas e removê-las
                    foreach (DataGridViewRow linha in dgvItensVenda.SelectedRows)
                    {
                        if (!linha.IsNewRow)
                        {
                            dgvItensVenda.Rows.Remove(linha);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InicializarDataGridViewItensVenda()
        {
            DataTable dt = new DataTable();

            // Definir colunas no DataTable
            dt.Columns.Add("ItemVendaID", typeof(int));         // ID do item (código incremental)
            dt.Columns.Add("NomeProduto", typeof(string));     // Nome ou descrição do produto
            dt.Columns.Add("ProdutoID", typeof(int));          // Código do produto
            dt.Columns.Add("Quantidade", typeof(int));         // Quantidade do produto
            dt.Columns.Add("ValorProduto", typeof(decimal));   // Valor unitário do produto
            dt.Columns.Add("SubTotal", typeof(decimal));       // Subtotal (Quantidade x ValorProduto)

            dgvItensVenda.DataSource = dt;

            // Renomear colunas no DataGridView
            dgvItensVenda.Columns["ItemVendaID"].HeaderText = "Cód. Item";
            dgvItensVenda.Columns["NomeProduto"].HeaderText = "Descrição do Produto";
            dgvItensVenda.Columns["ProdutoID"].HeaderText = "Cód. Prod.";
            dgvItensVenda.Columns["Quantidade"].HeaderText = "Qtd.";
            dgvItensVenda.Columns["ValorProduto"].HeaderText = "Valor Unitário";
            dgvItensVenda.Columns["SubTotal"].HeaderText = "Subtotal";

            // Centralizar colunas específicas
            dgvItensVenda.Columns["Quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItensVenda.Columns["ProdutoID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Centralizar cabeçalhos das colunas
            foreach (DataGridViewColumn column in dgvItensVenda.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Ajustar colunas manualmente
            dgvItensVenda.Columns["NomeProduto"].Width = 400;    // Exemplo de ajuste de largura da coluna NomeProduto
            dgvItensVenda.Columns["Quantidade"].Width = 100;      // Exemplo de ajuste de largura da coluna Quantidade
            dgvItensVenda.Columns["ValorProduto"].Width = 120;   // Exemplo de ajuste de largura da coluna ValorProduto
            dgvItensVenda.Columns["SubTotal"].Width = 120;       // Exemplo de ajuste de largura da coluna SubTotal

            // Tornar o grid somente leitura
            dgvItensVenda.ReadOnly = true;

            // Ocultar a coluna ItemVendaID
            dgvItensVenda.Columns["ItemVendaID"].Visible = false;
            dgvItensVenda.Columns["ProdutoID"].Visible = false;
        }



        private void IncluirItens()
        {
            try
            {
                string NomeProduto = txtNomeProduto.Text;
                int _ProdutoID = ProdutoID;
                int Quantidade = int.Parse(txtQuantidade.Text);
                decimal ValorProduto = decimal.Parse(txtValorProduto.Text);
                decimal SubTotal = Quantidade * ValorProduto;

                // Obter a fonte de dados do DataGridView
                DataTable dt = dgvItensVenda.DataSource as DataTable;

                if (dt == null)
                {
                    MessageBox.Show("A fonte de dados do DataGridView não está configurada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar se o produto já existe no DataTable
                DataRow linhaExistente = null;
                foreach (DataRow row in dt.Rows)
                {
                    if (row.Field<int>("ProdutoID") == _ProdutoID) // Substitua "ProdutoID" pelo nome exato da coluna no DataTable
                    {
                        linhaExistente = row;
                        break;
                    }
                }

                if (linhaExistente != null)
                {
                    // Produto já existe, atualizar quantidade e subtotal
                    int quantidadeAtual = linhaExistente.Field<int>("Quantidade");
                    linhaExistente["Quantidade"] = quantidadeAtual + Quantidade;
                    linhaExistente["SubTotal"] = (quantidadeAtual + Quantidade) * ValorProduto;
                }
                else
                {
                    // Produto não existe, adicionar nova linha na ordem correta
                    dt.Rows.Add(nextItemVendaID++, NomeProduto, _ProdutoID, Quantidade, ValorProduto, SubTotal);
                }

                // Atualizar o subtotal total (soma dos subtotais de todos os itens)
                SomarSubtotal();
                ContarLinhasComDados();
                // Limpar os campos
                txtValorProduto.Text = "0,00";
                txtValorRecebido.Text = "0,00";
                txtSubTotal.Text = "0,00";
                txtQuantidade.Text = "1";
                txtNomeProduto.Text = "";
                txtNomeProduto.Select();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir os dados no DataGridView: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PreencherTextBoxComLinhaSelecionada()
        {
            try
            {
                // Verifica se há uma linha selecionada no DataGridView
                if (dgvItensVenda.SelectedRows.Count > 0)
                {
                    // Obtém a linha selecionada
                    DataGridViewRow linhaSelecionada = dgvItensVenda.SelectedRows[0];

                    // Preenche os TextBox com os valores da linha selecionada
                    txtNomeProduto.Text = linhaSelecionada.Cells["NomeProduto"].Value.ToString();
                    ProdutoID = Convert.ToInt32(linhaSelecionada.Cells["ProdutoID"].Value);
                    txtQuantidade.Text = linhaSelecionada.Cells["Quantidade"].Value.ToString();
                    txtValorProduto.Text = linhaSelecionada.Cells["ValorProduto"].Value.ToString();

                    // Calcula e exibe o subtotal (opcional, dependendo da sua lógica)
                    decimal valorProduto = Convert.ToDecimal(linhaSelecionada.Cells["ValorProduto"].Value);
                    int quantidade = Convert.ToInt32(linhaSelecionada.Cells["Quantidade"].Value);
                    decimal subTotal = valorProduto * quantidade;
                    txtSubTotal.Text = subTotal.ToString("N2");
                }
                else
                {
                    MessageBox.Show("Nenhuma linha selecionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preencher os TextBox: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NovoCodigo()
        {
            // Gera novos Códigos para as chaves primárias
            VendaID = Utilitario.GerarNovoCodigoID("VendaID", "Venda");
            ItemVendaID = Utilitario.GerarNovoCodigoID("ItemVendaID", "ItemVenda");           
            ParcelaID = Utilitario.GerarNovoCodigoID("ParcelaID", "Parcela");

            txtVendaID.Text = VendaID.ToString();

            txtQuantidade.Leave += txtQuantidade_Leave;
            txtValorProduto.Leave += txtValorProduto_Leave;
            txtNomeCliente.Select();
        }

        private void LimparFormulario()
        {
            try
            {
                ResetarCamposTexto();

                VendaID = 0;
                ClienteID = 0;
                ProdutoID = 0;
                ContaReceberID = 0;
                ParcelaID = 0;
                nextItemVendaID = 0;

                // Chamar NovoCodigo para redefinir o estado inicial
                NovoCodigo();
            }
            catch (Exception ex)
            {
                Log($"Erro ao limpar o formulário: {ex.Message}");
                MessageBox.Show($"Erro ao limpar o formulário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetarCamposTexto()
        {
            txtValorProduto.Text = "0,00";
            txtValorRecebido.Text = "0,00";
            txtSubTotal.Text = "0,00";
            txtQuantidade.Text = "1";
            txtNomeProduto.Text = "";
            txtNomeCliente.Text = "";
           
            txtValorTotal.Text = "0,00";
            formaPgto  = "";
            txtVendaID.Text = "";
            txtQtdItens.Text = "0";
            dtpDataVenda.Value = DateTime.Now;
            dtpVencimento.Value = DateTime.Now;
        }

        private void LimparDataGridView(KryptonDataGridView dgv)
        {
            if (dgv.DataSource is DataTable dt)
            {
                dt.Clear(); // Limpa o DataTable diretamente
            }
            else
            {
                dgv.Rows.Clear(); // Limpa as linhas manualmente
            }
        }



        private void SomarSubtotal()
        {
            decimal somaSubtotal = 0;

            foreach (DataGridViewRow row in dgvItensVenda.Rows)
            {
                // Verifica se a célula não é nula e converte o valor para decimal
                if (row.Cells["Subtotal"].Value != null && decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal valor))
                {
                    somaSubtotal += valor;
                }
            }
            // Exibe o resultado em um TextBox ou Label
            txtValorTotal.Text = somaSubtotal.ToString("N2"); // ou lblSomaSubtotal.Text
        }


        private void Habilitabotoes()
        {
            if (radiobtnAVista.Checked)
            {
                // Se for à vista, habilita o botão FinalizarVenda e desabilita o Parcelar
                btnFinalizarVenda.Enabled = true;
                btnParcelar.Enabled = false;
            }
            else if (radiobtnParcelado.Checked)
            {
                // Se for parcelado, habilita o botão Parcelar e desabilita o FinalizarVenda
                btnFinalizarVenda.Enabled = false;
                btnParcelar.Enabled = true;
            }
        }
        private void FrmVendas_Load(object sender, EventArgs e)
        {
            NovoCodigo();
           Habilitabotoes();
        }
        public void ToMoney(KryptonTextBox text, string format = "N")
        {
            if (decimal.TryParse(text.Text, out decimal value))
            {
                text.Text = value.ToString(format);
            }
            else
            {
                text.Text = "0,00";
            }
        }
        private void TirarZeroEsquerda(System.Windows.Forms.TextBox tx)
        {
            string valor = tx.Text;
            string NovoValorSemZero = valor.TrimStart('0');
            tx.Text = NovoValorSemZero;
        }

        private void LocalizarProduto()
        {
            // Cria uma instância do FrmLocalizarProduto e define o Owner como o FrmVendas
            FrmLocalizarProduto frmLocalizarProduto = new FrmLocalizarProduto(this, txtNomeProduto.Text)
            {
                Owner = this,
                produtoSelecionado = txtNomeProduto.Text
            };
            frmLocalizarProduto.ShowDialog();
            frmLocalizarProduto.Text = "Localizar Produtos";

            ToMoney(txtValorProduto);
            ToMoney(txtValorTotal);
            txtQuantidade.Focus();
            CalcularSubtotal();
        }

        // Verifica se os datagrids estão vazios
        private bool ValidarGridsPreenchidos()
        {
            // Verifica se o DataGridView de itens da venda está vazio
            if (dgvItensVenda.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum item foi adicionado à venda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true; // Ambos os DataGridViews possuem dados
        }

    

      
      
       

        private void btnParcelar_Click(object sender, EventArgs e)
        {
        }

        private void AbrirFrmLocalizarClienteDinamico()
        {
            // Cria uma instância do frmLocalizarCliente e define o Owner como o FrmPedidoVendaNovo
            FrmLocalizarCliente frmLocalizarCliente = new FrmLocalizarCliente(this, clienteSelecionado)
            {
                Owner = this
            };
            frmLocalizarCliente.ShowDialog();
            frmLocalizarCliente.Text = "Localizar Clientes";
        }





        public void CalcularSubtotal()
        {
            try
            {
                if (decimal.TryParse(txtQuantidade.Text, out decimal quantidade) &&
                    decimal.TryParse(txtValorProduto.Text, out decimal precoUnitario) &&
                    decimal.TryParse(txtValorRecebido.Text, out decimal valorRecebido))
                {
                    decimal subtotal = (quantidade * precoUnitario) - valorRecebido;
                    txtSubTotal.Text = subtotal.ToString("N2");
                }
                else
                {
                    txtSubTotal.Text = "0.00";
                    MessageBox.Show("Por favor, preencha todos os campos corretamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }
        private void Log(string message)
        {
            File.AppendAllText("log.txt", $"{DateTime.Now}: {message}\n");
        }
        // Exemplo de uso do método Log
        private void ProcessarVenda()
        {
            try
            {
                // Código de processamento...
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show("Ocorreu um erro ao processar a venda.");
            }
        }
        // Exemplo de uso do método LerLog
        private void LerLog()
        {
            if (File.Exists("log.txt"))
            {
                string[] linhasDoLog = File.ReadAllLines("log.txt");
                foreach (string linha in linhasDoLog)
                {
                    Console.WriteLine(linha);
                }
            }
        }

        private void txtNomeCliente_KeyUp(object sender, KeyEventArgs e)
        {
            //string textoDigitado = txtNomeCliente.Text;

            //// Abre o formulário de pesquisa se ao menos uma letra for digitada
            //if (!string.IsNullOrWhiteSpace(textoDigitado))
            //{
            //    FrmLocalizarCliente frmLocalizar = new FrmLocalizarCliente(this)
            //    {
            //        txtPesquisa = { Text = textoDigitado } // Passa as letras digitadas
            //    };

            //    frmLocalizar.ShowDialog(); // Exibe o formulário como modal

            //    // Atualiza o campo com o cliente selecionado
            //    if (!string.IsNullOrWhiteSpace(frmLocalizar.nomeCliente))
            //    {
            //        txtNomeCliente.Text = frmLocalizar.nomeCliente;                   
            //    }
            //}
        }

        private void txtQuantidade_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
            {
                txtQuantidade.Text = "0";
            }
            CalcularSubtotal();
        }

        private void txtValorProduto_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValorProduto.Text))
            {
                txtValorProduto.Text = "0,00";
            }
            CalcularSubtotal();
        }

        private void txtValorRecebido_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValorRecebido.Text))
            {
                txtValorRecebido.Text = "0,00";
            }
            CalcularSubtotal();
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void txtValorProduto_Leave(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void txtValorRecebido_Leave(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void AbrirFormParcelar()
        {
            ParcelaID = Utilitario.GerarNovoCodigoID("ParcelaID", "Parcela");

            FrmGerarParcelas gerarparc = new FrmGerarParcelas(this, VendaID, valorTotal)
            {
                parcelaID = ParcelaID
            };

            gerarparc.vendaID = int.Parse(txtVendaID.Text);
            gerarparc.txtTotal.Text = txtValorTotal.Text;
            gerarparc.txtQtdParcelas.Text = "2";

            if (gerarparc.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Parcelas geradas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
        private void dgvItensVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ExcluirItemSelecionado();
            }
        }

        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            AbrirFrmLocalizarClienteDinamico();
        }

        private void btnLocalizarProduto_Click(object sender, EventArgs e)
        {
            LocalizarProduto();
        }

        private void FrmPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                AbrirFrmLocalizarClienteDinamico();
            }
            if (e.KeyCode == Keys.F5)
            {
                LocalizarProduto();
            }
            if (e.KeyCode == Keys.F2)
            {
                AbrirFormParcelar();
            }
        }

        private void dgvItensVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica se o clique foi em uma linha válida
            {
                PreencherTextBoxComLinhaSelecionada();
            }
        }

        private int ObterUltimaParcelaID(SqlCeConnection connection, SqlCeTransaction transaction)
        {
            string query = "SELECT MAX(ParcelaID) FROM Parcela WHERE VendaID = @VendaID";
            using (SqlCeCommand cmd = new SqlCeCommand(query, connection, transaction))
            {
                cmd.Parameters.Add("@VendaID", SqlDbType.Int).Value = VendaID;
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }




        public bool FinalizarVenda()
        {
            // Verifica a forma de pagamento
            if (radiobtnAVista.Checked)
            {
                formaPgto = "A Vista";
            }
            else if (radiobtnParcelado.Checked)
            {
                formaPgto = "Parcelado";
            }
            else
            {
                MessageBox.Show("Selecione a forma de pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Gera um novo ID para a venda
            VendaID = Utilitario.GerarNovoCodigoID("VendaID", "Venda");

            // Criar objeto de venda com o ID gerado
            VendaModel venda = new VendaModel
            {
                VendaID = VendaID, // Define o ID gerado manualmente
                ClienteID = ClienteID,
                DataVenda = DateTime.Now,
                ValorTotal = Convert.ToDecimal(txtValorTotal.Text),
                FormaPgto = formaPgto,
            };

            // Salvar a venda no banco de dados usando o ID gerado
            VendaDAL vendaDAL = new VendaDAL();
            vendaDAL.AddVenda(venda);

            // Verifica se a venda foi salva corretamente
            if (VendaID <= 0)
            {
                MessageBox.Show("Erro ao salvar a venda!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Salvar os itens da venda
            SalvarItensVenda(VendaID);

            // Se for à vista, gera apenas uma parcela e finaliza a venda
            if (radiobtnAVista.Checked)
            {
                SalvarParcela(VendaID, venda.ValorTotal);
                MessageBox.Show("Venda finalizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparDataGridView(dgvItensVenda);
                return true;
            }

            return true;
        }

        private void SalvarParcela(int vendaID, decimal valorTotal)
        {
            decimal valorRecebido = decimal.Parse(txtValorTotal.Text);

            try
            {
                ParcelaDAL parcelaDAL = new ParcelaDAL();

                // Cria uma única parcela com vencimento imediato e a forma de pagamento definida
                ParcelaModel parcela = new ParcelaModel
                {
                    ParcelaID = Utilitario.GerarNovoCodigoID("ParcelaID", "Parcela"),
                    VendaID = vendaID,
                    NumeroParcela = 1,
                    DataVencimento = DateTime.Now, // Pagamento imediato
                    ValorParcela = valorTotal,
                    ValorRecebido = valorRecebido,
                    SaldoRestante = valorTotal - valorRecebido,
                    Pago = valorRecebido >= valorTotal // Define como pago se o valor recebido for suficiente
                };

                parcelaDAL.InsertParcela(parcela);

                MessageBox.Show("Parcela salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar a parcela: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalvarItensVenda(int vendaID)
        {
            ItemVendaDAL itemVendaDAL = new ItemVendaDAL();
            DALL.ProdutosDal produtoDAL = new DALL.ProdutosDal(); // Instância para atualizar o estoque

            foreach (DataGridViewRow row in dgvItensVenda.Rows)
            {
                if (row.Cells["ItemVendaID"].Value != null &&
                    row.Cells["ProdutoID"].Value != null && row.Cells["Quantidade"].Value != null &&
                    row.Cells["ValorProduto"].Value != null && row.Cells["Subtotal"].Value != null)
                {
                    int produtoID = Convert.ToInt32(row.Cells["ProdutoID"].Value);
                    int quantidadeVendida = Convert.ToInt32(row.Cells["Quantidade"].Value);

                    // Criando o objeto ItemVenda
                    ItemVendaModel itemVenda = new ItemVendaModel
                    {
                        ItemVendaID = Convert.ToInt32(row.Cells["ItemVendaID"].Value),
                        VendaID = vendaID,
                        ProdutoID = produtoID,
                        Quantidade = quantidadeVendida,
                        PrecoUnitario = Convert.ToDecimal(row.Cells["ValorProduto"].Value),
                        Subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value)
                    };

                    // Salvar item da venda no banco de dados
                    itemVendaDAL.AddItemVenda(itemVenda);

                    // Atualizar o estoque do produto
                    produtoDAL.AtualizarEstoqueVenda(produtoID, quantidadeVendida);
                }
            }
        }


        private void radiobtnAVista_CheckedChanged(object sender, EventArgs e)
        {
            Habilitabotoes();
        }

        private void radiobtnParcelado_CheckedChanged(object sender, EventArgs e)
        {
           Habilitabotoes();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {

            if (VendaID == 0)
            {
                MessageBox.Show("Por favor, informe o ID da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgvItensVenda.Rows.Count == 0)
            {
                MessageBox.Show("Por favor, adicione itens à venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                FinalizarVenda();
            }
        }

        private void btnParcelar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValorTotal.Text) || decimal.Parse(txtValorTotal.Text) <= 0)
            {
                MessageBox.Show("Informe um valor válido para a venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Salva a venda antes de abrir o formulário de parcelas
            if (FinalizarVenda())
            {
                // Abre a tela FrmGerarParcelas para gerar as parcelas
                using (FrmGerarParcelas formParcelas = new FrmGerarParcelas(this, VendaID, decimal.Parse(txtValorTotal.Text)))
                {
                    if (formParcelas.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Parcelas geradas e venda finalizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparDataGridView(dgvItensVenda);
                        NovoCodigo();
                    }
                }
            }
        }

       

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se todos os valores necessários estão preenchidos
                if (VendaID == 0)
                {
                    MessageBox.Show("Por favor, informe o ID da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ItemVendaID == 0)
                {
                    MessageBox.Show("Por favor, informe o ID dos itens da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
                {
                    MessageBox.Show("Por favor, informe a quantidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade <= 0)
                {
                    MessageBox.Show("Por favor, informe uma quantidade válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtValorProduto.Text) || decimal.TryParse(txtValorProduto.Text, out decimal valor) && valor <= 0)
                {
                    MessageBox.Show("Por favor, informe um valor de produto válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNomeProduto.Text))
                {
                    MessageBox.Show("Por favor, informe o nome do produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Chama o método para incluir os itens na grid
                IncluirItens();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {
            if (bloqueiaPesquisa || string.IsNullOrEmpty(txtNomeCliente.Text))
                return;

            bloqueiaPesquisa = true; // Impede reabertura do formulário 

            using (FrmLocalizarCliente pesquisaCliente = new FrmLocalizarCliente(this, txtNomeCliente.Text))
            {
                pesquisaCliente.Owner = this; // Define o formulário principal como "dono"

                if (pesquisaCliente.ShowDialog() == DialogResult.OK)
                {
                    txtNomeCliente.Text = pesquisaCliente.ClienteSelecionado;
                }
            }

            bloqueiaPesquisa = false; // Libera a pesquisa novamente
        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {
            if (bloqueiaPesquisa || string.IsNullOrEmpty(txtNomeProduto.Text))
                return;

            bloqueiaPesquisa = true; // Bloqueia novas pesquisas para evitar loops

            using (FrmLocalizarProduto pesquisaProduto = new FrmLocalizarProduto(this, txtNomeProduto.Text))
            {
                pesquisaProduto.Owner = this; // Define o formulário principal como "dono"

                if (pesquisaProduto.ShowDialog() == DialogResult.OK)
                {
                    // Atualiza somente se o texto mudou
                    if (txtNomeProduto.Text != pesquisaProduto.produtoSelecionado)
                    {
                        txtNomeProduto.Text = pesquisaProduto.produtoSelecionado;
                    }
                }
            }

            bloqueiaPesquisa = false; // Libera a pesquisa novamente
        }

        private void dtpVencimento_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}

/*
 * 4. Melhorias Futuras
Exibir um alerta se o estoque ficar abaixo de um limite mínimo.
Impedir vendas caso o estoque seja insuficiente.

 * */