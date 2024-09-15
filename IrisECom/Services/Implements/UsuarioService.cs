using IrisECom.Models;
using IrisECom.Repositories;

namespace IrisECom.Services.Implements
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }
        public int Atualizar(Usuario usuario)
        {
            return _usuarioRepository.Atualizar(usuario);
        }

        public IEnumerable<Usuario> BuscarPorEmail(string email)
        {
            return _usuarioRepository.BuscarPorEmail(email);
        }

        public Usuario? BuscarPorId(int id)
        {
            return _usuarioRepository.BuscarPorId(id);
        }

        public IEnumerable<Usuario> BuscarTodos()
        {
            return _usuarioRepository.BuscarTodos();
        }

        public int Excluir(int id)
        {
            return _usuarioRepository.Excluir(id);
        }

        public int Inserir(Usuario usuario)
        {
           return _usuarioRepository.Inserir(usuario);
        }
    }
}
