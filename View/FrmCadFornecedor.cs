using GVC.BLL;
using GVC.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GVC.View
{
    public partial class FrmCadFornecedor : FrmModeloForm
    {
        private string QueryFornecedor = "SELECT MAX(FornecedorID) FROM Fornecedor";
        private int FornecedorID;        
        private string StatusOperacao;
        public FrmCadFornecedor(string statusOperacao)
        {
            this.StatusOperacao = statusOperacao;
            InitializeComponent();
            // Utiliza a classe Utilitario para adicionar os efeitos de foco a todos os TextBoxes no formulário
            Utilitario.AdicionarEfeitoFocoEmTodos(this);
        }
        public void SalvarRegistro()
        {
            try
            {
                FornecedorMODEL objetoModel = new FornecedorMODEL();

                objetoModel.FornecedorID = Convert.ToInt32(txtFornecedorID.Text);
                objetoModel.NomeFornecedor = txtNomeFornecedor.Text;
                objetoModel.Cnpj = txtCnpjCpf.Text;
                objetoModel.Endereco = txtEndereco.Text;
                objetoModel.Telefone = txtTelefone.Text;
                objetoModel.Email = txtEmail.Text;
                objetoModel.CidadeID = Convert.ToInt32(txtCidadeID.Text);

                FornecedorBLL objetoBll = new FornecedorBLL();

                objetoBll.Salvar(objetoModel);
                MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutFornecedor)Application.OpenForms["FrmManutFornecedor"]).HabilitarTimer(true);
            }
            catch (OverflowException ov)
            {
                MessageBox.Show("Overfow Exeção deu erro! " + ov);
            }
            catch (Win32Exception erro)
            {
                MessageBox.Show("Win32 Win32!!! \n" + erro);
            }
        }
        public void AlterarRegistro()
        {
            try
            {
                FornecedorMODEL objetoModel = new FornecedorMODEL();

                objetoModel.FornecedorID = Convert.ToInt32(txtFornecedorID.Text);
                objetoModel.NomeFornecedor = txtNomeFornecedor.Text;
                objetoModel.Cnpj = txtCnpjCpf.Text;
                objetoModel.Endereco = txtEndereco.Text;
                objetoModel.Telefone = txtTelefone.Text;
                objetoModel.Email = txtEmail.Text;
                objetoModel.CidadeID = Convert.ToInt32(txtCidadeID.Text);

                FornecedorBLL objetoBll = new FornecedorBLL();
                objetoBll.Alterar(objetoModel);

                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutFornecedor)Application.OpenForms["FrmManutFornecedor"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampo(this);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Alterar o registro!!! " + erro);
            }
        }
        
        public void ExcluirRegistro()
        {
            try
            {
                FornecedorMODEL objetoModel = new FornecedorMODEL();

                objetoModel.FornecedorID = Convert.ToInt32(txtFornecedorID.Text.Trim());
                FornecedorBLL objetoBll = new FornecedorBLL();

                objetoBll.Excluir(objetoModel);
                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                // Limpa os campos
                Utilitario.LimpaCampo(this);
                this.Close();
                var frmManutFornecedor = Application.OpenForms["FrmManutFornecedor"] as FrmManutFornecedor;
               
                if (frmManutFornecedor != null)
                {
                    frmManutFornecedor.HabilitarTimer(true);
                }
                else
                {
                    MessageBox.Show("FrmManutFornecedor não está aberto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Excluir o registro: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCadFornecedor_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryFornecedor);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                FornecedorID = NovoCodigo;
                txtFornecedorID.Text = numeroComZeros;
            }
        }


        private void btnLocalizar_Click_1(object sender, EventArgs e)
        {
            FrmLocalizarCidade frmLocalizarCidade = new FrmLocalizarCidade(this);
            frmLocalizarCidade.Text = "Localizar Fornecedor...";        
            
            frmLocalizarCidade.ShowDialog();

            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(FornecedorID, 6);
            FornecedorID = int.Parse(numeroComZeros);
            txtFornecedorID.Text = FornecedorID.ToString();
            btnSalva.Focus();           
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                AlterarRegistro();
            }
            if (StatusOperacao == "NOVO")
            {
                SalvarRegistro();
                Utilitario.LimpaCampo(this);
                txtNomeFornecedor.Focus();

                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryFornecedor);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                FornecedorID = NovoCodigo;
                txtFornecedorID.Text = numeroComZeros;

                ((FrmManutFornecedor)Application.OpenForms["FrmManutFornecedor"]).HabilitarTimer(true);

            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Usuário: " + txtNomeFornecedor.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            Utilitario.LimpaCampo(this);

            int NovoCodigo = Utilitario.GerarProximoCodigo(QueryFornecedor);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
            FornecedorID = NovoCodigo;
            txtFornecedorID.Text = numeroComZeros;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadFornecedor_FormClosed(object sender, FormClosedEventArgs e)
        {           
        }
    }
}
