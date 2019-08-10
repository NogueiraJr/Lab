using System;
using System.ComponentModel.DataAnnotations;

namespace _20180429.Models {
    public class Locacao {
        [Key]
        public int Locacoes_id { get; set; }
        public int Clientes_id { get; set; }
        public DateTime dtReserva { get; set; }
        public DateTime dtRetirada { get; set; }
        public DateTime dtDevolucao { get; set; }
    }
}