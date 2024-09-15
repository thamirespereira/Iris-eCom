using IrisECom.Models;
using IrisECom.Repositories;

namespace IrisECom.Services.Implements
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoRepository _produtoRepository;

        private readonly CategoriaRepository _categoriaRepository;

        public ProdutoService(ProdutoRepository produtoRepository, CategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _categoriaRepository = categoriaRepository ?? throw new ArgumentNullException(nameof(categoriaRepository));
        }



        public int Atualizar(Produto produto)
        {
            return _produtoRepository.Atualizar(produto);
        }

        public IEnumerable<Produto> BuscarPorCategoria(int codigo)
        {
            return _produtoRepository.BuscarPorCategoria(codigo);
        }

        public Produto? BuscarPorId(int id)
        {
            return _produtoRepository.BuscarPorId(id);
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            return _produtoRepository.BuscarTodos();
        }

        public int Excluir(int id)
        {
            return _produtoRepository.Excluir(id);
        }

        public int Inserir(Produto produto)
        {
            return _produtoRepository.Inserir(produto);
        }
        }
    }

