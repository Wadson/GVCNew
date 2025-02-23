using Microsoft.Identity.Client;
using GVC.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using static GVC.FrmModeloForm;

namespace GVC.View
{
    public partial class FrmLocalizarEstado : GVC.FrmBasePesquisa
    {       
        private Form _formChamador;
        protected int LinhaAtual = -1;        
        public FrmLocalizarEstado(Form formChamador)
        {
            InitializeComponent();
            _formChamador = formChamador;
            // Configurar o DataGridView (apenas exemplo, configure conforme necessário)
            dataGridPesquisar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
       
        public void Listar()
        {
            EstadoDALL dao = new EstadoDALL();
            dataGridPesquisar.DataSource = dao.ListarEstado();
            
            InicializaDataGridView();
        }       
        private void InicializaDataGridView()
        {
            //Redimensiona o tamanho das colunas do DataGridView 
            dataGridPesquisar.Columns[0].Width = 100;
            dataGridPesquisar.Columns[1].Width = 170;
            dataGridPesquisar.Columns[2].Width = 110;           

            //Renomeia as colunas do DataGridView 
            dataGridPesquisar.Columns[0].HeaderText = "Estado ID";
            dataGridPesquisar.Columns[1].HeaderText = "Nome Estado";
            dataGridPesquisar.Columns[2].HeaderText = "UF";            
        }
     
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
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

        private void dataGridPesquisar_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridPesquisar.CurrentRow != null)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
            }
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dataGridPesquisar.Focus();
            }
        }

        private void dataGridPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && dataGridPesquisar.CurrentCell.RowIndex == 0)
            {
                txtPesquisa.Focus();
            }
            // Adicione a navegação com as setas para cima e para baixo, se ainda não tiver

            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void FrmLocalizarEstado_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void FrmLocalizarEstado_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (dataGridPesquisar.Rows.Count == 0 || dataGridPesquisar.CurrentRow == null)
            {
                // O DataGridView está vazio, então saia do método
                return;
            }

            if (_formChamador is FrmCadCidade)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
               
                ((FrmCadCidade)Application.OpenForms["FrmCadCidade"]).txtEstadoID.Text = dataGridPesquisar[0, LinhaAtual].Value?.ToString();
                ((FrmCadCidade)Application.OpenForms["FrmCadCidade"]).txtNomeEstado.Text = dataGridPesquisar[1, LinhaAtual].Value?.ToString();                
            }           
        }

        private void FrmLocalizarEstado_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
