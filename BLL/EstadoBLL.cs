using GVC.DALL;
using GVC.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVC.BLL
{
    internal class EstadoBLL
    {
        EstadoDALL estadoDal = null;
        // ************************LISTA USUARIO*********************************************
        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            
            try
            {
                estadoDal = new EstadoDALL();
                dtable = estadoDal.Listar();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }

        public void Salvar(EstadoMODEL estado)
        {
            try
            {
                estadoDal = new EstadoDALL();
                estadoDal.Salvar(estado);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(EstadoMODEL estado)
        {
            try
            {
                estadoDal = new EstadoDALL();
                estadoDal.Excluir(estado);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Atualizar(EstadoMODEL estado)
        {
           
            try
            {
                estadoDal = new EstadoDALL();
                estadoDal.Atualizar(estado);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public EstadoMODEL Pesquisar(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT EstadoID, NomeEstado, Uf FROM Estado WHERE NomeEstado like '" + pesquisa + "%'", conn);
                conn.Open();
                SqlDataReader datareader;
                EstadoMODEL obj_estado = new EstadoMODEL();
                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);

                while (datareader.Read())
                {
                    obj_estado.EstadoID = Convert.ToInt32(datareader["EstadoID"]);
                    obj_estado.NomeEstado = datareader["NomeEstado"].ToString();
                    obj_estado.UF = datareader["Uf"].ToString();
                }
                return obj_estado;
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
    }
}
