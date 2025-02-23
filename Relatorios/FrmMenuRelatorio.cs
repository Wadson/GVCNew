using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GVC.Relatorios
{
    public partial class FrmMenuRelatorio : GVC.FrmModeloForm
    {
        public FrmMenuRelatorio()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClienteVendas_Click(object sender, EventArgs e)
        {
            RelClienteContaAberta relClienteContaAberta = new RelClienteContaAberta();
            relClienteContaAberta.ShowDialog();
        }

        private void btnRelatorioGeral_Click(object sender, EventArgs e)
        {
            FrmRelGeralContasAbertas frmRelGeralContasAbertas = new FrmRelGeralContasAbertas();
            frmRelGeralContasAbertas.ShowDialog();
        }

        private void btnRelprodutos_Click(object sender, EventArgs e)
        {
            FrmRelProdutos frmRelProdutos = new FrmRelProdutos();
            frmRelProdutos.ShowDialog();
        }
    }
}
