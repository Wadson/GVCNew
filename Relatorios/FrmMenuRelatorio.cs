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

        private void btnRelContaGeralAberta_Click(object sender, EventArgs e)
        {
            FrmRelGeralContasAbertas frm = new FrmRelGeralContasAbertas();
            frm.ShowDialog();
        }

        private void btnRelProdutos_Click(object sender, EventArgs e)
        {
            FrmRelProdutos frmRelProdutos = new FrmRelProdutos();
            frmRelProdutos.ShowDialog();
        }

        private void btnContaReceberGeral_Click(object sender, EventArgs e)
        {
            FrmRelContaReceberGeral frm = new FrmRelContaReceberGeral();
            frm.ShowDialog();
        }

        private void btnContaAbertaPorCliente_Click(object sender, EventArgs e)
        {
            FrmRelContaAbertaPorCliente frm = new FrmRelContaAbertaPorCliente();
            frm.ShowDialog();
        }

        private void btnHistoricoPagamento_Click(object sender, EventArgs e)
        {
            FrmRelHistoricoPagamento frmRelHistoricoPagamento = new FrmRelHistoricoPagamento();
            frmRelHistoricoPagamento.ShowDialog();
        }
    }
}
