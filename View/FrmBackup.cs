using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using System.IO;

namespace GVC.View
{
    public partial class FrmBackup : GVC.FrmModeloForm
    {
        public FrmBackup()
        {
            InitializeComponent();
        }

        private void btnGerarBackup_Click(object sender, EventArgs e)
        {
            var servidor = txtServidor.Text;
            var bancoDeDados = txtBancoDeDados.Text;
            var caminhoBackup = txtCaminhoBackup.Text.Trim();

            if (!VerificarPermissoesGravacao(caminhoBackup))
            {
                MessageBox.Show("Não há permissão para gravar no caminho especificado.", "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool sucesso = RealizarBackup(servidor, bancoDeDados, caminhoBackup);

            if (sucesso)
            {
                lblMensagem.Text = "Backup realizado com sucesso!";
            }
            else
            {
                lblMensagem.Text = "Falha ao realizar o backup.";


            }
        }
        private bool VerificarPermissoesGravacao(string caminho)
        {
            try
            {
                // Tenta criar um arquivo temporário no diretório especificado
                string tempFile = Path.Combine(caminho, "tempfile.tmp");
                File.Create(tempFile).Dispose();
                File.Delete(tempFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool RealizarBackup(string servidor, string bancoDeDados, string caminhoBackup)
        {
            string connectionString = $"Server={servidor};Database={bancoDeDados};Integrated Security=True;";

            // Certifique-se de que o diretório de backup existe
            if (!Directory.Exists(caminhoBackup))
            {
                Directory.CreateDirectory(caminhoBackup);
            }

            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                string backupFileName = $"BancoBackup_{DateTime.Now:yyyyMMddHHmmss}.bak";
                string backupPath = Path.Combine(caminhoBackup, backupFileName);
                string backupQuery = $"BACKUP DATABASE {bancoDeDados} TO DISK = '{backupPath}'";

                SqlCeCommand command = new SqlCeCommand(backupQuery, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao realizar o backup: " + ex.Message);
                    return false;
                }
            }
        }
        //private bool VerificarPermissoesGravacao(string caminho)
        //{
        //    try
        //    {
        //        // Tenta criar um arquivo temporário no diretório especificado
        //        string tempFile = System.IO.Path.Combine(caminho, "tempfile.tmp");
        //        System.IO.File.Create(tempFile).Dispose();
        //        System.IO.File.Delete(tempFile);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //private bool RealizarBackup(string servidor, string bancoDeDados, string caminhoBackup)
        //{
        //    string connectionString = $"Server={servidor};Database={bancoDeDados};Integrated Security=True;";

        //    using (SqlCeConnection connection = new SqlCeConnection(connectionString))
        //    {
        //        string backupFileName = $"BancoBackup_{DateTime.Now:yyyyMMddHHmmss}.bak";
        //        string backupPath = System.IO.Path.Combine(caminhoBackup, backupFileName);
        //        string backupQuery = $"BACKUP DATABASE {bancoDeDados} TO DISK = '{backupPath}'";

        //        SqlCeCommand command = new SqlCeCommand(backupQuery, connection);

        //        try
        //        {
        //            connection.Open();
        //            command.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Erro ao realizar o backup: " + ex.Message);
        //            return false;
        //        }
        //    }
        //}


        private void btnLocalBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtCaminhoBackup.Text = dialog.SelectedPath;
                }

            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
