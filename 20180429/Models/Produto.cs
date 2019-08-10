using System.ComponentModel.DataAnnotations;

namespace _20180429.Models {
    public class Produto {
        [Key]
        public int Produtos_id { get; set; }
        public string nomeProduto { get; set; }
    }
}