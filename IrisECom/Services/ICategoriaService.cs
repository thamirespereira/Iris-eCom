using IrisECom.Models;

namespace IrisECom.Services
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> BuscarTodos();
        Categoria? BuscarPorId(int id);
        IEnumerable<Categoria> BuscarPorNome(string nome);
        int Inserir(Categoria categoria);
        int Atualizar(Categoria categoria);
        int Excluir(int id);
    }
}
