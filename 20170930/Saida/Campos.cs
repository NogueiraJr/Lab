using System;

namespace Application
{
    public class Campos
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { set; get; }
        public string Conta { get; set; }
        public string Observacoes { get; set; }
    }

}
