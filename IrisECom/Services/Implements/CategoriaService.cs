using IrisECom.Models;
using IrisECom.Repositories;

namespace IrisECom.Services.Implements
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository ?? throw new ArgumentNullException(nameof(categoriaRepository));
        }
        public int Atualizar(Categoria categoria)
        {
            return _categoriaRepository.Atualizar(categoria);
        }

        public Categoria? BuscarPorId(int id)
        {
            return _categoriaRepository.BuscarPorId(id);
        }

        public IEnumerable<Categoria> BuscarPorNome(string nome)
        {
            return _categoriaRepository.BuscarPorNome(nome);
        }

        public IEnumerable<Categoria> BuscarTodos()
        {
            return _categoriaRepository.BuscarTodos();
        }

        public int Excluir(int id)
        {
            return _categoriaRepository.Excluir(id);
        }

        public int Inserir(Categoria categoria)
        {
            return _categoriaRepository.Inserir(categoria);
        }
    }
}
