using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IrisECom.Models
{
    [Table("tb_produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string? Nome { get; set; } = string.Empty;

        [Column(TypeName = "text")]
        public string? Descricao { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Preco { get; set; } = 0;

        [Column(TypeName = "text")]
        public string? InfoTecnica { get; set; } = string.Empty;

        [Column(TypeName = "int")]
        public int? Quantidade { get; set; } = 0;

        [Column(TypeName = "varchar")]
        [StringLength(5000)]
        public string? Imagem { get; set; } = string.Empty;

        [Column(TypeName = "int")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        [Column(TypeName = "int")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; } 

        public Produto(){}
    }
}
