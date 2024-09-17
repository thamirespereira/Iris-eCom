using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IrisECom.Models
{
    [Table("tb_usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string? Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string? Email { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string? Senha { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(8)]
        public string? CEP { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string? Endereco { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string? Bairro { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string? Cidade { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(2)]
        public string? UF { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(11)]
        public string? CPF { get; set; } = string.Empty;

        [Column(TypeName = "Date")]
        public DateOnly? DataNascimento { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(5000)]
        public string? Imagem { get; set; } = string.Empty;

        [InverseProperty("Usuario")]
        public ICollection<Produto>? Produtos { get; set; }

        public Usuario() { }
    }

    
}
