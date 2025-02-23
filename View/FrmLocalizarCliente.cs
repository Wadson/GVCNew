using GVC.DALL;
using GVC.Relatorios;
using System;
using System.Windows.Forms;

namespace GVC.View
{
    public partial class FrmLocalizarCliente : GVC.FrmBasePesquisa
    {        
        protected int LinhaAtual = -1;
        private int _clienteID;
        public int numeroComZeros { get; set; }
        public string ClienteSelecionado { get; set; }

        private Form _formChamador;
        public FrmLocalizarCliente(Form formChamador, string textoDigitado)
        {
            InitializeComponent();

            // Verifica se o formulário chamador é válido
            if (formChamador != null)
            {
                this._formChamador = formChamador;
            }
            txtPesquisa.Text = textoDigitado;
            txtPesquisa.SelectionStart = txtPesquisa.Text.Length;
            PesquisarCliente();

            //_formChamador = formChamador;
            dataGridPesquisar.SelectionChanged += dataGridPesquisar_SelectionChanged;
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
            this.dataGridPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridPesquisar_KeyDown);
            this.txtPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisa_KeyDown);
        }

        public new int ObterLinhaAtual()
        {
            return LinhaAtual;
        }

        public void PersonalizarDataGridView()
        {
            dataGridPesquisar.Columns["ClienteID"].HeaderText = "Cód. Cliente";
            dataGridPesquisar.Columns["NomeCliente"].HeaderText = "Nome do Cliente";
            dataGridPesquisar.Columns["Cpf"].HeaderText = "CPF";
            dataGridPesquisar.Columns["Endereco"].HeaderText = "Endereço";
            dataGridPesquisar.Columns["Telefone"].HeaderText = "Telefone";
            dataGridPesquisar.Columns["Email"].HeaderText = "E-mail";
            dataGridPesquisar.Columns["CidadeID"].HeaderText = "Cód. Cidade";
            dataGridPesquisar.Columns["NomeCidade"].HeaderText = "Nome da Cidade";
            dataGridPesquisar.Columns["NomeEstado"].HeaderText = "Nome do Estado";

            // Ajustar colunas automaticamente
            dataGridPesquisar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Tornar o grid somente leitura
            dataGridPesquisar.ReadOnly = true;

            // Centralizar coluna de Estoque (exemplo: NomeCidade)
            //this.dataGridPesquisar.Columns["NomeCidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configurar fundo amarelo claro
            dataGridPesquisar.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow; // Fundo amarelo claro

            // Ajustar largura do cabeçalho da linha
            dataGridPesquisar.RowHeadersWidth = 10; // Definir largura do cabeçalho da linha
                                                    // Ajustar largura dos cabeçalhos das colunas
            foreach (DataGridViewColumn column in dataGridPesquisar.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centralizar cabeçalho da coluna
                column.HeaderCell.Style.WrapMode = DataGridViewTriState.False; // Evitar quebra de texto no cabeçalho
                column.Width = 100; // Definir largura específica para cada coluna
            }
        }



        public void ListarCliente()
        {
            ClienteDALL dao = new ClienteDALL();
            dataGridPesquisar.DataSource = dao.PesquisarGeral();

            PersonalizarDataGridView();
        }

        private void FrmLocalizarCliente_Load(object sender, EventArgs e)
        {
            ListarCliente();
        }

        private void PesquisarCliente()
        {
            string textoPesquisa = txtPesquisa.Text.ToLower();

            string nome = "%" + txtPesquisa.Text + "%";
            ClienteDALL dao = new ClienteDALL();

            if (rbtCodigo.Checked)
            {
                dataGridPesquisar.DataSource = dao.PesquisarPorCodigo(nome);
            }
            else
            {
                dataGridPesquisar.DataSource = dao.PesquisarPorNome(nome);
            }
        }
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
           PesquisarCliente();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLocalizarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            SelecionarCliente(); // Seleciona o cliente no dataGridPesquisar
        }

        private bool isSelectingProduct = false;
        private Form formChamador;
        private void SelecionarCliente()
{
    if (isSelectingProduct) return;
    isSelectingProduct = true;

    try
    {
        if (LinhaAtual < 0 || LinhaAtual >= dataGridPesquisar.Rows.Count)
        {
            MessageBox.Show("Linha inválida.");
            return;
        }

        if (dataGridPesquisar["ClienteID", LinhaAtual]?.Value == null ||
            dataGridPesquisar["NomeCliente", LinhaAtual]?.Value == null)
        {
            MessageBox.Show("Dados do cliente inválidos.");
            return;
        }

        _clienteID = int.Parse(dataGridPesquisar["ClienteID", LinhaAtual].Value.ToString());
        ClienteSelecionado = dataGridPesquisar["NomeCliente", LinhaAtual].Value.ToString();

        if (this.Owner is FrmPedidoVendaNovo frmPedidoVendaNovo)
        {
            frmPedidoVendaNovo.ClienteID = _clienteID;
            frmPedidoVendaNovo.txtNomeCliente.Text = ClienteSelecionado;
        }
        else if (this.Owner is FrmContaReceberr frmContaReceberr)
        {
            frmContaReceberr.clienteID = _clienteID;
            frmContaReceberr.txtNomeCliente.Text = ClienteSelecionado;
        }
        else if (this.Owner is FrmRelatorios frmRelatorios)
        {
            frmRelatorios.txtClienteID.Text = _clienteID.ToString();
            frmRelatorios.txtNomeCliente.Text = ClienteSelecionado;
        }
        else if (this.Owner is RelClienteContaAberta frmRelGeralContasAbertas)
        {
            frmRelGeralContasAbertas.txtNomeCliente.Text = ClienteSelecionado;
        }
        else
        {
            MessageBox.Show("O formulário chamador não é reconhecido.");
        }

        this.DialogResult = DialogResult.OK; // Confirma que um cliente foi selecionado
        this.Close();
    }
    finally
    {
        isSelectingProduct = false;
    }
}
        //private void SelecionarCliente()
        //{
        //    if (isSelectingProduct) return;
        //    isSelectingProduct = true;

        //    try
        //    {
        //        if (LinhaAtual < 0 || LinhaAtual >= dataGridPesquisar.Rows.Count)
        //        {
        //            MessageBox.Show("Cliente não encontrado!.");
        //            return;
        //        }

        //        if (dataGridPesquisar["ClienteID", LinhaAtual]?.Value == null ||
        //            dataGridPesquisar["NomeCliente", LinhaAtual]?.Value == null)
        //        {
        //            MessageBox.Show("Dados do cliente inválidos.");
        //            return;
        //        }

        //        _clienteID = int.Parse(dataGridPesquisar["ClienteID", LinhaAtual].Value.ToString());
        //        ClienteSelecionado = dataGridPesquisar["NomeCliente", LinhaAtual].Value.ToString();

        //        if (this.Owner is FrmPedidoVendaNovo frmPedidoVendaNovo)
        //        {
        //            frmPedidoVendaNovo.ClienteID = _clienteID;
        //            frmPedidoVendaNovo.txtNomeCliente.Text = ClienteSelecionado;
        //        }
        //        else if (this.Owner is FrmContaReceberr frmContaReceberr)
        //        {
        //            frmContaReceberr.clienteID = _clienteID;
        //            frmContaReceberr.txtNomeCliente.Text = ClienteSelecionado;
        //        }
        //        else if (this.Owner is FrmRelatorios frmRelatorios)
        //        {
        //            frmRelatorios.txtClienteID.Text = _clienteID.ToString();
        //            frmRelatorios.txtNomeCliente.Text = ClienteSelecionado;
        //        }
        //        else if (this.Owner is RelClienteContaAberta frmRelGeralContasAbertas)
        //        {
        //            //frmRelGeralContasAbertas.txtClienteID.Text = ClienteID.ToString();
        //            frmRelGeralContasAbertas.txtNomeCliente.Text = ClienteSelecionado;
        //        }
        //        else
        //        {
        //            MessageBox.Show("O formulário chamador não é reconhecido.");
        //        }

        //        this.Close();
        //    }
        //    finally
        //    {
        //        isSelectingProduct = false;
        //    }
        //}



        private void dataGridPesquisar_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridPesquisar.CurrentRow != null)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
            }
        }

        private void dataGridPesquisar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ClienteSelecionado = dataGridPesquisar.Rows[e.RowIndex].Cells["NomeCliente"].Value.ToString();

                this.DialogResult = DialogResult.OK; // Indica que a seleção foi feita corretamente
                this.Close();
            }
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dataGridPesquisar.Focus();
                if (dataGridPesquisar.Rows.Count > 0)
                {
                    dataGridPesquisar.CurrentCell = dataGridPesquisar.Rows[0].Cells[0];
                }
            }
        }

        private void dataGridPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && dataGridPesquisar.CurrentCell.RowIndex == 0)
            {
                txtPesquisa.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita o "beep" do Enter no DataGridView

                if (dataGridPesquisar.CurrentRow != null)
                {
                    LinhaAtual = dataGridPesquisar.CurrentRow.Index; // Atualiza a linha atual corretamente
                    SelecionarCliente();
                }
            }
        }

    }
}