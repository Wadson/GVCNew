using GVC.MUI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using static GVC.View.FrmContaReceberr;
using ComponentFactory.Krypton.Toolkit;
using System;
using GVC.Relatorios;

namespace GVC.View
{
    public partial class FrmTelaPrincipal : KryptonForm
    {
        private System.Timers.Timer timer;
        public FrmTelaPrincipal()
        {
            InitializeComponent();
            StatusOperacao = "";
        }
        private string StatusOperacao = "";
        private FrmContaReceberr _frmContaReceberr;
        private Parcela _parcela;
        private void AbrirFormEnPanel(object Form)
        {
            if (this.panelConteiner.Controls.Count > 0)
                this.panelConteiner.Controls.RemoveAt(0);
            Form fh = Form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelConteiner.Controls.Add(fh);
            this.panelConteiner.Tag = fh;
            fh.Show();
        }


        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FrmManutUsuario frm = new FrmManutUsuario(StatusOperacao);
            AbrirFormEnPanel(frm);
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmManutCliente frm = new FrmManutCliente(StatusOperacao);
            StatusOperacao = "NOVO";
            AbrirFormEnPanel(frm);
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            FrmManutFornecedor frm = new FrmManutFornecedor(StatusOperacao);
            StatusOperacao = "NOVO";
            AbrirFormEnPanel(frm);
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            FrmManutProduto frm = new FrmManutProduto(StatusOperacao);
            StatusOperacao = "NOVO";
            AbrirFormEnPanel(frm);
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            FrmPedidoVendaNovo frm = new FrmPedidoVendaNovo();
            AbrirFormEnPanel(frm);
        }

        private void btnFerramentas_Click(object sender, EventArgs e)
        {
            FrmFerramentas frm = new FrmFerramentas();
            AbrirFormEnPanel(frm);
        }

        private void btnContaReceber_Click(object sender, EventArgs e)
        {
            // Suponha que você tenha uma instância de Parcela
            Parcela parcela = new Parcela();
            // Chama o construtor de FrmContaReceberr com os parâmetros necessários
            FrmContaReceberr frm = new FrmContaReceberr(parcela);
            AbrirFormEnPanel(frm);
        }
        

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            FrmMenuRelatorio frm = new FrmMenuRelatorio();
            AbrirFormEnPanel(frm);
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // Atualiza a data e hora
            this.Invoke(new Action(() =>
            {
                lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblHoraAtual.Text = DateTime.Now.ToString("HH:mm:ss");
            }));
        }
        private void AtualizaBarraStatus()
        {
            // Obtém o caminho do diretório de execução
            string currentPath = Path.GetDirectoryName(Application.ExecutablePath);

            // Atualiza a label de usuário na barra de status
            string usuarioLogado = FrmLogin.UsuarioConectado;
            string nivelAcesso = FrmLogin.NivelAcesso;
            lblUsuarioLogadoo.Text = $"{usuarioLogado}";
            lblTipoUsuarioo.Text = $"{nivelAcesso}";

            // Atualiza a data
            string data = DateTime.Now.ToLongDateString();
            data = data.Substring(0, 1).ToUpper() + data.Substring(1);
            lblDataa.Text = data;

            // Exibe informações do computador
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            var informacao = Environment.UserName;
            var nomeComputador = Environment.MachineName;

            lblEstacao.Text = nomeComputador;
            lblDataa.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblHoraAtuall.Text = DateTime.Now.ToString("HH:mm:ss");

            // Configuração do timer para atualizar a hora e a data
            timer = new System.Timers.Timer(1000); // Atualiza a cada segundo
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AtualizaBarraStatus();
        }


        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }

        private void loginToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadCidade frmCadCidade = new FrmCadCidade(StatusOperacao);
            StatusOperacao = "NOVO";
            frmCadCidade.ShowDialog();
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            FrmManutEstado frmManutEstado = new FrmManutEstado(StatusOperacao);
            StatusOperacao = "NOVO";
            AbrirFormEnPanel(frmManutEstado);
        }

        private void btnCidade_Click(object sender, EventArgs e)
        {
            FrmManutCidade frmManutCidade = new FrmManutCidade(StatusOperacao);
            StatusOperacao = "NOVO";
            AbrirFormEnPanel(frmManutCidade);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHoraAtuall.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
