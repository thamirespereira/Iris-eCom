
using IrisECom.Data;
using IrisECom.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IrisECom.Repositories
{
    public class ProdutoRepository
    {
        private readonly DataContext context;

        // IConfiguration é uma interface que fornece acesso a configurações do aplicativo
        public ProdutoRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<DataContext>() // Configurando options para o DataContext
                .UseSqlServer(connectionString)
                .Options;
            context = new DataContext(options);
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            return context.Produtos
               .Include(p => p.Categoria)
               .AsNoTracking();
        }

        public Produto? BuscarPorId(int id)
        {
            return context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.Nome.Contains(nome)).ToList();
        }

        public IEnumerable<Produto> BuscarPorCategoria(int codigo)
        {
            return context.Produtos
                .Include(p => p.Categoria)
                .Where(p => p.Categoria.Id == codigo)
                .AsNoTracking()
                .ToList();
        }

        public int Inserir(Produto produto)
        {

            try
            {
                context.Produtos.Add(produto);
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir produto: " + ex.Message);

            }
        }

        public int Atualizar(Produto produto)
        {
            try
            {
                context.Entry(produto).State = EntityState.Modified;
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar produto: " + ex.Message);
            }
        }

        public int Excluir(int id)
        {
            Produto? produto = BuscarPorId(id);

            if (produto != null)
            {
                context.Remove(produto);
                return context.SaveChanges();
            }
            return 0;
        }
    }
}