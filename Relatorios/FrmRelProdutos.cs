using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GVC.Relatorios
{
    public partial class FrmRelProdutos : GVC.FrmModeloForm
    {
        public FrmRelProdutos()
        {
            InitializeComponent();
        }

        private void FrmRelProdutos_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

            LocalReport relatorio = new LocalReport();
            //relatorio.DataSources.Add(new ReportDataSource(bdsiscontrolDataSet1);
        }
    }
}
