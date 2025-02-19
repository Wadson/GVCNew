using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using SisControl.MUI;

namespace SisControl.DALL
{
    internal class UsuarioDALL
    {
        public DataTable listaUsuario()
        {
            //DataTable ListaUsuario = Conexao.SQL_data_adapter("SELECT idusuario,nome, usuario, dtnascimento, nivelacesso, senha FROM usuario");

            var conn = Conexao.Conex();
            try
            {
                SqlCeCommand comando = new SqlCeCommand("SELECT UsuarioID, NomeUsuario, Email, Senha, TipoUsuario, Cpf, DataNascimento FROM Usuario", conn);
                //id_usuario, nome_usuario, user_usuario, dt_nascimento, nivelacesso_usuario, senha_usuario, email_usuario, dt_nascimento

                SqlCeDataAdapter daUsuario = new SqlCeDataAdapter();
                daUsuario.SelectCommand = comando;

                DataTable dtUsuario = new DataTable();
                daUsuario.Fill(dtUsuario);
                return dtUsuario;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }

        public void gravaUsuario(UsuarioMODEL usuarios)
        {
            var conn = Conexao.Conex();

            try
            {
                SqlCeCommand sqlcomm = new SqlCeCommand("INSERT INTO Usuario (UsuarioID, NomeUsuario, Email, Senha, TipoUsuario, Cpf, DataNascimento) VALUES (@UsuarioID, @NomeUsuario, @Email, @Senha, @TipoUsuario, @Cpf, @DataNascimento)", conn);

                sqlcomm.Parameters.AddWithValue("@UsuarioID", usuarios.UsuarioID);
                sqlcomm.Parameters.AddWithValue("@NomeUsuario", usuarios.NomeUsuario);
                sqlcomm.Parameters.AddWithValue("@Email", usuarios.Email);
                sqlcomm.Parameters.AddWithValue("@Senha", usuarios.Senha);
                sqlcomm.Parameters.AddWithValue("@TipoUsuario", usuarios.TipoUsuario);
                sqlcomm.Parameters.AddWithValue("@Cpf", usuarios.Cpf);
                sqlcomm.Parameters.AddWithValue("@DataNascimento", usuarios.DataNascimento);

                conn.Open();
                sqlcomm.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        // ***********E  X  C  L  U  I         U  S  U  A  R  I  O***********************************
        public void excluiUsuario(UsuarioMODEL usuarios)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCeCommand sqlcomando = new SqlCeCommand("DELETE FROM Usuario WHERE UsuarioID = @UsuarioID", conn);
                sqlcomando.Parameters.AddWithValue("@UsuarioID", usuarios.UsuarioID);
                conn.Open();
                sqlcomando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }
        //********A  T  U  A  L  I  Z  A     U  S  U  A  R  I  O  *****************************************************
        public void atualizaUsuario(UsuarioMODEL usuarios)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCeCommand sqlcomm = new SqlCeCommand("UPDATE Usuario SET NomeUsuario = @NomeUsuario, Email = @Email, Senha = @Senha, TipoUsuario = @TipoUsuario , Cpf = @Cpf, DataNascimento = @DataNascimento WHERE UsuarioID = @UsuarioID", conn);

                sqlcomm.Parameters.AddWithValue("@UsuarioID", usuarios.UsuarioID);
                sqlcomm.Parameters.AddWithValue("@NomeUsuario", usuarios.NomeUsuario);
                sqlcomm.Parameters.AddWithValue("@Email", usuarios.Email);
                sqlcomm.Parameters.AddWithValue("@Senha", usuarios.Senha);
                sqlcomm.Parameters.AddWithValue("@TipoUsuario", usuarios.TipoUsuario);                
                sqlcomm.Parameters.AddWithValue("@Cpf", usuarios.Cpf);
                sqlcomm.Parameters.AddWithValue("@DataNascimento", usuarios.DataNascimento);
                
                conn.Open();
                sqlcomm.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }

        }

        public void atualizaUsuarioSenha(UsuarioMODEL usuarios)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCeCommand sqlcomm = new SqlCeCommand("UPDATE Usuario SET Senha = @Senha WHERE UsuarioID = @UsuarioID", conn);

                sqlcomm.Parameters.AddWithValue("@Senha", usuarios.Senha);
                sqlcomm.Parameters.AddWithValue("@UsuarioID", usuarios.UsuarioID);

                conn.Open();
                sqlcomm.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable PesquisarPorNome(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT UsuarioID, NomeUsuario, Email, Senha, TipoUsuario FROM Usuario WHERE NomeUsuario  LIKE @NomeUsuario";
                SqlCeCommand cmd = new SqlCeCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", nome);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a pesquisa: " + ex);
                return null;
            }
        }
        public DataTable PesquisarPorCodigo(string codigo)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT UsuarioID, NomeUsuario, Email, Senha, TipoUsuario, Cpf, DataNascimento FROM Usuario WHERE UsuarioID  LIKE @UsuarioID";
                SqlCeCommand cmd = new SqlCeCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@UsuarioID", codigo);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a pesquisa: " + ex);
                return null;
            }
        }
    }
}
