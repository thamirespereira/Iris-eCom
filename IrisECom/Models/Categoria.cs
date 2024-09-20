using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrisECom.Models
{
    [Table("tb_categorias")]
    public class Categoria
    {
        public int Id { get; set; }

        public string? Nome { get; set; } = string.Empty;
        public string? Imagem { get; set; } = string.Empty;
        public ICollection<Produto>? Produtos { get; set; }
    }
}
