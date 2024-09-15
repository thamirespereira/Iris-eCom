using IrisECom.Models;

namespace IrisECom.Services
{
    public interface IProdutoService
    {
        IEnumerable<Produto> BuscarTodos();
        Produto? BuscarPorId(int id);
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> BuscarPorCategoria(int codigo);
        int Inserir(Produto produto);
        int Atualizar(Produto produto);
        int Excluir(int id);
    }
}
