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
    internal class EstadoDALL
    {
        public DataTable Listar()
        {
            //DataTable ListaUsuario = Conexao.SQL_data_adapter("SELECT idusuario,nome, usuario, dtnascimento, nivelacesso, senha FROM usuario");

            var conn = Conexao.Conex();
            try
            {
                SqlCeCommand comando = new SqlCeCommand("SELECT EstadoID, NomeEstado, Uf FROM Estado", conn);
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

        public void Salvar(EstadoMODEL estado)
        {
            var conn = Conexao.Conex();

            try
            {
                SqlCeCommand sqlcomm = new SqlCeCommand("INSERT INTO Estado (EstadoID, NomeEstado, Uf ) VALUES (@EstadoID, @NomeEstado, @Uf )", conn);

                sqlcomm.Parameters.AddWithValue("@EstadoID", estado.EstadoID);
                sqlcomm.Parameters.AddWithValue("@NomeEstado", estado.NomeEstado);
                sqlcomm.Parameters.AddWithValue("@Uf", estado.UF);

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
        public void Excluir(EstadoMODEL estado)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCeCommand sqlcomando = new SqlCeCommand("DELETE FROM Estado WHERE EstadoID = @EstadoID", conn);
                sqlcomando.Parameters.AddWithValue("@EstadoID", estado.EstadoID);
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
        public void Atualizar(EstadoMODEL estado)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCeCommand sqlcomm = new SqlCeCommand("UPDATE Estado SET NomeEstado = @NomeEstado, Uf = @Uf WHERE EstadoID = @EstadoID", conn);
                                
                sqlcomm.Parameters.AddWithValue("@NomeEstado", estado.NomeEstado);
                sqlcomm.Parameters.AddWithValue("@Uf", estado.UF);
                sqlcomm.Parameters.AddWithValue("@EstadoID", estado.EstadoID);

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
       
        public DataTable PesquisarPorCodigo(string codigo)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT EstadoID, NomeEstado, Uf FROM Estado WHERE EstadoID  LIKE @EstadoID";
                SqlCeCommand cmd = new SqlCeCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@EstadoID", codigo);
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
        public DataTable PesquisarPorNome(string codigo)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT EstadoID, NomeEstado, Uf FROM Estado WHERE NomeEstado  LIKE @NomeEstado";
                SqlCeCommand cmd = new SqlCeCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeEstado", codigo);
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
        public DataTable ListarEstado()
        {
            var conn = Conexao.Conex();
            DataTable dt = new DataTable();

            try
            {
                string sqlconn = "SELECT EstadoID, NomeEstado, Uf FROM Estado";
                using (SqlCeCommand cmd = new SqlCeCommand(sqlconn, conn))
                {
                    using (SqlCeDataAdapter da = new SqlCeDataAdapter(cmd))
                    {
                        conn.Open();
                        da.Fill(dt);
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a pesquisa: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
            }

            return dt;
        }

    }
}
