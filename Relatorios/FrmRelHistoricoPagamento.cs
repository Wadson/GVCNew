using GVC.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GVC.Relatorios
{
    public partial class FrmRelHistoricoPagamento : GVC.FrmModeloForm
    {
        public string clienteSelecionado { get; set; }
        public FrmRelHistoricoPagamento()
        {
            InitializeComponent();
        }

        private void FrmRelHistoricoPagamento_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
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
        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            this.dataTableHistoricoPagamentoTableAdapter.Fill(this.bdsiscontrolDataSet.DataTableHistoricoPagamento, txtNomeCliente.Text);
            this.dataTableContaAbertaPorClienteTableAdapter.FillContaAbertaPorCliente(this.bdsiscontrolDataSet.DataTableContaAbertaPorCliente, txtNomeCliente.Text);
            this.dataTableItemVendidoTableAdapter.Fill(this.bdsiscontrolDataSet.DataTableItemVendido, txtNomeCliente.Text);
            this.reportViewer1.RefreshReport();
        }

        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            AbrirFrmLocalizarCliente();
        }
    }
}
