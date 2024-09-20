using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IrisECom.Models
{
    [Table("tb_usuarios")]
    public class Usuario
    {
        public int Id { get; set; }

        public string? Nome { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Senha { get; set; } = string.Empty;

        public string? CEP { get; set; } = string.Empty;

        public string? Endereco { get; set; } = string.Empty;

        public string? Bairro { get; set; } = string.Empty;

        public string? Cidade { get; set; } = string.Empty;

        public string? UF { get; set; } = string.Empty;

        public string? CPF { get; set; } = string.Empty;

        public DateOnly? DataNascimento { get; set; }

        public string? Imagem { get; set; } = string.Empty;

        public ICollection<Produto>? Produtos { get; set; }

        public Usuario() { }
    }

    
}
