using GVC.BLL;
using GVC.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static GVC.View.FrmContaReceberr;

namespace GVC.View
{
    public partial class FrmExclusaoOrfaos : GVC.FrmModeloForm
    {
        public FrmExclusaoOrfaos()
        {
            InitializeComponent();
        }
        private void CarregarDados()
        {
            AtualizarDataGrid(dgvVendas, () => new VendaDAL().ListarVenda());
            AtualizarDataGrid(dgvPagamentosParciais, () => new PagamentoParcialDal().ListarPagamentosParciais());
            AtualizarDataGrid(dgvParcelas, () => new ParcelaDAL().ListarParcelas());
            AtualizarDataGrid(dgvItensVenda, () => new ItemVendaDAL().ListarItensVenda());
        }

        /// <summary>
        /// Atualiza o DataGridView com os dados fornecidos pelo método de listagem.
        /// </summary>
        private void AtualizarDataGrid(DataGridView dgv, Func<object> listarDados) =>
            dgv.DataSource = listarDados();

        /// <summary>
        /// Método genérico para excluir registros com confirmação e recarregar os dados.
        /// </summary>
        private void ExcluirRegistro(DataGridView dgv, string colunaID, Action<int> metodoExclusao, Action atualizarGrid, string nomeEntidade)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show($"Selecione um(a) {nomeEntidade.ToLower()} para excluir.", $"Excluir {nomeEntidade}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Deseja excluir o(a) {nomeEntidade.ToLower()} selecionado(a)?", $"Excluir {nomeEntidade}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int registroID = Convert.ToInt32(dgv.SelectedRows[0].Cells[colunaID].Value);
                metodoExclusao(registroID);

                MessageBox.Show($"{nomeEntidade} excluído(a) com sucesso.", $"Excluir {nomeEntidade}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                atualizarGrid();  // Recarrega os dados após exclusão
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir {nomeEntidade.ToLower()}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Handlers dos botões de exclusão
        private void btnExcluirVenda_Click(object sender, EventArgs e) =>
            ExcluirRegistro(dgvVendas, "VendaID", id => new VendaDAL().DeleteVenda(id), () => AtualizarDataGrid(dgvVendas, () => new VendaDAL().ListarVenda()), "Venda");

        private void btnExcluirPagamentoParcial_Click(object sender, EventArgs e) =>
            ExcluirRegistro(dgvPagamentosParciais, "PagamentoParcialID", id => new PagamentoParcialDal().ExcluirPagamentosParciaisPorParcelaID(id),
                            () => AtualizarDataGrid(dgvPagamentosParciais, () => new PagamentoParcialDal().ListarPagamentosParciais()), "Pagamento Parcial");

        private void btnExcluirParcelas_Click(object sender, EventArgs e) =>
            ExcluirRegistro(dgvParcelas, "ParcelaID", id => new ParcelaDAL().DeleteParcela(id),
                            () => AtualizarDataGrid(dgvParcelas, () => new ParcelaDAL().ListarParcelas()), "Parcela");

        private void btnExcluirItensVenda_Click(object sender, EventArgs e) =>
            ExcluirRegistro(dgvItensVenda, "ItemVendaID", id => new ItemVendaDAL().ExcluirItensPorVendaID(id),
                            () => AtualizarDataGrid(dgvItensVenda, () => new ItemVendaDAL().ListarItensVenda()), "Item de Venda");

        private void btnSair_Click(object sender, EventArgs e) => Close();

        private void FrmExclusaoOrfao_Load(object sender, EventArgs e) => CarregarDados();
        //****************************************************************************************************
        /// <summary>
        /// Exclui todos os registros selecionados no DataGridView com confirmação.
        /// </summary>
        private void ExcluirRegistrosSelecionados(DataGridView dgv, string colunaID, Action<int> metodoExclusao, Action atualizarGrid, string nomeEntidade)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show($"Selecione pelo menos um(a) {nomeEntidade.ToLower()} para excluir.", $"Excluir {nomeEntidade}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantidadeSelecionada = dgv.SelectedRows.Count;

            if (MessageBox.Show($"Deseja excluir os {quantidadeSelecionada} {nomeEntidade.ToLower()}(s) selecionado(s)?",
                                $"Excluir {nomeEntidade}(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int excluidosComSucesso = 0;
            int falhas = 0;

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                try
                {
                    int registroID = Convert.ToInt32(row.Cells[colunaID].Value);
                    metodoExclusao(registroID);
                    excluidosComSucesso++;
                }
                catch (Exception ex)
                {
                    falhas++;
                    // Log do erro pode ser adicionado aqui se necessário
                    Console.WriteLine($"Falha ao excluir {nomeEntidade.ToLower()} com ID {row.Cells[colunaID].Value}: {ex.Message}");
                }
            }

            atualizarGrid(); // Recarrega os dados após a exclusão

            string mensagem = $"Total selecionados: {quantidadeSelecionada}\nExcluídos com sucesso: {excluidosComSucesso}\nFalhas: {falhas}";
            MessageBox.Show(mensagem, $"Resultado da exclusão de {nomeEntidade}(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
