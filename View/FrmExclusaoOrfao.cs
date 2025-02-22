using SisControl.BLL;
using SisControl.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static SisControl.View.FrmContaReceberr;

namespace SisControl.View
{
    public partial class FrmExclusaoOrfao : SisControl.FrmModeloForm
    {
        public FrmExclusaoOrfao()
        {
            InitializeComponent();
        }

        private void CarregarDados()
        {
            ListarVenda();
            ListarPagamentosParciais();           
            ListarParcelas();
            ListarItensVenda();
        }
        private void FrmExclusaoOrfao_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        public void ListarVenda()
        {
            dgvVendas.DataSource = new VendaDAL().ListarVenda();
        }
        public void ListarPagamentosParciais()
        {
            dgvPagamentosParciais.DataSource = new PagamentoParcialDal().ListarPagamentosParciais();
        }       
        public void ListarParcelas()
        {
            dgvParcelas.DataSource = new ParcelaDAL().ListarParcelas();
        }
        public void ListarItensVenda()
        {
            dgvItensVenda.DataSource = new ItemVendaDAL().ListarItensVenda();
        }

        private void btnExcluirVenda_Click(object sender, EventArgs e)
        {
            ExcluirRegistro<int>(dgvVendas, "VendaID", id => new VendaDAL().DeleteVenda(id), ListarVenda);
        }

        private void btnExcluirPagamentoParcial_Click(object sender, EventArgs e)
        {
            ExcluirRegistro<int>(dgvPagamentosParciais, "PagamentoParcialID", id => new PagamentoParcialDal().ExcluirPagamentosParciaisPorParcelaID(id), ListarPagamentosParciais);
        }

        private void btnExcluirParcelas_Click(object sender, EventArgs e)
        {
            ExcluirRegistro<int>(dgvParcelas, "ParcelaID", id => new ParcelaDAL().DeleteParcela(id), ListarParcelas);
        }

        private void btnExcluirItensVenda_Click(object sender, EventArgs e)
        {
            ExcluirRegistro<int>(dgvItensVenda, "ItemVendaID", id => new ItemVendaDAL().ExcluirItensPorVendaID(id), ListarItensVenda);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //****************************************************************************************************
        private void ExcluirRegistro<T>(DataGridView dgv, string colunaID, Action<int> metodoExclusao, Action listarDados)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Deseja excluir a conta selecionada?", "Excluir conta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int registroID = Convert.ToInt32(dgv.SelectedRows[0].Cells[colunaID].Value);
                        metodoExclusao(registroID);

                        MessageBox.Show("Conta excluída com sucesso.", "Excluir conta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recarregar os dados
                        listarDados();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir a conta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma conta para excluir.", "Excluir conta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }     

    }
}
