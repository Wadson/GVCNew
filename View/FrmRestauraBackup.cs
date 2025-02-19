using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace SisControl.View
{
    public partial class FrmRestauraBackup : SisControl.FrmModeloForm
    {
        public FrmRestauraBackup()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLocalBackup_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Arquivos de backup (*.bak)|*.bak|Todos os arquivos (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtCaminhoBackup.Text = dialog.FileName;
                }
            }
        }

        private void btnGerarBackup_Click(object sender, EventArgs e)
        {
            var servidor = txtServidor.Text;
            var bancoDeDados = txtBancoDeDados.Text;
            var caminhoBackup = txtCaminhoBackup.Text.Trim();

            bool sucesso = RestaurarBackup(servidor, bancoDeDados, caminhoBackup);

            if (sucesso)
            {
                lblMensagem.Text = "Backup restaurado com sucesso!";
            }
            else
            {
                lblMensagem.Text = "Falha ao restaurar o backup.";
            }
        }
        private bool RestaurarBackup(string servidor, string bancoDeDados, string caminhoBackup)
        {
            string connectionString = $"Server={servidor};Database=master;Integrated Security=True;";

            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                string restoreQuery = $@"
                ALTER DATABASE {bancoDeDados} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE {bancoDeDados} FROM DISK = '{caminhoBackup}' WITH REPLACE;
                ALTER DATABASE {bancoDeDados} SET MULTI_USER;";

                SqlCeCommand command = new SqlCeCommand(restoreQuery, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao restaurar o backup: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
