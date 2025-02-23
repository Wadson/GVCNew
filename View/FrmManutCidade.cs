using ComponentFactory.Krypton.Toolkit;
using GVC.BLL;
using GVC.DALL;
using System;
using System.Drawing;
using System.Windows.Forms;
using GVC.View;

namespace GVC
{
    public partial class FrmManutCidade : GVC.FrmBaseManutencao
    {
        private new string StatusOperacao;
        public FrmManutCidade(string statusOperacao)
        {
            InitializeComponent();

            PersonalizarDataGridView(dataGridPesquisar);
            this.StatusOperacao = statusOperacao;
            
            //Centraliza o Label dentro do Panel
            label28.Location = new Point(
                (kryptonPanel2.Width - label28.Width) / 2,
                (kryptonPanel2.Height - label28.Height) / 2);

        }
      
        private void CarregaDados()
        {
            FrmCadCidade frmcadcidade = new FrmCadCidade(StatusOperacao);

            try
            {
                if (StatusOperacao == "NOVO")
                {
                    frmcadcidade.lblStatus.Text = "NOVO CADASTRO DE CIDADE";
                    frmcadcidade.lblStatus.ForeColor = Color.FromArgb(8, 142, 254);
                    StatusOperacao = "NOVO";
                    frmcadcidade.ShowDialog();

                    ((FrmManutCidade)Application.OpenForms["FrmManutCidade"]).HabilitarTimer(true);
                }
                if(StatusOperacao == "ALTERAR")
                {
                    frmcadcidade.txtCidadeID.Text =     dataGridPesquisar.CurrentRow.Cells["CidadeID"].Value.ToString();
                    frmcadcidade.txtNomeCidade.Text =      dataGridPesquisar.CurrentRow.Cells["NomeCidade"].Value.ToString();
                    frmcadcidade.txtEstadoID.Text =         dataGridPesquisar.CurrentRow.Cells["EstadoID"].Value.ToString();                                        

                    frmcadcidade.lblStatus.Text = "ALTERAR REGISTRO";
                    frmcadcidade.lblStatus.ForeColor = Color.Orange;   
                    StatusOperacao = "ALTERAR";
                    
                    frmcadcidade.btnSalvar.Text = "Alterar";
                    frmcadcidade.btnNovo.Enabled = false;
                                        
                    frmcadcidade.ShowDialog();
                    ((FrmManutCidade)Application.OpenForms["FrmManutCidade"]).HabilitarTimer(true);
                }
                if (StatusOperacao == "EXCLUSÃO")
                {
                    frmcadcidade.txtCidadeID.Text = dataGridPesquisar.CurrentRow.Cells["CidadeID"].Value.ToString();
                    frmcadcidade.txtNomeCidade.Text = dataGridPesquisar.CurrentRow.Cells["NomeCidade"].Value.ToString();
                    frmcadcidade.txtEstadoID.Text = dataGridPesquisar.CurrentRow.Cells["EstadoID"].Value.ToString();

                    frmcadcidade.lblStatus.Text = "EXCLUSÃO DE REGISTRO";
                    frmcadcidade.lblStatus.ForeColor = Color.Red;
                    StatusOperacao = "EXCLUSÃO";

                    frmcadcidade.btnSalvar.Text = "Excluir";
                    frmcadcidade.btnNovo.Enabled = false;                    
                    

                    frmcadcidade.txtCidadeID.Enabled = false;
                    frmcadcidade.txtNomeCidade.Enabled = false;
                    frmcadcidade.txtNomeCidade.Enabled = false;
                    frmcadcidade.txtEstadoID.Enabled  = false;                   

                    frmcadcidade.ShowDialog();
                    ((FrmManutCidade)Application.OpenForms["FrmManutCidade"]).HabilitarTimer(true);
                }                
                Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro..." + ex.Message);
            }           
        }
        public void PersonalizarDataGridView(KryptonDataGridView dgv)
        {
            // Verifica se há colunas no DataGridView antes de tentar personalizá-las
            if (dgv.Columns.Count > 0)
            {
                // Redimensionar as colunas manualmente
                dgv.Columns["CidadeID"].Width = 100;
                dgv.Columns["NomeCidade"].Width = 800;
                dgv.Columns["EstadoID"].Width = 100;

                // Centralizar cabeçalhos das colunas
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Centralizar o conteúdo das células nas colunas especificadas
                    if (column.Name == "CidadeID" || column.Name == "EstadoID")
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else if (column.Name == "NomeCidade")
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Alinhar à esquerda
                    }
                }
            }
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        public void Listar()
        {
            CidadeBLL cidadeBll = new CidadeBLL();
            dataGridPesquisar.DataSource = cidadeBll.Listar();
            PersonalizarDataGridView(dataGridPesquisar);
        }
        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            Listar();
            timer1.Enabled = false;
        }
              
        private void btnNovo_Click(object sender, EventArgs e)
        {
            StatusOperacao = "NOVO";
           CarregaDados();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            StatusOperacao = "ALTERAR";            
            CarregaDados();   
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            StatusOperacao = "EXCLUSÃO";           
            CarregaDados();
        }
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string textoPesquisa = txtPesquisa.Text.ToLower();

            string nome = "%" + txtPesquisa.Text + "%";
            CidadeDALL dao = new CidadeDALL();

            if (rbtCodigo.Checked)
            {               
                dataGridPesquisar.DataSource = dao.PesquisarPorCodigo(nome);
            }
            else
            {              
                dataGridPesquisar.DataSource = dao.PesquisarPorNome(nome);
            }
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

        private void FrmManutCidade_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
