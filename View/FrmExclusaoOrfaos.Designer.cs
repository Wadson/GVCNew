namespace SisControl.View
{
    partial class FrmExclusaoOrfaos
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
            this.dgvVendas = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgvPagamentosParciais = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgvItensVenda = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dgvParcelas = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnExcluirPagamentoParcial = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExcluirVenda = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExcluirParcelas = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExcluirItensVenda = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label28 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSair = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentosParciais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVendas
            // 
            this.dgvVendas.AllowUserToAddRows = false;
            this.dgvVendas.AllowUserToDeleteRows = false;
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Location = new System.Drawing.Point(-1, 52);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendas.Size = new System.Drawing.Size(387, 154);
            this.dgvVendas.TabIndex = 596;
            // 
            // dgvPagamentosParciais
            // 
            this.dgvPagamentosParciais.AllowUserToAddRows = false;
            this.dgvPagamentosParciais.AllowUserToDeleteRows = false;
            this.dgvPagamentosParciais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagamentosParciais.Location = new System.Drawing.Point(406, 52);
            this.dgvPagamentosParciais.Name = "dgvPagamentosParciais";
            this.dgvPagamentosParciais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagamentosParciais.Size = new System.Drawing.Size(362, 154);
            this.dgvPagamentosParciais.TabIndex = 597;
            // 
            // dgvItensVenda
            // 
            this.dgvItensVenda.AllowUserToAddRows = false;
            this.dgvItensVenda.AllowUserToDeleteRows = false;
            this.dgvItensVenda.Location = new System.Drawing.Point(406, 281);
            this.dgvItensVenda.Name = "dgvItensVenda";
            this.dgvItensVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItensVenda.Size = new System.Drawing.Size(362, 154);
            this.dgvItensVenda.TabIndex = 599;
            // 
            // dgvParcelas
            // 
            this.dgvParcelas.AllowUserToAddRows = false;
            this.dgvParcelas.AllowUserToDeleteRows = false;
            this.dgvParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParcelas.Location = new System.Drawing.Point(-1, 281);
            this.dgvParcelas.Name = "dgvParcelas";
            this.dgvParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParcelas.Size = new System.Drawing.Size(387, 154);
            this.dgvParcelas.TabIndex = 600;
            // 
            // btnExcluirPagamentoParcial
            // 
            this.btnExcluirPagamentoParcial.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            this.btnExcluirPagamentoParcial.Location = new System.Drawing.Point(655, 212);
            this.btnExcluirPagamentoParcial.Name = "btnExcluirPagamentoParcial";
            this.btnExcluirPagamentoParcial.OverrideDefault.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirPagamentoParcial.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.btnExcluirPagamentoParcial.OverrideDefault.Back.ColorAngle = 45F;
            this.btnExcluirPagamentoParcial.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.btnExcluirPagamentoParcial.OverrideDefault.Border.Color2 = System.Drawing.Color.Red;
            this.btnExcluirPagamentoParcial.OverrideDefault.Border.ColorAngle = 45F;
            this.btnExcluirPagamentoParcial.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirPagamentoParcial.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirPagamentoParcial.OverrideDefault.Border.Rounding = 20;
            this.btnExcluirPagamentoParcial.OverrideDefault.Border.Width = 1;
            this.btnExcluirPagamentoParcial.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.btnExcluirPagamentoParcial.Size = new System.Drawing.Size(113, 25);
            this.btnExcluirPagamentoParcial.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirPagamentoParcial.StateCommon.Back.Color2 = System.Drawing.Color.Red;
            this.btnExcluirPagamentoParcial.StateCommon.Back.ColorAngle = 45F;
            this.btnExcluirPagamentoParcial.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirPagamentoParcial.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirPagamentoParcial.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirPagamentoParcial.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirPagamentoParcial.StateCommon.Border.Rounding = 0;
            this.btnExcluirPagamentoParcial.StateCommon.Border.Width = 1;
            this.btnExcluirPagamentoParcial.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExcluirPagamentoParcial.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExcluirPagamentoParcial.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirPagamentoParcial.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirPagamentoParcial.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnExcluirPagamentoParcial.StatePressed.Back.ColorAngle = 135F;
            this.btnExcluirPagamentoParcial.StatePressed.Border.Color1 = System.Drawing.Color.Red;
            this.btnExcluirPagamentoParcial.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnExcluirPagamentoParcial.StatePressed.Border.ColorAngle = 135F;
            this.btnExcluirPagamentoParcial.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirPagamentoParcial.StatePressed.Border.Rounding = 20;
            this.btnExcluirPagamentoParcial.StatePressed.Border.Width = 1;
            this.btnExcluirPagamentoParcial.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirPagamentoParcial.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirPagamentoParcial.StateTracking.Back.ColorAngle = 45F;
            this.btnExcluirPagamentoParcial.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirPagamentoParcial.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirPagamentoParcial.StateTracking.Border.ColorAngle = 45F;
            this.btnExcluirPagamentoParcial.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirPagamentoParcial.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirPagamentoParcial.StateTracking.Border.Rounding = 20;
            this.btnExcluirPagamentoParcial.StateTracking.Border.Width = 1;
            this.btnExcluirPagamentoParcial.TabIndex = 628;
            this.btnExcluirPagamentoParcial.Values.Text = "&Excluir";
            this.btnExcluirPagamentoParcial.Click += new System.EventHandler(this.btnExcluirPagamentoParcial_Click);
            // 
            // btnExcluirVenda
            // 
            this.btnExcluirVenda.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            this.btnExcluirVenda.Location = new System.Drawing.Point(273, 212);
            this.btnExcluirVenda.Name = "btnExcluirVenda";
            this.btnExcluirVenda.OverrideDefault.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirVenda.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.btnExcluirVenda.OverrideDefault.Back.ColorAngle = 45F;
            this.btnExcluirVenda.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.btnExcluirVenda.OverrideDefault.Border.Color2 = System.Drawing.Color.Red;
            this.btnExcluirVenda.OverrideDefault.Border.ColorAngle = 45F;
            this.btnExcluirVenda.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirVenda.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirVenda.OverrideDefault.Border.Rounding = 20;
            this.btnExcluirVenda.OverrideDefault.Border.Width = 1;
            this.btnExcluirVenda.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.btnExcluirVenda.Size = new System.Drawing.Size(113, 25);
            this.btnExcluirVenda.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirVenda.StateCommon.Back.Color2 = System.Drawing.Color.Red;
            this.btnExcluirVenda.StateCommon.Back.ColorAngle = 45F;
            this.btnExcluirVenda.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirVenda.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirVenda.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirVenda.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirVenda.StateCommon.Border.Rounding = 0;
            this.btnExcluirVenda.StateCommon.Border.Width = 1;
            this.btnExcluirVenda.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExcluirVenda.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExcluirVenda.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirVenda.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirVenda.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnExcluirVenda.StatePressed.Back.ColorAngle = 135F;
            this.btnExcluirVenda.StatePressed.Border.Color1 = System.Drawing.Color.Red;
            this.btnExcluirVenda.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnExcluirVenda.StatePressed.Border.ColorAngle = 135F;
            this.btnExcluirVenda.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirVenda.StatePressed.Border.Rounding = 20;
            this.btnExcluirVenda.StatePressed.Border.Width = 1;
            this.btnExcluirVenda.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirVenda.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirVenda.StateTracking.Back.ColorAngle = 45F;
            this.btnExcluirVenda.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirVenda.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirVenda.StateTracking.Border.ColorAngle = 45F;
            this.btnExcluirVenda.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirVenda.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirVenda.StateTracking.Border.Rounding = 20;
            this.btnExcluirVenda.StateTracking.Border.Width = 1;
            this.btnExcluirVenda.TabIndex = 629;
            this.btnExcluirVenda.Values.Text = "&Excluir";
            this.btnExcluirVenda.Click += new System.EventHandler(this.btnExcluirVenda_Click);
            // 
            // btnExcluirParcelas
            // 
            this.btnExcluirParcelas.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            this.btnExcluirParcelas.Location = new System.Drawing.Point(273, 441);
            this.btnExcluirParcelas.Name = "btnExcluirParcelas";
            this.btnExcluirParcelas.OverrideDefault.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirParcelas.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.btnExcluirParcelas.OverrideDefault.Back.ColorAngle = 45F;
            this.btnExcluirParcelas.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.btnExcluirParcelas.OverrideDefault.Border.Color2 = System.Drawing.Color.Red;
            this.btnExcluirParcelas.OverrideDefault.Border.ColorAngle = 45F;
            this.btnExcluirParcelas.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirParcelas.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirParcelas.OverrideDefault.Border.Rounding = 20;
            this.btnExcluirParcelas.OverrideDefault.Border.Width = 1;
            this.btnExcluirParcelas.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.btnExcluirParcelas.Size = new System.Drawing.Size(113, 25);
            this.btnExcluirParcelas.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirParcelas.StateCommon.Back.Color2 = System.Drawing.Color.Red;
            this.btnExcluirParcelas.StateCommon.Back.ColorAngle = 45F;
            this.btnExcluirParcelas.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirParcelas.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirParcelas.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirParcelas.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirParcelas.StateCommon.Border.Rounding = 0;
            this.btnExcluirParcelas.StateCommon.Border.Width = 1;
            this.btnExcluirParcelas.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExcluirParcelas.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExcluirParcelas.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirParcelas.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirParcelas.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnExcluirParcelas.StatePressed.Back.ColorAngle = 135F;
            this.btnExcluirParcelas.StatePressed.Border.Color1 = System.Drawing.Color.Red;
            this.btnExcluirParcelas.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnExcluirParcelas.StatePressed.Border.ColorAngle = 135F;
            this.btnExcluirParcelas.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirParcelas.StatePressed.Border.Rounding = 20;
            this.btnExcluirParcelas.StatePressed.Border.Width = 1;
            this.btnExcluirParcelas.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirParcelas.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirParcelas.StateTracking.Back.ColorAngle = 45F;
            this.btnExcluirParcelas.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirParcelas.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirParcelas.StateTracking.Border.ColorAngle = 45F;
            this.btnExcluirParcelas.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirParcelas.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirParcelas.StateTracking.Border.Rounding = 20;
            this.btnExcluirParcelas.StateTracking.Border.Width = 1;
            this.btnExcluirParcelas.TabIndex = 630;
            this.btnExcluirParcelas.Values.Text = "&Excluir";
            this.btnExcluirParcelas.Click += new System.EventHandler(this.btnExcluirParcelas_Click);
            // 
            // btnExcluirItensVenda
            // 
            this.btnExcluirItensVenda.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            this.btnExcluirItensVenda.Location = new System.Drawing.Point(655, 441);
            this.btnExcluirItensVenda.Name = "btnExcluirItensVenda";
            this.btnExcluirItensVenda.OverrideDefault.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirItensVenda.OverrideDefault.Back.Color2 = System.Drawing.Color.Red;
            this.btnExcluirItensVenda.OverrideDefault.Back.ColorAngle = 45F;
            this.btnExcluirItensVenda.OverrideDefault.Border.Color1 = System.Drawing.Color.Red;
            this.btnExcluirItensVenda.OverrideDefault.Border.Color2 = System.Drawing.Color.Red;
            this.btnExcluirItensVenda.OverrideDefault.Border.ColorAngle = 45F;
            this.btnExcluirItensVenda.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirItensVenda.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirItensVenda.OverrideDefault.Border.Rounding = 20;
            this.btnExcluirItensVenda.OverrideDefault.Border.Width = 1;
            this.btnExcluirItensVenda.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.btnExcluirItensVenda.Size = new System.Drawing.Size(113, 25);
            this.btnExcluirItensVenda.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirItensVenda.StateCommon.Back.Color2 = System.Drawing.Color.Red;
            this.btnExcluirItensVenda.StateCommon.Back.ColorAngle = 45F;
            this.btnExcluirItensVenda.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirItensVenda.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirItensVenda.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirItensVenda.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirItensVenda.StateCommon.Border.Rounding = 0;
            this.btnExcluirItensVenda.StateCommon.Border.Width = 1;
            this.btnExcluirItensVenda.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExcluirItensVenda.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExcluirItensVenda.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirItensVenda.StatePressed.Back.Color1 = System.Drawing.Color.Red;
            this.btnExcluirItensVenda.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnExcluirItensVenda.StatePressed.Back.ColorAngle = 135F;
            this.btnExcluirItensVenda.StatePressed.Border.Color1 = System.Drawing.Color.Red;
            this.btnExcluirItensVenda.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnExcluirItensVenda.StatePressed.Border.ColorAngle = 135F;
            this.btnExcluirItensVenda.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirItensVenda.StatePressed.Border.Rounding = 20;
            this.btnExcluirItensVenda.StatePressed.Border.Width = 1;
            this.btnExcluirItensVenda.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirItensVenda.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirItensVenda.StateTracking.Back.ColorAngle = 45F;
            this.btnExcluirItensVenda.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnExcluirItensVenda.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnExcluirItensVenda.StateTracking.Border.ColorAngle = 45F;
            this.btnExcluirItensVenda.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExcluirItensVenda.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnExcluirItensVenda.StateTracking.Border.Rounding = 20;
            this.btnExcluirItensVenda.StateTracking.Border.Width = 1;
            this.btnExcluirItensVenda.TabIndex = 631;
            this.btnExcluirItensVenda.Values.Text = "&Excluir";
            this.btnExcluirItensVenda.Click += new System.EventHandler(this.btnExcluirItensVenda_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label28.ForeColor = System.Drawing.Color.Green;
            this.label28.Location = new System.Drawing.Point(141, 25);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(88, 24);
            this.label28.TabIndex = 632;
            this.label28.Text = "VENDAS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(478, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 24);
            this.label1.TabIndex = 633;
            this.label1.Text = "PAGAMENTOS PARCIAIS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(120, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 635;
            this.label3.Text = "PARCELAS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(524, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 24);
            this.label4.TabIndex = 636;
            this.label4.Text = "ITENS VENDA";
            // 
            // btnSair
            // 
            this.btnSair.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSair.Location = new System.Drawing.Point(578, 491);
            this.btnSair.Name = "btnSair";
            this.btnSair.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.btnSair.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.OverrideDefault.Back.ColorAngle = 45F;
            this.btnSair.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.OverrideDefault.Border.ColorAngle = 45F;
            this.btnSair.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSair.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSair.OverrideDefault.Border.Rounding = 1;
            this.btnSair.OverrideDefault.Border.Width = 1;
            this.btnSair.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnSair.Size = new System.Drawing.Size(190, 30);
            this.btnSair.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnSair.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnSair.StateCommon.Back.ColorAngle = 45F;
            this.btnSair.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSair.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSair.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSair.StateCommon.Border.Rounding = 1;
            this.btnSair.StateCommon.Border.Width = 1;
            this.btnSair.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnSair.StatePressed.Back.ColorAngle = 135F;
            this.btnSair.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnSair.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnSair.StatePressed.Border.ColorAngle = 135F;
            this.btnSair.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSair.StatePressed.Border.Rounding = 1;
            this.btnSair.StatePressed.Border.Width = 1;
            this.btnSair.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnSair.StateTracking.Back.ColorAngle = 45F;
            this.btnSair.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSair.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateTracking.Border.ColorAngle = 45F;
            this.btnSair.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSair.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSair.StateTracking.Border.Rounding = 1;
            this.btnSair.StateTracking.Border.Width = 1;
            this.btnSair.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSair.TabIndex = 637;
            this.btnSair.Values.Text = "&Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FrmExclusaoOrfaos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(780, 533);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.btnExcluirItensVenda);
            this.Controls.Add(this.btnExcluirParcelas);
            this.Controls.Add(this.btnExcluirVenda);
            this.Controls.Add(this.btnExcluirPagamentoParcial);
            this.Controls.Add(this.dgvParcelas);
            this.Controls.Add(this.dgvItensVenda);
            this.Controls.Add(this.dgvPagamentosParciais);
            this.Controls.Add(this.dgvVendas);
            this.Name = "FrmExclusaoOrfaos";
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Text = "MANUTENÇÃO DE REGISTROS ORFÃOS";
            this.Load += new System.EventHandler(this.FrmExclusaoOrfao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagamentosParciais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvVendas;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvPagamentosParciais;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvItensVenda;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvParcelas;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExcluirPagamentoParcial;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExcluirVenda;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExcluirParcelas;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExcluirItensVenda;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSair;
    }
}
