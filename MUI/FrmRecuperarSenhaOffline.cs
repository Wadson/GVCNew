using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GVC.MUI
{
    public partial class FrmRecuperarSenhaOffline : GVC.FrmModeloForm
    {

        public FrmRecuperarSenhaOffline()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Busca o usuário no banco de dados com base no CPF e na data de nascimento.
        /// Pressupõe que a tabela Usuario possui as colunas CPF e DataNascimento.
        /// </summary>
        private Usuario ObterUsuarioPorCPFDataNascimento(string cpf, DateTime dataNascimento)
        {
            Usuario usuario = null;
            using (var con = Conexao.Conex())
            {
                string query = "SELECT UsuarioID, Email FROM Usuario WHERE CPF = @CPF AND DataNascimento = @DataNascimento";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CPF", cpf);
                    cmd.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                            Email = reader["Email"].ToString()
                        };
                    }
                    con.Close();
                }
            }
            return usuario;
        }

        /// <summary>
        /// Gera uma senha temporária de 8 caracteres.
        /// </summary>
        private string GerarNovaSenha()
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder senha = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                senha.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return senha.ToString();
        }

        /// <summary>
        /// Atualiza a senha do usuário no banco de dados, salvando o hash da nova senha.
        /// </summary>
        private bool AtualizarSenhaUsuario(int usuarioID, string novaSenha)
        {
            bool sucesso = false;
            string hashSenha = GerarHashSHA256(novaSenha);

            using (var con = Conexao.Conex())
            {
                string query = "UPDATE Usuario SET Senha = @Senha WHERE UsuarioID = @UsuarioID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Senha", hashSenha);
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    sucesso = rows > 0;
                    con.Close();
                }
            }
            return sucesso;
        }

        /// <summary>
        /// Gera o hash SHA256 para a senha informada.
        /// </summary>
        private string GerarHashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecuperarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                string cpf = txtCpf.Text.Trim();
                DateTime dataNascimento;
                if (!DateTime.TryParse(txtDataNascimento.Text, out dataNascimento))
                {
                    MessageBox.Show("Data de Nascimento inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Busca o usuário baseado no CPF e na data de nascimento
                Usuario usuario = ObterUsuarioPorCPFDataNascimento(cpf, dataNascimento);
                if (usuario != null)
                {
                    // Gerar nova senha temporária
                    string novaSenha = GerarNovaSenha();

                    // Atualizar senha no banco (armazenando o hash da nova senha)
                    if (AtualizarSenhaUsuario(usuario.UsuarioID, novaSenha))
                    {
                        lblNovaSenha.Visible = true;
                        lblNovaSenhaRotulo.Visible = true;
                        lblNovaSenha.Text = novaSenha;
                        lblCopiarNovaSenha.Visible = true;
                        // Exibir a nova senha diretamente no formulário
                        MessageBox.Show("Sua nova senha é: " + novaSenha + "\nRecomendamos que a altere após o primeiro acesso.",
                                        "Recuperação de Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar a senha no sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("CPF ou Data de Nascimento não encontrados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Erro no formato da data de nascimento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       


        private void PersonalizaCampos(MaskedTextBox activeTextBox, PictureBox activePictureBox, Panel activePanel)
        {
            // Configurar os demais campos de texto, painéis e imagens como inativos antes de personalizar o ativo
            ResetarCampos();

            // Configurar o campo de texto ativo, painel ativo e imagem ativa
            activeTextBox.Clear();
            activePanel.BackColor = Color.FromArgb(8, 142, 254);
            activeTextBox.ForeColor = Color.FromArgb(78, 184, 206);

            // Definir a imagem correta com base no TextBox ativo
            if (activeTextBox == txtCpf)
            {
                activePictureBox.Image = Properties.Resources.cpfAzul24;
            }
            else if (activeTextBox == txtDataNascimento)
            {
                activePictureBox.Image = Properties.Resources.calendarioAzul24;
            }           
        }

        private void ResetarCampos()
        {
            // Resetar todos os campos de texto, painéis e imagens para inativos
            pictureBoxCpf.Image = Properties.Resources.cpfBranco24;
            panel1.BackColor = Color.White;
            txtCpf.ForeColor = Color.White;

            pictureBoxDataNasc.Image = Properties.Resources.calendarioBranco24;
            panel2.BackColor = Color.White;
            txtDataNascimento.ForeColor = Color.White;
        }

        private void txtCpf_Enter(object sender, EventArgs e)
        {
            PersonalizaCampos(txtCpf, pictureBoxCpf, panel1);
        }

        private void txtDataNascimento_Enter(object sender, EventArgs e)
        {
            PersonalizaCampos(txtDataNascimento, pictureBoxDataNasc, panel2);
        }

        private void txtCpf_Click(object sender, EventArgs e)
        {
            PersonalizaCampos(txtCpf, pictureBoxCpf, panel1);
        }

        private void txtDataNascimento_Click(object sender, EventArgs e)
        {
            PersonalizaCampos(txtDataNascimento, pictureBoxDataNasc, panel2);
        }

        private void txtDataNascimento_Leave(object sender, EventArgs e)
        {
            ResetarCampos();
        }
        private void CopiarTextoDoLabel()
        {
            if(string.IsNullOrEmpty(lblNovaSenha.Text))
            {
                MessageBox.Show("Não há texto para copiar!", "Copiar Texto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string textoDoLabel = lblNovaSenha.Text;
            Clipboard.SetText(textoDoLabel);
            MessageBox.Show("Texto copiado para a área de transferência!", "Copiar Texto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void lblCopiarNovaSenha_Click(object sender, EventArgs e)
        {
            CopiarTextoDoLabel();
        }
    }






    /// <summary>
    /// Classe para representar os dados mínimos de um usuário para esse processo.
    /// </summary>
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Email { get; set; }
    }

}

   
    

