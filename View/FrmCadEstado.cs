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
    public partial class FrmCadEstado : FrmModeloForm
    {

        private string QueryEstado = "SELECT MAX(EstadoID)  FROM Estado";
        private string StatusOperacao;
        private int EstadoID;
        //public string formChamador { get; set; }

        public FrmCadEstado( string statusOperação)
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
                EstadoMODEL objetoEstdo = new EstadoMODEL();

                objetoEstdo.EstadoID = Convert.ToInt32(txtEstadoID.Text);
                objetoEstdo.NomeEstado = txtNomeEstado.Text;
                objetoEstdo.UF = txtUf.Text;

                EstadoBLL estadobll = new EstadoBLL();
                estadobll.Atualizar(objetoEstdo);

                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutEstado)Application.OpenForms["FrmManutEstado"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
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

                EstadoMODEL objetoestado = new EstadoMODEL();

                objetoestado.EstadoID = Convert.ToInt32(txtEstadoID.Text);
                objetoestado.NomeEstado = txtNomeEstado.Text;
                objetoestado.UF = txtUf.Text;

                EstadoBLL estadoBll = new EstadoBLL();
                estadoBll.Salvar(objetoestado);

                MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutEstado)Application.OpenForms["FrmManutEstado"]).HabilitarTimer(true);

                Utilitario.LimpaCampoKrypton(this);
                txtNomeEstado.Focus();

                txtEstadoID.Text = Utilitario.GerarProximoCodigo(QueryEstado).ToString();
                //Utilitario.AcrescentarZerosEsquerda(txtClienteID.Text, 6);//();                                                                    

                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryEstado);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                EstadoID = NovoCodigo;
                txtEstadoID.Text = numeroComZeros;

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
                EstadoMODEL objetoestado = new EstadoMODEL();

                objetoestado.EstadoID = Convert.ToInt32(txtEstadoID.Text);
                EstadoBLL estadoBll = new EstadoBLL();

                estadoBll.Excluir(objetoestado);
                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutEstado)Application.OpenForms["FrmManutEstado"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
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

            int NovoCodigo = Utilitario.GerarProximoCodigo(QueryEstado);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
            EstadoID = NovoCodigo;
            txtEstadoID.Text = numeroComZeros;
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
                if (MessageBox.Show("Deseja Excluir? \n\n O Cliente: " + txtNomeEstado.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            FrmLocalizarCidade frmLocalizarCidade = new FrmLocalizarCidade(this);
            frmLocalizarCidade.Text = "Localizar Cidade...";   
            
            frmLocalizarCidade.ShowDialog();            
            btnSalvar.Focus();           
        }

        private void FrmCadEstado_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryEstado);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
                EstadoID = NovoCodigo;
                txtEstadoID.Text = numeroComZeros;

                txtNomeEstado.Focus();
            }
        }
    }
}
