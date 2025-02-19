namespace SisControl.View
{
    partial class FrmPedidoVendaNovo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidoVendaNovo));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpVencimento = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.radiobtnParcelado = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radiobtnAVista = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btnLocalizarProduto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtNomeProduto = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtQuantidade = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnIncluir = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtValorProduto = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValorRecebido = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtSubTotal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLocalizarCliente = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtNomeCliente = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtpDataVenda = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.txtVendaID = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dgvItensVenda = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtValorTotal = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtQtdItens = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnNovo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnFinalizarVenda = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnParcelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSair = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.dtpVencimento);
            this.groupBox4.Controls.Add(this.radiobtnParcelado);
            this.groupBox4.Controls.Add(this.radiobtnAVista);
            this.groupBox4.Controls.Add(this.btnLocalizarProduto);
            this.groupBox4.Controls.Add(this.txtNomeProduto);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtQuantidade);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btnIncluir);
            this.groupBox4.Controls.Add(this.txtValorProduto);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtValorRecebido);
            this.groupBox4.Controls.Add(this.txtSubTotal);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(7, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(924, 110);
            this.groupBox4.TabIndex = 575;
            this.groupBox4.TabStop = false;
            // 
            // dtpVencimento
            // 
            this.dtpVencimento.Animated = true;
            this.dtpVencimento.AutoRoundedCorners = true;
            this.dtpVencimento.BackColor = System.Drawing.Color.Transparent;
            this.dtpVencimento.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.dtpVencimento.BorderRadius = 17;
            this.dtpVencimento.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.dtpVencimento.Checked = true;
            this.dtpVencimento.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.dtpVencimento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpVencimento.ForeColor = System.Drawing.Color.White;
            this.dtpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimento.IndicateFocus = true;
            this.dtpVencimento.Location = new System.Drawing.Point(4, 70);
            this.dtpVencimento.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpVencimento.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpVencimento.Name = "dtpVencimento";
            this.dtpVencimento.Size = new System.Drawing.Size(128, 36);
            this.dtpVencimento.TabIndex = 628;
            this.dtpVencimento.UseTransparentBackground = true;
            this.dtpVencimento.Value = new System.DateTime(2025, 2, 19, 7, 9, 15, 860);
            this.dtpVencimento.ValueChanged += new System.EventHandler(this.dtpVencimento_ValueChanged);
            // 
            // radiobtnParcelado
            // 
            this.radiobtnParcelado.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.radiobtnParcelado.Location = new System.Drawing.Point(210, 79);
            this.radiobtnParcelado.Name = "radiobtnParcelado";
            this.radiobtnParcelado.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.radiobtnParcelado.Size = new System.Drawing.Size(81, 22);
            this.radiobtnParcelado.TabIndex = 618;
            this.radiobtnParcelado.Values.Text = "Parcelado";
            this.radiobtnParcelado.CheckedChanged += new System.EventHandler(this.radiobtnParcelado_CheckedChanged);
            // 
            // radiobtnAVista
            // 
            this.radiobtnAVista.Checked = true;
            this.radiobtnAVista.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.radiobtnAVista.Location = new System.Drawing.Point(140, 80);
            this.radiobtnAVista.Name = "radiobtnAVista";
            this.radiobtnAVista.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.radiobtnAVista.Size = new System.Drawing.Size(64, 22);
            this.radiobtnAVista.TabIndex = 619;
            this.radiobtnAVista.Values.Text = "A Vista";
            this.radiobtnAVista.CheckedChanged += new System.EventHandler(this.radiobtnAVista_CheckedChanged);
            // 
            // btnLocalizarProduto
            // 
            this.btnLocalizarProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocalizarProduto.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Custom1;
            this.btnLocalizarProduto.Location = new System.Drawing.Point(808, 27);
            this.btnLocalizarProduto.Name = "btnLocalizarProduto";
            this.btnLocalizarProduto.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarProduto.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarProduto.OverrideDefault.Back.ColorAngle = 45F;
            this.btnLocalizarProduto.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarProduto.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarProduto.OverrideDefault.Border.ColorAngle = 45F;
            this.btnLocalizarProduto.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLocalizarProduto.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnLocalizarProduto.OverrideDefault.Border.Rounding = 1;
            this.btnLocalizarProduto.OverrideDefault.Border.Width = 1;
            this.btnLocalizarProduto.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.btnLocalizarProduto.Size = new System.Drawing.Size(105, 28);
            this.btnLocalizarProduto.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarProduto.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarProduto.StateCommon.Back.ColorAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.btnLocalizarProduto.StateCommon.Back.ColorAngle = 45F;
            this.btnLocalizarProduto.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarProduto.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarProduto.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLocalizarProduto.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnLocalizarProduto.StateCommon.Border.Rounding = 1;
            this.btnLocalizarProduto.StateCommon.Border.Width = 1;
            this.btnLocalizarProduto.StateCommon.Content.Image.Effect = ComponentFactory.Krypton.Toolkit.PaletteImageEffect.Normal;
            this.btnLocalizarProduto.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLocalizarProduto.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLocalizarProduto.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalizarProduto.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnLocalizarProduto.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnLocalizarProduto.StatePressed.Back.ColorAngle = 135F;
            this.btnLocalizarProduto.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnLocalizarProduto.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnLocalizarProduto.StatePressed.Border.ColorAngle = 135F;
            this.btnLocalizarProduto.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLocalizarProduto.StatePressed.Border.Rounding = 1;
            this.btnLocalizarProduto.StatePressed.Border.Width = 1;
            this.btnLocalizarProduto.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarProduto.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarProduto.StateTracking.Back.ColorAngle = 45F;
            this.btnLocalizarProduto.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarProduto.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarProduto.StateTracking.Border.ColorAngle = 45F;
            this.btnLocalizarProduto.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLocalizarProduto.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnLocalizarProduto.StateTracking.Border.Rounding = 1;
            this.btnLocalizarProduto.StateTracking.Border.Width = 1;
            this.btnLocalizarProduto.TabIndex = 2;
            this.btnLocalizarProduto.Values.Image = global::SisControl.Properties.Resources.Pesquisar;
            this.btnLocalizarProduto.Values.Text = "&(F5)";
            this.btnLocalizarProduto.Click += new System.EventHandler(this.btnLocalizarProduto_Click);
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeProduto.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.txtNomeProduto.Location = new System.Drawing.Point(7, 28);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtNomeProduto.Size = new System.Drawing.Size(795, 27);
            this.txtNomeProduto.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtNomeProduto.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtNomeProduto.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtNomeProduto.StateCommon.Border.ColorAngle = 1F;
            this.txtNomeProduto.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtNomeProduto.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtNomeProduto.StateCommon.Border.Rounding = 1;
            this.txtNomeProduto.StateCommon.Border.Width = 1;
            this.txtNomeProduto.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.txtNomeProduto.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.txtNomeProduto.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtNomeProduto.TabIndex = 1;
            this.txtNomeProduto.TextChanged += new System.EventHandler(this.txtNomeProduto_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label12.Location = new System.Drawing.Point(132, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 13);
            this.label12.TabIndex = 585;
            this.label12.Text = "FORMA DE PAGAMENTO?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(10, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 15);
            this.label6.TabIndex = 545;
            this.label6.Text = "DATA VENCIMENTO";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label17.Location = new System.Drawing.Point(11, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(145, 13);
            this.label17.TabIndex = 467;
            this.label17.Text = "DESCRIÇÃO DO PRODUTO";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantidade.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.txtQuantidade.Location = new System.Drawing.Point(299, 74);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtQuantidade.Size = new System.Drawing.Size(106, 30);
            this.txtQuantidade.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtQuantidade.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtQuantidade.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtQuantidade.StateCommon.Border.ColorAngle = 1F;
            this.txtQuantidade.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtQuantidade.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtQuantidade.StateCommon.Border.Rounding = 1;
            this.txtQuantidade.StateCommon.Border.Width = 1;
            this.txtQuantidade.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txtQuantidade.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtQuantidade.TabIndex = 3;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(309, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 563;
            this.label7.Text = "Quantidade";
            // 
            // btnIncluir
            // 
            this.btnIncluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncluir.Location = new System.Drawing.Point(759, 61);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnIncluir.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnIncluir.OverrideDefault.Back.ColorAngle = 45F;
            this.btnIncluir.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnIncluir.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnIncluir.OverrideDefault.Border.ColorAngle = 45F;
            this.btnIncluir.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnIncluir.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnIncluir.OverrideDefault.Border.Rounding = 1;
            this.btnIncluir.OverrideDefault.Border.Width = 1;
            this.btnIncluir.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Gadugi", 9F);
            this.btnIncluir.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Gadugi", 9F);
            this.btnIncluir.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnIncluir.Size = new System.Drawing.Size(155, 43);
            this.btnIncluir.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnIncluir.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnIncluir.StateCommon.Back.ColorAngle = 45F;
            this.btnIncluir.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnIncluir.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnIncluir.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnIncluir.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnIncluir.StateCommon.Border.Rounding = 1;
            this.btnIncluir.StateCommon.Border.Width = 1;
            this.btnIncluir.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnIncluir.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnIncluir.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnIncluir.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnIncluir.StatePressed.Back.ColorAngle = 135F;
            this.btnIncluir.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnIncluir.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnIncluir.StatePressed.Border.ColorAngle = 135F;
            this.btnIncluir.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnIncluir.StatePressed.Border.Rounding = 1;
            this.btnIncluir.StatePressed.Border.Width = 1;
            this.btnIncluir.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnIncluir.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnIncluir.StateTracking.Back.ColorAngle = 45F;
            this.btnIncluir.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnIncluir.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnIncluir.StateTracking.Border.ColorAngle = 45F;
            this.btnIncluir.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnIncluir.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnIncluir.StateTracking.Border.Rounding = 1;
            this.btnIncluir.StateTracking.Border.Width = 1;
            this.btnIncluir.TabIndex = 619;
            this.btnIncluir.Values.Image = global::SisControl.Properties.Resources.Adicionar;
            this.btnIncluir.Values.Text = "&Incluir Item";
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // txtValorProduto
            // 
            this.txtValorProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorProduto.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.txtValorProduto.Location = new System.Drawing.Point(411, 74);
            this.txtValorProduto.Name = "txtValorProduto";
            this.txtValorProduto.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtValorProduto.Size = new System.Drawing.Size(106, 30);
            this.txtValorProduto.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtValorProduto.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtValorProduto.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtValorProduto.StateCommon.Border.ColorAngle = 1F;
            this.txtValorProduto.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtValorProduto.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtValorProduto.StateCommon.Border.Rounding = 1;
            this.txtValorProduto.StateCommon.Border.Width = 1;
            this.txtValorProduto.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txtValorProduto.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorProduto.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtValorProduto.TabIndex = 4;
            this.txtValorProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorProduto.Leave += new System.EventHandler(this.txtValorProduto_Leave);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(425, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 564;
            this.label8.Text = "P. Unitário";
            // 
            // txtValorRecebido
            // 
            this.txtValorRecebido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorRecebido.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.txtValorRecebido.Location = new System.Drawing.Point(523, 74);
            this.txtValorRecebido.Name = "txtValorRecebido";
            this.txtValorRecebido.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtValorRecebido.Size = new System.Drawing.Size(106, 30);
            this.txtValorRecebido.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtValorRecebido.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtValorRecebido.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtValorRecebido.StateCommon.Border.ColorAngle = 1F;
            this.txtValorRecebido.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtValorRecebido.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtValorRecebido.StateCommon.Border.Rounding = 1;
            this.txtValorRecebido.StateCommon.Border.Width = 1;
            this.txtValorRecebido.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.txtValorRecebido.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorRecebido.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtValorRecebido.TabIndex = 5;
            this.txtValorRecebido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorRecebido.Leave += new System.EventHandler(this.txtValorRecebido_Leave);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotal.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.txtSubTotal.Location = new System.Drawing.Point(635, 74);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtSubTotal.Size = new System.Drawing.Size(106, 30);
            this.txtSubTotal.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtSubTotal.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtSubTotal.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtSubTotal.StateCommon.Border.ColorAngle = 1F;
            this.txtSubTotal.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtSubTotal.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtSubTotal.StateCommon.Border.Rounding = 1;
            this.txtSubTotal.StateCommon.Border.Width = 1;
            this.txtSubTotal.StateCommon.Content.Color1 = System.Drawing.Color.Red;
            this.txtSubTotal.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtSubTotal.TabIndex = 588;
            this.txtSubTotal.TabStop = false;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label11.Location = new System.Drawing.Point(523, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 16);
            this.label11.TabIndex = 584;
            this.label11.Text = "Vlr.  Recebido";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(632, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 25);
            this.label10.TabIndex = 566;
            this.label10.Text = "Sub Total";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label14.Location = new System.Drawing.Point(8, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 15);
            this.label14.TabIndex = 296;
            this.label14.Text = "NOME DO CLIENTE";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.btnLocalizarCliente);
            this.groupBox3.Controls.Add(this.txtNomeCliente);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(7, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(924, 55);
            this.groupBox3.TabIndex = 572;
            this.groupBox3.TabStop = false;
            // 
            // btnLocalizarCliente
            // 
            this.btnLocalizarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocalizarCliente.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Custom1;
            this.btnLocalizarCliente.Location = new System.Drawing.Point(808, 23);
            this.btnLocalizarCliente.Name = "btnLocalizarCliente";
            this.btnLocalizarCliente.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarCliente.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarCliente.OverrideDefault.Back.ColorAngle = 45F;
            this.btnLocalizarCliente.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarCliente.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarCliente.OverrideDefault.Border.ColorAngle = 45F;
            this.btnLocalizarCliente.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLocalizarCliente.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnLocalizarCliente.OverrideDefault.Border.Rounding = 1;
            this.btnLocalizarCliente.OverrideDefault.Border.Width = 1;
            this.btnLocalizarCliente.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.btnLocalizarCliente.Size = new System.Drawing.Size(105, 28);
            this.btnLocalizarCliente.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarCliente.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarCliente.StateCommon.Back.ColorAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.btnLocalizarCliente.StateCommon.Back.ColorAngle = 45F;
            this.btnLocalizarCliente.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarCliente.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarCliente.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLocalizarCliente.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnLocalizarCliente.StateCommon.Border.Rounding = 1;
            this.btnLocalizarCliente.StateCommon.Border.Width = 1;
            this.btnLocalizarCliente.StateCommon.Content.Image.Effect = ComponentFactory.Krypton.Toolkit.PaletteImageEffect.Normal;
            this.btnLocalizarCliente.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLocalizarCliente.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLocalizarCliente.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalizarCliente.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnLocalizarCliente.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnLocalizarCliente.StatePressed.Back.ColorAngle = 135F;
            this.btnLocalizarCliente.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnLocalizarCliente.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnLocalizarCliente.StatePressed.Border.ColorAngle = 135F;
            this.btnLocalizarCliente.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLocalizarCliente.StatePressed.Border.Rounding = 1;
            this.btnLocalizarCliente.StatePressed.Border.Width = 1;
            this.btnLocalizarCliente.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarCliente.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarCliente.StateTracking.Back.ColorAngle = 45F;
            this.btnLocalizarCliente.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnLocalizarCliente.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnLocalizarCliente.StateTracking.Border.ColorAngle = 45F;
            this.btnLocalizarCliente.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLocalizarCliente.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnLocalizarCliente.StateTracking.Border.Rounding = 1;
            this.btnLocalizarCliente.StateTracking.Border.Width = 1;
            this.btnLocalizarCliente.TabIndex = 1002;
            this.btnLocalizarCliente.Values.Image = global::SisControl.Properties.Resources.Pesquisar;
            this.btnLocalizarCliente.Values.Text = "&(F4)";
            this.btnLocalizarCliente.Click += new System.EventHandler(this.btnLocalizarCliente_Click);
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeCliente.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.txtNomeCliente.Location = new System.Drawing.Point(7, 24);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtNomeCliente.Size = new System.Drawing.Size(795, 27);
            this.txtNomeCliente.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtNomeCliente.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtNomeCliente.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtNomeCliente.StateCommon.Border.ColorAngle = 1F;
            this.txtNomeCliente.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtNomeCliente.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtNomeCliente.StateCommon.Border.Rounding = 1;
            this.txtNomeCliente.StateCommon.Border.Width = 1;
            this.txtNomeCliente.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.txtNomeCliente.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.txtNomeCliente.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtNomeCliente.TabIndex = 0;
            this.txtNomeCliente.TextChanged += new System.EventHandler(this.txtNomeCliente_TextChanged);
            this.txtNomeCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNomeCliente_KeyUp);
            // 
            // dtpDataVenda
            // 
            this.dtpDataVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataVenda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataVenda.Location = new System.Drawing.Point(796, 32);
            this.dtpDataVenda.Name = "dtpDataVenda";
            this.dtpDataVenda.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.dtpDataVenda.Size = new System.Drawing.Size(134, 25);
            this.dtpDataVenda.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.dtpDataVenda.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.dtpDataVenda.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dtpDataVenda.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataVenda.TabIndex = 607;
            this.dtpDataVenda.TabStop = false;
            // 
            // txtVendaID
            // 
            this.txtVendaID.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.txtVendaID.Location = new System.Drawing.Point(98, 32);
            this.txtVendaID.Name = "txtVendaID";
            this.txtVendaID.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtVendaID.ReadOnly = true;
            this.txtVendaID.Size = new System.Drawing.Size(125, 27);
            this.txtVendaID.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtVendaID.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtVendaID.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtVendaID.StateCommon.Border.ColorAngle = 1F;
            this.txtVendaID.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtVendaID.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtVendaID.StateCommon.Border.Rounding = 1;
            this.txtVendaID.StateCommon.Border.Width = 1;
            this.txtVendaID.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.txtVendaID.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.txtVendaID.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtVendaID.TabIndex = 607;
            this.txtVendaID.TabStop = false;
            this.txtVendaID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(654, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 465;
            this.label1.Text = "DATA DA VENDA:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(11, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 16);
            this.label9.TabIndex = 498;
            this.label9.Text = "VENDA Nº:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 653);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(936, 22);
            this.statusStrip1.TabIndex = 580;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dgvItensVenda
            // 
            this.dgvItensVenda.AllowUserToAddRows = false;
            this.dgvItensVenda.AllowUserToDeleteRows = false;
            this.dgvItensVenda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItensVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensVenda.Location = new System.Drawing.Point(8, 250);
            this.dgvItensVenda.MultiSelect = false;
            this.dgvItensVenda.Name = "dgvItensVenda";
            this.dgvItensVenda.ReadOnly = true;
            this.dgvItensVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItensVenda.Size = new System.Drawing.Size(755, 195);
            this.dgvItensVenda.TabIndex = 593;
            this.dgvItensVenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItensVenda_CellClick);
            this.dgvItensVenda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItensVenda_KeyDown);
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtValorTotal.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.txtValorTotal.Location = new System.Drawing.Point(318, 3);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(131, 22);
            this.txtValorTotal.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtValorTotal.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtValorTotal.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtValorTotal.StateCommon.Border.ColorAngle = 1F;
            this.txtValorTotal.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtValorTotal.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtValorTotal.StateCommon.Border.Rounding = 1;
            this.txtValorTotal.StateCommon.Border.Width = 1;
            this.txtValorTotal.StateCommon.Content.Color1 = System.Drawing.Color.Green;
            this.txtValorTotal.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtValorTotal.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtValorTotal.TabIndex = 609;
            this.txtValorTotal.TabStop = false;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.label28.Location = new System.Drawing.Point(406, 1);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(88, 24);
            this.label28.TabIndex = 613;
            this.label28.Text = "VENDAS";
            // 
            // txtQtdItens
            // 
            this.txtQtdItens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQtdItens.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.txtQtdItens.Location = new System.Drawing.Point(103, 3);
            this.txtQtdItens.Name = "txtQtdItens";
            this.txtQtdItens.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.txtQtdItens.ReadOnly = true;
            this.txtQtdItens.Size = new System.Drawing.Size(131, 22);
            this.txtQtdItens.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.txtQtdItens.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtQtdItens.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.txtQtdItens.StateCommon.Border.ColorAngle = 1F;
            this.txtQtdItens.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtQtdItens.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtQtdItens.StateCommon.Border.Rounding = 1;
            this.txtQtdItens.StateCommon.Border.Width = 1;
            this.txtQtdItens.StateCommon.Content.Color1 = System.Drawing.Color.Green;
            this.txtQtdItens.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.txtQtdItens.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtQtdItens.TabIndex = 611;
            this.txtQtdItens.TabStop = false;
            this.txtQtdItens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.Location = new System.Drawing.Point(769, 402);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnNovo.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnNovo.OverrideDefault.Back.ColorAngle = 45F;
            this.btnNovo.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnNovo.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnNovo.OverrideDefault.Border.ColorAngle = 45F;
            this.btnNovo.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNovo.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnNovo.OverrideDefault.Border.Rounding = 1;
            this.btnNovo.OverrideDefault.Border.Width = 1;
            this.btnNovo.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Gadugi", 9F);
            this.btnNovo.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Gadugi", 9F);
            this.btnNovo.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnNovo.Size = new System.Drawing.Size(155, 43);
            this.btnNovo.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnNovo.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnNovo.StateCommon.Back.ColorAngle = 45F;
            this.btnNovo.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnNovo.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnNovo.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNovo.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnNovo.StateCommon.Border.Rounding = 1;
            this.btnNovo.StateCommon.Border.Width = 1;
            this.btnNovo.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnNovo.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNovo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnNovo.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnNovo.StatePressed.Back.ColorAngle = 135F;
            this.btnNovo.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnNovo.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnNovo.StatePressed.Border.ColorAngle = 135F;
            this.btnNovo.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNovo.StatePressed.Border.Rounding = 1;
            this.btnNovo.StatePressed.Border.Width = 1;
            this.btnNovo.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnNovo.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnNovo.StateTracking.Back.ColorAngle = 45F;
            this.btnNovo.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnNovo.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnNovo.StateTracking.Border.ColorAngle = 45F;
            this.btnNovo.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNovo.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnNovo.StateTracking.Border.Rounding = 1;
            this.btnNovo.StateTracking.Border.Width = 1;
            this.btnNovo.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNovo.TabIndex = 620;
            this.btnNovo.Values.Image = global::SisControl.Properties.Resources.Novo;
            this.btnNovo.Values.Text = "&Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizarVenda.Location = new System.Drawing.Point(769, 323);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnFinalizarVenda.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFinalizarVenda.OverrideDefault.Back.ColorAngle = 45F;
            this.btnFinalizarVenda.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnFinalizarVenda.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFinalizarVenda.OverrideDefault.Border.ColorAngle = 45F;
            this.btnFinalizarVenda.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFinalizarVenda.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFinalizarVenda.OverrideDefault.Border.Rounding = 1;
            this.btnFinalizarVenda.OverrideDefault.Border.Width = 1;
            this.btnFinalizarVenda.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarVenda.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Gadugi", 9F);
            this.btnFinalizarVenda.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Gadugi", 9F);
            this.btnFinalizarVenda.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnFinalizarVenda.Size = new System.Drawing.Size(155, 43);
            this.btnFinalizarVenda.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnFinalizarVenda.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFinalizarVenda.StateCommon.Back.ColorAngle = 45F;
            this.btnFinalizarVenda.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnFinalizarVenda.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFinalizarVenda.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFinalizarVenda.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFinalizarVenda.StateCommon.Border.Rounding = 1;
            this.btnFinalizarVenda.StateCommon.Border.Width = 1;
            this.btnFinalizarVenda.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnFinalizarVenda.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnFinalizarVenda.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarVenda.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnFinalizarVenda.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnFinalizarVenda.StatePressed.Back.ColorAngle = 135F;
            this.btnFinalizarVenda.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnFinalizarVenda.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnFinalizarVenda.StatePressed.Border.ColorAngle = 135F;
            this.btnFinalizarVenda.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFinalizarVenda.StatePressed.Border.Rounding = 1;
            this.btnFinalizarVenda.StatePressed.Border.Width = 1;
            this.btnFinalizarVenda.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFinalizarVenda.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnFinalizarVenda.StateTracking.Back.ColorAngle = 45F;
            this.btnFinalizarVenda.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnFinalizarVenda.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnFinalizarVenda.StateTracking.Border.ColorAngle = 45F;
            this.btnFinalizarVenda.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFinalizarVenda.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFinalizarVenda.StateTracking.Border.Rounding = 1;
            this.btnFinalizarVenda.StateTracking.Border.Width = 1;
            this.btnFinalizarVenda.TabIndex = 621;
            this.btnFinalizarVenda.Values.Image = global::SisControl.Properties.Resources.FinalizarVenda;
            this.btnFinalizarVenda.Values.Text = "&Finalizar";
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // btnParcelar
            // 
            this.btnParcelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParcelar.Location = new System.Drawing.Point(769, 251);
            this.btnParcelar.Name = "btnParcelar";
            this.btnParcelar.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnParcelar.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnParcelar.OverrideDefault.Back.ColorAngle = 45F;
            this.btnParcelar.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnParcelar.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnParcelar.OverrideDefault.Border.ColorAngle = 45F;
            this.btnParcelar.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnParcelar.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnParcelar.OverrideDefault.Border.Rounding = 1;
            this.btnParcelar.OverrideDefault.Border.Width = 1;
            this.btnParcelar.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParcelar.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Gadugi", 9F);
            this.btnParcelar.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Gadugi", 9F);
            this.btnParcelar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnParcelar.Size = new System.Drawing.Size(155, 43);
            this.btnParcelar.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnParcelar.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnParcelar.StateCommon.Back.ColorAngle = 45F;
            this.btnParcelar.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnParcelar.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnParcelar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnParcelar.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnParcelar.StateCommon.Border.Rounding = 1;
            this.btnParcelar.StateCommon.Border.Width = 1;
            this.btnParcelar.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnParcelar.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnParcelar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParcelar.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnParcelar.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnParcelar.StatePressed.Back.ColorAngle = 135F;
            this.btnParcelar.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnParcelar.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnParcelar.StatePressed.Border.ColorAngle = 135F;
            this.btnParcelar.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnParcelar.StatePressed.Border.Rounding = 1;
            this.btnParcelar.StatePressed.Border.Width = 1;
            this.btnParcelar.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnParcelar.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnParcelar.StateTracking.Back.ColorAngle = 45F;
            this.btnParcelar.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnParcelar.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnParcelar.StateTracking.Border.ColorAngle = 45F;
            this.btnParcelar.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnParcelar.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnParcelar.StateTracking.Border.Rounding = 1;
            this.btnParcelar.StateTracking.Border.Width = 1;
            this.btnParcelar.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnParcelar.TabIndex = 622;
            this.btnParcelar.Values.Image = global::SisControl.Properties.Resources.Parcelar;
            this.btnParcelar.Values.Text = "&Parcelar";
            this.btnParcelar.Click += new System.EventHandler(this.btnParcelar_Click_1);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel2.Controls.Add(this.label28);
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.kryptonPanel2.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.SeparatorHighInternalProfile;
            this.kryptonPanel2.Size = new System.Drawing.Size(936, 26);
            this.kryptonPanel2.TabIndex = 624;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel3.Controls.Add(this.label3);
            this.kryptonPanel3.Controls.Add(this.label2);
            this.kryptonPanel3.Controls.Add(this.txtValorTotal);
            this.kryptonPanel3.Controls.Add(this.txtQtdItens);
            this.kryptonPanel3.Location = new System.Drawing.Point(1, 646);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.kryptonPanel3.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.SeparatorHighInternalProfile;
            this.kryptonPanel3.Size = new System.Drawing.Size(936, 30);
            this.kryptonPanel3.TabIndex = 625;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(8, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 627;
            this.label3.Text = "Qtd. Itens";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(248, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 626;
            this.label2.Text = "TOTAL";
            // 
            // btnSair
            // 
            this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSair.Location = new System.Drawing.Point(769, 597);
            this.btnSair.Name = "btnSair";
            this.btnSair.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSair.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.OverrideDefault.Back.ColorAngle = 45F;
            this.btnSair.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSair.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.OverrideDefault.Border.ColorAngle = 45F;
            this.btnSair.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSair.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSair.OverrideDefault.Border.Rounding = 1;
            this.btnSair.OverrideDefault.Border.Width = 1;
            this.btnSair.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Gadugi", 9F);
            this.btnSair.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Gadugi", 9F);
            this.btnSair.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnSair.Size = new System.Drawing.Size(155, 43);
            this.btnSair.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSair.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateCommon.Back.ColorAngle = 45F;
            this.btnSair.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSair.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSair.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSair.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSair.StateCommon.Border.Rounding = 1;
            this.btnSair.StateCommon.Border.Width = 1;
            this.btnSair.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSair.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSair.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnSair.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
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
            this.btnSair.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
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
            this.btnSair.TabIndex = 626;
            this.btnSair.Values.Image = global::SisControl.Properties.Resources.sair;
            this.btnSair.Values.Text = "&Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Parcelar.png");
            this.imageList1.Images.SetKeyName(1, "Adicionar.png");
            // 
            // FrmPedidoVendaNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(936, 675);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.dtpDataVenda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnParcelar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.txtVendaID);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.dgvItensVenda);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPedidoVendaNovo";
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmVendas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPedido_KeyDown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.kryptonPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvItensVenda;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNomeCliente;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNomeProduto;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSubTotal;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtValorRecebido;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtValorProduto;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtQuantidade;
        public ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpDataVenda;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtVendaID;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtValorTotal;
        private System.Windows.Forms.Label label28;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLocalizarCliente;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLocalizarProduto;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtQtdItens;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radiobtnParcelado;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radiobtnAVista;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNovo;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnIncluir;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFinalizarVenda;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnParcelar;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSair;
        private System.Windows.Forms.ImageList imageList1;
        public Guna.UI2.WinForms.Guna2DateTimePicker dtpVencimento;
    }
}
