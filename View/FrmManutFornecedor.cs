using ComponentFactory.Krypton.Toolkit;
using GVC.BLL;
using GVC.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GVC.View
{
    public partial class FrmManutFornecedor : GVC.FrmBaseManutencao
    {
        private new string StatusOperacao;
        public FrmManutFornecedor( string statusOperacao)
        {
            this.StatusOperacao = statusOperacao;
            InitializeComponent();

            //Centraliza o Label dentro do Panel
            label28.Location = new Point(
                (kryptonPanel2.Width - label28.Width) / 2,
                (kryptonPanel2.Height - label28.Height) / 2);
        }
        private void CarregaDados()
        {
            FrmCadFornecedor frm = new FrmCadFornecedor(StatusOperacao);

            if (StatusOperacao == "NOVO")
            {
                frm.lblStatus.Text = "NOVO CADASTRO DE FORNECEDOR";   
                frm.lblStatus.ForeColor = Color.FromArgb(8, 142, 254);
                frm.ShowDialog();
            }
            if (StatusOperacao == "ALTERAR")
            {
                try
                {
                    // Verificar se a DataGridView contém alguma linha
                    if (dataGridPesquisar.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    // Execução do código desejado

                    frm.txtFornecedorID.Text = dataGridPesquisar.CurrentRow.Cells["FornecedorID"].Value.ToString();
                    frm.txtNomeFornecedor.Text = dataGridPesquisar.CurrentRow.Cells["Fornecedor"].Value.ToString();
                    frm.txtCnpjCpf.Text = dataGridPesquisar.CurrentRow.Cells["Cnpj"].Value.ToString();                    
                    frm.txtEndereco.Text = dataGridPesquisar.CurrentRow.Cells["Endereco"].Value.ToString();
                    frm.txtTelefone.Text = dataGridPesquisar.CurrentRow.Cells["Telefone"].Value.ToString();
                    frm.txtEmail.Text = dataGridPesquisar.CurrentRow.Cells["Email"].Value.ToString();
                    frm.txtNomeCidade.Text = dataGridPesquisar.CurrentRow.Cells["Cidade"].Value.ToString();
                    string cidade = dataGridPesquisar.CurrentRow.Cells["Cidade"].Value.ToString();
                    frm.txtCidadeID.Text = dataGridPesquisar.CurrentRow.Cells["CidadeID"].Value.ToString();
                    // Query SQL corrigida
                    string query = "SELECT Estado.NomeEstado AS Estado FROM Estado " +
                                   "INNER JOIN Cidade ON Estado.EstadoID = Cidade.EstadoID " +
                                   "WHERE Cidade.NomeCidade = @NomeCidade";

                    Utilitario.PesquisarPorCodigoRetornarNomeTexBox(query, "@NomeCidade", cidade, frm.txtEstado);

                    frm.lblStatus.Text = "ALTERAR CADASTRO";
                    frm.lblStatus.ForeColor = Color.Orange;
                    StatusOperacao = "ALTERAR";
                    
                    frm.btnNovo.Enabled = false;
                    frm.btnSalva.Text = "Alterar";

                    frm.ShowDialog();                   
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                try
                {
                    // Verificar se a DataGridView contém alguma linha
                    if (dataGridPesquisar.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    // Exemplo: Acessar a primeira célula de cada linha
                    //  var valor = row.Cells[0].Value;
                    frm.txtFornecedorID.Text = dataGridPesquisar.CurrentRow.Cells["FornecedorID"].Value.ToString();
                    frm.txtNomeFornecedor.Text = dataGridPesquisar.CurrentRow.Cells["Fornecedor"].Value.ToString();
                    frm.txtCnpjCpf.Text = dataGridPesquisar.CurrentRow.Cells["Cnpj"].Value.ToString();
                    frm.txtEndereco.Text = dataGridPesquisar.CurrentRow.Cells["Endereco"].Value.ToString();
                    frm.txtTelefone.Text = dataGridPesquisar.CurrentRow.Cells["Telefone"].Value.ToString();
                    frm.txtEmail.Text = dataGridPesquisar.CurrentRow.Cells["Email"].Value.ToString();
                    frm.txtNomeCidade.Text = dataGridPesquisar.CurrentRow.Cells["Cidade"].Value.ToString();
                    string cidade = dataGridPesquisar.CurrentRow.Cells["Cidade"].Value.ToString();
                    frm.txtCidadeID.Text = dataGridPesquisar.CurrentRow.Cells["CidadeID"].Value.ToString();
                    string query = "SELECT Estado.NomeEstado AS Estado FROM Estado " +
                                  "INNER JOIN Cidade ON Estado.EstadoID = Cidade.EstadoID " +
                                  "WHERE Cidade.NomeCidade = @NomeCidade";

                    Utilitario.PesquisarPorCodigoRetornarNomeTexBox(query, "@NomeCidade", cidade, frm.txtEstado);



                    frm.lblStatus.Text = "EXCLUSÃO DE REGISTRO!";
                    frm.lblStatus.ForeColor = Color.Red;
                    StatusOperacao = "EXCLUSÃO";
                   
                    frm.btnNovo.Enabled = false;
                   

                    frm.txtFornecedorID.Enabled = false;
                    frm.txtNomeFornecedor.Enabled = false;
                    frm.txtCnpjCpf.Enabled = false;
                    frm.txtEndereco.Enabled = false;
                    frm.txtTelefone.Enabled = false;
                    frm.btnSalva.Text = "Excluir";  
                    frm.ShowDialog();                                     
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
       
        public void PersonalizarDataGridView(KryptonDataGridView dgv)
        {
           
            //Alinhar o as colunas

            dgv.Columns["FornecedorID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgv.Columns["CidadeID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                       

            dgv.Columns[0].Name = "FornecedorID"   ;
            dgv.Columns[1].Name = "Fornecedor" ;
            dgv.Columns[2].Name = "Cnpj"           ;
            dgv.Columns[3].Name = "Endereco"        ;
            dgv.Columns[4].Name = "Telefone"           ;
            dgv.Columns[5].Name = "Email"          ;
            dgv.Columns[6].Name = "CidadeID"            ;
            dgv.Columns[7].Name = "Cidade"          ;

            dgv.Columns["FornecedorID"].Visible = false;
            dgv.Columns["CidadeID"].Visible = false;


            // Ajustar colunas automaticamente
            dataGridPesquisar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        public void ListarFornecedor()
        {
            FornecedorBLL objetoBll = new FornecedorBLL();
            dataGridPesquisar.DataSource = objetoBll.Listar();
            PersonalizarDataGridView(dataGridPesquisar);
        }
        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
        }
        private void FrmManutCategoria_Load(object sender, EventArgs e)
        {
            ListarFornecedor();
        }
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string textoPesquisa = txtPesquisa.Text.ToLower();

            string nome = "%" + txtPesquisa.Text + "%";
            FornecedorDALL dao = new FornecedorDALL();

            if (rbtCodigo.Checked)
            {               
                dataGridPesquisar.DataSource = dao.PesquisarPorCodigo(nome);
            }
            else
            {               
                dataGridPesquisar.DataSource = dao.PesquisarPorNome(nome);
            }
        }

        private void FrmManutFornecedor_Load(object sender, EventArgs e)
        {
            ListarFornecedor();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ListarFornecedor();
            timer1.Enabled = false;
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            StatusOperacao = "EXCLUSÃO";
            CarregaDados();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            StatusOperacao = "ALTERAR";
            CarregaDados();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            StatusOperacao = "NOVO";
            CarregaDados();
        }

        private void rbtCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            txtPesquisa.Focus();
        }

        private void rbtDescricao_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisa.Text = "";
            txtPesquisa.Focus();
        }
    }
}
