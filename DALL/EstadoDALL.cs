using GVC.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using GVC.MUI;

namespace GVC.DALL
{
    internal class EstadoDALL
    {
        public DataTable Listar()
        {
            //DataTable ListaUsuario = Conexao.SQL_data_adapter("SELECT idusuario,nome, usuario, dtnascimento, nivelacesso, senha FROM usuario");

            var conn = Conexao.Conex();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT EstadoID, NomeEstado, Uf FROM Estado", conn);
                //id_usuario, nome_usuario, user_usuario, dt_nascimento, nivelacesso_usuario, senha_usuario, email_usuario, dt_nascimento

                SqlDataAdapter daUsuario = new SqlDataAdapter();
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
                SqlCommand sqlcomm = new SqlCommand("INSERT INTO Estado (EstadoID, NomeEstado, Uf ) VALUES (@EstadoID, @NomeEstado, @Uf )", conn);

                sqlcomm.Parameters.AddWithValue("@EstadoID", estado.EstadoID);
                sqlcomm.Parameters.AddWithValue("@NomeEstado", estado.NomeEstado);
                sqlcomm.Parameters.AddWithValue("@Uf", estado.UF);

                conn.Open();
                sqlcomm.ExecuteNonQuery();
            }
            catch (SqlException ex)
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
                SqlCommand sqlcomando = new SqlCommand("DELETE FROM Estado WHERE EstadoID = @EstadoID", conn);
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
                SqlCommand sqlcomm = new SqlCommand("UPDATE Estado SET NomeEstado = @NomeEstado, Uf = @Uf WHERE EstadoID = @EstadoID", conn);
                                
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
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@EstadoID", codigo);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
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
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeEstado", codigo);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
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
                using (SqlCommand cmd = new SqlCommand(sqlconn, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
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
