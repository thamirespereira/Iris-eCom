using IrisECom.Models;

namespace IrisECom.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> BuscarTodos();
        Usuario? BuscarPorId(int id);
        Usuario? BuscarPorEmail(string email);
        int Inserir(Usuario usuario);
        int Atualizar(Usuario usuario);
        int Excluir(int id);
    }
}
