using Microsoft.Reporting.WinForms;
using SisControl.View;
using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace SisControl.Relatorios
{
    public partial class RelClienteContaAberta : SisControl.FrmModeloForm
    {
        public string clienteSelecionado { get; set; } //Não serve para nada, só para preencher o parametro do construtor
        public RelClienteContaAberta()
        {
            InitializeComponent();
        }

        private void CarregarRelatorio()
        {           
            using (var conn = Conexao.Conex())
            {
                conn.Open();
                string query = @"SELECT 
                                        c.NomeCliente,
                                        p.ParcelaID,
                                        p.NumeroParcela,
                                        p.DataVencimento,
                                        p.ValorParcela,
                                        p.ValorRecebido,
                                        p.SaldoRestante,
                                        p.Pago,
                                        pg.ValorPago AS PagamentoParcial,
                                        pg.DataPagamento
                                    FROM Parcela p
                                    INNER JOIN Venda v ON v.VendaID = p.VendaID
                                    INNER JOIN Cliente c ON c.ClienteID = v.ClienteID
                                    LEFT JOIN PagamentosParciais pg ON pg.ParcelaID = p.ParcelaID
                                    ORDER BY c.NomeCliente, p.DataVencimento, p.NumeroParcela";

                SqlCeDataAdapter adapter = new SqlCeDataAdapter(query, conn);

                DataSetRelatorio ds = new DataSetRelatorio(); // Nome do seu DataSet.xsd
                adapter.Fill(ds, "Parcela"); // Nome da tabela do DataSet

                reportViewer1.LocalReport.ReportPath = "RelClienteItemCompra.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("DataSetRelatorio", ds.Tables["Parcela"])
                );
                reportViewer1.RefreshReport();
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            AbrirFrmLocalizarCliente();
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {            
        }

        private void RelClienteContaAberta_Load(object sender, EventArgs e)
        {

            CarregarRelatorio();
        }
    }
}