using GVC.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Data.SqlClient;
using GVC.DALL;
using static GVC.View.FrmContaReceberr;

namespace GVC.View
{
    public partial class FrmGerarParcelas : FrmModeloForm
    {
        public int clienteID;
        public int vendaID;
        public List<ParcelaModel> parcelas;
        public decimal valorParcela, valorTotal;
        public int numeroParcelas;
        public string nomeCliente = "";
        public DateTime dataVencimento;
        private string QueryParcela = "SELECT MAX(ParcelaID)  FROM Parcela";
        FrmPedidoVendaNovo frmPedidoVenda = new FrmPedidoVendaNovo();

        private Form _formChamador;
        public FrmGerarParcelas(Form formChamador, int vendaID, decimal valorTotal)
        {
            InitializeComponent();
            _formChamador = formChamador;
            this.VendaID = vendaID;
            this.ValorTotal = valorTotal;

            this.valorTotal = valorTotal;
            this.numeroParcelas = numeroParcelas;
            this.parcelas = new List<ParcelaModel>();
        }


        private int VendaID;
        private decimal ValorTotal;


        public int parcelaID { get; set; }

        // Método público para definir o valor de parcelaID
        public void SetParcelaID(int id)
        {
            // Atribui o valor passado do parâmetro id para a variável pública parcelaID
            parcelaID = id;
        }

