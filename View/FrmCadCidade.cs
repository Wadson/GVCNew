using SisControl.BLL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace SisControl.View
{
    public partial class FrmCadCidade : FrmModeloForm
    {

        private string QueryCidade = "SELECT MAX(CidadeID)  FROM Cidade";
        private string StatusOperacao;
        private int CidadeID;
        //public string formChamador { get; set; }

        public FrmCadCidade( string statusOperação)
        {
            InitializeComponent();

            this.StatusOperacao = statusOperação;
            // Utiliza a classe Utilitario para adicionar os efeitos de foco a todos os TextBoxes no formulário
            Utilitario.AdicionarEfeitoFocoEmTodos(this);
        }
        public void AlterarRegistro()
        {
            try
            {
                CidadeMODEL objetoCIDADE = new CidadeMODEL();

                objetoCIDADE.CidadeID = Convert.ToInt32(txtCidadeID.Text);
                objetoCIDADE.NomeCidade = txtNomeCidade.Text;                                
                objetoCIDADE.EstadoID = int.Parse(txtEstadoID.Text);                

                CidadeBLL cidadeBll = new CidadeBLL();
                cidadeBll.Atualizar(objetoCIDADE);

                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutCidade)Application.OpenForms["FrmManutCidade"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampoKrypton(this);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Alterar o registro!!! " + erro);
            }
        }
        public void SalvarRegistro()
        {
            try
            {
                CidadeMODEL objetoCIDADE = new CidadeMODEL();

                objetoCIDADE.CidadeID = Convert.ToInt32(txtCidadeID.Text);
                objetoCIDADE.NomeCidade = txtNomeCidade.Text;
                objetoCIDADE.EstadoID = int.Parse(txtEstadoID.Text);

                CidadeBLL cidadeBll = new CidadeBLL();
                cidadeBll.Salvar(objetoCIDADE);

                MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutCidade)Application.OpenForms["FrmManutCidade"]).HabilitarTimer(true);

                Utilitario.LimpaCampoKrypton(this);
                txtNomeCidade.Focus();

                txtCidadeID.Text = Utilitario.GerarProximoCodigo(QueryCidade).ToString();
                //Utilitario.AcrescentarZerosEsquerda(txtClienteID.Text, 6);//();                                                                    

                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryCidade);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                CidadeID = NovoCodigo;
                txtCidadeID.Text = numeroComZeros;

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
        public void ExcluirRegistro()
        {
            try
            {
                CidadeMODEL objetoCIDADE = new CidadeMODEL();

                objetoCIDADE.CidadeID = Convert.ToInt32(txtCidadeID.Text);               

                CidadeBLL cidadeBll = new CidadeBLL();
                cidadeBll.Excluir(objetoCIDADE);


                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutCidade)Application.OpenForms["FrmManutCidade"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampoKrypton(this);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Excluir o registro!!! " + erro);
            }
        }
    

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Utilitario.LimpaCampo(this);

            int NovoCodigo = Utilitario.GerarProximoCodigo(QueryCidade);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
            CidadeID = NovoCodigo;
            txtCidadeID.Text = numeroComZeros;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (StatusOperacao == "NOVO")
            {
                SalvarRegistro();
            }
            else if (StatusOperacao == "ALTERAR")
            {
                AlterarRegistro();
            }
            else if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Cliente: " + txtNomeCidade.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            FrmLocalizarEstado frm = new FrmLocalizarEstado(this);
            frm.Text = "Localizar Estado...";

            frm.ShowDialog();            
            btnSalvar.Focus();           
        }       
        private void FrmCadCidade_Load(object sender, EventArgs e)
        {

            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryCidade);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                CidadeID = NovoCodigo;
                txtCidadeID.Text = numeroComZeros;

                txtNomeCidade.Focus();
            }
        }
    }
}
