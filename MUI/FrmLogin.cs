using GVC.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Security.Cryptography;

namespace GVC.MUI
{
    public partial class FrmLogin : GVC.FrmModeloForm
    {
        public FrmLogin()
        {
            InitializeComponent();            
        }
        // Propriedades estáticas para armazenar os dados do usuário
        public static string UsuarioConectado { get; set; }
        public static string NivelAcesso { get; set; }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PersonalizaCampos(TextBox activeTextBox, PictureBox activePictureBox, Panel activePanel)
        {
            // Configurar os demais campos de texto, painéis e imagens como inativos antes de personalizar o ativo
            ResetarCampos();

            // Configurar o campo de texto ativo, painel ativo e imagem ativa
            activeTextBox.Clear();
            activePanel.BackColor = Color.FromArgb(8, 142, 254);
            activeTextBox.ForeColor = Color.FromArgb(78, 184, 206);

            // Definir a imagem correta com base no TextBox ativo
            if (activeTextBox == txtUserName)
            {
                activePictureBox.Image = Properties.Resources.UsuarioBlue24;
            }
            else if (activeTextBox == txtEmail)
            {
                activePictureBox.Image = Properties.Resources.EmailAzul24;
            }
            else if (activeTextBox == txtPassword)
            {
                activePictureBox.Image = Properties.Resources.SenhasBlue24;
            }
        }

        private void ResetarCampos()
        {
            // Resetar todos os campos de texto, painéis e imagens para inativos
            pictureBoxUser.Image = Properties.Resources.Usuario24;
            panel1.BackColor = Color.White;
            txtUserName.ForeColor = Color.White;

            pictureBoxEmail.Image = Properties.Resources.EmailBranco24;
            panel2.BackColor = Color.White;
            txtEmail.ForeColor = Color.White;

            pictureBoxRepetePassWord.Image = Properties.Resources.Senhas24;
            panel3.BackColor = Color.White;
            txtPassword.ForeColor = Color.White;
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            PersonalizaCampos(txtUserName, pictureBoxUser, panel1);
        }

        private void txtPasssword_Click(object sender, EventArgs e)
        {
            PersonalizaCampos(txtEmail, pictureBoxEmail, panel2);
        }

        private void txtRepetPass_Click(object sender, EventArgs e)
        {
            PersonalizaCampos(txtPassword, pictureBoxRepetePassWord, panel3);
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            PersonalizaCampos(txtUserName, pictureBoxUser, panel1);
        }

        private void txtPasssword_Enter(object sender, EventArgs e)
        {
            PersonalizaCampos(txtEmail, pictureBoxEmail, panel2);
        }

        private void txtRepetPass_Enter(object sender, EventArgs e)
        {
            PersonalizaCampos(txtPassword, pictureBoxRepetePassWord, panel3);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            ResetarCampos();
        }

        private void txtPasssword_Leave(object sender, EventArgs e)
        {
            ResetarCampos();
        }

        private void txtRepetPass_Leave(object sender, EventArgs e)
        {
            ResetarCampos();
        }

        private void ObterDadosUsuario(string email, string senhaHash)
        {
            // Consulta SQL para obter os dados do usuário
            string query = "SELECT NomeUsuario, TipoUsuario FROM Usuario WHERE Email = @Email AND Senha = @Senha";

            using (var con = Conexao.Conex())  // A conexão com o banco de dados
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    // Adicionando parâmetros para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senhaHash);

                    con.Open();
                    SqlCeDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())  // Se o usuário for encontrado
                    {
                        // Atribuindo os dados do usuário às propriedades estáticas
                        UsuarioConectado = reader["NomeUsuario"].ToString();
                        NivelAcesso = reader["TipoUsuario"].ToString();
                    }

                    con.Close();
                }
            }
        }



        private bool ValidarLogin(string username, string email, string password)
        {
            bool loginValido = false;

            // Aqui você faz a consulta no banco de dados para validar o usuário
            string senhaHash = GerarHashSHA256(password);  // Gera o hash da senha

            string query = "SELECT NomeUsuario, TipoUsuario FROM Usuario WHERE Email = @Email AND Senha = @Senha";

            using (var con = Conexao.Conex())  // A conexão com o banco de dados
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    // Adicionando parâmetros para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senhaHash);

                    con.Open();
                    SqlCeDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())  // Se o usuário for encontrado
                    {
                        // Atribuindo os dados do usuário às propriedades estáticas
                        UsuarioConectado = reader["NomeUsuario"].ToString();
                        NivelAcesso = reader["TipoUsuario"].ToString();

                        loginValido = true;  // Login bem-sucedido
                    }
                    else
                    {
                        loginValido = false;  // Login falhou
                    }

                    con.Close();
                }
            }

            return loginValido;
        }


        private bool VerificarSenhaHash(string senhaDigitada, string hashBanco)
        {
            // Gera o hash da senha digitada para comparar com o hash armazenado
            string hashSenhaDigitada = GerarHashSHA256(senhaDigitada);
            return hashSenhaDigitada == hashBanco;
        }

        private string GerarHashSHA256(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }





        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (ValidarLogin(username, email, password))  // Chama a validação
            {
                MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // O nome do usuário e nível de acesso já foram atribuídos nas propriedades estáticas do FrmLogin
                this.Hide();
                FrmPrincipal frm = new FrmPrincipal();
                frm.Show();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRepetPass_Validating(object sender, CancelEventArgs e)
        {
            ResetarCampos();
        }

        private void lblEsqueciSenha_Click(object sender, EventArgs e)
        {
            FrmRecuperarSenhaOffline frmRecuperarSenhaOffline = new FrmRecuperarSenhaOffline();
            frmRecuperarSenhaOffline.ShowDialog();
        }
    }
}
