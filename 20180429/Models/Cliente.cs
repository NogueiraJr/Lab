using System.ComponentModel.DataAnnotations;

namespace _20180429.Models {
    public class Cliente {
        [Key]
        public int Clientes_id { get; set; }
        public string nomeCliente { get; set; }
    }
}