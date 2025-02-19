using ComponentFactory.Krypton.Toolkit;
using SisControl.BLL;
using SisControl.DALL;
using System;
using System.Drawing;
using System.Windows.Forms;
using SisControl.View;

namespace SisControl
{
    public partial class FrmManutEstado : SisControl.FrmBaseManutencao
    {
        private new string StatusOperacao;
        public FrmManutEstado(string statusOperacao)
        {
            InitializeComponent();
            PersonalizarDataGridView(dataGridPesquisar);
            this.StatusOperacao = statusOperacao;
            //Centraliza o Label dentro do Panel
            label28.Location = new Point(
                (kryptonPanel2.Width - label28.Width) / 2,
                (kryptonPanel2.Height - label28.Height) / 2);

        }
        public void PersonalizarDataGridView(KryptonDataGridView dgv)
        {
            // Verifica se há colunas no DataGridView antes de tentar personalizá-las
            if (dgv.Columns.Count > 0)
            {
                // Redimensionar as colunas manualmente
                dgv.Columns["EstadoID"].Width = 100;
                dgv.Columns["NomeEstado"].Width = 800;
                dgv.Columns["Uf"].Width = 100;

                // Centralizar cabeçalhos das colunas
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Centralizar o conteúdo das células nas colunas especificadas
                    if (column.Name == "EstadoID")
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else if (column.Name == "NomeEstado")
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Alinhar à esquerda
                    }
                }
            }
        }
        private void CarregaDados()
        {
            FrmCadEstado frm = new FrmCadEstado(StatusOperacao);

            try
            {
                if (StatusOperacao == "NOVO")
                {
                    frm.lblStatus.Text = "NOVO CADASTRO DE ESTADO";
                    frm.lblStatus.ForeColor = Color.FromArgb(8, 142, 254);
                    StatusOperacao = "NOVO";
                    frm.ShowDialog();

                    ((FrmManutEstado)Application.OpenForms["FrmManutEstado"]).HabilitarTimer(true);
                }
                if(StatusOperacao == "ALTERAR")
                {
                    frm.txtEstadoID.Text =     dataGridPesquisar.CurrentRow.Cells["EstadoID"].Value.ToString();
                    frm.txtNomeEstado.Text =      dataGridPesquisar.CurrentRow.Cells["NomeEstado"].Value.ToString();
                    frm.txtUf.Text =         dataGridPesquisar.CurrentRow.Cells["Uf"].Value.ToString();

                    frm.lblStatus.Text = "ALTERAR REGISTRO";
                    frm.lblStatus.ForeColor = Color.Orange;   
                    StatusOperacao = "ALTERAR";

                    frm.btnSalvar.Text = "Alterar";
                    frm.btnNovo.Enabled = false;
                    frm.ShowDialog();
                    ((FrmManutEstado)Application.OpenForms["FrmManutEstado"]).HabilitarTimer(true);
                }
                if (StatusOperacao == "EXCLUSÃO")
                {
                    frm.txtEstadoID.Text = dataGridPesquisar.CurrentRow.Cells["EstadoID"].Value.ToString();
                    frm.txtNomeEstado.Text = dataGridPesquisar.CurrentRow.Cells["NomeEstado"].Value.ToString();
                    frm.txtUf.Text = dataGridPesquisar.CurrentRow.Cells["Uf"].Value.ToString();

                    frm.lblStatus.Text = "EXCLUSÃO DE REGISTRO";
                    frm.lblStatus.ForeColor = Color.Orange;
                    StatusOperacao = "EXCLUSÃO";

                    frm.btnSalvar.Text = "Excluir";
                    frm.btnNovo.Enabled = false;
                    frm.ShowDialog();
                    ((FrmManutEstado)Application.OpenForms["FrmManutEstado"]).HabilitarTimer(true);
                }
         
                Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro..." + ex.Message);
            }
           //((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
        }
        private void FrmManutUsuario_Load(object sender, EventArgs e)
        {
            Listar();
        }
       

        public void Listar()
        {
            EstadoBLL estadobll = new EstadoBLL();
            dataGridPesquisar.DataSource = estadobll.Listar();
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
            EstadoDALL dao = new EstadoDALL();

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
    }
}
