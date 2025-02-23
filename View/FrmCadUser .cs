using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using GVC.BLL;
using GVC.MODEL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GVC
{
    public partial class FrmCadUser : KryptonForm
    {
        private string QueryUsuario = "SELECT MAX(UsuarioID) FROM Usuario";
        private string StatusOperacao;
        private int UsuarioID;

        public FrmCadUser(string statusOperacao)
        {
            InitializeComponent();
            this.StatusOperacao = statusOperacao;
            Utilitario.AdicionarEfeitoFocoEmTodos(this);
        }

        // Método para criar hash SHA-256
        public static string HashSHA256(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Converte para hexadecimal
                }
                return builder.ToString();
            }
        }

        public void SalvarRegistro()
        {
            try
            {
                if (UsuarioID != 0 && txtNomeUsuario.Text != string.Empty && cmbTipoUsuario.Text != string.Empty && txtSenha.Text == txtRepitaSenha.Text)
                {
                    UsuarioMODEL objusuario = new UsuarioMODEL
                    {
                        UsuarioID = Convert.ToInt32(txtUsarioID.Text),
                        NomeUsuario = txtNomeUsuario.Text,
                        Email = txtEmail.Text,
                        Senha = HashSHA256(txtSenha.Text), // Armazena a senha como hash
                        TipoUsuario = cmbTipoUsuario.Text,
                        Cpf = txtCPF.Text,
                        DataNascimento = dtpDataNascimento.Value
                    };

                    UsuarioBLL usuariobll = new UsuarioBLL();
                    usuariobll.Salvar(objusuario);

                    MessageBox.Show("Registro gravado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
                    Utilitario.LimpaCampoKrypton(this);
                }
                else
                {
                    MessageBox.Show("Verifique os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao salvar o registro: " + erro.Message);
            }
        }

        public void AlterarRegistro()
        {
            try
            {
                UsuarioMODEL objetoUsuario = new UsuarioMODEL
                {
                    UsuarioID = Convert.ToInt32(txtUsarioID.Text),
                    NomeUsuario = txtNomeUsuario.Text,
                    Email = txtEmail.Text,
                    Senha = HashSHA256(txtSenha.Text), // Armazena a senha alterada como hash
                    TipoUsuario = cmbTipoUsuario.Text,
                    Cpf = txtCPF.Text,
                    DataNascimento = dtpDataNascimento.Value
                };

                UsuarioBLL usuarioBll = new UsuarioBLL();
                usuarioBll.Alterar(objetoUsuario);

                MessageBox.Show("Registro alterado com sucesso!", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
                Utilitario.LimpaCampoKrypton(this);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao alterar o registro: " + erro.Message);
            }
        }
        public void ExcluirRegistro()
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsarioID.Text))
                {
                    MessageBox.Show("Selecione um usuário para excluir!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int usuarioId = Convert.ToInt32(txtUsarioID.Text);

                UsuarioMODEL objetoUsuario = new UsuarioMODEL
                {
                    UsuarioID = usuarioId
                };

                UsuarioBLL usuarioBll = new UsuarioBLL();
                usuarioBll.Excluir(objetoUsuario);

                MessageBox.Show("Registro excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Atualiza a tela de manutenção de usuários
                ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);

                // Limpa os campos e fecha o formulário
                Utilitario.LimpaCampoKrypton(this);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao excluir o registro: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                AlterarRegistro();
            }
            else if (StatusOperacao == "NOVO")
            {
                SalvarRegistro();
                Utilitario.LimpaCampo(this);
                txtNomeUsuario.Focus();

                UsuarioID = Utilitario.GerarProximoCodigo(QueryUsuario);
                txtUsarioID.Text = Utilitario.AcrescentarZerosEsquerda(UsuarioID, 6);
                ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
            }
            else if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show($"Deseja excluir o usuário {txtNomeUsuario.Text}?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadUser_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "NOVO")
            {
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryUsuario);
                UsuarioID = NovoCodigo;
                txtUsarioID.Text = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 4);
                txtNomeUsuario.Focus();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Utilitario.LimpaCampo(this);
            int NovoCodigo = Utilitario.GerarProximoCodigo(QueryUsuario);
            UsuarioID = NovoCodigo;
            txtUsarioID.Text = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 6);
        }

        private void FrmCadUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