        private void PersonalizarDataGridParcelas()
        {
            if (dgvParcelas.Columns.Count == 0)
                return; // Evita erro caso o DataGridView ainda não tenha colunas

            // Definir cabeçalhos das colunas
            dgvParcelas.Columns["ParcelaID"].HeaderText = "Cód. Parc.";
            dgvParcelas.Columns["ValorParcela"].HeaderText = "Vlr. Parc.";
            dgvParcelas.Columns["NumeroParcela"].HeaderText = "Nr. Parc.";
            dgvParcelas.Columns["DataVencimento"].HeaderText = "Dta. Vcto";

            // Formatar a exibição dos valores
            dgvParcelas.Columns["ValorParcela"].DefaultCellStyle.Format = "C2"; // Formato monetário
            dgvParcelas.Columns["DataVencimento"].DefaultCellStyle.Format = "dd/MM/yyyy"; // Formato de data

            // Centralizar colunas específicas
            dgvParcelas.Columns["ParcelaID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvParcelas.Columns["NumeroParcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvParcelas.Columns["DataVencimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Definir tamanhos das colunas
            dgvParcelas.Columns["ParcelaID"].Width = 90;
            dgvParcelas.Columns["ValorParcela"].Width = 90;
            dgvParcelas.Columns["NumeroParcela"].Width = 70;
            dgvParcelas.Columns["DataVencimento"].Width = 100;

            // Ocultar a coluna ParcelaID se necessário
            dgvParcelas.Columns["ParcelaID"].Visible = false;
        }

        private void GerarParcelas()
        {
            try
            {
                int dias = Convert.ToInt32(txtDias.Text);
                int numeroParcelas = Convert.ToInt32(txtQtdParcelas.Text);
                decimal valorTotal = Convert.ToDecimal(txtTotal.Text);
                DateTime dataVencimento = Convert.ToDateTime(dtPrimeiraParc.Value).Date;
                decimal valorParcela = Math.Round(valorTotal / numeroParcelas, 2);

                DataTable dt = new DataTable();
                dt.Columns.Add("ParcelaID", typeof(int));
                dt.Columns.Add("ValorParcela", typeof(decimal));
                dt.Columns.Add("NumeroParcela", typeof(int));
                dt.Columns.Add("DataVencimento", typeof(DateTime));

                // Gerar as parcelas
                int parcelaID = Utilitario.GerarNovoCodigoID("ParcelaID", "Parcela");
                for (var i = 0; i < numeroParcelas; i++)
                {
                    dt.Rows.Add(parcelaID, valorParcela, i + 1, dataVencimento.AddDays(i * dias).Date);
                    parcelaID++;
                }

                // Atualizar o DataGridView local
                dgvParcelas.DataSource = dt;

                // Personalizar o DataGridView
                PersonalizarDataGridParcelas();
                // Passar os dados para o FrmPedido               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar parcelas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      
        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            GerarParcelas();
        }

        private void txtQtdParcelas_Leave(object sender, EventArgs e)
        {
            GerarParcelas();
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmGerarParcelas_Load(object sender, EventArgs e)
        {
            txtTotal.Text = ValorTotal.ToString("N2");
        }
        //private void SalvarParcelas()
        //{
        //    using (var connection = Conexao.Conex()) // Obtém a conexão do SQL Server Express
        //    {
        //        connection.Open();
        //        using (var transaction = connection.BeginTransaction())
        //        {
        //            try
        //            {
        //                // Antes de inserir parcelas, verificar se a venda já foi salva
        //                if (!VendaExiste(frmPedidoVenda.VendaID, connection, transaction))
        //                {
        //                    throw new Exception("A venda ainda não foi salva no banco de dados.");
        //                }

        //                InserirParcelas(connection, transaction); // Insere as parcelas dentro da transação
        //                transaction.Commit();

        //                // Fecha a tela e retorna OK
        //                this.DialogResult = DialogResult.OK;
        //                this.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                MessageBox.Show("Erro ao salvar parcelas: " + ex.Message);
        //            }
        //        }
        //    }
        //}
        //private bool VendaExiste(int vendaID, SqlConnection connection, SqlCeTransaction transaction)
        //{
        //    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Venda WHERE VendaID = @VendaID", connection, transaction))
        //    {
        //        cmd.Parameters.AddWithValue("@VendaID", vendaID);
        //        return (int)cmd.ExecuteScalar() > 0;
        //    }
        //}

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //// Primeiro, garantir que a venda e os itens sejam salvos antes de inserir as parcelas
            //if (frmPedidoVenda.VendaID <= 0)
            //{
            //    frmPedidoVenda.SalvarVendaEItens();
            //}

            // Agora, podemos salvar as parcelas
            SalvarParcelas();

        }

        private void btnGerarParcelas_Click(object sender, EventArgs e)
        {
            GerarParcelas();
        }
        private void SalvarParcelas()
        {
            using (var connection = Conexao.Conex()) // Obtém a conexão do SQL Server Express
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        InserirParcelas(connection, transaction); // Insere as parcelas dentro da transação
                        transaction.Commit();

                        // Fecha a tela e retorna OK
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erro ao salvar parcelas: " + ex.Message);
                    }
                }
            }
        }

       
        public void InserirParcelas(SqlConnection connection, SqlTransaction transaction)
        {
            List<ParcelaModel> parcelas = new List<ParcelaModel>();

            if (dgvParcelas.Rows.Count == 0 || dgvParcelas.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                return; // Se não houver parcelas, sai do método
            }

            // Loop através das linhas do DataGridView
            foreach (DataGridViewRow row in dgvParcelas.Rows)
            {
                if (row.Cells["ParcelaID"].Value != null &&
                    row.Cells["DataVencimento"].Value != null &&
                    row.Cells["ValorParcela"].Value != null &&
                    row.Cells["NumeroParcela"].Value != null)
                {
                    var parcela = new ParcelaModel
                    {
                        // Se a coluna ParcelaID for auto-incremento, não precisa preencher aqui
                        VendaID = VendaID,
                        ParcelaID = Convert.ToInt32(row.Cells["ParcelaID"].Value),
                        NumeroParcela = Convert.ToInt32(row.Cells["NumeroParcela"].Value),
                        DataVencimento = Convert.ToDateTime(row.Cells["DataVencimento"].Value),
                        ValorParcela = Convert.ToDecimal(row.Cells["ValorParcela"].Value),
                        ValorRecebido = 0,
                        SaldoRestante = Convert.ToDecimal(row.Cells["ValorParcela"].Value),
                        Pago = false
                    };

                    parcelas.Add(parcela);
                }
            }

            // Insere todas as parcelas no banco de dados dentro da transação
            ParcelaDAL dal = new ParcelaDAL(); // Criar uma instância da classe ParcelaDal
            foreach (var parcela in parcelas)
            {
                dal.InsertParcela(parcela);
            }

        }

    }
}
