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

            this.reportViewer2.RefreshReport();
        }
    }
}