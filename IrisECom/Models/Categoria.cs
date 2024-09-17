using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrisECom.Models
{
    [Table("tb_categorias")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string? Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(5000)]
        public string? Imagem { get; set; } = string.Empty;

        [InverseProperty("Categoria")]
        public ICollection<Produto>? Produtos { get; set; }
    }
}
