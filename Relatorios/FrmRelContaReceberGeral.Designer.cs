namespace GVC.Relatorios
{
    partial class FrmRelContaReceberGeral
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bdsiscontrolDataSet = new GVC.bdsiscontrolDataSet();
            this.dataTableContasReceberGeralBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTableContasReceberGeralTableAdapter = new GVC.bdsiscontrolDataSetTableAdapters.DataTableContasReceberGeralTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bdsiscontrolDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableContasReceberGeralBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataTableContasReceberGeralBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GVC.Relatorios.RelContaAbertaGeral.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(706, 499);
            this.reportViewer1.TabIndex = 0;
            // 
            // bdsiscontrolDataSet
            // 
            this.bdsiscontrolDataSet.DataSetName = "bdsiscontrolDataSet";
            this.bdsiscontrolDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTableContasReceberGeralBindingSource
            // 
            this.dataTableContasReceberGeralBindingSource.DataMember = "DataTableContasReceberGeral";
            this.dataTableContasReceberGeralBindingSource.DataSource = this.bdsiscontrolDataSet;
            // 
            // dataTableContasReceberGeralTableAdapter
            // 
            this.dataTableContasReceberGeralTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelContaReceberGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(706, 499);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelContaReceberGeral";
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Load += new System.EventHandler(this.FrmRelContaReceberGeral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdsiscontrolDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableContasReceberGeralBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private bdsiscontrolDataSet bdsiscontrolDataSet;
        private System.Windows.Forms.BindingSource dataTableContasReceberGeralBindingSource;
        private bdsiscontrolDataSetTableAdapters.DataTableContasReceberGeralTableAdapter dataTableContasReceberGeralTableAdapter;
    }
}
