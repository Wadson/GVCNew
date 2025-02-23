using GVC.BLL;
using GVC.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GVC.View
{
    public partial class FrmCadProdutos : FrmModeloForm
    {
        private string QueryProdutos = "SELECT MAX(ProdutoID)  FROM Produtos";
        
        private string StatusOperacao;
        private int ProdutoID;

        public FrmCadProdutos(string statusOperacao)
        {
            InitializeComponent();

            // Utiliza a classe Utilitario para adicionar os efeitos de foco a todos os TextBoxes no formulário
            Utilitario.AdicionarEfeitoFocoEmTodos(this);

            this.txtPrecoCusto.Enter += new System.EventHandler(this.txtPrecoCusto_Enter);
            this.txtPrecoCusto.Leave += new System.EventHandler(this.txtPrecoCusto_Leave);
            this.txtLucro.Enter += new System.EventHandler(this.txtLucro_Enter);
            this.txtLucro.Leave += new System.EventHandler(this.txtLucro_Leave);


            this.StatusOperacao = statusOperacao;
        }
        #region ENTER COMO TAB **************************************************************************************

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.ActiveControl is KryptonButton)
                {
                    ((KryptonButton)this.ActiveControl).PerformClick();
                    return true;
                }
                else
                {
                    SelectNextControl(this.ActiveControl, true, true, true, true);
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        SelectNextControl(this.ActiveControl, true, true, true, true);
        //        return true;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        //TECLA ENTER COMO ENTER




        #endregion ********************ENTER COMO TAB**********************************************************
        private void FrmCadProdutos_Load(object sender, EventArgs e)
        {
            Utilitario.FormatTextBoxToCurrencyKrypton(txtPrecoCusto);
            Utilitario.FormatTextBoxToCurrencyKrypton(txtLucro);
            Utilitario.FormatTextBoxToCurrencyKrypton(txtPrecoDeVenda);

            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryProdutos);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 4);
                txtProdutoID.Text = numeroComZeros;
            }            
            cmbStatus.SelectedIndex = 1;
        }

        private void CalcularPrecoVenda()
        {
            if (decimal.TryParse(txtPrecoCusto.Text, out decimal precoCusto) &&
                !string.IsNullOrWhiteSpace(txtLucro.Text))
            {
                decimal precoVenda = 0;

                if (txtLucro.Text.EndsWith("%"))
                {
                    string lucroPercentualStr = txtLucro.Text.TrimEnd('%');
                    if (decimal.TryParse(lucroPercentualStr, out decimal lucroPercentual))
                    {
                        precoVenda = precoCusto + (precoCusto * lucroPercentual / 100);
                    }
                }
                else if (decimal.TryParse(txtLucro.Text, out decimal lucro))
                {
                    precoVenda = precoCusto + lucro;
                }

                txtPrecoDeVenda.Text = precoVenda.ToString(CultureInfo.CurrentCulture);
            }
            else
            {
                txtPrecoDeVenda.Text = string.Empty;
            }
        }

        private void CalcularLucro()
        {
            if (decimal.TryParse(txtPrecoCusto.Text, out decimal precoCusto) &&
                decimal.TryParse(txtPrecoDeVenda.Text, out decimal precoVenda))
            {
                decimal lucroCalculado = precoVenda - precoCusto;
                txtLucro.Text = lucroCalculado.ToString(CultureInfo.CurrentCulture);
            }
            else
            {
                txtLucro.Text = string.Empty;
            }
        }


        private void FrmCadProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Muda o foco para o próximo controle
                this.SelectNextControl(this.ActiveControl, true, true, true, true);

                // Impede o som de alerta padrão do Windows
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }



        private void Salvar()
        {
            // Criar uma nova instância de ProdutoMODEL e preencher com os dados do formulário
            ProdutosModel produto = new ProdutosModel
            {
                ProdutoID = int.Parse(txtProdutoID.Text),
                NomeProduto = txtNomeProduto.Text,
                PrecoCusto = decimal.Parse(txtPrecoCusto.Text),
                Lucro = decimal.Parse(txtLucro.Text),
                PrecoDeVenda = decimal.Parse(txtPrecoDeVenda.Text),
                Estoque = int.Parse(txtEstoque.Text),
                DataDeEntrada = dtpDataDeEntrada.Value,
                Status = cmbStatus.Text,
                          
                Referencia = txtReferencia.Text
            };

            try
            {
                // Chamar o método SalvarProduto da BLL
                ProdutoBLL produtosbll = new ProdutoBLL();
                produtosbll.Salvar(produto);

                MessageBox.Show("Produto salvo com sucesso!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Utilitario.LimpaCampoKrypton(this);
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryProdutos);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 4);
                txtProdutoID.Text = numeroComZeros;
                txtNomeProduto.Focus();
                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Excluir()
        {
            try
            {
                ProdutosModel objetoProduto = new ProdutosModel();

                objetoProduto.ProdutoID = Convert.ToInt32(txtProdutoID.Text);
                ProdutoBLL produtoBll = new ProdutoBLL();

                produtoBll.Excluir(objetoProduto);
                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampoKrypton(this);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Excluir o registro!!! " + erro);
            }
        }
        private void Alterar()
        {
            try
            {
                // Criar uma nova instância de ProdutoMODEL e preencher com os dados do formulário
                ProdutosModel produto = new ProdutosModel
                {
                    ProdutoID = int.Parse(txtProdutoID.Text),
                    NomeProduto = txtNomeProduto.Text,
                    PrecoCusto = decimal.Parse(txtPrecoCusto.Text),
                    Lucro = decimal.Parse(txtLucro.Text),
                    PrecoDeVenda = decimal.Parse(txtPrecoDeVenda.Text),
                    Estoque = int.Parse(txtEstoque.Text),
                    DataDeEntrada = dtpDataDeEntrada.Value,
                    Status = cmbStatus.Text,
                    Referencia = txtReferencia.Text
                };

                // Chamar o método AlterarProduto da BLL
                ProdutoBLL produtosbll = new ProdutoBLL();
                produtosbll.Alterar(produto);

                MessageBox.Show("Produto alterado com sucesso!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Utilitario.LimpaCampoKrypton(this);            
                this.Close();
                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Alterar o registro: " + ex.Message);
            }
        }


        private void btnSalva_Click(object sender, EventArgs e)
        {
            FrmManutUsuario pesquisausuario = new FrmManutUsuario(StatusOperacao);

            if (StatusOperacao == "ALTERAR")
            {
                Alterar();
            }
            if (StatusOperacao == "NOVO")
            {
                Salvar();
                Utilitario.LimpaCampoKrypton(this);
                txtNomeProduto.Focus();

                ProdutoID = Utilitario.GerarProximoCodigo(QueryProdutos);
                int codigo = ProdutoID;
                txtProdutoID.Text = Utilitario.AcrescentarZerosEsquerda(codigo, 6);

                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Usuário: " + txtNomeProduto.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Excluir();
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Utilitario.LimpaCampoKrypton(this);
            ProdutoID = Utilitario.GerarProximoCodigo("SELECT MAX(ProdutoID) FROM Produto");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      

        private void btnLocalizarImagem_Click(object sender, EventArgs e)
        {           
        }
          
        private void txtPrecoCusto_Leave(object sender, EventArgs e)
        {
            txtPrecoCusto.BackColor = Color.White;

            // Formata apenas se não estiver vazio
            if (!string.IsNullOrWhiteSpace(txtPrecoCusto.Text))
            {
                CalcularPrecoVenda();
            }

            if (!string.IsNullOrWhiteSpace(txtPrecoDeVenda.Text))
            {
                Utilitario.FormatTextBoxToCurrencyKrypton(txtPrecoDeVenda);
            }
            Utilitario.FormatTextBoxToCurrencyKrypton(txtPrecoCusto);
        }

        private void txtLucro_Leave(object sender, EventArgs e)
        {
            /*Utilitario.FormatTextBoxToCurrency(txtLucro)*/
            ;
            txtLucro.BackColor = Color.White;

            // Formata apenas se não estiver vazio
            if (!string.IsNullOrWhiteSpace(txtLucro.Text))
            {
                CalcularPrecoVenda();
            }

            if (!string.IsNullOrWhiteSpace(txtPrecoDeVenda.Text))
            {
                Utilitario.FormatTextBoxToCurrencyKrypton(txtPrecoDeVenda);
            }
            Utilitario.FormatTextBoxToCurrencyKrypton(txtLucro);
        }

        private void txtPrecoCusto_Enter(object sender, EventArgs e)
        {
            KryptonTextBox textBox = sender as KryptonTextBox;

            
            if (textBox != null && textBox.Text == "0,00")
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    textBox.Text = string.Empty;
                });
            }
        }

        private void txtLucro_Enter(object sender, EventArgs e)
        {
            KryptonTextBox textBox = sender as KryptonTextBox;
                       
            if (textBox != null && textBox.Text == "0,00")
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    textBox.Text = string.Empty;
                });
            }
        }

        private void txtPrecoDeVenda_Leave(object sender, EventArgs e)
        {
            CalcularLucro();
        }
    }
}

