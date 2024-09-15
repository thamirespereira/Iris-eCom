namespace IrisECom.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty;
        public decimal? Preco { get; set; } = 0;
        public string? InfoTecnica { get; set; } = string.Empty;
        public int? Quantidade { get; set; } = 0;
        public string? Imagem { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; } 

        public Produto(){}
    }
}
