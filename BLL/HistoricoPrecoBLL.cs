using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GVC.BLL
{
    internal class HistoricoPrecoBLL
    {
        public int HistoricoID { get; set; }
        public int ProdutoID { get; set; }
        public DateTime DataRegistro { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal Lucro { get; set; }
        public decimal PrecoVenda { get; set; }

    }
}
