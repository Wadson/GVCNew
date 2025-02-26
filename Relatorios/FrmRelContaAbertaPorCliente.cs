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
    public partial class FrmRelContaAbertaPorCliente : GVC.FrmModeloForm
    {
        public string clienteSelecionado { get; set; }
        public FrmRelContaAbertaPorCliente()
        {
            InitializeComponent();
        }

        private void FrmRelContaAbertaPorCliente_Load(object sender, EventArgs e)
        {            
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
            this.dataTableContaAbertaPorClienteTableAdapter.FillContaAbertaPorCliente(this.bdsiscontrolDataSet.DataTableContaAbertaPorCliente, txtNomeCliente.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
