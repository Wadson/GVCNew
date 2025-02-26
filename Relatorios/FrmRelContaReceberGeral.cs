using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GVC.Relatorios
{
    public partial class FrmRelContaReceberGeral : GVC.FrmModeloForm
    {
        public FrmRelContaReceberGeral()
        {
            InitializeComponent();
        }

        private void FrmRelContaReceberGeral_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdsiscontrolDataSet.DataTableContasReceberGeral'. Você pode movê-la ou removê-la conforme necessário.
            this.dataTableContasReceberGeralTableAdapter.FillContasReceberGeral(this.bdsiscontrolDataSet.DataTableContasReceberGeral);

            this.reportViewer1.RefreshReport();
        }
    }
}
